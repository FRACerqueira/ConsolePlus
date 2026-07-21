// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Provides methods for emitting ANSI escape codes to control the console output.
    /// </summary>
    public interface IAnsiCommands
    {
        /// <summary>
        /// This control function moves the cursor to the specified line and column (1-indexed)
        /// by emitting <c>CSI row;column H</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUP"/>.
        /// </remarks>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        void CursorPosition(int row, int column);

        /// <summary>
        /// Moves the cursor to position 1,1 (top left corner) by emitting <c>CSI H</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUP"/>.
        /// </remarks>
        void CursorHome();

        /// <summary>
        /// Moves the cursor up a specified number of lines in the same column by emitting <c>CSI n A</c>.
        /// The cursor stops at the top margin.
        /// If the cursor is already above the top margin, then the cursor stops at the top line.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUU"/>.
        /// </remarks>
        /// <param name="steps">The number of steps to move the cursor up.</param>
        void CursorUp(int steps);

        /// <summary>
        /// This control function moves the cursor down a specified number of lines in the same column
        /// by emitting <c>CSI n B</c>.
        /// The cursor stops at the bottom margin.
        /// If the cursor is already below the bottom margin, then the cursor stops at the bottom line.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUD"/>.
        /// </remarks>
        /// <param name="steps">The number of steps to move the cursor down.</param>
        void CursorDown(int steps);

        /// <summary>
        /// This control function moves the cursor to the right by a specified number of columns
        /// by emitting <c>CSI n C</c>.
        /// The cursor stops at the right border of the page.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUF"/>.
        /// </remarks>
        /// <param name="steps">The number of steps to move the cursor right.</param>
        void CursorRight(int steps);

        /// <summary>
        /// This control function moves the cursor to the right by a specified number of columns
        /// by emitting <c>CSI n C</c>.
        /// The cursor stops at the right border of the page.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUF"/>.
        /// </remarks>
        /// <param name="steps">The number of steps to move the cursor right.</param>
        void CursorForward(int steps);

        /// <summary>
        /// This control function moves the cursor to the left by a specified number of columns
        /// by emitting <c>CSI n D</c>.
        /// The cursor stops at the left border of the page.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUB"/>.
        /// </remarks>
        /// <param name="steps">The number of steps to move the cursor left.</param>
        void CursorLeft(int steps);

        /// <summary>
        /// This control function moves the cursor to the left by a specified number of columns
        /// by emitting <c>CSI n D</c>.
        /// The cursor stops at the left border of the page.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#CUB"/>.
        /// </remarks>
        /// <param name="steps">The number of steps to move the cursor backward.</param>
        void CursorBackward(int steps);

        /// <summary>
        /// Shows the cursor by emitting <c>CSI ? 25 h</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#SM"/>.
        /// </remarks>
        void ShowCursor();

        /// <summary>
        /// Hides the cursor by emitting <c>CSI ? 25 l</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#RM"/>.
        /// </remarks>
        void HideCursor();

        /// <summary>
        /// Saves current cursor position for SCO console mode by emitting <c>CSI s</c> (SCOSC)
        /// if staying on page, otherwise <c>ESC 7</c> (DECSC).
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/SCOSC.html"/> and
        /// <see href="https://vt100.net/docs/vt510-rm/DECSC.html"/>.
        /// </remarks>
        /// <param name="stayOnPage">Whether to keep the cursor on the current page.</param>
        void SaveCursor(bool stayOnPage = true);

        /// <summary>
        /// Moves cursor to the position saved by save cursor command in SCO console mode
        /// by emitting <c>CSI u</c> (SCORC) if staying on page, otherwise <c>ESC 8</c> (DECRC).
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/SCORC.html"/> and
        /// <see href="https://vt100.net/docs/vt510-rm/DECRC.html"/>.
        /// </remarks>
        /// <param name="stayOnPage">Whether to keep the cursor on the current page.</param>
        void RestoreCursor(bool stayOnPage = true);

        /// <summary>
        /// Moves the active position to the n-th character of the active line
        /// by emitting <c>CSI n G</c>
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/CHA.html"/>.
        /// </remarks>
        /// <param name="position">The horizontal position.</param>
        void CursorHorizontalAbsolute(int position);

        /// <summary>
        /// Enters the alternative screen buffer by emitting <c>CSI ? 1049 h</c>.
        /// </summary>
        void EnterAltScreen();

        /// <summary>
        /// Exits the alternative screen buffer by emitting <c>CSI ? 1049 l</c>.
        /// </summary>
        void ExitAltScreen();

        /// <summary>
        /// This control function erases characters on the line that has the cursor.
        /// EL clears all character attributes from erased character positions.
        /// EL works inside or outside the scrolling margins.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#EL"/>.
        /// </remarks>
        /// <param name="mode">
        /// The section of the line to erase.
        /// <list type="bullet|number|table">
        ///     <item>
        ///         <term>0</term>
        ///         <description>From the cursor through the end of the line.</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>From the beginning of the line through the cursor.</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>The complete line.</description>
        ///     </item>
        /// </list>
        /// </param>
        void EraseInLine(int mode = 0);

        /// <summary>
        /// This control function erases characters from part or all of the display.
        /// When you erase complete lines, they become single-height, single-width lines,
        /// with all visual character attributes cleared.
        /// ED works inside or outside the scrolling margins.
        /// </summary>
        /// <param name="mode">
        /// The amount of the display to erase.
        /// <list type="bullet|number|table">
        ///     <item>
        ///         <term>0</term>
        ///         <description>From the cursor through the end of the display.</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>From the beginning of the display through the cursor.</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>The complete display.</description>
        ///     </item>
        ///     <item>
        ///         <term>3</term>
        ///         <description>Clears the scrollback buffer</description>
        ///     </item>
        /// </list>
        /// </param>
        void EraseInDisplay(int mode = 0);

        /// <summary>
        /// Clears the scrollback buffer by emitting <c>CSI 3J</c>.
        /// </summary>
        void ClearScrollback();

        /// <summary>
        /// Move the active position n tabs backward
        /// by emitting <c>CSI n Z</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/CBT.html"/>.
        /// </remarks>
        /// <param name="tabs">The number of tabs to move backwards</param>
        void CursorBackwardTabulation(int tabs = 1);

        /// <summary>
        /// Move the active position n tabs forward
        /// by emitting <c>CSI n I</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/CHT.html"/>.
        /// </remarks>
        /// <param name="tabs">The number of tabs to move forward</param>
        void CursorHorizontalTabulation(int tabs = 1);

        /// <summary>
        /// Move the cursor to the next line
        /// by emitting <c>CSI n E</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/CNL.html"/>.
        /// </remarks>
        /// <param name="lines">The number of lines to move</param>
        void CursorNextLine(int lines = 1);

        /// <summary>
        /// Move the cursor to the preceding line
        /// by emitting <c>CSI n F</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/CPL.html"/>.
        /// </remarks>
        /// <param name="lines">The number of lines to move</param>
        void CursorPreviousLine(int lines = 1);

        /// <summary>
        /// Moves the cursor down one line in the same column by emitting <c>ESC D</c>.
        /// If the cursor is at the bottom margin, then the screen performs a scroll-up.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/IND.html"/>.
        /// </remarks>
        void Index();

        /// <summary>
        /// Moves the cursor up one line in the same column by emitting <c>ESC M</c>.
        /// If the cursor is at the top margin, then the screen performs a scroll-down.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt100-ug/chapter3.html#RI"/>.
        /// </remarks>
        void ReverseIndex();

        /// <summary>
        /// This control function deletes one or more characters from the cursor position to the right
        /// by emitting <c>CSI n P</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/DCH.html"/>.
        /// </remarks>
        /// <param name="characters">
        /// The number of characters to delete. If <paramref name="characters"/> is greater than the number of characters between the cursor and the right margin, then DCH only deletes the remaining characters.
        /// </param>
        void DeleteCharacter(int characters = 1);

        /// <summary>
        /// Select the style of the cursor on the screen by emitting <c>CSI n SP q</c>
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/DECSCUSR.html"/>.
        /// </remarks>
        /// <param name="style">
        /// The style of the cursor
        /// <list type="bullet|number|table">
        ///     <item>
        ///         <term>0</term>
        ///         <description>Terminal default.</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>Blinking block.</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>Steady block.</description>
        ///     </item>
        ///     <item>
        ///         <term>3</term>
        ///         <description>Blinking underline.</description>
        ///     </item>
        ///     <item>
        ///         <term>5</term>
        ///         <description>Steady underline.</description>
        ///     </item>
        ///     <item>
        ///         <term>6</term>
        ///         <description>Steady vertical bar.</description>
        ///     </item>
        /// </list>
        /// </param>
        void SetCursorStyle(int style = 0);

        /// <summary>
        /// This control function deletes one or more lines in the scrolling region
        /// by emitting <c>CSI n M</c>, starting with the line that has the cursor.
        /// As lines are deleted, lines below the cursor and in the scrolling region move up.
        /// The terminal adds blank lines with no visual character attributes at the bottom of the scrolling region.
        /// If <c>lines</c> is greater than the number of lines remaining on the page, DL deletes only the remaining lines.
        /// DL has no effect outside the scrolling margins.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/DL.html"/>.
        /// </remarks>
        /// <param name="lines">The number of lines to delete.</param>
        void DeleteLine(int lines = 0);

        /// <summary>
        /// Erases one or more characters from the cursor position to the right by emitting <c>CSI n X</c> (ECH).
        /// ECH clears character attributes from erased character positions.
        /// ECH works inside or outside the scrolling margins.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/ECH.html"/>.
        /// </remarks>
        /// <param name="characters">The number of characters to erase. A value of 0 or 1 erases one character.</param>
        void EraseCharacter(int characters = 1);

        /// <summary>
        /// inserts one or more space (SP) characters starting at the cursor position
        /// by emitting <c>CSI n @</c> (ICH).
        /// The ICH sequence inserts blank characters with the normal character attribute.
        /// The cursor remains at the beginning of the blank characters.
        /// Text between the cursor and right margin moves to the right.
        /// Characters scrolled past the right margin are lost. ICH has no effect outside the scrolling margins.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/ICH.html"/>.
        /// </remarks>
        /// <param name="characters">The number of characters to insert.</param>
        void InsertCharacter(int characters = 1);

        /// <summary>
        /// Inserts one or more blank lines, starting at the cursor by emitting <c>CSI n L</c> (IL).
        /// As lines are inserted, lines below the cursor and in the scrolling region move down.
        /// Lines scrolled off the page are lost. IL has no effect outside the page margins.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/IL.html"/>.
        /// </remarks>
        /// <param name="lines">The number of lines to insert.</param>
        void InsertLine(int lines = 1);

        /// <summary>
        /// Moves the user window up a specified number of lines in page memory
        /// by emitting <c>CSI n T</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/SD.html"/>.
        /// </remarks>
        /// <param name="lines">
        /// The number of lines to move the user window up in page memory.
        /// <c>lines</c> new lines appear at the top of the display.
        /// <c>lines</c> old lines disappear at the bottom of the display.
        /// You cannot pan past the top margin of the current page.</param>
        void ScrollUp(int lines = 1);

        /// <summary>
        /// Moves the user window down a specified number of lines in page memory
        /// by emitting <c>CSI n S</c>.
        /// </summary>
        /// <remarks>
        /// See <see href="https://vt100.net/docs/vt510-rm/SU.html"/>.
        /// </remarks>
        /// <param name="lines">
        /// The number of lines to move the user window down in page memory.
        /// <c>lines</c> new lines appear at the bottom of the display.
        /// <c>lines</c> old lines disappear at the top of the display.
        /// You cannot pan past the bottom margin of the current page.</param>
        void ScrollDown(int lines = 1);
    }
}