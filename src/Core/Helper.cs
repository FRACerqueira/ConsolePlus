// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Threading;

namespace ConsolePlusLibrary.Core
{
    internal static class Helper
    {
        /// <summary>
        /// Global cancellation token source for the entire library. This token is triggered on process exit or when the user presses Ctrl+C.
        /// </summary>
        public static CancellationTokenSource MainToken = new();

        /// <summary>
        /// Global exit code for the application. This can be set to a non-zero value to indicate an error condition when the process exits. The library will set this to a non-zero value if an unhandled exception occurs or if the user aborts the operation with Ctrl+C.
        /// </summary>
        public static int ExitCode;

        /// <summary>
        /// Global variable to store the last unhandled exception that occurred within. 
        /// </summary>
        public static Exception? LastException { get; set; }

    }
}
