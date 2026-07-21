// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Defines a console profile describing capabilities, dimensions, colors and display behavior
    /// for the current console/terminal session.
    /// </summary>
    /// <remarks>
    /// An implementation should provide immutable (snapshot) values representing the environment
    /// at the time it was created. These values can be used to adapt rendering (color depth,
    /// ANSI/Unicode support, margins, buffer size and overflow strategy).
    /// </remarks>
    public interface IProfileReadOnly
    {
        /// <summary>
        /// Gets the original culture of the console at the time the profile was created.
        /// </summary>
        string OriginalCulture { get; }

        /// <summary>
        /// Gets the default input encoding (<see cref="Encoding"/>) of the console at the time the profile was created.
        /// </summary>
        Encoding DefaultInputEncoding { get; }

        /// <summary>
        /// Gets the default output encoding (<see cref="Encoding"/>) of the console at the time the profile was created.
        /// </summary>
        Encoding DefaultOutputEncoding { get; }

        /// <summary>
        /// Gets the original input encoding (<see cref="Encoding"/>) of the console at the time the profile was created.
        /// </summary>
        Encoding OriginalInputEncoding { get; }

        /// <summary>
        /// Gets the original output encoding (<see cref="Encoding"/>) of the console at the time the profile was created.
        /// </summary>
        Encoding OriginalOutputEncoding { get; }

        /// <summary>
        /// Gets the default foreground <see cref="Color"/> used when no explicit color is specified.
        /// </summary>
        /// <value>The default foreground color.</value>
        Color DefaultForegroundColor { get; }

        /// <summary>
        /// Gets the default background <see cref="Color"/> used when no explicit color is specified.
        /// </summary>
        /// <value>The default background color.</value>
        Color DefaultBackgroundColor { get; }

        /// <summary>
        /// Gets the profile name (e.g. an identifier for the terminal type or configuration).
        /// </summary>
        /// <value>The logical name of this profile.</value>
        string ProfileName { get; }

        /// <summary>
        /// Gets a value indicating whether the output device is a terminal (TTY).
        /// </summary>
        /// <value><c>true</c> if running on an interactive terminal; otherwise <c>false</c>.</value>
        bool IsTerminal { get; }

        /// <summary>
        /// Gets a value indicating whether or not the console supports interaction.
        /// </summary>
        bool Interactive { get; }

        /// <summary>
        /// Gets a value (<see cref="AutoDetect"/>) indicating whether Unicode output is fully supported.
        /// </summary>
        /// <value><c>true</c> if Unicode is supported; otherwise <c>false</c>.</value>
        AutoDetect SupportUnicode { get; }

        /// <summary>
        /// Gets a value (<see cref="AutoDetect"/>) indicating whether ANSI escape sequences are supported for styling/output.
        /// </summary>
        /// <value>The level of ANSI escape sequence support.</value>
        AutoDetect SupportsAnsi { get; }

        /// <summary>
        /// Gets the color depth (<see cref="ColorSystem"/>) of the console.
        /// </summary>

        ColorSystem ColorDepth { get; }        
        
        /// <summary>
        /// Gets a value indicating whether ANSI escape sequences are detected as supported in the current environment.
        /// </summary>
        bool DetectedAnsiSupport { get; internal set; }
        
        /// <summary>
        /// Gets a value indicating whether Unicode output is detected as supported in the current environment.
        /// </summary>
        bool DetectedUnicodeSupport { get; internal set; }
    }
}
