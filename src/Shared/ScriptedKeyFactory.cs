// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Collections.Generic;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Builds synthetic <see cref="ConsoleKeyInfo"/> values for demo-mode scripted input,
    /// mirroring the char/key mapping used by the headless test driver's InputQueue.
    /// </summary>
    internal static class ScriptedKeyFactory
    {
        /// <summary>
        /// Builds a <see cref="ConsoleKeyInfo"/> from a character, inferring its <see cref="ConsoleKey"/> and Shift state.
        /// </summary>
        internal static ConsoleKeyInfo FromChar(char ch)
            => new(ch, CharToKey(ch), shift: char.IsUpper(ch), alt: false, control: false);

        /// <summary>
        /// Builds a <see cref="ConsoleKeyInfo"/> from a <see cref="ConsoleKey"/>, filling in the KeyChar
        /// a real console would report alongside it (required for controls that check KeyChar, e.g. Enter).
        /// </summary>
        internal static ConsoleKeyInfo FromKey(ConsoleKey key, bool shift = false, bool alt = false, bool ctrl = false)
            => new(DefaultCharFor(key), key, shift, alt, ctrl);

        /// <summary>
        /// Builds the sequence of <see cref="ConsoleKeyInfo"/> representing each character of the given text.
        /// </summary>
        internal static IEnumerable<ConsoleKeyInfo> FromText(string text)
        {
            foreach (var ch in text)
            {
                yield return FromChar(ch);
            }
        }

        private static char DefaultCharFor(ConsoleKey key) => key switch
        {
            ConsoleKey.Enter => '\r',
            ConsoleKey.Tab => '\t',
            ConsoleKey.Backspace => '\b',
            ConsoleKey.Escape => (char)27,
            _ => '\0',
        };

        private static ConsoleKey CharToKey(char ch)
        {
            if (char.IsAsciiLetter(ch))
            {
                return Enum.Parse<ConsoleKey>(char.ToUpperInvariant(ch).ToString());
            }
            if (char.IsAsciiDigit(ch))
            {
                return (ConsoleKey)('0' + (ch - '0'));
            }
            return ch switch
            {
                ' ' => ConsoleKey.Spacebar,
                '-' => ConsoleKey.OemMinus,
                '.' => ConsoleKey.OemPeriod,
                ',' => ConsoleKey.OemComma,
                _ => ConsoleKey.Oem1,
            };
        }
    }
}
