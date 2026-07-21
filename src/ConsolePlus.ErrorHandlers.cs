// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.IO;

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {

        /// <summary>
        /// Gets a value indicating whether error output is redirected to a file.
        /// </summary>
        public static bool IsErrorRedirected
        {
            get
            {
                return _consoledrive.IsErrorRedirected;
            }
        }

        /// <summary>
        /// Sets the error output to the specified TextWriter.
        /// </summary>
        /// <param name="value">The TextWriter to set as the error output.</param>
        public static void SetError(TextWriter value)
        {
            _consoledrive.SetError(value);
        }

        /// <summary>
        /// Gets <see cref="TextWriter"/> used for error output operations.
        /// </summary>
        public static TextWriter Error
        {
            get
            {
                return _consoledrive.Error;
            }
        }
    }
}
