// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {
        /// <summary>
        /// Gets a value indicating whether output is redirected to a file.
        /// </summary>
        public static bool IsOutputRedirected => _consoledrive.IsOutputRedirected;

        /// <summary>
        /// Sets the output destination to the specified <see cref="TextWriter"/>.
        /// </summary>
        /// <param name="value">The <see cref="TextWriter"/> to set as the output destination.</param>
        public static void SetOut(TextWriter value) => _consoledrive.SetOut(value);

        /// <summary>
        /// Gets <see cref="Encoding"/> used for output operations.
        /// </summary>
        public static Encoding OutputEncoding
        {
            get => _consoledrive.OutputEncoding;
            set => _consoledrive.OutputEncoding = value;
        }

        /// <summary>
        /// Gets <see cref="TextWriter"/> used for output operations.
        /// </summary>
        public static TextWriter Out => _consoledrive.Out;

        #region Write types to output

        /// <summary>
        /// Writes a character to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        public static void Write(char value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a character to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(char value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a character to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(char value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a character to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(char value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a character array to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        public static void Write(char[]? value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a character array to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(char[]? value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a character array to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(char[]? value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a character array to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(char[]? value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes an object to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        public static void Write(object value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes an object to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(object value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes an object to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(object value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes an object to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(object value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a boolean to the console.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        public static void Write(bool value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a boolean to the console.
        /// </summary>
        /// <param name="value">The boolean  value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(bool value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a boolean to the console.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(bool value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a boolean to the console.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(bool value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a double to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        public static void Write(double value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a double to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(double value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a double to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(double value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a double to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(double value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a float to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        public static void Write(float value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a float to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(float value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a float to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(float value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a float to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(float value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a decimal to the console.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        public static void Write(decimal value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a decimal to the console.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(decimal value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a decimal to the console.
        /// </summary>
        /// <param name="value">The decimal  value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(decimal value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a decimal to the console.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(decimal value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes an integer to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        public static void Write(int value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes an integer to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(int value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes an integer to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(int value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes an integer to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(int value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a long integer to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        public static void Write(long value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a long integer to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(long value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a long integer to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(long value, bool clearrestofline) =>
            _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes a long integer to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(long value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        /// <summary>
        /// Writes a string followed to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        public static void Write(string value) =>
        _consoledrive.Write(value);

        /// <summary>
        /// Writes a string followed to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void Write(string value, Style style) =>
        _consoledrive.Write(value, style);

        /// <summary>
        /// Writes a string followed to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        public static void Write(string value, bool clearrestofline) =>
        _consoledrive.Write(value, clearrestofline);

        /// <summary>
        /// Writes out a formatted string to the console.  Uses the same semantics as string.Format.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arg) =>
        _consoledrive.WriteFormat(format, arg);

        /// <summary>
        /// Writes out a formatted string to the console.  Uses the same semantics as string.Format.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, params object?[] arg) =>
        _consoledrive.WriteFormat(format, style, arg);

        /// <summary>
        /// Writes a string followed to the console.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, bool clearrestofline, params object?[] arg) =>
        _consoledrive.WriteFormat(format, clearrestofline, arg);

        /// <summary>
        /// Writes a string followed to the console.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, bool clearrestofline, params object?[] arg) =>
        _consoledrive.WriteFormat(format, style, clearrestofline, arg);

        #endregion

        /// <summary>
        /// Writes a string to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void Write(string value, Style style, bool clearrestofline) =>
        _consoledrive.Write(value, style, clearrestofline);

        #region WriteLine types to output

        /// <summary>
        /// Writes a line terminator to the console.
        /// </summary>
        public static void WriteLine() =>
        _consoledrive.WriteLine("",true);

        /// <summary>
        /// Writes a character followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        public static void WriteLine(char value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a character followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(char value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a character followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(char value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a character followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(char value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a character array followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        public static void WriteLine(char[]? value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a character array followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(char[]? value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a character array followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(char[]? value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a character array followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The character array value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(char[]? value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes an object followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        public static void WriteLine(object value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes an object followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(object value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes an object followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(object value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes an object followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The object value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(object value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        public static void WriteLine(bool value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The boolean  value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(bool value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(bool value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a boolean followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The boolean value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(bool value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a double followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        public static void WriteLine(double value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a double followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(double value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a double followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(double value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a double followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The double value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(double value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a float followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        public static void WriteLine(float value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a float followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(float value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a float followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(float value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a float followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The float value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(float value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a decimal followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        public static void WriteLine(decimal value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a decimal followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(decimal value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a decimal followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The decimal  value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(decimal value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a decimal followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(decimal value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        public static void WriteLine(int value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(int value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(int value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes an integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The integer value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(int value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a long integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        public static void WriteLine(long value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a long integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(long value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a long integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(long value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes a long integer followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The long value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>
        public static void WriteLine(long value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);

        /// <summary>
        /// Writes a string followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        public static void WriteLine(string value) =>
        _consoledrive.WriteLine(value);

        /// <summary>
        /// Writes a string followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        public static void WriteLine(string value, Style style) =>
        _consoledrive.WriteLine(value, style);

        /// <summary>
        /// Writes a string followed by a line terminator with optional style and line clearing to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        public static void WriteLine(string value, bool clearrestofline) =>
        _consoledrive.WriteLine(value, clearrestofline);

        /// <summary>
        /// Writes out a formatted string and a new line.  Uses the same semantics as string.Format.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arg) =>
        _consoledrive.WriteLineFormat(format, arg);

        /// <summary>
        /// Writes out a formatted string and a new line.  Uses the same semantics as string.Format.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, params object?[] arg) =>
        _consoledrive.WriteLineFormat(format, style, arg);

        /// <summary>
        /// Writes a string followed by a line terminator with optional style and line clearing to the console.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, bool clearrestofline, params object?[] arg) =>
        _consoledrive.WriteLineFormat(format, clearrestofline, arg);

        /// <summary>
        /// Writes a string followed by a line terminator with optional style and line clearing to the console.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        /// <param name="arg">An array of objects to format.</param>
        public static void WriteLineFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, Style style, bool clearrestofline, params object?[] arg) =>
        _consoledrive.WriteLineFormat(format, style, clearrestofline, arg);

        #endregion

        /// <summary>
        /// Writes a string followed by a line terminator to the console.
        /// </summary>
        /// <param name="value">The string value to write.</param>
        /// <param name="style">The style to apply to the output.</param>
        /// <param name="clearrestofline">If true, clears the rest of the line after writing.</param>   
        public static void WriteLine(string value, Style style, bool clearrestofline) =>
        _consoledrive.WriteLine(value, style, clearrestofline);
    }
}
