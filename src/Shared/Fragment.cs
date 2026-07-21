// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents a rendered text fragment with optional style and semantic kind.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Fragment"/> class.
    /// </remarks>
    /// <param name="text">Fragment content.</param>
    /// <param name="style">Style applied to this fragment, when applicable.</param>
    /// <param name="type">Fragment category (raw text, line break, clear-to-end-of-line, etc.).</param>
    public readonly struct Fragment(string text, Style? style = null, FragmentKind type = FragmentKind.ContentText)
    {
        /// <summary>
        /// Gets the fragment style.
        /// </summary>
        public Style? Style { get; } = style;

        /// <summary>
        /// Gets the fragment text.
        /// </summary>
        public string Text { get; } = type == FragmentKind.ContentText ? text.NormalizeNewLines() : text;

        /// <summary>
        /// Gets the fragment type.
        /// </summary>
        public FragmentKind Type { get; } = type;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Text, Style, Type);

        /// <inheritdoc/>
        public override bool Equals(object? obj) =>
            obj is Fragment other &&
            Text == other.Text &&
            Type == other.Type &&
            Equals(Style, other.Style);

        /// <summary>
        /// Determines whether two <see cref="Fragment"/> values are equal.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> when both fragments are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Fragment left, Fragment right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="Fragment"/> values are not equal.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns><c>true</c> when the fragments differ; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Fragment left, Fragment right) => !left.Equals(right);

        /// <summary>
        /// Parses input text (with optional markup tags) into styled fragments.
        /// </summary>
        /// <param name="text">Input text. Markup tags such as <c>[red]</c> and <c>[/]</c> are supported.</param>
        /// <param name="defaultstyletext">Base style used before any markup tag is applied.</param>
        /// <param name="clearrestofline">When <c>true</c>, inserts <see cref="FragmentKind.ClearRestofline"/> fragments around line boundaries.</param>
        /// <returns>Parsed fragments ready for rendering.</returns>
        public static Fragment[] FromText(string? text, Style defaultstyletext, bool clearrestofline = false)
        {
            if (string.IsNullOrEmpty(text))
            {
                return [];
            }

            string localtext = text.NormalizeNewLines();
            if (localtext == Environment.NewLine)
            {
                return [new Fragment("", defaultstyletext, FragmentKind.LineBreak)];
            }

            // Fast path: no markup delimiters means there are no color/style tokens to parse.
            // Return the original text fragmented by line directly, skipping tokenizer overhead.
            if (localtext.AsSpan().IndexOfAny('[', ']') < 0)
            {
                return CreateRawTextFallback(localtext, defaultstyletext, clearrestofline);
            }

            List<Fragment> result = [];
            MarkupColorTokenizer tokenizer = new(localtext);
            Stack<Style> stack = new();
            Color currentForeground = defaultstyletext.Foreground;
            Color currentBackground = defaultstyletext.Background;
            Overflow currentOverflow = defaultstyletext.OverflowStrategy;
            while (tokenizer.MoveNext())
            {
                MarkupColor? token = tokenizer.Current;
                if (token == null)
                {
                    break;
                }

                bool notfound = false;
                if (token.Kind == MarkupColorKind.Open)
                {
                    string[] parts = token.Value.Split([' ']);
                    if (parts.Length == 1 && parts[0].Contains(':'))
                    {
                        int index = parts[0].IndexOf(':');
                        parts = [parts[0][..index], "on", parts[0][(index + 1)..]];
                    }

                    bool foreground = true;
                    Color partForeground = currentForeground;
                    Color partBackground = currentBackground;
                    bool first = true;
                    foreach (string part in parts)
                    {
                        if (part.Equals("on", StringComparison.OrdinalIgnoreCase))
                        {
                            foreground = false;
                            continue;
                        }

                        Color? color = ResolveColorToken(part, out bool isColorSyntax);
                        if (color == null)
                        {
                            if (isColorSyntax)
                            {
                                return CreateRawTextFallback(text, defaultstyletext, clearrestofline);
                            }

                            if (!first)
                            {
                                return CreateRawTextFallback(text, defaultstyletext, clearrestofline);
                            }

                            notfound = true;
                            token = new MarkupColor(MarkupColorKind.Text, $"[{token.Value}]", token.Position);
                            break;
                        }

                        if (foreground)
                        {
                            partForeground = color.Value;
                        }
                        else
                        {
                            partBackground = color.Value;
                        }

                        first = false;
                    }

                    if (!notfound)
                    {
                        stack.Push(new Style(partForeground, partBackground, currentOverflow));
                        currentForeground = partForeground;
                        currentBackground = partBackground;
                    }
                }

                if (token.Kind == MarkupColorKind.Close)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }

                    if (stack.Count == 0)
                    {
                        currentForeground = defaultstyletext.Foreground;
                        currentBackground = defaultstyletext.Background;
                        currentOverflow = defaultstyletext.OverflowStrategy;
                    }
                    else
                    {
                        currentForeground = stack.Peek().Foreground;
                        currentBackground = stack.Peek().Background;
                        currentOverflow = stack.Peek().OverflowStrategy;
                    }
                }

                if (token.Kind == MarkupColorKind.Text)
                {
                    Style lineStyle = new(currentForeground, currentBackground, currentOverflow);
                    AppendTextSegments(result, token.Value.AsSpan(), lineStyle, clearrestofline);
                }
            }

            return [.. result];
        }

        /// <summary>
        /// Creates a plain-text fallback result when markup parsing cannot be applied.
        /// </summary>
        /// <param name="text">Original input text.</param>
        /// <param name="defaultstyletext">Style applied to emitted text fragments.</param>
        /// <param name="clearrestofline">Whether clear-to-end-of-line fragments should be emitted.</param>
        /// <returns>Fragments that preserve the original text content.</returns>
        private static Fragment[] CreateRawTextFallback(string text, Style defaultstyletext, bool clearrestofline)
        {
            List<Fragment> result = [];
            Style lineStyle = new(defaultstyletext.Foreground, defaultstyletext.Background, defaultstyletext.OverflowStrategy);
            AppendTextSegments(result, text.AsSpan(), lineStyle, clearrestofline);
            return [.. result];
        }

        /// <summary>
        /// Appends text as one or more fragments, splitting by line breaks and preserving CRLF semantics.
        /// </summary>
        /// <param name="result">Destination collection for generated fragments.</param>
        /// <param name="text">Source text span.</param>
        /// <param name="lineStyle">Style used for emitted text fragments.</param>
        /// <param name="clearrestofline">Whether to emit <see cref="FragmentKind.ClearRestofline"/> fragments.</param>
        private static void AppendTextSegments(List<Fragment> result, ReadOnlySpan<char> text, Style lineStyle, bool clearrestofline)
        {
            if (!text.Contains('\n'))
            {
                if (clearrestofline)
                {
                    result.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                }

                if (!text.IsEmpty)
                {
                    result.Add(new Fragment(text.ToString(), lineStyle));
                }

                return;
            }

            ReadOnlySpan<char> remaining = text;
            while (true)
            {
                int idx = remaining.IndexOf('\n');
                if (idx < 0)
                {
                    // Trim any trailing lone \r before emitting the final fragment
                    ReadOnlySpan<char> last = remaining.Length > 0 && remaining[^1] == '\r'
                        ? remaining[..^1] : remaining;
                    if (clearrestofline)
                    {
                        result.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                    }

                    if (!last.IsEmpty)
                    {
                        result.Add(new Fragment(last.ToString(), lineStyle));
                    }

                    break;
                }

                // Strip preceding \r so that \r\n counts as a single newline
                ReadOnlySpan<char> line = idx > 0 && remaining[idx - 1] == '\r'
                    ? remaining[..(idx - 1)] : remaining[..idx];
                if (clearrestofline)
                {
                    result.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                }

                if (!line.IsEmpty)
                {
                    result.Add(new Fragment(line.ToString(), lineStyle));
                }

                result.Add(new Fragment("", null, FragmentKind.LineBreak));
                remaining = remaining[(idx + 1)..];
            }
        }

        /// <summary>
        /// Resolves a color token from CSS name, weighted CSS name (for example <c>Blue500</c> or
        /// <c>Red300</c>), hexadecimal notation, or <c>rgb(r,g,b)</c> notation.
        /// </summary>
        /// <param name="token">Token text to resolve.</param>
        /// <param name="isColorSyntax">Set to <c>true</c> when the token looks like explicit color syntax (hex/rgb).</param>
        /// <returns>The resolved color, or <c>null</c> when the token is not a valid color.</returns>
        private static Color? ResolveColorToken(string token, out bool isColorSyntax)
        {
            isColorSyntax = false;

            if (ColorTableCss.TryGetColor(token, out Color cssColor))
            {
                return cssColor;
            }

            if (token.StartsWith("#", StringComparison.OrdinalIgnoreCase))
            {
                isColorSyntax = true;
                return ParseHexColor(token);
            }

            if (token.StartsWith("rgb", StringComparison.OrdinalIgnoreCase))
            {
                isColorSyntax = true;
                return ParseRgbColor(token);
            }

            // CSS base name plus a numeric weight suffix, e.g. [Blue500] or [Red300].
            if (ColorTableCss.TryGetWeightedColor(token, out Color weightedColor))
            {
                return weightedColor;
            }

            return null;
        }

        /// <summary>
        /// Parses a hexadecimal color token (#RRGGBB or #RGB).
        /// </summary>
        /// <param name="hex">Hexadecimal color token.</param>
        /// <returns>The parsed color, or <c>null</c> when invalid.</returns>
        private static Color? ParseHexColor(ReadOnlySpan<char> hex)
        {
            // Skip leading '#' and trim — span slices, zero allocations
            if (!hex.IsEmpty && hex[0] == '#') hex = hex[1..];
            hex = hex.Trim();

            try
            {
                if (!hex.IsEmpty)
                {
                    if (hex.Length == 6)
                    {
                        return new Color(
                            byte.Parse(hex[..2], NumberStyles.HexNumber, CultureInfo.InvariantCulture),
                            byte.Parse(hex[2..4], NumberStyles.HexNumber, CultureInfo.InvariantCulture),
                            byte.Parse(hex[4..],  NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                    }
                    else if (hex.Length == 3)
                    {
                        // Expand each nibble: #RGB → #RRGGBB via nibble * 17 (0x11)
                        // e.g. 0xA → 0xAA = 10 * 17 = 170. No string allocation.
                        return new Color(
                            (byte)(HexNibble(hex[0]) * 17),
                            (byte)(HexNibble(hex[1]) * 17),
                            (byte)(HexNibble(hex[2]) * 17));
                    }
                }
            }
            catch (Exception)
            {
                //ignore
            }
            return null;
        }

        /// <summary>
        /// Converts a single hexadecimal character to its numeric value.
        /// </summary>
        /// <param name="c">Hex character.</param>
        /// <returns>Value between 0 and 15; returns 0 for invalid input.</returns>
        private static int HexNibble(char c) =>
            c is >= '0' and <= '9' ? c - '0' :
            c is >= 'a' and <= 'f' ? c - 'a' + 10 :
            c is >= 'A' and <= 'F' ? c - 'A' + 10 : 0;

        /// <summary>
        /// Parses an <c>rgb(r,g,b)</c> color token.
        /// </summary>
        /// <param name="rgb">RGB color token.</param>
        /// <returns>The parsed color, or <c>null</c> when invalid.</returns>
        private static Color? ParseRgbColor(ReadOnlySpan<char> rgb)
        {
            try
            {
                if (rgb.Length >= 5) // "rgb()" minimum
                {
                    // Skip "rgb" prefix and trim — span slice, no allocation
                    ReadOnlySpan<char> inner = rgb[3..].Trim();

                    if (!inner.IsEmpty && inner[0] == '(' && inner[^1] == ')')
                    {
                        inner = inner[1..^1]; // strip parentheses — still zero allocation

                        // stackalloc: zero heap; TrimEntries handles spaces after commas
                        Span<Range> ranges = stackalloc Range[4];
                        int count = inner.Split(ranges, ',',
                            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                        if (count == 3)
                        {
                            return new Color(
                                (byte)int.Parse(inner[ranges[0]], CultureInfo.InvariantCulture),
                                (byte)int.Parse(inner[ranges[1]], CultureInfo.InvariantCulture),
                                (byte)int.Parse(inner[ranges[2]], CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
            catch (Exception)
            {
                //ignore
            }
            return null;
        }

    }
}
