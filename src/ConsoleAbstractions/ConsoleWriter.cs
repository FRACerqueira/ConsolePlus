// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsolePlusLibrary.ConsoleAbstractions
{

    /// <summary>
    /// Represents a console writer (Ansi and non-Ansi), capable of outputting text to the console.
    /// </summary>
    internal sealed class ConsoleWriter(IConsolePlus outputconsole)
    {
        private readonly IConsolePlus _outputconsole = outputconsole ?? throw new ArgumentNullException(nameof(outputconsole));
        private readonly List<byte> _styleBuffer = [];
        private readonly ColorSystem _colorSystem = outputconsole.Profile.ColorDepth;
        private readonly AnsiCommands ansiCommands = new(outputconsole);

        public IAnsiCommands Ansi
        {
            get
            {
                return ansiCommands;
            }
        }

        /// <summary>
        /// Replaces emoji markup with corresponding unicode characters.
        /// </summary>
        /// <param name="value">A string with emojis codes, e.g. "Hello :smiley:!".</param>
        /// <returns>A string with emoji codes replaced with actual emoji.</returns>
        private string ReplaceEmoji(string value)
        {
            if (value.AsSpan().Count(':') < 2)
            {
                // An emoji code needs a pair of colons (e.g. ":smiley:").
                // Fewer than two colons means no emoji. Return what was passed in with no changes.
                return value;
            }

            StringBuilder? output = null;
            var index = 0;

            while (index < value.Length)
            {
                var start = value.IndexOf(':', index);
                if (start < 0 || start == value.Length - 1)
                {
                    break;
                }

                var end = value.IndexOf(':', start + 1);
                if (end < 0)
                {
                    break;
                }

                var emojiKey = value.Substring(start + 1, end - start - 1);
                if (Emoji.GetByName(emojiKey) is { Length: > 0 } emojiValue)
                {
                    output ??= new StringBuilder(value.Length);
                    output.Append(value, index, start - index);
                    output.Append(emojiValue);
                    index = end + 1;
                }
                else
                {
                    output?.Append(value, index, (start + 1) - index);

                    index = start + 1;
                }
            }

            if (output == null)
            {
                return value;
            }

            if (index < value.Length)
            {
                output.Append(value, index, value.Length - index);
            }
            if (_outputconsole.SupportsAnsi)
            {
                return output.ToString();
            }
            return string.Empty;
        }

        internal void WriteOutput(Fragment[] segments)
        {
            var lastStyle = _outputconsole.CurrentStyle;
            foreach (var item in segments)
            {
                if ((item.Style?.OverflowStrategy ?? Overflow.None) != Overflow.None && _outputconsole.Width - _outputconsole.CursorLeft <=0) 
                { 
                    continue;
                }
                var curStyle = _outputconsole.CurrentStyle;
                switch (item.Type)
                {
                    case FragmentKind.ContentText:
                        var textout = ReplaceEmoji(item.Text);
                        switch (item.Style?.OverflowStrategy ?? Overflow.None)
                        {
                            case Overflow.Crop:
                                {
                                    // Computed only when overflow handling is actually needed
                                    int len = textout.GetDisplayLength() is { Length: > 0 } d ? d[0] : 0;
                                    if (len + _outputconsole.CursorLeft > _outputconsole.Width)
                                    {
                                        // Budget is in display COLUMNS, not characters — a wide rune (CJK)
                                        // is 1 char but 2 columns, so a plain char-index Substring can throw
                                        // or overflow the line. TruncateToDisplayWidth trims by rune width.
                                        textout = textout.TruncateToDisplayWidth(_outputconsole.Width - _outputconsole.CursorLeft);
                                    }
                                    break;
                                }
                            case Overflow.Ellipsis:
                                {
                                    // Computed only when overflow handling is actually needed
                                    string ellipsisStr = _outputconsole.SupportsUnicode ? Constants.UnicodeEllipsis : Constants.AsciiEllipsis;
                                    int lentellipsis = ellipsisStr.GetDisplayLength()[0];
                                    int len = textout.GetDisplayLength() is { Length: > 0 } d ? d[0] : 0;
                                    int remainingSpace = _outputconsole.Width - _outputconsole.CursorLeft;
                                    if (len > remainingSpace)
                                    {
                                        int truncateLen = remainingSpace - lentellipsis;
                                        if (truncateLen > 0)
                                        {
                                            textout = textout.TruncateToDisplayWidth(truncateLen) + ellipsisStr;
                                        }
                                        else
                                        {
                                            textout = textout.TruncateToDisplayWidth(remainingSpace);
                                        }
                                    }
                                    break;
                                }
                        }
                        if (textout.Length > 0)
                        {
                            ApplyStyle(item.Style);
                            if (_outputconsole.WriteToErrorOutput)
                            {
                                _outputconsole.Error.Write(textout);
                            }
                            else
                            {
                                _outputconsole.Out.Write(textout);
                            }
                            ApplyStyle(curStyle);
                        }
                        break;
                    case FragmentKind.LineBreak:
                        if (_outputconsole.WriteToErrorOutput)
                        {
                            _outputconsole.Error.WriteLine();
                        }
                        else
                        {
                            _outputconsole.Out.WriteLine();
                        }
                        break;
                    case FragmentKind.ClearRestofline:
                        ApplyStyle(lastStyle);
                        ClearRestofline();
                        ApplyStyle(curStyle);
                        break;
                }
            }
            if (lastStyle != _outputconsole.CurrentStyle)
            {
                ApplyStyle(lastStyle);
            }
        }

        public void WriteOutput(string text, Style style, bool clearrestofline = false)
        {
            List<Fragment> result = [];
            ReadOnlySpan<char> remaining = text.AsSpan();

            while (true)
            {
                int idx = remaining.IndexOf('\n');
                if (idx < 0)
                {
                    // No more newlines — trim any trailing lone \r before emitting the final segment
                    ReadOnlySpan<char> last = remaining.Length > 0 && remaining[^1] == '\r'
                        ? remaining[..^1]
                        : remaining;
                    if (clearrestofline)
                        result.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                    if (!last.IsEmpty)
                        result.Add(new Fragment(last.ToString(), style));
                    break;
                }

                // Strip preceding \r so that \r\n counts as a single newline
                ReadOnlySpan<char> line = idx > 0 && remaining[idx - 1] == '\r'
                    ? remaining[..(idx - 1)]
                    : remaining[..idx];

                if (clearrestofline)
                {
                    result.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                }
                if (!line.IsEmpty)
                {
                    result.Add(new Fragment(line.ToString(), style));
                }
                result.Add(new Fragment("", null, FragmentKind.LineBreak));

                remaining = remaining[(idx + 1)..];
            }

            WriteOutput([.. result]);
        }

        internal void WriteMarkupOutput(string text, Style style, bool clearrestofline = false)
        {
            Fragment[] segments = Fragment.FromText(text, style, clearrestofline);
            WriteOutput(segments);
        }

        internal void ClearRestofline()
        {
            if (_outputconsole.SupportsAnsi)
            {

                ansiCommands.EraseInLine();
            }
            else
            {
                var (Left, Top) = _outputconsole.GetCursorPosition();
                int remaining = _outputconsole.Width - _outputconsole.CursorLeft;
                if (remaining > 0)
                {
                    if (outputconsole.WriteToErrorOutput)
                    {
                        _outputconsole.Error.Write(new string(' ', remaining));
                    }
                    else
                    {
                        _outputconsole.Out.Write(new string(' ', remaining));
                    }
                }
                _outputconsole.SetCursorPosition(Left, Top);
            }
        }

        internal bool ApplyStyle(Style? style)
        {
            if (style == null)
            {
                return false;
            }
            if (_outputconsole.SupportsAnsi)
            {
                _styleBuffer.Clear();
                _styleBuffer.AddRange(AnsiColorBuilder.Build(_colorSystem, style.Value.Foreground, true));
                _styleBuffer.AddRange(AnsiColorBuilder.Build(_colorSystem, style.Value.Background, false));
                return WriteSgr(_styleBuffer);
            }
            else
            {
                bool changed = false;
                if (style.Value.Foreground != _outputconsole.ForegroundColor)
                {
                    _outputconsole.ForegroundColor = style.Value.Foreground;
                    changed = true;
                }
                if (style.Value.Background != _outputconsole.BackgroundColor)
                {
                    _outputconsole.BackgroundColor = style.Value.Background;
                    changed = true;
                }
                return changed;
            }
        }

        private bool WriteSgr(List<byte> codes)
        {
            if (codes.Count == 0)
            {
                return false;
            }
            // Each byte formats to at most 3 digits plus a ';' separator, so codes.Count * 4 always
            // holds the full sequence. A foreground + background true-color pair produces up to 10 codes
            // (38;2;R;G;B;48;2;R;G;B => 33 chars), which the previous 24-char buffer could not hold.
            int maxLength = codes.Count * 4;
            Span<char> buffer = maxLength <= 64 ? stackalloc char[64] : new char[maxLength];
            int pos = 0;
            for (int i = 0; i < codes.Count; i++)
            {
                if (i > 0) buffer[pos++] = ';';
                codes[i].TryFormat(buffer[pos..], out int written, provider: CultureInfo.CurrentCulture);
                pos += written;
            }
            ansiCommands.WriteCsi(new string(buffer[..pos]), 'm');
            return true;
        }
    }
}
