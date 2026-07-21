// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Provides extension methods for <see cref="ConsoleKeyInfo"/> to evaluate specific key combinations,
    /// including standard keys and Emacs-style shortcuts.
    /// </summary>
    public static class ConsoleKeyInfoExtensions
    {
        // IsOSPlatform result is process-invariant; compute once at class-load time
        // instead of re-evaluating the runtime check on every keystroke.
        private static readonly bool s_isWindows = OperatingSystem.IsWindows();
        /// <summary>
        /// Determines whether the pressed key matches the specified <paramref name="key"/> and <paramref name="modifier"/>.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="key">The expected <see cref="ConsoleKey"/>.</param>
        /// <param name="modifier">The expected <see cref="ConsoleModifiers"/>.</param>
        /// <returns><c>true</c> if both key and modifier match; otherwise, <c>false</c>.</returns>
        public static bool IsPressSpecialKey(this ConsoleKeyInfo keyinfo, ConsoleKey key, ConsoleModifiers modifier)
        {
            return keyinfo.Key == key && keyinfo.Modifiers == modifier;
        }

        /// <summary>
        /// Determines whether the pressed key represents an Enter action.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+J as Enter (Emacs style).</param>
        /// <returns><c>true</c> if Enter (or accepted Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// On non-Windows platforms both CR (13) and LF (10) may be emitted. This method normalizes those cases.
        /// </remarks>
        public static bool IsPressEnterKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return s_isWindows
                ? (keyinfo.Key == ConsoleKey.Enter && keyinfo.Modifiers == 0) || (emacskeys && keyinfo.Key == ConsoleKey.J && keyinfo.Modifiers == ConsoleModifiers.Control)
                : (keyinfo.KeyChar == 13 && keyinfo.Modifiers == 0)
                   || (keyinfo.KeyChar == 10 && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.J && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether the Alt+L (lower-case word) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+L was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsLowersCurrentWord(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.L && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether the Control+U (clear before cursor) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+U was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsClearBeforeCursor(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.U && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Control+K (clear after cursor) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+K was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsClearAfterCursor(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.K && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Control+W (clear word before cursor) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+W was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsClearWordBeforeCursor(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.W && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Control+D (clear word after cursor) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+D was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsClearWordAfterCursor(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.D && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Alt+C (capitalize over cursor) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+C was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsCapitalizeOverCursor(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.C && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether the Alt+F (forward word) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+F was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsForwardWord(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.F && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether the Alt+B (backward word) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+B was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsBackwardWord(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.B && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether the Alt+U (upper-case word) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+U was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsUppersCurrentWord(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.U && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether the Control+T (transpose previous characters) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+T was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsTransposePrevious(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.T && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Control+L (clear content) Emacs shortcut was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+L was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsClearContent(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.L && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Tab key (without modifiers) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Tab was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressTabKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Tab && keyinfo.Modifiers == 0;
        }

        /// <summary>
        /// Determines whether the Ctrl+Tab key was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Ctrl+Tab was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlTabKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Tab && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the Alt+Tab key was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+Tab was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressAltTabKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Tab && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether the Ctrl+Alt+Tab key was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Ctrl+Alt+Tab was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlAltTabKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Tab && keyinfo.Modifiers == (ConsoleModifiers.Control | ConsoleModifiers.Alt);
        }

        /// <summary>
        /// Determines whether Shift+Tab was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Shift+Tab was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressShiftTabKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Tab && keyinfo.Modifiers == ConsoleModifiers.Shift;
        }

        /// <summary>
        /// Determines whether End or (optionally) Control+E (Emacs end-of-line) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+E.</param>
        /// <returns><c>true</c> if End (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressEndKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.End && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.E && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Home or (optionally) Control+A (Emacs beginning-of-line) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+A.</param>
        /// <returns><c>true</c> if Home (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressHomeKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.Home && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.A && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Control+Home was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+Home was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlHomeKey(this ConsoleKeyInfo keyinfo)
        {
            return (keyinfo.Key == ConsoleKey.Home && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Control+End was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+End was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlEndKey(this ConsoleKeyInfo keyinfo)
        {
            return (keyinfo.Key == ConsoleKey.End && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Backspace or (optionally) Control+H (Emacs delete previous character) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+H.</param>
        /// <returns><c>true</c> if Backspace (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressBackspaceKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.Backspace && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.H && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Delete or (optionally) Control+D (Emacs delete forward) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+D.</param>
        /// <returns><c>true</c> if Delete (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressDeleteKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.Delete && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.D && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Control+Delete (clear word after cursor) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+Delete was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlDeleteKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Delete && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether LeftArrow or (optionally) Control+B (Emacs move backward) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+B.</param>
        /// <returns><c>true</c> if LeftArrow (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressLeftArrowKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.LeftArrow && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.B && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether Spacebar (without modifiers) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Spacebar was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressSpaceKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Spacebar && keyinfo.Modifiers == 0;
        }

        /// <summary>
        /// Determines whether Control+Alt+Spacebar was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+Alt+Spacebar was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlAltSpaceKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Spacebar && keyinfo.Modifiers == (ConsoleModifiers.Control | ConsoleModifiers.Alt);
        }

        /// <summary>
        /// Determines whether Alt+Spacebar was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Alt+Spacebar was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressAltSpaceKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Spacebar && keyinfo.Modifiers == ConsoleModifiers.Alt;
        }

        /// <summary>
        /// Determines whether Control+Spacebar was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Control+Spacebar was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressCtrlSpaceKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Spacebar && keyinfo.Modifiers == ConsoleModifiers.Control;
        }

        /// <summary>
        /// Determines whether the cross-terminal filter activation key was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns>
        /// <c>true</c> for Ctrl+Alt+Spacebar (primary) or Ctrl+Spacebar (fallback for terminals
        /// that do not report Ctrl+Alt+Spacebar consistently); otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPressFilterActivationKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.IsPressCtrlAltSpaceKey() || keyinfo.IsPressCtrlSpaceKey();
        }

        /// <summary>
        /// Determines whether the key represents an "expand" action for tree controls.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> for Numpad Plus or '+' character; otherwise, <c>false</c>.</returns>
        public static bool IsPressExpandKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Add || keyinfo.KeyChar == '+';
        }

        /// <summary>
        /// Determines whether the key represents a "collapse" action for tree controls.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> for Numpad Minus or '-' character; otherwise, <c>false</c>.</returns>
        public static bool IsPressCollapseKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Subtract || keyinfo.KeyChar == '-';
        }

        /// <summary>
        /// Determines whether RightArrow or (optionally) Control+F (Emacs move forward) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+F.</param>
        /// <returns><c>true</c> if RightArrow (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressRightArrowKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.RightArrow && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.F && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether UpArrow or (optionally) Control+P (Emacs previous line/history) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+P.</param>
        /// <returns><c>true</c> if UpArrow (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressUpArrowKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.UpArrow && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.P && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether DownArrow or (optionally) Control+N (Emacs next line/history) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Control+N.</param>
        /// <returns><c>true</c> if DownArrow (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressDownArrowKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.DownArrow && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.N && keyinfo.Modifiers == ConsoleModifiers.Control);
        }

        /// <summary>
        /// Determines whether PageUp or (optionally) Alt+P (Emacs previous extended navigation) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Alt+P.</param>
        /// <returns><c>true</c> if PageUp (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressPageUpKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.PageUp && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.P && keyinfo.Modifiers == ConsoleModifiers.Alt);
        }

        /// <summary>
        /// Determines whether PageDown or (optionally) Alt+N (Emacs next extended navigation) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <param name="emacskeys">If <c>true</c>, also accepts Alt+N.</param>
        /// <returns><c>true</c> if PageDown (or Emacs equivalent) was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressPageDownKey(this ConsoleKeyInfo keyinfo, bool emacskeys = true)
        {
            return (keyinfo.Key == ConsoleKey.PageDown && keyinfo.Modifiers == 0)
                   || (emacskeys && keyinfo.Key == ConsoleKey.N && keyinfo.Modifiers == ConsoleModifiers.Alt);
        }

        /// <summary>
        /// Determines whether Escape (without modifiers) was pressed.
        /// </summary>
        /// <param name="keyinfo">The <see cref="ConsoleKeyInfo"/> to evaluate.</param>
        /// <returns><c>true</c> if Escape was pressed; otherwise, <c>false</c>.</returns>
        public static bool IsPressEscKey(this ConsoleKeyInfo keyinfo)
        {
            return keyinfo.Key == ConsoleKey.Escape && keyinfo.Modifiers == 0;
        }
    }
}
