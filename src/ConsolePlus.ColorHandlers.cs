// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {

        /// <summary>
        /// Resets the console colors to default.
        /// </summary>
        public static void ResetColor() => _consoledrive.ResetColor();

        /// <summary>
        /// Gets or sets the foreground color (<see cref="ConsoleColor"/>) of the console.
        /// </summary>
        public static ConsoleColor ForegroundColor
        {
            get => _consoledrive.ForegroundColor;
            set => _consoledrive.ForegroundColor = value;
        }

        /// <summary>
        /// Gets or sets the foreground color (<see cref="Color"/>) of the console using RGB values.
        /// </summary>
        public static Color ForegroundRgbColor
        {
            get => _consoledrive.ForegroundRgbColor;
            set => _consoledrive.ForegroundRgbColor = value;
        }

        /// <summary>
        /// Gets or sets the background color (<see cref="ConsoleColor"/>) of the console.
        /// </summary>
        public static ConsoleColor BackgroundColor
        {
            get => _consoledrive.BackgroundColor;
            set => _consoledrive.BackgroundColor = value;
        }

        /// <summary>
        /// Gets or sets the background color (<see cref="Color"/>) of the console using RGB values.
        /// </summary>
        public static Color BackgroundRgbColor
        {
            get => _consoledrive.BackgroundRgbColor;
            set => _consoledrive.BackgroundRgbColor = value;
        }

        /// <summary>
        /// Gets the color depth (<see cref="ColorSystem"/>) of the console, indicating the number of colors supported.
        /// </summary>
        public static ColorSystem ColorDepth => _consoledrive.ColorDepth;

    }
}
