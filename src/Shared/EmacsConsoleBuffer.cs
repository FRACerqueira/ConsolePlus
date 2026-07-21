// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Globalization;
using System.Text;
#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents a buffer for console input that supports Emacs-style keyboard shortcuts and editing capabilities.
    /// </summary>
    /// <param name="isreadlonly">Indicates whether the buffer is read-only.</param>
    /// <param name="caseOption">Specifies the case transformation options for the input.</param>
    /// <param name="enableEmacsKeys">
    /// <param name="validate">A function to validate each input character.</param>
    /// When <c>true</c> (default) the Emacs letter shortcuts (Ctrl/Alt + letter, e.g. Ctrl+A, Ctrl+E,
    /// Ctrl+K, Alt+F, ...) are recognized. When <c>false</c> those shortcuts are ignored, which is useful
    /// on terminals that capture Ctrl/Alt combinations themselves (common on Linux). Dedicated physical
    /// keys (arrows, Home, End, Delete, Backspace, Insert) keep working regardless of this flag.
    /// </param>
    public sealed class EmacsConsoleBuffer(bool isreadlonly, CaseOptions caseOption, bool enableEmacsKeys, Func<char, bool>? validate = null)
    {
        private readonly StringBuilder _inputBuffer = new();
        private bool _overwritemode;
        private readonly bool _readonly = isreadlonly;
        private readonly CaseOptions _caseOption = caseOption;
        private readonly Func<char, bool>? _validate = validate;
        private readonly bool _enableEmacsKeys = enableEmacsKeys;

        // Inlined check replaces _nonRenderingCategories array + LINQ .Contains() — zero allocations.
        private static bool IsNonRenderingCategory(UnicodeCategory category) =>
            category == UnicodeCategory.Control ||
            category == UnicodeCategory.OtherNotAssigned ||
            category == UnicodeCategory.Surrogate;

        /// <summary>
        /// Gets the current cursor position within the buffer.
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// Gets the number of characters currently in the buffer.
        /// </summary>
        public int Length => _inputBuffer.Length;

        /// <summary>
        /// Processes a key press using Emacs-style editing semantics and updates the buffer accordingly.
        /// </summary>
        /// <param name="keyinfo">The key that was pressed.</param>
        /// <param name="maxlength">The maximum number of characters the buffer may hold.</param>
        /// <returns><c>true</c> when the key was accepted and handled; otherwise, <c>false</c>.</returns>
        public bool TryAcceptedReadlineConsoleKey(ConsoleKeyInfo keyinfo,int maxlength = int.MaxValue)
        {
            bool isvalid = false;

            //skip keys tab, enter.
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                return isvalid;
            }

            isvalid = true;

            if (!_readonly && IsPrintable(keyinfo) || keyinfo.Key == ConsoleKey.Tab)
            {
                char transformedChar = keyinfo.KeyChar;
                switch (_caseOption)
                {
                    case CaseOptions.Uppercase:
                        transformedChar = char.ToUpper(transformedChar,CultureInfo.CurrentCulture);
                        break;
                    case CaseOptions.Lowercase:
                        transformedChar = char.ToLower(transformedChar,CultureInfo.CurrentCulture);
                        break;
                }
                isvalid = _validate?.Invoke(transformedChar) ?? true;
                if (isvalid)
                {
                    if (_overwritemode)
                    {
                        Update(transformedChar);
                    }
                    else
                    {
                        if (Length < maxlength)
                        {
                            Insert(transformedChar);
                        }
                    }
                }
                return isvalid;
            }

            switch (keyinfo.Key)
            {
                //toggle input replacement mode.
                case ConsoleKey.Insert:
                    {
                        _overwritemode = !_overwritemode;
                    }
                    break;
                //Emacs keyboard shortcut when when have any text with length > 1
                //Transpose the previous two characters
                case ConsoleKey.T when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 1:
                    {
                        TransposeChars();
                    }
                    break;
                //Emacs keyboard shortcut, when when have any text
                // Clears the content
                case ConsoleKey.L when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                    {
                        Clear();
                    }
                    break;
                //Emacs keyboard shortcut when when have any text
                //Lowers the case of every character from the cursor's position to the end of the current word
                case ConsoleKey.L when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Alt && Length > 0:
                    LowerAfterCursor();
                    break;
                //Emacs keyboard shortcut when when have any text
                // Clears the line content before the cursor
                case ConsoleKey.U when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                    {
                        string aux = ToForward();
                        InternalClear();
                        InternalLoadPrintable(aux, maxlength);
                        Position = 0;
                    }
                    break;
                //Emacs keyboard shortcut  when when have any text
                //Upper the case of every character from the cursor's position to the end of the current word
                case ConsoleKey.U when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Alt && Length > 0:
                    UpperAfterCursor();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Clears the line content after the cursor
                case ConsoleKey.K when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                    {
                        string aux = ToBackward();
                        InternalClear();
                        InternalLoadPrintable(aux, maxlength);
                        Position = Length;
                    }
                    break;
                //Emacs keyboard shortcut when when have any text
                //Clear the word before the cursor
                case ConsoleKey.W when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                    RemoveWordBeforeCursor();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Capitalizes the character under the cursor and moves to the end of the word
                case ConsoleKey.C when _enableEmacsKeys && !_readonly && keyinfo.Modifiers != ConsoleModifiers.Alt && Length > 0:
                    UpperCharMoveEndWord();
                    break;
                //Emacs keyboard shortcut when when have any text
                // Clear the word after the cursor
                case ConsoleKey.D when _enableEmacsKeys && !_readonly &&keyinfo.Modifiers == ConsoleModifiers.Alt && Length > 0:
                    RemoveWordAfterCursor();
                    break;
                //Emacs keyboard shortcut when when have any text
                // Moves the cursor forward one word.
                case ConsoleKey.F when _enableEmacsKeys && keyinfo.Modifiers == ConsoleModifiers.Alt && Length > 0:
                    ForwardWord();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Moves the cursor backward one word.
                case ConsoleKey.B when _enableEmacsKeys && keyinfo.Modifiers == ConsoleModifiers.Alt && Length > 0:
                    BackwardWord();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Deletes the previous character (same as backspace).
                case ConsoleKey.H when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                case ConsoleKey.Backspace when !_readonly && keyinfo.Modifiers == 0 && Length > 0:
                    Backspace();
                    break;
                //Emacs keyboard shortcut when when have any text
                //(end) moves the cursor to the line end (equivalent to the key End).
                case ConsoleKey.E when _enableEmacsKeys && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                case ConsoleKey.End when keyinfo.Modifiers == 0 && Length > 0:
                    ToEnd();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Moves the cursor to the line start (equivalent to the key Home).
                case ConsoleKey.A when _enableEmacsKeys && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                case ConsoleKey.Home when keyinfo.Modifiers == 0 && Length > 0:
                    ToStart();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Moves the cursor back one character (equivalent to the key ←).
                case ConsoleKey.B when _enableEmacsKeys && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                case ConsoleKey.LeftArrow when keyinfo.Modifiers == 0 && Length > 0:
                    Backward();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Moves the cursor forward one character (equivalent to the key →).
                case ConsoleKey.F when _enableEmacsKeys && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                case ConsoleKey.RightArrow when keyinfo.Modifiers == 0 && Length > 0:
                    Forward();
                    break;
                //Emacs keyboard shortcut when when have any text
                //Delete the current character (then equivalent to the key Delete).
                case ConsoleKey.D when _enableEmacsKeys && !_readonly && keyinfo.Modifiers == ConsoleModifiers.Control && Length > 0:
                case ConsoleKey.Delete when !_readonly && keyinfo.Modifiers == 0 && Length > 0:
                    Delete();
                    break;
                default:
                    isvalid = false;
                    break;
            }
            return isvalid;
        }

        /// <summary>
        /// Replaces the buffer content with the printable characters from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The text to load, or <c>null</c> to leave the buffer unchanged.</param>
        /// <param name="maxlength">The maximum number of characters the buffer may hold.</param>
        /// <returns>The current <see cref="EmacsConsoleBuffer"/> instance, to allow chaining.</returns>
        public EmacsConsoleBuffer LoadPrintable(string? value, int maxlength = int.MaxValue)
        {
            if (value == null)
            {
                return this;
            }
            InternalClear();
            InternalLoadPrintable(value, maxlength);
            return this;
        }

        /// <summary>
        /// Clears all content from the buffer and resets the cursor position.
        /// </summary>
        /// <returns>The current <see cref="EmacsConsoleBuffer"/> instance, to allow chaining.</returns>
        public EmacsConsoleBuffer Clear()
        {
            InternalClear();
            return this;
        }

        /// <summary>
        /// Moves the cursor to the beginning of the buffer.
        /// </summary>
        public void ToHome()
        {
            ToStart();
        }

        /// <summary>
        /// Gets the buffer content from the beginning up to the current cursor position.
        /// </summary>
        /// <returns>The text before the cursor, or an empty string when the buffer is empty.</returns>
        public string ToBackward()
        {
            if (Length == 0)
            {
                return string.Empty;
            }
            return _inputBuffer.ToString(0, Position);
        }

        /// <summary>
        /// Gets the buffer content from the current cursor position to the end.
        /// </summary>
        /// <returns>The text from the cursor onward, or an empty string when the buffer is empty.</returns>
        public string ToForward()
        {
            if (Length == 0)
            {
                return string.Empty;
            }
            return _inputBuffer.ToString(Position, _inputBuffer.Length - Position);
        }

        /// <inheritdoc/>
        public override string ToString() => _inputBuffer.ToString();

        /// <summary>
        /// Determines whether the specified character is printable (renderable) in the console.
        /// </summary>
        /// <param name="c">The character to evaluate.</param>
        /// <returns><c>true</c> when the character is printable; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "ByDesign")]
        public bool IsPrintable(char c)
        {
            if (char.IsControl(c))
            {
                return false;
            }

            return char.IsWhiteSpace(c) ||
                !IsNonRenderingCategory(char.GetUnicodeCategory(c));
        }

        /// <summary>
        /// Determines whether the character produced by the specified key press is printable and
        /// not combined with a Control or Alt modifier.
        /// </summary>
        /// <param name="keyinfo">The key press to evaluate.</param>
        /// <returns><c>true</c> when the key produces a printable character; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "ByDesign")]
        public bool IsPrintable(ConsoleKeyInfo keyinfo)
        {
            char c = keyinfo.KeyChar;

            if (char.IsControl(c))
            {
                return false;
            }

            bool isPrintable = char.IsWhiteSpace(c) ||
                !IsNonRenderingCategory(char.GetUnicodeCategory(c));

            return isPrintable && !keyinfo.Modifiers.HasFlag(ConsoleModifiers.Control) && !keyinfo.Modifiers.HasFlag(ConsoleModifiers.Alt);
        }

        #region private

        private void InternalLoadPrintable(string value, int maxlength)
        {
            foreach (char item in value)
            {
                if (IsPrintable(item) && Length < maxlength)
                {
                    Insert(item);
                }
            }
        }

        private void InternalClear()
        {
            _inputBuffer.Clear();
            Position = 0;
        }

        private bool TransposeChars()
        {
            if (IsStart())
            {
                return false;
            }

            int firstIdx = Position - 1;
            int secondIdx = Position;

            if (IsEnd())
            {
                firstIdx--;
                secondIdx--;
            }

            (_inputBuffer[firstIdx], _inputBuffer[secondIdx]) = (_inputBuffer[secondIdx], _inputBuffer[firstIdx]);
            return true;
        }

        private EmacsConsoleBuffer ForwardWord()
        {
            bool foundSeparatorWord = false;
            while (!IsEnd())
            {
                if (_inputBuffer[Position] == ' ')
                {
                    foundSeparatorWord = true;
                }
                else if (foundSeparatorWord && _inputBuffer[Position] != ' ')
                {
                    break;
                }
                Position++;
            }
            return this;
        }

        private EmacsConsoleBuffer BackwardWord()
        {
            int foundSeparatorWord = 0;
            bool lastFoundNotSpace = false;
            while (!IsStart())
            {
                Position--;
                if (_inputBuffer[Position] == ' ')
                {
                    if (lastFoundNotSpace)
                    {
                        foundSeparatorWord++;
                    }
                }
                else
                {
                    lastFoundNotSpace = true;
                }
                if (foundSeparatorWord == 2)
                {
                    Position++;
                    break;
                }
            }
            return this;
        }

        private EmacsConsoleBuffer RemoveWordBeforeCursor()
        {
            if (IsEnd())
            {
                Position--;
            }
            bool firstSpace = !IsStart() && _inputBuffer[Position] == ' ';
            while (!IsStart())
            {
                if (_inputBuffer[Position] != ' ')
                {
                    firstSpace = false;
                    _inputBuffer.Remove(Position, 1);
                    Position--;
                }
                else
                {
                    if (!firstSpace)
                    {
                        Position++;
                        break;
                    }
                    else
                    {
                        _inputBuffer.Remove(Position, 1);
                        Position--;
                    }
                }
            }
            return this;
        }

        private EmacsConsoleBuffer UpperAfterCursor()
        {
            while (!IsEnd())
            {
                _inputBuffer[Position] = char.ToUpperInvariant(_inputBuffer[Position]);
                Position++;
                if (_inputBuffer[Position - 1] == ' ')
                {
                    break;
                }
            }
            return this;
        }

        private EmacsConsoleBuffer UpperCharMoveEndWord()
        {
            if (IsEnd())
            {
                return this;
            }
            bool firstSpace = _inputBuffer[Position] == ' ';
            if (firstSpace)
            {
                while (!IsEnd())
                {
                    if (_inputBuffer[Position] == ' ')
                    {
                        Position++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!IsEnd())
            {
                _inputBuffer[Position] = char.ToUpperInvariant(_inputBuffer[Position]);
                Position++;
            }
            while (!IsEnd())
            {
                if (_inputBuffer[Position] != ' ')
                {
                    Position++;
                }
                else
                {
                    break;
                }
            }
            return this;
        }

        private EmacsConsoleBuffer LowerAfterCursor()
        {
            while (!IsEnd())
            {
                _inputBuffer[Position] = char.ToLowerInvariant(_inputBuffer[Position]);
                Position++;
                if (_inputBuffer[Position - 1] == ' ')
                {
                    break;
                }
            }
            return this;
        }

        private EmacsConsoleBuffer RemoveWordAfterCursor()
        {
            if (IsEnd())
            {
                return this;
            }
            bool firstSpace = _inputBuffer[Position] == ' ';
            while (!IsEnd())
            {
                if (_inputBuffer[Position] != ' ')
                {
                    firstSpace = false;
                    _inputBuffer.Remove(Position, 1);
                }
                else
                {
                    if (!firstSpace)
                    {
                        break;
                    }
                    else
                    {
                        _inputBuffer.Remove(Position, 1);
                    }
                }
            }
            return this;
        }

        private bool IsStart() => Position == 0;

        private bool IsEnd() => Position >= _inputBuffer.Length;


        private EmacsConsoleBuffer ToEnd()
        {
            Position = _inputBuffer.Length;
            return this;
        }

        private EmacsConsoleBuffer ToStart()
        {
            Position = 0;
            return this;
        }

        private void Update(char value)
        {
            if (IsEnd())
            {
                Insert(value);
                return;
            }
            _inputBuffer[Position] = value;
            Position++;
        }

        private void Insert(char value)
        {
            if (IsEnd())
            {
                _inputBuffer.Append(value);
            }
            else
            {
                _inputBuffer.Insert(Position, value);
            }
            Position++;
        }

        private EmacsConsoleBuffer Backward()
        {
            if (!IsStart())
            {
                Position--;
            }
            return this;
        }

        private EmacsConsoleBuffer Forward()
        {
            if (!IsEnd())
            {
                Position++;
            }
            return this;
        }

        private EmacsConsoleBuffer Backspace()
        {
            if (!IsStart())
            {
                _inputBuffer.Remove(--Position, 1);
            }
            return this;
        }

        private EmacsConsoleBuffer Delete()
        {
            if (_inputBuffer.Length > 0 && !IsEnd())
            {
                _inputBuffer.Remove(Position, 1);
            }
            return this;
        }

        #endregion
    }

}
