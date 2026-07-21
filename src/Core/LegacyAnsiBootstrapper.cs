// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsolePlusLibrary.Core
{
    internal static class LegacyAnsiBootstrapper
    {
        private static bool _initialized;

        public static bool TryEnable()
        {
            if (_initialized)
            {
                return false;
            }

            _initialized = true;

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return false;
            }

            var version = Environment.OSVersion.Version;
            if (version <= new Version(5, 0) || version >= new Version(10, 0))
            {
                return false;
            }

            var basePath = AppContext.BaseDirectory;
            var folder = Environment.Is64BitProcess ? "x64" : "x86";
            var executablePath = Path.Combine(basePath, "ExternalAnsiBundleLegacy", folder, "ansicon.exe");

            if (!Environment.Is64BitProcess && !File.Exists(executablePath))
            {
                executablePath = Path.Combine(basePath, "ExternalAnsiBundleLegacy", "x32", "ansicon.exe");
            }

            if (!File.Exists(executablePath))
            {
                return false;
            }

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = executablePath,
                    Arguments = "-p",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetDirectoryName(executablePath) ?? basePath,
                };

                using var process = Process.Start(startInfo);
                if (process is null)
                {
                    return false;
                }

                process.WaitForExit();

                return process.ExitCode == 0;
            }
            catch
            {
                // best effort only
            }
            return false;   
        }
    }
}