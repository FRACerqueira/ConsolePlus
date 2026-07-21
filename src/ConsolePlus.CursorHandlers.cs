// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {
        /// <summary>
        /// Sets the position of the cursor.
        /// </summary>
        /// <param name="left">The column position of the cursor.</param>
        /// <param name="top">The row position of the cursor.</param>
        public static void SetCursorPosition(int left, int top) => _consoledrive.SetCursorPosition(left, top);

        /// <summary>
        /// Gets or sets the column position of the cursor.
        /// </summary>
        public static int CursorLeft
        {
            get => _consoledrive.CursorLeft;
            set => _consoledrive.CursorLeft = value;
        }

        /// <summary>
        /// Gets or sets the row position of the cursor.
        /// </summary>
        public static int CursorTop
        {
            get => _consoledrive.CursorTop;
            set => _consoledrive.CursorTop = value;
        }

        /// <summary>
        /// Gets the current position of the cursor as a tuple containing the left and top coordinates.
        /// </summary>
        /// <returns>A tuple with the left and top coordinates of the cursor.</returns>
        public static (int Left, int Top) GetCursorPosition() => _consoledrive.GetCursorPosition();

        /// <summary>
        /// Gets or sets a value indicating whether the cursor is visible.
        /// </summary>
        public static bool CursorVisible
        {
            get => _consoledrive.CursorVisible;
            set => _consoledrive.CursorVisible = value;
        }

        /// <summary>
        /// Hides the cursor.
        /// </summary>
        public static bool HideCursor() => _consoledrive.HideCursor();

        /// <summary>
        /// Shows the cursor.
        /// </summary>
        public static bool ShowCursor() => _consoledrive.ShowCursor();

    }
}
