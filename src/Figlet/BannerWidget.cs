// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsolePlusLibrary.Figlet
{
    internal sealed class BannerWidget(IConsolePlus console, string text, Style style) 
    {
        private readonly IConsolePlus _console = console ?? throw new ArgumentNullException(nameof(console));
        private FigletFont _font = new();
        private DashOptions _bannerDash = DashOptions.None;

        public void  Border(DashOptions dashOptions)
        {
            _bannerDash = dashOptions;
        }

        public void FromFont(string filepathFont)
        {
            ArgumentException.ThrowIfNullOrEmpty(filepathFont);
            _font = new FigletFont(filepathFont);
        }

        public void FromFont(Stream streamFont)
        {
            ArgumentNullException.ThrowIfNull(streamFont);
            _font = new FigletFont(streamFont);
        }

        public void Show()
        {
            var segments = GetSegments();
            _console.Writer.WriteOutput(segments);
        }

        private Fragment[] GetSegments()
        {
            var segments = new List<Fragment>();
            if (string.IsNullOrEmpty(text))
            {
                return [];
            }

            // Strip \r and \n in a single span pass — avoids two string.Replace allocations
            if (text.AsSpan().IndexOfAny('\r', '\n') >= 0)
            {
                var buf = new char[text.Length];
                int pos = 0;
                foreach (char c in text)
                    if (c != '\r' && c != '\n') buf[pos++] = c;
                text = new string(buf, 0, pos);
            }

            var renderedText = _font.ToAsciiArtMarkup(text, style);

            // Compute max line width without StringBuilder: track running char count
            int max = 0;
            int lineLen = 0;
            foreach (var item in renderedText)
            {
                if (item.Type == FragmentKind.LineBreak)
                {
                    if (lineLen > max) max = lineLen;
                    lineLen = 0;
                }
                else
                {
                    lineLen += item.Text.Length;
                }
            }
            if (lineLen > max) max = lineLen; // last line (no trailing LineBreak)

            var borderUp = DashUtil.GetBorderUp((IConsole)console, _bannerDash);
            if (!string.IsNullOrWhiteSpace(borderUp))
            {
                segments.Add(new Fragment(new string(borderUp[0], max), style.Overflow(Overflow.Crop)));
                segments.Add(new Fragment("", null, FragmentKind.LineBreak));
            }

            segments.AddRange(renderedText);

            var borderDown = DashUtil.GetBorderDown((IConsole)console, _bannerDash);
            if (!string.IsNullOrWhiteSpace(borderDown))
            {
                segments.Add(new Fragment(new string(borderDown[0], max), style.Overflow(Overflow.Crop)));
                segments.Add(new Fragment("", null, FragmentKind.LineBreak));
            }

            return [.. segments];
        }
    }
}
