// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {


        /// <summary>
        /// Gets a value indicating whether input is redirected from a file.
        /// </summary>
        public static bool IsInputRedirected
        {
            get
            {
                return _consoledrive.IsInputRedirected;
            }
        }

        /// <summary>
        /// Sets the input source to the specified <see cref="TextReader"/>.
        /// </summary>
        /// <param name="value">The <see cref="TextReader"/> to set as the input source.</param>
        public static void SetIn(TextReader value)
        {
            _consoledrive.SetIn(value);
        }

        /// <summary>
        /// Gets <see cref="TextReader"/> used for input operations.
        /// </summary>
        public static TextReader In
        {
            get
            {
                return _consoledrive.In;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Encoding"/> used for input operations.
        /// </summary>
        public static Encoding InputEncoding
        {
            get
            {
                return _consoledrive.InputEncoding;
            }
            set
            {
                _consoledrive.InputEncoding = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a key press is available in the input stream.
        /// </summary>
        public static bool KeyAvailable
        {
            get
            {
                return _consoledrive.KeyAvailable;
            }
        }

        /// <summary>
        /// Reads the next character from the console.
        /// </summary>
        /// <returns>The next character read from the console, or -1 if no input is available.</returns>
        public static int Read()
        {
            return _consoledrive.Read();
        }

        /// <summary>
        /// Reads the next key press (<see cref="ConsoleKeyInfo"/>) from the console, optionally intercepting it so that it is not displayed on the console.
        /// </summary>
        /// <param name="intercept">If true, the key press is not displayed on the console.</param>
        /// <returns>The key press information.</returns>
        public static ConsoleKeyInfo ReadKey(bool intercept = false)
        {
            return _consoledrive.ReadKey(intercept);
        }

        /// <summary>
        /// Reads the next key press (<see cref="ConsoleKeyInfo"/>) from the console, optionally intercepting it so that it is not displayed on the console.
        /// </summary>
        /// <param name="intercept">If true, the key press is not displayed on the console.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
		/// <returns>The key press information.</returns>
        public static Task<ConsoleKeyInfo?> ReadKeyAsync(bool intercept, CancellationToken cancellationToken = default)
        {
            return _consoledrive.ReadKeyAsync(intercept, cancellationToken);
        }

        /// <summary>
        /// Reads a line of characters from the console.
        /// </summary>
        /// <returns>The line of characters read from the console, or null if no input is available.</returns>
        public static string? ReadLine()
        {
            return _consoledrive.ReadLine();
        }
    }
}
