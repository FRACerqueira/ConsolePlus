// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsolePlusLibrary.Core
{
    internal static class UnicodeDetector
    {
        /// <summary>
        /// Detects if the current console environment supports Unicode output, which is important for rendering certain characters and symbols correctly.
        /// </summary>
        /// <returns>True if Unicode output is supported; otherwise, false.</returns>
        public static bool Detect(TextWriter buffer, AutoDetect unicode)
        {
            if (unicode != AutoDetect.Detect)
            {
                return unicode == AutoDetect.Yes;
            }
            try
            {
                var encoding = buffer.Encoding;

                if (encoding == Encoding.UTF8)
                {
                    return true;
                }

                //  Regras específicas por sistema operacional
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Atalho rápido: encodings Unicode explícitos.
                    if (encoding.CodePage is 65001 or 1200 or 1201 or 12000 or 12001)
                    {
                        return true;
                    }

                    // Terminais modernos normalmente suportam Unicode
                    var wt = Environment.GetEnvironmentVariable("WT_SESSION");
                    var conEmu = Environment.GetEnvironmentVariable("ConEmuANSI");

                    return !string.IsNullOrWhiteSpace(wt) ||
                           string.Equals(conEmu, "On", StringComparison.OrdinalIgnoreCase);
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                    RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD) ||
                    RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    // Em Unix, locale UTF-8 é o melhor indicativo
                    var lang = Environment.GetEnvironmentVariable("LC_ALL")
                               ?? Environment.GetEnvironmentVariable("LC_CTYPE")
                               ?? Environment.GetEnvironmentVariable("LANG")
                               ?? string.Empty;

                    // TERM=dumb geralmente não oferece recursos completos de terminal
                    var term = Environment.GetEnvironmentVariable("TERM") ?? string.Empty;
                    if (term.Equals("dumb", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }

                    return lang.Contains("UTF-8", StringComparison.OrdinalIgnoreCase) ||
                           lang.Contains("UTF8", StringComparison.OrdinalIgnoreCase);
                }


                //Capacidade real de codificação (regra principal)
                var strict = Encoding.GetEncoding(
                    encoding.CodePage,
                    EncoderFallback.ExceptionFallback,
                    DecoderFallback.ExceptionFallback);

                // Caracteres de planos diferentes (BMP + suplementar)
                _ = strict.GetBytes("✓漢🙂");

                return true;
            }
            catch (EncoderFallbackException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
