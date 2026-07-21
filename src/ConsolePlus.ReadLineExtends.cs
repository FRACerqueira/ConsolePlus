// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePlusLibrary
{
    /// <summary>
    /// Extension methods for ConsolePlus, providing additional functionality to the IConsole interface.
    /// </summary>
    public static partial class ConsolePlusExtends
    {
        /// <summary>
        /// Reads a line of input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns the line of input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <remarks>
        /// the new line is not included in the result, but it is included in the console output. 
        /// If you want to read a line of input without including the new line in the console output, you can use the <see cref="ReadInlineEmacs"/> method instead.
        /// </remarks>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static string ReadLineEmacs(this IConsole console, Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null)
        {
            return ConsolePlus.Envlock.RunAsync(async () =>
            {
                var result = await InputEmacsAsync(console, ConsolePlus.EnabledEmacs, false, caseOptions, maxlength, style ?? console.CurrentStyle, acceptInput, default);
                if (result != null)
                {
                    console.WriteLine();
                }
                return result!;
            }).Result!;
        }

        /// <summary>
        /// Reads input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static string ReadInlineEmacs(this IConsole console, Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null)
        {
            return ConsolePlus.Envlock.RunAsync(
                () => InputEmacsAsync(console, ConsolePlus.EnabledEmacs, false, caseOptions, maxlength, style ?? console.CurrentStyle, acceptInput, default)
            ).Result!;
        }

        /// <summary>
        /// Reads a line of input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns the line of input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <remarks>
        /// the new line is not included in the result, but it is included in the console output. 
        /// If you want to read a line of input without including the new line in the console output, you can use the <see cref="ReadInlineEmacsAsync"/> method instead.
        /// </remarks>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static Task<string?> ReadLineEmacsAsync(this IConsole console, Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null, CancellationToken cancellationToken = default)
        {
            return ConsolePlus.Envlock.RunAsync(async () =>
            {
                var result = await InputEmacsAsync(console, ConsolePlus.EnabledEmacs, false, caseOptions, maxlength, style ?? console.CurrentStyle, acceptInput, cancellationToken);
                if (result != null)
                {
                    console.WriteLine();
                }
                return result;
            });
        }

        /// <summary>
        /// Reads input from the console using Emacs-style key bindings, allowing for more efficient and familiar text editing capabilities. 
        /// This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
        /// enabling them to navigate and edit their input more effectively. 
        /// The method returns the input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="caseOptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">Specifies the maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <param name="acceptInput">A function to determine whether a character is accepted as input.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The line of input entered by the user as a string.</returns>
        public static Task<string?> ReadInlineEmacsAsync(this IConsole console, Func<char, bool>? acceptInput = null, CaseOptions caseOptions = CaseOptions.Any, int maxlength = int.MaxValue, Style? style = null, CancellationToken cancellationToken = default)
        {
            return ConsolePlus.Envlock.RunAsync(
                () => InputEmacsAsync(console, ConsolePlus.EnabledEmacs, false, caseOptions, maxlength, style ?? console.CurrentStyle, acceptInput, cancellationToken)
            );
        }


        /// <summary>
        /// Asynchronously reads a line of input from the console using Emacs-style key bindings, 
        /// allowing for customizable input behavior and cancellation support.
        /// The method returns the input entered by the user as a string after the Enter key is pressed.
        /// </summary>
        /// <param name="console">The console instance to read input from.</param>
        /// <param name="enabledemacs">Indicates whether Emacs-style key bindings are enabled.</param>
        /// <param name="isreadonly">Indicates whether the input is read-only.</param>
        /// <param name="caseoptions">Specifies the case options for the input.</param>
        /// <param name="maxlength">The maximum length of the input.</param>
        /// <param name="style">The style to apply to the input.</param>
        /// <param name="acceptInput">An optional function to determine whether a character is accepted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous read operation. The task result contains the input string, or null if canceled.
        /// </returns>
        /// <remarks>
        /// The new line is not included in the result. 
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the maximum length is less than or equal to zero.</exception>
        private static async Task<string?> InputEmacsAsync(IConsole console,bool enabledemacs, bool isreadonly, CaseOptions caseoptions, int maxlength, Style style, Func<char, bool>? acceptInput = null, CancellationToken cancellationToken = default)
        {
            using var localcts = CancellationTokenSource.CreateLinkedTokenSource(Helper.MainToken.Token, cancellationToken);
            var writer = ((IConsolePlus)console).Writer;
            if (maxlength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxlength), "Maximum length must be greater than zero.");
            }
            bool oldcurvisible = console.CursorVisible;
            console.CursorVisible = false;
            EmacsConsoleBuffer inputBuffer = new(isreadonly, caseoptions, enabledemacs, acceptInput);
            bool endinput = false;
            try
            {

                (int initleft, int inittop) = console.GetCursorPosition();
                do
                {
                    console.CursorVisible = true;
                    var keyInfo = await console.ReadKeyAsync(true, localcts.Token);
                    if (localcts.Token.IsCancellationRequested)
                    {
                        console.SetCursorPosition(initleft, inittop);
                        return null;
                    }
                    console.CursorVisible = false;
                    // Capture .Value once — avoids double nullable struct dereference
                    ConsoleKeyInfo key = keyInfo!.Value;
                    var oldlength = inputBuffer.Length;
                    if (!inputBuffer.TryAcceptedReadlineConsoleKey(key, maxlength))
                    {
                        if (key.Key == ConsoleKey.Enter && key.Modifiers == ConsoleModifiers.None)
                        {
                            endinput = true;
                            continue;
                        }
                    }
                    console.SetCursorPosition(initleft, inittop);
                    if (oldlength > inputBuffer.Length)
                    {
                        writer.WriteOutput(new string(' ', oldlength), console.CurrentStyle, false);
                        console.SetCursorPosition(initleft, inittop);
                    }
                    writer.WriteOutput(inputBuffer.ToBackward(), style, false);
                    var (Left, Top) = console.GetCursorPosition();
                    writer.WriteOutput(inputBuffer.ToForward(), style, false);
                    console.SetCursorPosition(Left, Top);

                } while (!endinput);
                if (inputBuffer.Length == 0)
                {
                    return string.Empty;
                }
                return inputBuffer.ToString();
            }
            catch (OperationCanceledException)
            {
                // swallow the exception and return null to indicate cancellation
                return null;
            }
            finally
            {
                console.CursorVisible = oldcurvisible;
            }
        }
    }
}
