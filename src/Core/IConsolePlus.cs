// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.ConsoleAbstractions;

namespace ConsolePlusLibrary.Core
{
    /// <summary>
    /// Defines an interface for a console abstraction for internal use.
    /// </summary>
    internal interface IConsolePlus : IConsole
    {
        /// <summary>
        /// Gets or sets a value indicating whether to write output to the error stream instead of the standard output stream. When set to true, all output will be directed to the error stream, which can be useful for logging errors or separating error messages from regular output.
        /// </summary>
        bool WriteToErrorOutput { get; set; }
        
        /// <summary>
        /// Gets the console writer (<see cref="ConsoleWriter"/>) for this console, allowing for writing output to the console with support for styles and segments.
        /// </summary>
        ConsoleWriter Writer { get; }
    }
}
