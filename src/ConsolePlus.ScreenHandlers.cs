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
        /// Beeps the console speaker.
        /// </summary>
        public static void Beep() => _consoledrive.Beep();

        /// <summary>
        /// Gets the console profile describing (<see cref="IProfileReadOnly"/>) the capabilities and configuration of the current console/terminal environment.
        /// </summary>
        public static IProfileReadOnly Profile => _consoledrive.Profile;

        /// <summary>
        /// Gets a value indicating whether the console supports ANSI escape sequences.
        /// </summary>
        public static bool SupportsAnsi => _consoledrive.SupportsAnsi;

        /// <summary>
        /// Gets a value indicating whether the console supports Unicode characters.
        /// </summary>
        public static bool SupportsUnicode => _consoledrive.SupportsUnicode;

        /// <summary>
        /// Gets the current width of the console window.
        /// </summary>
        public static int Width => _consoledrive.Width;

        /// <summary>
        /// Gets the current height of the console window.
        /// </summary>
        public static int Height => _consoledrive.Height;

        /// <summary>
        /// Clears the console buffer with <see cref="Color"/> and set BackgroundColor with <see cref="Color"/>
        /// </summary>
        /// <param name="backcolor">The <see cref="Color"/> Background</param>
        public static void Clear(Color? backcolor = null)
        {
            _consoledrive.Clear(backcolor);
        }

        /// <summary>
        /// Gets the current target buffer (<see cref="TargetScreen"/>), primary or secondary of the console.
        /// </summary>
        public static TargetScreen CurrentBuffer => _consoledrive.CurrentBuffer;

        /// <summary>
        /// Swaps the active console buffer to the specified target screen (<see cref="TargetScreen"/>), primary or secondary.
        /// </summary>
        /// <param name="value">The target screen (<see cref="TargetScreen"/>) to switch to.</param>
        /// <returns>True if the buffer was successfully swapped; otherwise, false.</returns>
        public static bool SwapBuffer(TargetScreen value) => _consoledrive.SwapBuffer(value);

        /// <summary>
        /// Event raised when the console size changes (<see cref="ConsoleSizeChangedEventArgs"/>).
        /// </summary>
        public static event EventHandler<ConsoleSizeChangedEventArgs>? SizeChanged
        {
            add
            {
                _consoledrive.SizeChanged += value;
            }
            remove
            {
                _consoledrive.SizeChanged -= value;
            }
        }

    }
}
