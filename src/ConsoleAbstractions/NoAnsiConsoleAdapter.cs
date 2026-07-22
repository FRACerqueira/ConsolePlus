// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePlusLibrary.ConsoleAbstractions
{
    /// <summary>
    /// Cross-platform implementation of the IConsole interface for environments that do not support ANSI escape sequences natively, 
    /// such as the Windows Console before Windows 10. 
    /// </summary>
    internal sealed class NoAnsiConsoleAdapter : IConsole, IConsolePlus, IDisposable
    {
        private int _lastWidth;
        private int _lastHeight;
        private CancellationTokenSource? _sizeMonitorCts;
        private Task? _sizeMonitorTask;
        private Color _consoleForegroundColor;
        private Color _consoleBackgroundColor;
        private bool _cursorVisible;
        private readonly IProfileReadOnly _profile;
        private readonly ConsoleWriter _writer;
        private bool _writeToErrorOutput;
        private bool _disposed;
        private readonly ILock _lock;
        private readonly CancellationToken _mainToken;
        private bool _enabledEmacs;


        /// <inheritdoc/>
        public event EventHandler<ConsoleSizeChangedEventArgs>? SizeChanged;

        /// <inheritdoc/>
        public bool EnabledEmacs
        {
            get
            {
                return _lock.Run(() =>
                {
                    return _enabledEmacs;
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    _enabledEmacs = value;
                });
            }
        }

        /// <inheritdoc/>
        public NoAnsiConsoleAdapter(IProfileReadOnly profile, ILock lockenv, CancellationToken mainToken)
        {
            _lock = lockenv;
            _profile = profile;
            _writer = new ConsoleWriter(this);
            _mainToken = mainToken;
            _lock.Run(() =>
            {
                // Change the output and input code page to 65001 (UTF-8)
                System.Console.OutputEncoding = Encoding.UTF8;
                System.Console.InputEncoding = Encoding.UTF8;

                _lastWidth = EnvironmentUtil.GetSafeWidth();
                _lastHeight = EnvironmentUtil.GetSafeHeight();
                _consoleForegroundColor = _profile.DefaultForegroundColor;
                _consoleBackgroundColor = _profile.DefaultBackgroundColor;
                // Start monitoring console size changes
                StartSizeMonitoring();
                // Ensure cursor is visible by default
                ShowCursor(); 
            });
        }

        /// <inheritdoc/>
        public CancellationToken CancelToken => _mainToken;


        /// <inheritdoc/>
        public IProfileReadOnly Profile
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return _profile;
                });
            }
        }


        /// <inheritdoc/>
        public bool WriteToErrorOutput
        {
            get
            {
                return _lock.Run(() =>
                {
                    return _writeToErrorOutput;
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    _writeToErrorOutput = value;
                });
            }
        }

        /// <inheritdoc/>
        public ConsoleWriter Writer
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return _writer;
                });
            }
        }

        /// <inheritdoc/>
        public IAnsiCommands Ansi
        {
            get
            {
                ThrowIfDisposed();
                throw new NotImplementedException("ANSI commands are not supported in this console adapter.");
            }
        }

        /// <inheritdoc/>
        public TargetScreen CurrentBuffer => TargetScreen.Primary;


        /// <inheritdoc/>
        public Style CurrentStyle
        {
            get
            {
                return _lock.Run(() =>
                {
                    return new Style(_consoleForegroundColor, _consoleBackgroundColor);
                });
            }
        }

        /// <inheritdoc/>
        public int Width
        {
            get
            {
                return _lock.Run(() =>
                {
                    return EnvironmentUtil.GetSafeWidth();
                });
            }
        }

        /// <inheritdoc/>
        public int Height
        {
            get
            {
                return _lock.Run(() =>
                {
                    return EnvironmentUtil.GetSafeHeight();
                });
            }
        }

        /// <inheritdoc/>
        public bool SupportsAnsi => false;


        /// <inheritdoc/>
        public bool SwapBuffer(TargetScreen value) => false;

        /// <inheritdoc/>
        public bool SupportsUnicode
        {
            get
            {
                return _lock.Run(() =>
                {
                    return _profile.DetectedUnicodeSupport || _profile.SupportUnicode == AutoDetect.Yes;
                });
            }
        }

        /// <inheritdoc/>
        public ConsoleColor ForegroundColor
        {
            get
            {
                return _lock.Run(() =>
                {
                    return Color.ToConsoleColor(_consoleForegroundColor);
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    if (_profile.ColorDepth == ColorSystem.NoColors)
                    {
                        return; // No color support, ignore changes
                    }
                    _consoleForegroundColor = value;
                    System.Console.ForegroundColor = value;
                });
            }
        }

        /// <inheritdoc/>
        public Color ForegroundRgbColor
        {
            get
            {
                return _lock.Run(() =>
                {
                    return _consoleForegroundColor;
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    if (_profile.ColorDepth == ColorSystem.NoColors)
                    {
                        return; // No color support, ignore changes
                    }
                    _consoleForegroundColor = value;
                    System.Console.ForegroundColor = value;
                });
            }
        }

        /// <inheritdoc/>
        public ConsoleColor BackgroundColor
        {
            get
            {
                return _lock.Run(() =>
                {
                    return Color.ToConsoleColor(_consoleBackgroundColor);
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    if (_profile.ColorDepth == ColorSystem.NoColors)
                    {
                        return; // No color support, ignore changes
                    }
                    _consoleBackgroundColor = value;
                    System.Console.BackgroundColor = value;
                });
            }
        }

        /// <inheritdoc/>
        public Color BackgroundRgbColor
        {
            get
            {
                return _lock.Run(() =>
                {
                    return _consoleBackgroundColor;
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    if (_profile.ColorDepth == ColorSystem.NoColors)
                    {
                        return; // No color support, ignore changes
                    }
                    _consoleBackgroundColor = value;
                    System.Console.BackgroundColor = value;
                });
            }
        }

        /// <inheritdoc/>
        public ColorSystem ColorDepth
        {
            get
            {
                return _lock.Run(() =>
                {
                    return _profile.ColorDepth;
                });
            }
        }

        /// <inheritdoc/>
        public bool IsInputRedirected => System.Console.IsInputRedirected;

        /// <inheritdoc/>
        public bool IsOutputRedirected => System.Console.IsOutputRedirected;

        /// <inheritdoc/>
        public bool IsErrorRedirected => System.Console.IsErrorRedirected;

        /// <inheritdoc/>
        public void Write(string? value, Style style , bool clearrestofline = false)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                if (value == null)
                {
                    return;
                }
                _writer.WriteMarkupOutput(value, style, clearrestofline);
            });
        }

        /// <inheritdoc/>
        public void WriteRaw(string? value, Style style, bool clearrestofline = false)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                if (value == null)
                {
                    return;
                }
                _writer.WriteOutput(value, style, clearrestofline);
            });
        }

        /// <inheritdoc/>
        public void WriteLine(string? value , Style style, bool clearrestofline = false)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                if (value == null)
                {
                    return;
                }
                Write(value, style, clearrestofline);
                _writer.WriteMarkupOutput(Environment.NewLine, style, false);
            });
        }

        /// <inheritdoc/>
        public void Write(char value)
        {
            ThrowIfDisposed();
            Write(value.ToString(), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(char value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(), style, false);
        }

        /// <inheritdoc/>
        public void Write(char value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(char value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(char[]? value)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(new string(value), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(char[]? value, Style style)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(new string(value), style, false);
        }

        /// <inheritdoc/>
        public void Write(char[]? value, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(new string(value), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(char[]? value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(new string(value), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(object? value)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value.ToString(), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(object? value, Style style)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value.ToString(), style, false);
        }

        /// <inheritdoc/>
        public void Write(object? value, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value.ToString(), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(object? value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value.ToString(), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(bool value)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(bool value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void Write(bool value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(bool value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline );
        }

        /// <inheritdoc/>
        public void Write(double value)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(double value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void Write(double value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(double value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(float value)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(float value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void Write(float value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(float value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(decimal value)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(decimal value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void Write(decimal value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(decimal value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(int value)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(int value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void Write(int value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(int value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(long value)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(long value, Style style)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void Write(long value, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void Write(long value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            Write(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }


        /// <inheritdoc/>
        public void WriteLine()
        {
            ThrowIfDisposed();
            WriteLine("", CurrentStyle, true);
        }

        /// <inheritdoc/>
        public void WriteLine(char value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(char value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(), style, false);
        }

        /// <inheritdoc/>
        public void WriteLine(char value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(char value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(char[]? value)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(new string(value), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(char[]? value, Style style)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(new string(value), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(char[]? value, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(new string(value), CurrentStyle, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(char[]? value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(new string(value), style, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(bool value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(bool value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, false);
        }

        /// <inheritdoc/>
        public void WriteLine(bool value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(bool value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(double value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(double value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(double value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(double value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(float value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);

        }

        /// <inheritdoc/>
        public void WriteLine(float value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(float value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(float value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(decimal value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);

        }

        /// <inheritdoc/>
        public void WriteLine(decimal value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(decimal value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(decimal value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(int value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(int value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(int value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(int value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(long value)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(long value, Style style)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(long value, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), CurrentStyle, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(long value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            WriteLine(value.ToString(System.Console.Out.FormatProvider), style, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(object? value)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value.ToString(), CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(object? value, Style style)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value.ToString(), style, false);

        }

        /// <inheritdoc/>
        public void WriteLine(object? value, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value.ToString(), CurrentStyle, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteLine(object? value, Style style, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value.ToString(), style, clearrestofline);

        }

        /// <inheritdoc/>
        public void WriteFormat(string format, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            Write(formattedString, CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteFormat(string format, Style style, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            Write(formattedString, style, false);
        }

        /// <inheritdoc/>
        public void WriteFormat(string format, bool clearrestofline, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            Write(formattedString, CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteFormat(string format, Style style, bool clearrestofline, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            Write(formattedString, style, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLineFormat(string format, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            WriteLine(formattedString, CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLineFormat(string format, Style style, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            WriteLine(formattedString, style, false);
        }

        /// <inheritdoc/>
        public void WriteLineFormat(string format, bool clearrestofline, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            WriteLine(formattedString, CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLineFormat(string format, Style style, bool clearrestofline, params object?[] arg)
        {
            ThrowIfDisposed();
            string? formattedString = string.Format(Out.FormatProvider, format, arg);
            WriteLine(formattedString, style, clearrestofline);
        }

        /// <inheritdoc/>
        public void Clear(Color? backcolor = null)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                if (backcolor.HasValue)
                {
                    BackgroundRgbColor = backcolor.Value;
                }
                Clear();
            });
        }
        private static void Clear()
        {
            System.Console.Clear();
        }


        /// <inheritdoc/>
        public void SetCursorPosition(int left, int top)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                System.Console.SetCursorPosition(left, top);
            });
        }

        /// <inheritdoc/>
        public int CursorLeft
        {
            get { return _lock.Run(() => EnvironmentUtil.GetSafeLeftCursor()); }
            set { _lock.Run(() => System.Console.SetCursorPosition(value, CursorTop)); }
        }

        /// <inheritdoc/>
        public int CursorTop
        {
            get { return _lock.Run(() => EnvironmentUtil.GetSafeTopCursor()); }
            set { _lock.Run(() => System.Console.SetCursorPosition(CursorLeft, value)); }
        }

        /// <inheritdoc/>
        public (int Left, int Top) GetCursorPosition()
        {
            return _lock.Run(() =>
            {
                ThrowIfDisposed();
                return (EnvironmentUtil.GetSafeLeftCursor(), EnvironmentUtil.GetSafeTopCursor());
            });
        }

        /// <inheritdoc/>
        public bool CursorVisible
        {
            get { return _lock.Run(() => _cursorVisible); }
            set
            {
                if (value)
                {
                    ShowCursor();
                }
                else
                {
                    HideCursor();
                }
            }
        }

        /// <inheritdoc/>
        public bool HideCursor()
        {
            return _lock.Run(() =>
            {
                ThrowIfDisposed();
                try
                {
                    System.Console.CursorVisible = false;
                }
                finally
                {
                    _cursorVisible = false;
                }
                return _cursorVisible;
            });
        }

        /// <inheritdoc/>
        public bool ShowCursor()
        {
            return _lock.Run(() =>
            {
                ThrowIfDisposed();
                try
                {
                    System.Console.CursorVisible = true;
                }
                catch (PlatformNotSupportedException)
                {
                    // Ignore if the platform doesn't support this operation
                }
                finally
                {
                    _cursorVisible = true;
                }
                return _cursorVisible;
            });
        }

        /// <inheritdoc/>
        public string? ReadLine()
        {
            if (!_profile.Interactive)
            {
                throw new InvalidOperationException("Console is not interactive.");
            }
            return _lock.Run(() =>
            {
                ThrowIfDisposed();
                return System.Console.ReadLine();
            });
        }

        /// <inheritdoc/>
        public int Read()
        {
            if (!_profile.Interactive)
            {
                throw new InvalidOperationException("Console is not interactive.");
            }
            return _lock.Run(() =>
            {
                ThrowIfDisposed();
                return System.Console.Read();
            });
        }

        /// <inheritdoc/>
        public ConsoleKeyInfo ReadKey(bool intercept = false)
        {
            return ReadKeyAsync(intercept, CancellationToken.None).GetAwaiter().GetResult()!.Value;
        }

        /// <inheritdoc/>
        public async Task<ConsoleKeyInfo?> ReadKeyAsync(bool intercept, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            if (!_profile.Interactive)
            {
                throw new InvalidOperationException("Console is not interactive.");
            }
            return await _lock.RunAsync<ConsoleKeyInfo?>(async () =>
            {
                using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _mainToken);
                while (true)
                {

                    if (!System.Console.KeyAvailable)
                    {
                        try
                        {
                            await Task.Delay(16, linkedCts.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            return null;
                        }
                        continue;
                    }
                    ConsoleKeyInfo candidate = System.Console.ReadKey(intercept);
                    if (candidate.Key != 0 || candidate.KeyChar != '\0')
                    {
                        return candidate;
                    }
                }
            });
        }


        /// <inheritdoc/>
        public void ResetColor()
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                System.Console.ResetColor();
            });
        }

        /// <inheritdoc/>
        public void Beep()
        {
            ThrowIfDisposed();
            try
            {
                System.Console.Beep();
            }
            catch
            {
                // Ignore if the platform doesn't support this operation
            }
        }

        /// <inheritdoc/>
        public void SetError(TextWriter value)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                System.Console.SetError(value);
            });
        }

        /// <inheritdoc/>
        public void SetIn(TextReader value)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                System.Console.SetIn(value);
            });
        }

        /// <inheritdoc/>
        public void SetOut(TextWriter value)
        {
            _lock.Run(() =>
            {
                ThrowIfDisposed();
                System.Console.SetOut(value);
            });
        }

        /// <inheritdoc/>
        public bool KeyAvailable
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return _profile.Interactive && System.Console.KeyAvailable;
                });
            }
        }

        /// <inheritdoc/>
        public Encoding InputEncoding
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return !_profile.Interactive || System.Console.IsInputRedirected ? Encoding.Default : System.Console.InputEncoding;
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    if (_profile.Interactive && !System.Console.IsInputRedirected)
                    {
                        System.Console.InputEncoding = value;
                    }
                });
            }
        }

        /// <inheritdoc/>
        public Encoding OutputEncoding
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return System.Console.IsOutputRedirected ? Encoding.Default : System.Console.OutputEncoding;
                });
            }
            set
            {
                _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    if (!System.Console.IsOutputRedirected)
                    {
                        System.Console.OutputEncoding = value;
                        _profile.DetectedUnicodeSupport = UnicodeDetector.Detect(System.Console.Out, _profile.SupportUnicode);
                    }
                });
            }
        }

        /// <inheritdoc/>
        public TextReader In
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return System.Console.In;
                });
            }
        }

        /// <inheritdoc/>
        public TextWriter Out
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return System.Console.Out;
                });
            }
        }

        /// <inheritdoc/>
        public TextWriter Error
        {
            get
            {
                return _lock.Run(() =>
                {
                    ThrowIfDisposed();
                    return System.Console.Error;
                });
            }
        }

        private void StartSizeMonitoring()
        {
            _sizeMonitorCts = new CancellationTokenSource();
            _sizeMonitorTask = Task.Run(() => MonitorSizeChanges(_sizeMonitorCts.Token), _sizeMonitorCts.Token);
        }

        private async Task MonitorSizeChanges(CancellationToken cancellationToken)
        {
            // Poll interval (ms) — detects changes quickly with minimal CPU cost.
            const int PollIntervalMs = 50;
            // Silence window: fires only after N ms with no new change (debounce).
            const int StabilityThresholdMs = 150;

            int stableWidth = _lastWidth;
            int stableHeight = _lastHeight;
            int pendingWidth = _lastWidth;
            int pendingHeight = _lastHeight;
            int silenceMs = 0;
            bool hasPending = false;

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(PollIntervalMs, cancellationToken).ConfigureAwait(false);

                    int currentWidth = EnvironmentUtil.GetSafeWidth();
                    int currentHeight = EnvironmentUtil.GetSafeHeight();

                    if (currentWidth != pendingWidth || currentHeight != pendingHeight)
                    {
                        // Tamanho ainda está mudando — reinicia o contador de silêncio
                        pendingWidth = currentWidth;
                        pendingHeight = currentHeight;
                        silenceMs = 0;
                        hasPending = true;
                    }
                    else if (hasPending)
                    {
                        silenceMs += PollIntervalMs;

                        if (silenceMs >= StabilityThresholdMs)
                        {
                            // Tamanho estável por StabilityThresholdMs ms — dispara UMA vez
                            _lastWidth = pendingWidth;
                            _lastHeight = pendingHeight;

                            SizeChanged?.Invoke(this, new ConsoleSizeChangedEventArgs
                            {
                                Width = pendingWidth,
                                Height = pendingHeight,
                                PreviousWidth = stableWidth,
                                PreviousHeight = stableHeight
                            });

                            stableWidth = pendingWidth;
                            stableHeight = pendingHeight;
                            silenceMs = 0;
                            hasPending = false;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Cancelamento esperado — saída limpa
            }
            catch
            {
                // Ignora falhas inesperadas de leitura do console
            }
        }


        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _sizeMonitorCts?.Cancel();
            try
            {
                _sizeMonitorTask?.Wait(1000);
            }
            catch
            {
                // Ignore exceptions during cleanup
            }
            _sizeMonitorTask?.Dispose();
            _sizeMonitorCts?.Dispose();
            _sizeMonitorTask = null;
            _sizeMonitorCts = null;
            _disposed = true;

            GC.SuppressFinalize(this);
        }

        private void ThrowIfDisposed()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
        }

        /// <inheritdoc/>
        public void Write(string? value)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value, CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void Write(string? value, Style style)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value, style, false);
        }

        /// <inheritdoc/>
        public void Write(string? value, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            Write(value, CurrentStyle, clearrestofline);
        }

        /// <inheritdoc/>
        public void WriteLine(string? value)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value, CurrentStyle, false);
        }

        /// <inheritdoc/>
        public void WriteLine(string? value, Style style)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value, style, false);
        }

        /// <inheritdoc/>
        public void WriteLine(string? value, bool clearrestofline)
        {
            ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            WriteLine(value, CurrentStyle, clearrestofline);
        }
    }
}
