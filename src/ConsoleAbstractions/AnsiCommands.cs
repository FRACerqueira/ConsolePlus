// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.ConsoleAbstractions
{
    internal sealed class AnsiCommands(IConsolePlus output) : IAnsiCommands
    {
        private readonly IConsolePlus _output = output;

        /// <inheritdoc/>
        public void CursorPosition(int row, int column)
        {
            WriteCsi($"{row + 1};{column + 1}", 'H');
        }

        /// <inheritdoc/>
        public void CursorHome()
        {
            WriteCsi("H");
        }

        /// <inheritdoc/>
        public void CursorUp(int steps)
        {
            if (steps == 0)
            {
                return;
            }
            WriteCsi(steps, 'A');
        }

        /// <inheritdoc/>
        public void CursorDown(int steps)
        {
            if (steps == 0)
            {
                return;
            }

            WriteCsi(steps, 'B');
        }

        /// <inheritdoc/>
        public void CursorRight(int steps)
        {
            CursorForward(steps);
        }

        /// <inheritdoc/>
        public void CursorForward(int steps)
        {
            if (steps == 0)
            {
                return;
            }
            WriteCsi(steps, 'C');
        }

        /// <inheritdoc/>
        public void CursorLeft(int steps)
        {
            CursorBackward(steps);
        }

        /// <inheritdoc/>
        public void CursorBackward(int steps)
        {
            if (steps == 0)
            {
                return;
            }

            WriteCsi(steps, 'D');
        }

        /// <inheritdoc/>
        public void ShowCursor()
        {
            WriteCsi(25, 'h', decPrivateMode: true);
        }

        /// <inheritdoc/>
        public void HideCursor()
        {
            WriteCsi(25, 'l', decPrivateMode: true);
        }

        /// <inheritdoc/>
        public void SaveCursor(bool stayOnPage = true)
        {
            if (stayOnPage)
            {
                // SCOSC
                WriteCsi("s");
            }

            // DECSC
            WriteEsc("7");
        }

        /// <inheritdoc/>
        public void RestoreCursor(bool stayOnPage = true)
        {
            if (stayOnPage)
            {
                // SCORC
                WriteCsi("u");
            }

            // DECRC
            WriteEsc("8");
        }

        /// <inheritdoc/>
        public void CursorHorizontalAbsolute(int position)
        {
            WriteCsi(position, 'G');
        }

        /// <inheritdoc/>
        public void EnterAltScreen()
        {
            WriteCsi(1049, 'h', decPrivateMode: true);
        }

        /// <inheritdoc/>
        public void ExitAltScreen()
        {
            WriteCsi(1049, 'l', decPrivateMode: true);
        }

        /// <inheritdoc/>
        public void EraseInLine(int mode = 0)
        {
            WriteCsi(mode, 'K');
        }

        /// <inheritdoc/>
        public void EraseInDisplay(int mode = 0)
        {
            WriteCsi(mode, 'J');

        }

        /// <inheritdoc/>
        public void ClearScrollback()
        {
            EraseInDisplay(3);
        }

        /// <inheritdoc/>
        public void CursorBackwardTabulation(int tabs = 1)
        {
            if (tabs == 0)
            {
                return;
            }
            WriteCsi(tabs, 'Z');
        }

        /// <inheritdoc/>
        public void CursorHorizontalTabulation(int tabs = 1)
        {
            if (tabs == 0)
            {
                return;
            }
            WriteCsi(tabs, 'I');
        }

        /// <inheritdoc/>
        public void CursorNextLine(int lines = 1)
        {
            if (lines == 0)
            {
                return;
            }
            WriteCsi(lines, 'E');
        }

        /// <inheritdoc/>
        public void CursorPreviousLine(int lines = 1)
        {
            if (lines == 0)
            {
                return;
            }
            WriteCsi(lines, 'F');
        }

        /// <inheritdoc/>
        public void Index()
        {
            WriteEsc("D");
        }

        /// <inheritdoc/>
        public void ReverseIndex()
        {
            WriteEsc("M");
        }

        /// <inheritdoc/>
        public void DeleteCharacter(int characters = 1)
        {
            WriteCsi(characters, 'P');
        }

        /// <inheritdoc/>
        public void SetCursorStyle(int style = 0)
        {
            WriteCsi($"{style} ", 'q');
        }

        /// <inheritdoc/>
        public void DeleteLine(int lines = 0)
        {
            WriteCsi(lines, 'M');
        }

        /// <inheritdoc/>
        public void EraseCharacter(int characters = 1)
        {
            WriteCsi(characters, 'X');
        }

        /// <inheritdoc/>
        public void InsertCharacter(int characters = 1)
        {
            WriteCsi(characters, '@');
        }

        /// <inheritdoc/>
        public void InsertLine(int lines = 1)
        {
            WriteCsi(lines, 'L');
        }

        /// <inheritdoc/>
        public void ScrollUp(int lines = 1)
        {
            WriteCsi(lines, 'T');
        }

        /// <inheritdoc/>
        public void ScrollDown(int lines = 1)
        {
            WriteCsi(lines, 'S');
        }

        internal void WriteCsi(int value, char terminator, bool decPrivateMode = false)
        {
            WriteCsi($"{value}{terminator}", decPrivateMode);
        }

        internal void WriteCsi(string parameters, char terminator, bool decPrivateMode = false)
        {
            WriteCsi($"{parameters}{terminator}", decPrivateMode);
        }

        internal void WriteCsi(string parameters, bool decPrivateMode = false)
        {
            if (_output.WriteToErrorOutput)
            {
                _output.Error.Write(decPrivateMode ? $"\e[?{parameters}" : $"\e[{parameters}");
            }
            else
            {
                _output.Out.Write(decPrivateMode ? $"\e[?{parameters}" : $"\e[{parameters}");
            }
        }

        private void WriteEsc(string value)
        {
            if (_output.WriteToErrorOutput)
            {
                _output.Error.Write($"\e{value}");
            }
            else
            {
                _output.Out.Write($"\e{value}");
            }
        }
    }
}
