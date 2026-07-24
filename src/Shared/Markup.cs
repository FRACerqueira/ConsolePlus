// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Provides functionality for working with markup text.
    /// </summary>
    public static class Markup
    {
        /// <summary>
        /// Escapes the specified markup text.
        /// </summary>
        /// <param name="markup">The markup text to escape.</param>
        /// <returns>The escaped markup text.</returns>
        public static string EscapeMarkup(this string? markup)
        { 
            return Escape(markup);
        }


        /// <summary>
        /// Escapes the specified markup text.
        /// </summary>
        /// <param name="markup">The markup text to escape.</param>
        /// <returns>The escaped markup text.</returns>
        public static string Escape(string? markup)
        {
            if (markup == null) return string.Empty;

            ReadOnlySpan<char> src = markup.AsSpan();

            // Fast path: no special chars — return original reference, zero allocations
            if (src.IndexOfAny('[', ']') < 0) return markup;

            // Count how many chars need doubling to calculate the exact output length
            int extras = 0;
            foreach (char c in src)
                if (c == '[' || c == ']') extras++;

            // Single-pass string.Create: 1 allocation vs 2 chained Replace() calls
            return string.Create(src.Length + extras, markup, static (span, input) =>
            {
                int pos = 0;
                foreach (char c in input)
                {
                    if (c == '[' || c == ']')
                    {
                        span[pos++] = c; // first copy
                        span[pos++] = c; // escape double
                    }
                    else
                    {
                        span[pos++] = c;
                    }
                }
            });
        }

        /// <summary>
        /// Removes the markup from the specified text.
        /// </summary>
        /// <param name="markup">The markup text to remove.</param>
        /// <returns>The text without markup.</returns>
        public static string RemoveMarkup(this string? markup)
        {
            return Remove(markup);
        }

        /// <summary>
        /// Removes the markup from the specified text.
        /// </summary>
        /// <param name="markup">The markup text to remove.</param>
        /// <returns>The text without markup.</returns>
        public static string Remove(string? markup)
        {
            if (string.IsNullOrWhiteSpace(markup))
            {
                return string.Empty;
            }

            // Fast path: no '[' or ']' means there is no markup to strip.
            // Returns the original reference with zero allocations (no tokenizer/StringBuilder).
            if (markup.AsSpan().IndexOfAny('[', ']') < 0)
            {
                return markup;
            }

            // Tokenizer is fault-tolerant and returns malformed markup as text,
            // so no exception fallback is needed here.
            {
                var result = new StringBuilder(markup.Length);
                var tokenizer = new MarkupColorTokenizer(markup);
                while (tokenizer.MoveNext() && tokenizer.Current != null)
                {
                    if (tokenizer.Current.Kind == MarkupColorKind.Text)
                    {
                        result.Append(tokenizer.Current.Value);
                    }
                }
                return result.ToString();
            }
        }

        /// <summary>
        /// Calculates the length of the text without markup in the specified markup text.
        /// </summary>
        /// <param name="markup">The markup text to calculate the length for.</param>
        /// <returns>The length of the text without markup. </returns>
        public static int LengthMarkup(this string? markup)
        {
            return Length(markup);
        }

        /// <summary>
        /// Calculates the length of the text without markup in the specified markup text.
        /// </summary>
        /// <param name="markup">The markup text to calculate the length for.</param>
        /// <returns>The length of the text without markup.</returns>
        public static int Length(string? markup)
        {
            if (string.IsNullOrWhiteSpace(markup))
            {
                return 0;
            }

            // Fast path: no '[' or ']' means the visible length equals the raw length.
            // Avoids allocating the tokenizer for plain text.
            if (markup.AsSpan().IndexOfAny('[', ']') < 0)
            {
                return markup.Length;
            }

            int result = 0;
            var tokenizer = new MarkupColorTokenizer(markup);
            while (tokenizer.MoveNext() && tokenizer.Current != null)
            {
                if (tokenizer.Current.Kind == MarkupColorKind.Text)
                {
                    result += tokenizer.Current.Value.Length;
                }
            }

            return result;
        }
    }
}
