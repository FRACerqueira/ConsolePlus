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
/// Represents a console size-changed event.
/// </summary>
public sealed class ConsoleSizeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the new width of the console window.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets the new height of the console window.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets the previous width of the console window.
        /// </summary>
        public int PreviousWidth { get; set; }

        /// <summary>
        /// Gets the previous height of the console window.
        /// </summary>
        public int PreviousHeight { get; set; }
    }
}
