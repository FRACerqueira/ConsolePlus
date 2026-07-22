// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
{ 
#pragma warning restore IDE0130 // Namespace does not match folder structure
    /// <summary>
    /// Interface for abstracting console operations.
    /// </summary>
    public interface IConsole 
    {

        /// <summary>
        /// Get a value indicating whether Emacs-style key bindings are enabled in the console. 
        /// When enabled, standard Emacs key combinations can be used for text editing and navigation.
        /// </summary>
        bool EnabledEmacs { get; set; }

        /// <summary>
        /// Gets the cancellation token (<see cref="CancellationToken"/>) that can be used to observe cancellation requests for console operations.
        /// </summary>
        CancellationToken CancelToken { get; }

        /// <summary>
        /// Gets the ANSI command emitter (<see cref="IAnsiCommands"/>) for this console, allowing for emitting ANSI escape sequences to control the console output.
        /// </summary>
        IAnsiCommands Ansi { get; }

        /// <summary>
        /// Gets the console profile (<see cref="IProfileReadOnly"/>) describing the capabilities and configuration of the current console/terminal environment.
        /// </summary>
        IProfileReadOnly Profile { get; }

        /// <summary>
        /// Gets the current width of the console window.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the current height of the console window.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets a value indicating whether the console supports ANSI escape sequences.
        /// </summary>
        bool SupportsAnsi { get; }

        /// <summary>
        /// Gets a value indicating whether the console supports Unicode characters.
        /// </summary>
        bool SupportsUnicode { get; }

        /// <summary>
        /// Gets or sets the foreground (<see cref="ConsoleColor"/>) color of the console.
        /// </summary>
        ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the console.
        /// </summary>
        ConsoleColor BackgroundColor { get; set; }
        
        /// <summary>
        /// Gets or sets the foreground color (<see cref="Color"/>) of the console using RGB values.
        /// </summary>  
        Color ForegroundRgbColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the console using RGB values.
        /// </summary>
        Color BackgroundRgbColor { get; set; }

        /// <summary>
        /// Gets the color depth (<see cref="ColorSystem"/>) of the console, indicating the number of colors supported.
        /// </summary>
        ColorSystem ColorDepth { get; }

        /// <summary>
        /// Event raised when the console size changes.
        /// </summary>
        event EventHandler<ConsoleSizeChangedEventArgs>? SizeChanged;

        /// <summary>
        /// Writes a character to the console.
        /// </summary>
        /// <param name="value">The character to write.</param>
        void Write(char value);

        /// <summary>
        /// Writes a character to the console with the specified style.
        /// </summary>
        /// <param name="value">The character to write.</param>
        /// <param name="style">The style to apply to the character.</param>
        void Write(char value, Style style);

        /// <summary>
        /// Writes a character to the console and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The character to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(char value, bool clearrestofline);

        /// <summary>
        /// Writes a character to the console with the specified style and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The character to write.</param>
        /// <param name="style">The style to apply to the character.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(char value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes an array of characters to the console.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        void Write(char[]? value);

        /// <summary>
        /// Writes an array of characters to the console with the specified style.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        /// <param name="style">The style to apply to the characters.</param>
        void Write(char[]? value, Style style);

        /// <summary>
        /// Writes an array of characters to the console and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(char[]? value, bool clearrestofline);

        /// <summary>
        /// Writes an array of characters to the console with the specified style and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        /// <param name="style">The style to apply to the characters.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(char[]? value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes an object to the console.
        /// </summary>
        /// <param name="value">The object to write.</param>
        void Write(object? value);

        /// <summary>
        /// Writes an object to the console with the specified style.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <param name="style">The style to apply to the object.</param>
        void Write(object? value, Style style);

        /// <summary>
        /// Writes an object to the console and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(object? value, bool clearrestofline);

        /// <summary>
        /// Writes an object to the console with the specified style and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <param name="style">The style to apply to the object.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(object? value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a boolean to the console.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        void Write(bool value);

        /// <summary>
        /// Writes a boolean to the console with the specified style.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        /// <param name="style">The style to apply to the boolean.</param>
        void Write(bool value, Style style);

        /// <summary>
        /// Writes a boolean to the console and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(bool value, bool clearrestofline);

        /// <summary>
        /// Writes a boolean to the console with the specified style and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        /// <param name="style">The style to apply to the boolean.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(bool value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a double to the console.
        /// </summary>
        /// <param name="value">The double to write.</param>
        void Write(double value);

        /// <summary>
        /// Writes a double to the console with the specified style.
        /// </summary>
        /// <param name="value">The double to write.</param>
        /// <param name="style">The style to apply to the double.</param>
        void Write(double value, Style style);

        /// <summary>
        /// Writes a double to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The double to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(double value, bool clearrestofline);

        /// <summary>
        /// Writes a double to the console with the specified style and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The double to write.</param>
        /// <param name="style">The style to apply to the double.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(double value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a float to the console.
        /// </summary>
        /// <param name="value">The float to write.</param>
        void Write(float value);

        /// <summary>
        /// Writes a float to the console with the specified style.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <param name="style">The style to apply to the float.</param>
        void Write(float value, Style style);

        /// <summary>
        /// Writes a float to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(float value, bool clearrestofline);

        /// <summary>
        /// Writes a float to the console with the specified style and clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <param name="style">The style to apply to the float.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(float value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a decimal to the console.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        void Write(decimal value);

        /// <summary>
        /// Writes a decimal to the console with the specified style.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        /// <param name="style">The style to apply to the decimal.</param>
        void Write(decimal value, Style style);

        /// <summary>
        /// Writes a decimal to the console and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(decimal value, bool clearrestofline);

        /// <summary>
        /// Writes a decimal to the console with the specified style and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        /// <param name="style">The style to apply to the decimal.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(decimal value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes an integer to the console.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        void Write(int value);

        /// <summary>
        /// Writes an integer to the console with the specified style.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        /// <param name="style">The style to apply to the integer.</param>
        void Write(int value, Style style);

        /// <summary>
        /// Writes an integer to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(int value, bool clearrestofline);

        /// <summary>
        /// Writes an integer to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        /// <param name="style">The style to apply to the integer.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(int value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a long integer to the console.
        /// </summary>
        /// <param name="value">The long integer to write.</param>
        void Write(long value);

        /// <summary>
        /// Writes a long integer to the console with the specified style.
        /// </summary>
        /// <param name="value">The long integer to write.</param>
        /// <param name="style">The style to apply to the long integer.</param>
        void Write(long value, Style style);

        /// <summary>
        /// Writes a long integer to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The long integer to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(long value, bool clearrestofline);

        /// <summary>
        /// Writes a long integer to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The long integer to write.</param>
        /// <param name="style">The style to apply to the long integer.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(long value, Style style, bool clearrestofline);


        /// <summary>
        /// Writes a string to the console.
        /// </summary>
        /// <param name="value">The string to write.</param>
        void Write(string? value);

        /// <summary>
        /// Writes a string to the console with the specified style.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="style">The style to apply to the string.</param>
        void Write(string? value, Style style);

        /// <summary>
        /// Writes a string to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(string? value, bool clearrestofline);

        /// <summary>
        /// Writes a string to the console with the specified style and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="style">The style to apply to the string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void Write(string? value, Style style, bool clearrestofline);


        /// <summary>
        /// Writes a string to the console as raw text (without markup parsing) using the specified style, optionally clearing the rest of the line after writing.
        /// </summary>
        /// <remarks>
        /// Unlike <see cref="Write(string?, Style, bool)"/>, markup tags such as <c>[red]</c> are not interpreted and are written verbatim. The clear-to-end-of-line request is honored even when <paramref name="value"/> is empty or a line break.
        /// </remarks>
        /// <param name="value">The string to write verbatim.</param>
        /// <param name="style">The style to apply to the string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteRaw(string? value, Style style, bool clearrestofline = false);


        /// <summary>
        /// Writes a formatted string , using the specified format and arguments.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arg);

        /// <summary>
        /// Writes a formatted string, using the specified format and arguments, with the specified style.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="style">The style to apply to the formatted string.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, params object?[] arg);

        /// <summary>
        /// Writes a formatted string, using the specified format and arguments, and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, bool clearrestofline, params object?[] arg);

        /// <summary>
        /// Writes a formatted string, using the specified format and arguments, with the specified style and clears the rest of the line after writing.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="style">The style to apply to the formatted string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, bool clearrestofline, params object?[] arg);

        /// <summary>
        /// Writes a line terminator to the console.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Writes a character followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character to write.</param>
        void WriteLine(char value);

        /// <summary>
        /// Writes a character followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The character to write.</param>
        /// <param name="style">The style to apply to the character.</param>
        void WriteLine(char value, Style style);

        /// <summary>
        /// Writes a character followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The character to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(char value, bool clearrestofline);

        /// <summary>
        /// Writes a character followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The character to write.</param>
        /// <param name="style">The style to apply to the character.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(char value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes an array of characters followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        void WriteLine(char[]? value);

        /// <summary>
        /// Writes an array of characters followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        /// <param name="style">The style to apply to the characters.</param>
        void WriteLine(char[]? value, Style style);

        /// <summary>
        /// Writes an array of characters followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(char[]? value, bool clearrestofline);

        /// <summary>
        /// Writes an array of characters followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The array of characters to write.</param>
        /// <param name="style">The style to apply to the characters.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(char[]? value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        void WriteLine(bool value);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        /// <param name="style">The style to apply to the boolean.</param>
        void WriteLine(bool value, Style style);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(bool value, bool clearrestofline);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The boolean to write.</param>
        /// <param name="style">The style to apply to the boolean.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(bool value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a double followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The double to write.</param>
        void WriteLine(double value);

        /// <summary>
        /// Writes a double followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The double to write.</param>
        /// <param name="style">The style to apply to the double.</param>
        void WriteLine(double value, Style style);

        /// <summary>
        /// Writes a double followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The double to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(double value, bool clearrestofline);

        /// <summary>
        /// Writes a double followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The double to write.</param>
        /// <param name="style">The style to apply to the double.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(double value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a float followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The float to write.</param>
        void WriteLine(float value);

        /// <summary>
        /// Writes a float followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <param name="style">The style to apply to the float.</param>
        void WriteLine(float value, Style style);

        /// <summary>
        /// Writes a float followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(float value, bool clearrestofline);

        /// <summary>
        /// Writes a float followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The float to write.</param>
        /// <param name="style">The style to apply to the float.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(float value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        void WriteLine(int value);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        /// <param name="style">The style to apply to the integer.</param>
        void WriteLine(int value, Style style);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(int value, bool clearrestofline);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The integer to write.</param>
        /// <param name="style">The style to apply to the integer.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(int value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a long followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The long to write.</param>
        void WriteLine(long value);

        /// <summary>
        /// Writes a long followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The long to write.</param>
        /// <param name="style">The style to apply to the long.</param>
        void WriteLine(long value, Style style);

        /// <summary>
        /// Writes a long followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The long to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(long value, bool clearrestofline);

        /// <summary>
        /// Writes a long followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The long to write.</param>
        /// <param name="style">The style to apply to the long.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(long value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes an object followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The object to write.</param>
        void WriteLine(object? value);

        /// <summary>
        /// Writes an object followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <param name="style">The style to apply to the object.</param>
        void WriteLine(object? value, Style style);

        /// <summary>
        /// Writes an object followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(object? value, bool clearrestofline);

        /// <summary>
        /// Writes an object followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <param name="style">The style to apply to the object.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(object? value, Style style, bool clearrestofline);


        /// <summary>
        /// Writes a string to the console with the specified style.
        /// </summary>
        /// <param name="value">The string to write.</param>
        void WriteLine(string? value);

        /// <summary>
        /// Writes a string to the console with the specified style.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="style">The style to apply to the string.</param>
        void WriteLine(string? value, Style style);

        /// <summary>
        /// Writes a string to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(string? value, bool clearrestofline);

        /// <summary>
        /// Writes a string to the console with the specified style and  clears the rest of the line after writing.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="style">The style to apply to the string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        void WriteLine(string? value, Style style, bool clearrestofline);

        /// <summary>
        /// Writes a formatted string followed by a line terminator to the console, using the specified format and arguments.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="arg"></param>
        void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arg);

        /// <summary>
        /// Writes a formatted string followed by a line terminator to the console with the specified style.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="style">The style to apply to the formatted string.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, params object?[] arg);

        /// <summary>
        /// Writes a formatted string followed by a line terminator to the console and optionally clears the rest of the line after writing.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, bool clearrestofline, params object?[] arg);

        /// <summary>
        /// Writes a formatted string followed by a line terminator to the console with the specified style and clears the rest of the line after writing.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="style">The style to apply to the formatted string.</param>
        /// <param name="clearrestofline">Whether to clear the rest of the line after writing.</param>
        /// <param name="arg">An array of objects to format.</param>
        void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, bool clearrestofline, params object?[] arg);

        /// <summary>
        /// Clears the console buffer and corresponding console window of display information.
        /// </summary>
        /// <param name="backgroundcolor">The background color to use when clearing the console.</param>
        void Clear(Color? backgroundcolor = null);

        /// <summary>
        /// Gets the current style (<see cref="Style"/>) of the console.
        /// </summary>
        Style CurrentStyle { get; }

        /// <summary>
        /// Sets the position of the cursor.
        /// </summary>
        /// <param name="left">The column position of the cursor.</param>
        /// <param name="top">The row position of the cursor.</param>
        void SetCursorPosition(int left, int top);

        /// <summary>
        /// Gets or sets the column position of the cursor.
        /// </summary>
        int CursorLeft { get; set; }

        /// <summary>
        /// Gets or sets the row position of the cursor.
        /// </summary>
        int CursorTop { get; set; }

        /// <summary>
        /// Gets the current position of the cursor as a tuple containing the left and top coordinates.
        /// </summary>
        /// <returns>A tuple containing the left and top coordinates of the cursor.</returns>
        (int Left, int Top) GetCursorPosition();

        /// <summary>
        /// Gets or sets a value indicating whether the cursor is visible.
        /// </summary>
        bool CursorVisible { get; set; }

        /// <summary>
        /// Hides the cursor.
        /// </summary>
        /// <returns>True if the cursor was successfully hidden; otherwise, false.</returns>
        bool HideCursor();

        /// <summary>
        /// Shows the cursor.
        /// </summary>
        /// <returns>True if the cursor was successfully shown; otherwise, false.</returns>
        bool ShowCursor();

        /// <summary>
        /// Reads a line of characters from the console.
        /// </summary>
        /// <returns>The line of characters read from the console, or null if no input is available.</returns>
        string? ReadLine();

        /// <summary>
        /// Reads the next character from the console.
        /// </summary>
        /// <returns>The next character read from the console, or -1 if no input is available.</returns>
        int Read();

        /// <summary>
        /// Reads the next key press (<see cref="ConsoleKeyInfo"/>) from the console, optionally intercepting it so that it is not displayed on the console.
        /// </summary>
        /// <param name="intercept">If true, the key press is not displayed on the console.</param>
        /// <returns>The key press information.</returns>
        ConsoleKeyInfo ReadKey(bool intercept = false);

        /// <summary>
        /// Asynchronously reads the next key press (<see cref="ConsoleKeyInfo"/>) from the console, optionally intercepting it so it is not displayed on the console.
        /// </summary>
        /// <param name="intercept">If true, the key press is not displayed on the console.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>The key press information.</returns>
        Task<ConsoleKeyInfo?> ReadKeyAsync(bool intercept, CancellationToken cancellationToken);

        /// <summary>
        /// Resets the console colors to default.
        /// </summary>
        void ResetColor();

        /// <summary>
        /// Beeps the console speaker.
        /// </summary>
        void Beep();

        /// <summary>
        /// Gets a value indicating whether input is redirected from a file.
        /// </summary>
        bool IsInputRedirected { get; }

        /// <summary>
        /// Gets a value indicating whether output is redirected to a file.
        /// </summary>
        bool IsOutputRedirected { get; }

        /// <summary>
        /// Gets a value indicating whether error output is redirected to a file.
        /// </summary>
        bool IsErrorRedirected { get; }

        /// <summary>
        /// Sets the error output to the specified TextWriter.
        /// </summary>
        /// <param name="value">The TextWriter to set as the error output.</param>
        void SetError(TextWriter value);

        /// <summary>
        /// Sets the input source to the specified TextReader.
        /// </summary>
        /// <param name="value">The TextReader to set as the input source.</param>
        void SetIn(TextReader value);

        /// <summary>
        /// Sets the output destination to the specified TextWriter.
        /// </summary>
        /// <param name="value">The TextWriter to set as the output destination.</param>
        void SetOut(TextWriter value);

        /// <summary>
        /// Gets a value indicating whether a key press is available in the input stream.
        /// </summary>
        bool KeyAvailable { get; }

        /// <summary>
        /// Gets or sets the encoding (<see cref="Encoding"/>) used for input operations.
        /// </summary>
        Encoding InputEncoding { get; set; }

        /// <summary>
        /// Gets encoding (<see cref="Encoding"/>) used for output operations.
        /// </summary>
        Encoding OutputEncoding { get; set; }

        /// <summary>
        /// Gets TextReader (<see cref="TextReader"/>) used for input operations.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "By design, matches Console.In")]
        TextReader In { get; }

        /// <summary>
        /// Gets TextWriter (<see cref="TextWriter"/>) used for output operations.
        /// </summary>
        TextWriter Out { get; }

        /// <summary>
        /// Gets TextWriter (<see cref="TextWriter"/>) used for error output operations.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "By design, matches Console.In")]
        TextWriter Error { get; }

        /// <summary>
        /// Gets the current target buffer (<see cref="TargetScreen"/>) : primary or secondary of the console.
        /// </summary>
        TargetScreen CurrentBuffer { get; }

        /// <summary>
        /// Swaps the active console buffer to the specified target screen (primary or secondary).
        /// </summary>
        /// <param name="value">The target screen to switch to.</param>
        /// <returns>True if the buffer was successfully swapped; otherwise, false.</returns>
        bool SwapBuffer(TargetScreen value);


    }
}
