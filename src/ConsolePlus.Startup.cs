// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.ConsoleAbstractions;
using ConsolePlusLibrary.Core;
using System;
using System.Globalization;
using System.Text;

namespace ConsolePlusLibrary
{
    /// <summary>
    /// Provides the global entry point for all console services.
    /// </summary>
    /// <remarks>
    /// The static initialization sequence detects terminal capabilities (ANSI, Unicode, color depth, legacy mode),
    /// captures the original console state (culture, encoding, colors) and prepares an internal profile.
    /// Resources are restored automatically on process exit.
    /// </remarks>
    public static partial class ConsolePlus
    {
        internal static Action<IConsole, Exception?, bool>? ActionBeforeExitValue;
        internal static readonly ILock Envlock = new LockEnvironment();

        private static readonly ProfileConsole _profile;
        private static bool _ctrlCPress;
        private static readonly IConsole _consoledrive;
        private static readonly string _originalCulture;
        private static readonly ConsoleColor _originalForecolor;
        private static readonly ConsoleColor _originalBackcolor;
        private static readonly Encoding _originalInputEncoding;
        private static readonly Encoding _originalOutputEncoding;

        /// <summary>
        /// Static constructor. Detects environment capabilities and initializes the internal console driver.
        /// </summary>
        static ConsolePlus()
        {
            // Register a callback to ensure that the console exits with a non-zero code on unhandled exceptions, allowing external tools to detect failures.
            Helper.MainToken.Token.Register(() =>
            {
                Helper.ExitCode = 1;
            });

            // Attempt to enable ANSI support on legacy Windows versions using an external helper tool.
            var ansilegacy = LegacyAnsiBootstrapper.TryEnable();

            _originalCulture = CultureInfo.CurrentCulture.Name;
            _originalForecolor = Console.ForegroundColor;
            _originalBackcolor = Console.BackgroundColor;
            _originalInputEncoding = Console.InputEncoding;
            _originalOutputEncoding = Console.OutputEncoding;

            _profile = EnvironmentUtil.CreateProfile(ansilegacy, _originalCulture, _originalBackcolor, _originalForecolor, Encoding.UTF8, Encoding.UTF8);

            if (_profile.SupportsAnsi == AutoDetect.Yes || _profile.DetectedAnsiSupport || ansilegacy)
            {
                _consoledrive = new AnsiConsoleAdapter(_profile,Envlock, Helper.MainToken.Token);
            }
            else
            {
                _consoledrive = new NoAnsiConsoleAdapter(_profile,Envlock, Helper.MainToken.Token);
            }
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Console.CancelKeyPress += Console_CancelKeyPress;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is not OperationCanceledException _)
            {
                Helper.LastException = (Exception)e.ExceptionObject;
            }
            Helper.MainToken.Cancel();
            Environment.Exit(Helper.ExitCode);
        }

        private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            EnvironmentUtil.ResetState(_profile.DetectedAnsiSupport, _originalCulture, _originalForecolor, _originalBackcolor, _originalInputEncoding, _originalOutputEncoding);
            Console.Error.Flush();
            Console.Out.Flush();
            if (Helper.LastException != null)
            {
                _consoledrive.WriteLine($"An unhandled exception occurred: {Helper.LastException}");
            }
            ActionBeforeExitValue?.Invoke(_consoledrive, Helper.LastException, _ctrlCPress);
        }

        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            if (!e.Cancel)
            {
                Helper.MainToken.Cancel();
                _ctrlCPress = true;
                Environment.Exit(Helper.ExitCode);
            }
        }

        /// <summary>
        /// Enables/Disable Emacs-style key bindings in the console, allowing for standard Emacs key combinations to be used for text editing and navigation.
        /// </summary>
        public static bool EnabledEmacs
        {
            get => _consoledrive.EnabledEmacs;
            set => _consoledrive.EnabledEmacs = value;
        }

        /// <summary>
        /// Registers a callback action to be invoked before the console exits, allowing for custom cleanup or final output. 
        /// The action receives the current console instance and a boolean indicating if Ctrl+C was pressed as parameters.
        /// </summary>
        /// <param name="action">The action to be invoked before the console exits.</param>
        public static void ActionBeforeExit(Action<IConsole,Exception?,bool> action)
        {
            ActionBeforeExitValue = action;
        }

        /// <summary>
        /// Gets the ANSI command emitter (<see cref="IAnsiCommands"/>) for this console, allowing for emitting ANSI escape sequences to control the console output.
        /// </summary>
        public static IAnsiCommands Ansi
        {
            get
            {
                return _consoledrive.Ansi;
            }
        }
    }
}
