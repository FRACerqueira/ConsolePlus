// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {
        /// <summary>
        /// Gets the underlying <see cref="IConsole"/> driver instance backing the static console facade.
        /// </summary>
        public static IConsole Driver => _consoledrive;

        /// <summary>
        /// Runs the specified action inside the console's global synchronization scope, ensuring that
        /// console output performed by the action is not interleaved with output from other threads.
        /// </summary>
        /// <param name="action">The action to run atomically with respect to console output.</param>
        public static void RunAtomic(Action action) => Envlock.Run(action);

        /// <summary>
        ///  Clear line
        /// </summary>
        /// <param name="row">The row to clear</param>
        /// <param name="style">Optional <see cref="Style"/> overriding current output style.</param>
        public static void ClearLine(int? row = null, Style? style = null)
        {
            _consoledrive.ClearLine(row, style);
        }

        /// <summary>
        /// Write lines with line terminator
        /// </summary>
        /// <param name="steps">Numbers de lines.</param>
        public static void WriteLines(int steps = 1)
        {
            _consoledrive.WriteLines(steps);
        }

        /// <summary>
        ///  Create context to write on standard error output stream for any output included until the 'dispose' is done.
        /// </summary>
        /// <returns>
        /// An <see cref="IDisposable"/> context that redirects output to the standard error stream when disposed.
        /// </returns>
        public static IDisposable OutputError()
        {
            return _consoledrive.OutputError();
        }



        /// <summary>
        /// Displays a dashed line with optional style above and/or below the text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="style">The style to apply.</param>
        /// <param name="dashOptions">The dash options to apply.</param>
        /// <param name="extralines">Extra blank lines appended after the dash line (default: 0).</param>
        /// <param name="applycolorbackground">If <c>true</c>, applies background color across the full line (default: <c>false</c>).</param>
        public static void Dash(string? text, Style? style = null, DashOptions dashOptions = DashOptions.SingleBorder, int extralines = 0, bool applycolorbackground = false)
        {
            _consoledrive.Dash(text, dashOptions, style, extralines, applycolorbackground);
        }

        /// <summary>
        /// Displays a banner with optional dashed borders and style.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="style">The style to apply.</param>
        /// <param name="dashOptions">The dash options to apply.</param>
        public static void Banner(string? text, Style? style = null, DashOptions dashOptions = DashOptions.None)
        {
            _consoledrive.Banner(text, style, dashOptions);
        }

        /// <summary>
        /// Displays a banner using the specified Figlet font, with optional dashed borders and style.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="pathfontFiglet">The path to the Figlet font file.</param>
        /// <param name="style">The style to apply.</param>
        /// <param name="dashOptions">The dash options to apply.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the path to the Figlet font is null or empty.
        /// </exception>
        public static void Banner(string? text, string pathfontFiglet, Style? style = null, DashOptions dashOptions = DashOptions.None)
        {
            _consoledrive.Banner(text, pathfontFiglet, style, dashOptions);
        }

        /// <summary>
        /// Displays a banner using the specified Figlet font, with optional dashed borders and style.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="streamFontFiglet">The stream to the Figlet font.</param>
        /// <param name="style">The style to apply.</param>
        /// <param name="dashOptions">The dash options to apply.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the stream to the Figlet font is null.
        /// </exception>
        public static void Banner(string? text, Stream streamFontFiglet, Style? style = null, DashOptions dashOptions = DashOptions.None)
        {
            _consoledrive.Banner(text, streamFontFiglet, style, dashOptions);
        }

        /// <summary>
        /// Reads a line of input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns the line of input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <remarks>
        /// the new line is not included in the result, but it is included in the console output. 
        /// If you want to read a line of input without including the new line in the console output, you can use the ReadInlineEmacs method instead.
        /// </remarks>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static string ReadLineEmacs(Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null)
        {
            return _consoledrive.ReadLineEmacs(acceptInput,caseOptions, maxlength, style ?? _consoledrive.CurrentStyle);
        }


        /// <summary>
        /// Reads input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static string ReadInlineEmacs(Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null)
        {
            return _consoledrive.ReadInlineEmacs(acceptInput, caseOptions, maxlength, style ?? _consoledrive.CurrentStyle);
        }


        /// <summary>
        /// Reads a line of input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns the line of input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <remarks>
        /// the new line is not included in the result, but it is included in the console output. 
        /// If you want to read a line of input without including the new line in the console output, you can use the ReadInlineEmacs method instead.
        /// </remarks>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static Task<string?> ReadLineEmacsAsync(Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null, CancellationToken cancellationToken = default)
        {
            return _consoledrive.ReadLineEmacsAsync(acceptInput, caseOptions, maxlength, style ?? _consoledrive.CurrentStyle, cancellationToken);   
        }

        /// <summary>
        /// Reads input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns the input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static Task<string?> ReadInlineEmacsAsync(Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null, CancellationToken cancellationToken = default)
        {
            return _consoledrive.ReadInlineEmacsAsync(acceptInput, caseOptions, maxlength, style ?? _consoledrive.CurrentStyle, cancellationToken);
        }

    }
}
