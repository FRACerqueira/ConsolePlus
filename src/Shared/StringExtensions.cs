// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Globalization;
using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Provides extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Normalizes the new lines in the specified text.
        /// </summary>
        /// <param name="text">The text to normalize.</param>
        /// <returns>The text with normalized new lines.</returns>
        public static string NormalizeNewLines(this string? text)
        {
            if (text == null) return string.Empty;

            // Fast path: no \r present (clean input — the common case)
            if (text.IndexOf('\r') < 0)
            {
                // Linux: \n is already the correct line ending — zero allocations
                if (Environment.NewLine.Length == 1) return text;
                // Windows: no \n either — nothing to normalise, zero allocations
                if (text.IndexOf('\n') < 0) return text;
                // Windows: bare \n present — single allocation
                return text.Replace("\n", "\r\n", StringComparison.Ordinal);
            }

            // Slow path: has \r — strip them then ensure \n → Environment.NewLine (rare)
            return text.Replace("\r", "", StringComparison.Ordinal)
                       .Replace("\n", Environment.NewLine, StringComparison.Ordinal);
        }

        /// <summary>
        /// Splits the specified text into lines, normalizing the new lines in the process.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] SplitLines(this string text)
        {
            return text.NormalizeNewLines().Split(["\r\n", "\n"], StringSplitOptions.None);
        }

        /// <summary>
        /// Calculates the display length of each line in the specified text, taking into account the width of Unicode characters.
        /// </summary>
        /// <param name="text">The text to calculate the display length for.</param>
        /// <returns>An array containing the display length of each line in the text.</returns>
        public static int[] GetDisplayLength(this string? text)
        {
            if (string.IsNullOrEmpty(text)) return [0];

            // Fast path: single line (no \n) — avoids List<int> allocation entirely
            if (text.IndexOf('\n') < 0)
            {
                int w = 0;
                foreach (Rune r in text.EnumerateRunes())
                    w += GetRuneWidth(r);
                return w > 0 ? [w] : [];
            }

            // Multi-line: count \n in one char pass to pre-size the result array
            int n = 0;
            foreach (char c in text) if (c == '\n') n++;

            // n+1 covers the segment after the last \n (dropped if empty, see below)
            int[] lines = new int[n + 1];
            int idx = 0, len = 0;
            foreach (Rune r in text.EnumerateRunes())
            {
                if (r.Value == '\r') continue;
                if (r.Value == '\n') { lines[idx++] = len; len = 0; continue; }
                len += GetRuneWidth(r);
            }
            if (len > 0) lines[idx++] = len;

            // Return exact slice; when idx == n+1 the array is already right-sized
            return idx == lines.Length ? lines : lines[..idx];
        }

        private static int GetRuneWidth(Rune rune)
        {
            var category = Rune.GetUnicodeCategory(rune);
            if (category is UnicodeCategory.NonSpacingMark or
                UnicodeCategory.EnclosingMark or
                UnicodeCategory.Control or
                UnicodeCategory.Format or
                UnicodeCategory.Surrogate)
            {
                return 0;
            }
            return IsWideRune(rune) ? 2 : 1;
        }

        private static bool IsWideRune(Rune rune)
        {
            var value = rune.Value;
            return (value >= 0x1100 && value <= 0x115F) ||
                   value == 0x2329 ||
                   value == 0x232A ||
                   (value >= 0x2E80 && value <= 0x303E) ||
                   (value >= 0x3040 && value <= 0xA4CF) ||
                   (value >= 0xAC00 && value <= 0xD7A3) ||
                   (value >= 0xF900 && value <= 0xFAFF) ||
                   (value >= 0xFE10 && value <= 0xFE19) ||
                   (value >= 0xFE30 && value <= 0xFE6F) ||
                   (value >= 0xFF00 && value <= 0xFF60) ||
                   (value >= 0xFFE0 && value <= 0xFFE6) ||
                   (value >= 0x1F300 && value <= 0x1FAFF) ||
                   (value >= 0x20000 && value <= 0x2FFFD) ||
                   (value >= 0x30000 && value <= 0x3FFFD);
        }
    }
}
