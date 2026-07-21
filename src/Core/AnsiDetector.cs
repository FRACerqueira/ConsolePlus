// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ConsolePlusLibrary.Core
{
    internal static partial class AnsiDetector
    {
        private static readonly Regex[] _regexes =
        [
            XtermRegex(), // xterm, PuTTY, Mintty
                RxvtRegex(), // RXVT
                EtermRegex(), // Eterm
                ScreenRegex(), // GNU screen, tmux
                TmuxRegex(), // tmux
                Vt100Regex(), // DEC VT series
                Vt102Regex(), // DEC VT series
                Vt220Regex(), // DEC VT series
                Vt320Regex(), // DEC VT series
                AnsiRegex(), // ANSI
                ScoAnsiRegex(), // SCO ANSI
                CygwinRegex(), // Cygwin, MinGW
                LinuxRegex(), // Linux console
                KonsoleRegex(), // Konsole
                BvtermRegex(), // Bitvise SSH Client
                St256colorRegex(), // Suckless Simple Terminal, st
                AlacrittyRegex(), // Alacritty
            ];

        [GeneratedRegex("^xterm")]
        private static partial Regex XtermRegex();

        [GeneratedRegex("^rxvt")]
        private static partial Regex RxvtRegex();

        [GeneratedRegex("^eterm")]
        private static partial Regex EtermRegex();

        [GeneratedRegex("^screen")]
        private static partial Regex ScreenRegex();

        [GeneratedRegex("tmux")]
        private static partial Regex TmuxRegex();

        [GeneratedRegex("^vt100")]
        private static partial Regex Vt100Regex();

        [GeneratedRegex("^vt102")]
        private static partial Regex Vt102Regex();

        [GeneratedRegex("^vt220")]
        private static partial Regex Vt220Regex();

        [GeneratedRegex("^vt320")]
        private static partial Regex Vt320Regex();

        [GeneratedRegex("ansi")]
        private static partial Regex AnsiRegex();

        [GeneratedRegex("scoansi")]
        private static partial Regex ScoAnsiRegex();

        [GeneratedRegex("cygwin")]
        private static partial Regex CygwinRegex();

        [GeneratedRegex("linux")]
        private static partial Regex LinuxRegex();

        [GeneratedRegex("konsole")]
        private static partial Regex KonsoleRegex();

        [GeneratedRegex("bvterm")]
        private static partial Regex BvtermRegex();

        [GeneratedRegex("^st-256color")]
        private static partial Regex St256colorRegex();

        [GeneratedRegex("alacritty")]
        private static partial Regex AlacrittyRegex();

        public static bool IsValidTerminal(string term)
        {
            return !string.IsNullOrWhiteSpace(term) && _regexes.Any(regex => regex.IsMatch(term));
        }

        public static bool Detect(TextWriter buffer, AutoDetect ansi)
        {
            return Detect(
                buffer,
                ansi,
                Console.IsOutputRedirected,
                Console.IsErrorRedirected);
        }

        internal static bool Detect(
            TextWriter buffer,
            AutoDetect ansi,
            bool isOutputRedirected,
            bool isErrorRedirected)
        {
            var supportsAnsi = ansi == AutoDetect.Yes;

            if (ansi == AutoDetect.Detect)
            {
                if (buffer.IsStandardOut() && isOutputRedirected)
                {
                    return false;
                }

                if (buffer.IsStandardError() && isErrorRedirected)
                {
                    return false;
                }
                return Detect(buffer.IsStandardError(), true);
            }
            return supportsAnsi;
        }

        private static bool Detect(bool stdError, bool upgrade)
        {
            // Running on Windows?
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Running under ConEmu?
                var conEmu = Environment.GetEnvironmentVariable("ConEmuANSI");
                if (!string.IsNullOrEmpty(conEmu) && conEmu.Equals("On", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                return Windows.SupportsAnsi(upgrade, stdError);
            }

            return DetectFromTerm();
        }

        private static bool DetectFromTerm()
        {
            // Check if the terminal is of type ANSI/VT100/xterm compatible.
            var term = Environment.GetEnvironmentVariable("TERM");
            if (!string.IsNullOrWhiteSpace(term))
            {
                if (_regexes.Any(regex => regex.IsMatch(term)))
                {
                    return true;
                }
            }
            return false;
        }

        private static partial class Windows
        {
            private const int STD_OUTPUT_HANDLE = -11;

            private const int STD_ERROR_HANDLE = -12;

            private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

            private const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

            [LibraryImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static partial bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

            [LibraryImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static partial bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

            [LibraryImport("kernel32.dll", SetLastError = true)]
            private static partial IntPtr GetStdHandle(int nStdHandle);

            [LibraryImport("kernel32.dll")]
            public static partial uint GetLastError();

            public static bool SupportsAnsi(bool upgrade, bool stdError)        {
                try
                {
                    var @out = GetStdHandle(stdError ? STD_ERROR_HANDLE : STD_OUTPUT_HANDLE);
                    if (!GetConsoleMode(@out, out var mode))
                    {
                        // Could not get console mode, try TERM (set in cygwin, WSL-Shell).
                        return DetectFromTerm();
                    }

                    if ((mode & ENABLE_VIRTUAL_TERMINAL_PROCESSING) == 0)
                    {
                        if (!upgrade)
                        {
                            return false;
                        }

                        // Try enable ANSI support.
                        mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;
                        if (!SetConsoleMode(@out, mode))
                        {
                            // Enabling failed.
                            return false;
                        }
                    }

                    return true;
                }
                catch
                {
                    // All we know here is that we don't support ANSI.
                    return false;
                }
            }
        }
    }
}