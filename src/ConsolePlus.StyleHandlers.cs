// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {

        /// <summary>
        /// Gets the current console <see cref="Style"/>, reflecting the active foreground and background colors.
        /// </summary>
        public static Style CurrentStyle => _consoledrive.CurrentStyle;

        /// <summary>
        /// Creates a new <see cref="Style"/> instance with the specified foreground color and the current background color.
        /// </summary>
        /// <param name="value">The foreground color (<see cref="Color"/>) to apply.</param>
        /// <returns>A new <see cref="Style"/> instance with the specified foreground color and the current background color.</returns> 
        public static Style StyleForeground(Color value) =>
            new(value, _consoledrive.CurrentStyle.Background);

        /// <summary>
        /// Creates a new <see cref="Style"/> instance with the specified background color and the current foreground color.
        /// </summary>
        /// <param name="value">The background color (<see cref="Color"/>) to apply.</param>
        /// <returns>A new <see cref="Style"/> instance with the specified background color and the current foreground color.</returns>     
        public static Style StyleBackground(Color value) =>
            new(_consoledrive.CurrentStyle.Foreground, value);

        /// <summary>
        /// Creates a new <see cref="Style"/> instance with the foreground and background colors inverted.
        /// </summary>
        /// <returns>A new <see cref="Style"/> instance with the foreground and background colors inverted.</returns>           
        public static Style StyleInvert()
        {
            // Read both colors atomically with a single lock acquisition via CurrentStyle,
            // then swap: background becomes foreground and vice-versa.
            Style current = _consoledrive.CurrentStyle;
            return new Style(current.Background, current.Foreground);
        }
    }
}
