// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.ConsoleAbstractions;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsolePlusLibrary.Core
{
    internal static partial class EnvironmentUtil
    {
       public static int GetSafeTopCursor(int defaultValue = Constants.DefaultCursorTop)
        {
            try
            {
                var top = Console.CursorTop;
                if (top < 0)
                {
                    top = defaultValue;
                }
                return top;
            }
            catch (IOException)
            {
                return defaultValue;
            }
        }

        public static int GetSafeLeftCursor(int defaultValue = Constants.DefaultCursorLeft)
        {
            try
            {
                var left = Console.CursorLeft;
                if (left < 0)
                {
                    left = defaultValue;
                }
                return left;
            }
            catch (IOException)
            {
                return defaultValue;
            }
        }

        public static int GetSafeWidth(int defaultValue = Constants.DefaultTerminalWidth)
        {
            try
            {
                var width = Console.BufferWidth;
                if (width <= 0)
                {
                    width = defaultValue;
                }

                return width;
            }
            catch (IOException)
            {
                return defaultValue;
            }
        }

        public static int GetSafeHeight(int defaultValue = Constants.DefaultTerminalHeight)
        {
            try
            {
                var height = Console.WindowHeight;
                if (height <= 0)
                {
                    height = defaultValue;
                }

                return height;
            }
            catch (IOException)
            {
                return defaultValue;
            }
        }

        public static void ResetState(bool isansi, string originalCulture, ConsoleColor originalForecolor, ConsoleColor originalBackcolor, Encoding originalInputEncoding, Encoding originalOutputEncoding)
        {
            try
            {
                // try restore cursor visibility if it was changed
                Console.CursorVisible = true;
            }
            catch (Exception)
            {
                //skip Exception
            }
            try
            {
                // try restore input encoding if it was changed
                Console.InputEncoding = originalInputEncoding;
            }
            catch (Exception)
            {
                //skip Exception
            }
            try
            {
                // try restore output encoding if it was changed
                Console.OutputEncoding = originalOutputEncoding;
            }
            catch (Exception)
            {
                //skip Exception
            }
            try
            {
                if (isansi)
                {
                    var (left, top) = Console.GetCursorPosition();
                    // try Exit alternate screen buffer if it was used
                    Console.Write("\u001b[?1049l");
                    Console.SetCursorPosition(left, top);
                }
            }
            catch (Exception)
            {
                //skip Exception
            }
            try
            {
                // try Restore original culture
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(originalCulture);
            }
            catch (Exception)
            {
                //skip Exception
            }
            try
            {
                // try Restore original console colors
                Console.ForegroundColor = originalForecolor;
                Console.BackgroundColor = originalBackcolor;
            }
            catch (Exception)
            {
                //skip Exception
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProfileConsole"/> by detecting the current console environment and optionally loading settings from a JSON profile file. It gathers information about ANSI support, color capabilities, terminal support, and sets default colors based on the provided parameters. If a JSON profile is found, it enriches the profile with additional information.
        /// </summary>
        /// <param name="ansilegacy">Indicates whether ANSI support was enabled on legacy Windows versions.</param>
        /// <param name="originalCulture">The original culture of the console.</param>
        /// <param name="originalBackcolor">The original background color of the console.</param>
        /// <param name="originalForecolor">The original foreground color of the console.</param>
        /// <param name="originalInputEncoding">The original input encoding of the console.</param>
        /// <param name="originalOutputEncoding">The original output encoding of the console.</param>
        /// <returns>A new instance of <see cref="ProfileConsole"/>.</returns>
        public static ProfileConsole CreateProfile(bool ansilegacy, string originalCulture, ConsoleColor originalBackcolor, ConsoleColor originalForecolor, Encoding originalInputEncoding, Encoding originalOutputEncoding)
        {

            var terminaldetect = HasTerminalSupport();
            var profile = new ProfileConsole
            {
                OriginalCulture = originalCulture,
                ProfileName = "ConsolePlus",
                IsTerminal = terminaldetect,
                Interactive = true,
                SupportUnicode = AutoDetect.Detect,
                SupportsAnsi = AutoDetect.Detect,
                ColorDepth = ColorSystem.NoColors,
                DefaultBackgroundColor = originalBackcolor,
                DefaultForegroundColor = originalForecolor,
                OriginalInputEncoding = originalInputEncoding,
                OriginalOutputEncoding = originalOutputEncoding,
                DefaultInputEncoding = originalInputEncoding,
                DefaultOutputEncoding = originalOutputEncoding,
                DetectedAnsiSupport = false,
                DetectedUnicodeSupport = false,
            };

            profile.EnrichersCI();

            if (LoadConsoleProfileFromJson() is FrozenDictionary<string, string> profileFromJson)
            {
                if (profileFromJson.TryGetValue("OriginalCulture", out string? originalCultureStr))
                {
                    if (originalCultureStr != null && originalCultureStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        if (originalCultureStr.ExistsCulture())
                        {
                            profile.OriginalCulture = CultureInfo.GetCultureInfo(originalCultureStr!).Name;
                        }
                    }
                }
                if (profileFromJson.TryGetValue("DefaultInputEncoding", out string? defaultInputEncodingStr))
                {
                    if (defaultInputEncodingStr != null && defaultInputEncodingStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (profile.DefaultInputEncoding != Console.InputEncoding)
                        {
                            profile.DefaultInputEncoding = Console.InputEncoding;
                            profile.SupportsAnsi = AutoDetect.Detect; // if input encoding is detected, we can also trigger a new detection for ANSI support as it can be related
                        }
                    }
                    else if (defaultInputEncodingStr != null && defaultInputEncodingStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        if (IsValidEncoding(defaultInputEncodingStr))
                        {
                            profile.DefaultInputEncoding = Encoding.GetEncoding(defaultInputEncodingStr);
                            profile.SupportsAnsi = AutoDetect.Detect; // if input encoding is detected, we can also trigger a new detection for ANSI support as it can be related
                        }
                    }
                }
                if (profileFromJson.TryGetValue("DefaultOutputEncoding", out string? defaultOutputEncodingStr))
                {
                    if (defaultOutputEncodingStr != null && defaultOutputEncodingStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (profile.DefaultOutputEncoding != Console.OutputEncoding)
                        {
                            profile.DefaultOutputEncoding = Console.OutputEncoding;
                            profile.SupportsAnsi = AutoDetect.Detect; // if input encoding is detected, we can also trigger a new detection for ANSI support as it can be related
                        }
                    }
                    else if (defaultOutputEncodingStr != null && defaultOutputEncodingStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        if (IsValidEncoding(defaultOutputEncodingStr))
                        {
                            profile.DefaultOutputEncoding = Encoding.GetEncoding(defaultOutputEncodingStr);
                            profile.SupportsAnsi = AutoDetect.Detect; // if input encoding is detected, we can also trigger a new detection for ANSI support as it can be related
                        }
                    }
                }
                if (profileFromJson.TryGetValue("DefaultBackgroundColor", out string? defaultBackgroundColorStr))
                {
                    if (defaultBackgroundColorStr != null && defaultBackgroundColorStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        if (Color.TryFromHex(defaultBackgroundColorStr, out var color))
                        {
                            profile.DefaultBackgroundColor = color;
                        }
                    }
                }
                if (profileFromJson.TryGetValue("DefaultForegroundColor", out string? defaultForegroundColorStr))
                {
                    if (defaultForegroundColorStr != null && defaultForegroundColorStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        if (Color.TryFromHex(defaultForegroundColorStr, out var color))
                        {
                            profile.DefaultForegroundColor = color;
                        }
                    }
                }
                if (profileFromJson.TryGetValue("ProfileName", out string? profileName) && !string.IsNullOrWhiteSpace(profileName))
                {
                    profile.ProfileName = profileName;
                }
                if (profileFromJson.TryGetValue("IsTerminal", out string? isTerminalStr))
                {
                    if (isTerminalStr != null && isTerminalStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0 && bool.TryParse(isTerminalStr, out var isTerminal))
                    {
                        profile.IsTerminal = isTerminal;
                    }
                }
                if (profileFromJson.TryGetValue("Interactive", out string? interactiveStr))
                {
                    if (interactiveStr != null && interactiveStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0 && bool.TryParse(interactiveStr, out var interactive))
                    {
                        profile.Interactive = interactive;
                    }
                }

                if (profileFromJson.TryGetValue("SupportUnicode", out string? supportUnicodeStr) && supportUnicodeStr != null && supportUnicodeStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0 && Enum.TryParse<AutoDetect>(supportUnicodeStr, true, out var supportUnicode))
                {
                    profile.ChangedSupportUnicode = true;
                    profile.SupportUnicode = supportUnicode;

                }
                if (profileFromJson.TryGetValue("SupportsAnsi", out string? supportsAnsiStr) && supportsAnsiStr != null && supportsAnsiStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0 && Enum.TryParse<AutoDetect>(supportsAnsiStr, true, out var supportsAnsi))
                {
                    profile.ChangedSupportsAnsi = true;
                    profile.SupportsAnsi = supportsAnsi;

                }
                if (profileFromJson.TryGetValue("ColorDepth", out string? colorDepthStr) && colorDepthStr != null)
                {
                    if (colorDepthStr.CompareTo("Detect", StringComparison.OrdinalIgnoreCase) != 0 && Enum.TryParse<ColorSystem>(colorDepthStr, true, out var colorDepth))
                    {
                        profile.ChangedColorDepth = true;
                        profile.ColorDepth = colorDepth;
                    }
                }
            }

            Console.InputEncoding = profile.DefaultInputEncoding;
            Console.OutputEncoding = profile.DefaultOutputEncoding;

            if (profile.SupportsAnsi == AutoDetect.Detect && !profile.ChangedSupportsAnsi)
            {
                var ansiDetection = ansilegacy || AnsiDetector.Detect(Console.Out, AutoDetect.Detect);
                profile.DetectedAnsiSupport = ansiDetection;
            }
            if (profile.SupportUnicode == AutoDetect.Detect && !profile.ChangedSupportUnicode)
            {
                var unicodeDetection = UnicodeDetector.Detect(Console.Out, AutoDetect.Detect);
                profile.DetectedUnicodeSupport = unicodeDetection;
            }
            if (!profile.ChangedColorDepth)
            {
                var colordetect = ColorSystemDetector(profile.DetectedAnsiSupport || profile.SupportsAnsi == AutoDetect.Yes);
                profile.ColorDepth = colordetect;
            }
            return profile;
        }

        /// <summary>
        /// Determines whether the specified encoding name corresponds to a valid encoding recognized by the .NET framework.
        /// </summary>
        /// <param name="name">The name of the encoding to check.</param>
        /// <returns>true if the specified encoding name is valid and recognized; otherwise, false.</returns>
        private static bool IsValidEncoding(string name)
        {
            try
            {
                Encoding enc = Encoding.GetEncoding(name);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        /// <summary>
        /// Searches for a ConsoleProfile.json file in the execution folder and deserializes it to a ProfileConsole instance.
        /// </summary>
        /// <returns>A ProfileConsole instance loaded from the JSON file, or null if the file is not found.</returns>
        public static FrozenDictionary<string, string>? LoadConsoleProfileFromJson()
        {
            string executionPath = AppContext.BaseDirectory;
            string profileFilePath = Path.Combine(executionPath, Constants.ProfileName);

            if (!File.Exists(profileFilePath))
            {
                return null;
            }
            try
            {
                string jsonContent = File.ReadAllText(profileFilePath);

                // Deserialize directly to JsonElement values — avoids boxing every value as object.
                // JsonElement.ToString() returns the unquoted string for String tokens and raw text
                // for numbers/booleans, which is identical to the previous object.ToString() pattern.
                var tempDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonContent);

                // Single-pass projection to FrozenDictionary; StringComparer.OrdinalIgnoreCase is
                // explicitly preserved (the previous ToFrozenDictionary() call without comparer
                // silently dropped it).
                return tempDict!.ToFrozenDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.ToString(),
                    StringComparer.OrdinalIgnoreCase);
            }
            catch (Exception)
            {
                // skip any error and return null to fallback to default profile
                return null;
            }
        }

        // Adapted from https://github.com/willmcgugan/rich/blob/f0c29052c22d1e49579956a9207324d9072beed7/rich/console.py#L391
        /// <summary>
        /// Detects the best color system supported by the current terminal/console environment.
        /// </summary>
        /// <param name="supportsAnsi">Indicates if ANSI sequences are supported.</param>
        /// <returns>The detected <see cref="ColorSystem"/>.</returns>
        public static ColorSystem ColorSystemDetector(bool supportsAnsi)
        {
            if (Environment.GetEnvironmentVariable("NO_COLOR") != null)
            {
                return ColorSystem.NoColors;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (!supportsAnsi)
                {
                    return ColorSystem.Standard;
                }

                if (GetWindowsVersionInformation(out int major, out int build))
                {
                    if ((major == 10 && build >= 15063) || major > 10)
                    {
                        return ColorSystem.TrueColor;
                    }
                }
            }
            else
            {
                string? colorTerm = Environment.GetEnvironmentVariable("COLORTERM");
                if (!string.IsNullOrWhiteSpace(colorTerm))
                {
                    if (colorTerm.Equals("truecolor", StringComparison.OrdinalIgnoreCase) ||
                       colorTerm.Equals("24bit", StringComparison.OrdinalIgnoreCase))
                    {
                        return ColorSystem.TrueColor;
                    }
                }
            }

            return ColorSystem.Standard;
        }

        /// <summary>
        /// Detects if the current environment has terminal support, which is essential for features like ANSI sequences and advanced console capabilities.
        /// </summary>
        /// <returns>True if the environment has terminal support; otherwise, false.</returns>
        public static bool HasTerminalSupport()
        {
            // Check if running on Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Check for Windows Terminal or ConEmu
                string? wtSession = Environment.GetEnvironmentVariable("WT_SESSION");
                string? conEmu = Environment.GetEnvironmentVariable("ConEmuANSI");

                if (!string.IsNullOrEmpty(wtSession) ||
                    (conEmu?.Equals("On", StringComparison.OrdinalIgnoreCase) ?? false))
                {
                    return true;
                }

                // Check Windows version for modern console
                if (Environment.OSVersion.Version.Build >= 22621)
                {
                    try
                    {
                        //https://support.microsoft.com/en-us/windows/command-prompt-and-windows-powershell-6453ce98-da91-476f-8651-5c14d5777c20
                        string keydefaultconsole = (string?)Microsoft.Win32.Registry.GetValue(
                            @"HKEY_CURRENT_USER\Console\%%Startup",
                            "DelegationConsole", null) ?? "";
                        if (keydefaultconsole == "{B23D10C0-E52E-411E-9D5B-C09FDF709C7D}")
                        {
                            return false;
                        }
                        else if (keydefaultconsole == "{00000000-0000-0000-0000-000000000000}") //Automatic select
                        {
                            string InstallPath = (string?)Microsoft.Win32.Registry.GetValue(
                                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\wt.exe",
                                "", null) ?? "";
                            return InstallPath != "";
                        }
                    }
                    catch
                    {
                        //none;
                    }
                    return true;
                }
            }
            else
            {
                // Check terminal type on Unix-like systems
                string term = Environment.GetEnvironmentVariable("TERM") ?? "";
                return AnsiDetector.IsValidTerminal(term);
            }

            return false;
        }

        /// <summary>
        /// Attempts to extract Windows version information (major, build) from OS description.
        /// </summary>
        /// <param name="major">Outputs Windows major version.</param>
        /// <param name="build">Outputs Windows build number.</param>
        /// <returns><c>true</c> if parsing succeeded; otherwise <c>false</c>.</returns>
        private static bool GetWindowsVersionInformation(out int major, out int build)
        {
            major = 0;
            build = 0;

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return false;
            }

            Regex regex = RegexCheckWindows();
            Match match = regex.Match(RuntimeInformation.OSDescription);
            if (match.Success && int.TryParse(match.Groups["major"].Value, out major))
            {
                if (int.TryParse(match.Groups["build"].Value, out build))
                {
                    return true;
                }
            }

            return false;
        }

        [GeneratedRegex("Microsoft Windows (?'major'[0-9]*).(?'minor'[0-9]*).(?'build'[0-9]*)\\s*$")]
        private static partial Regex RegexCheckWindows();
    }
}
