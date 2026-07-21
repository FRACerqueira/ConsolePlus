// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.IO;

namespace ConsolePlusLibrary.Core
{
    internal static class TextWriterExtensions
    {
        public static bool IsStandardOut(this TextWriter writer)
        {
            try
            {
                return writer == System.Console.Out;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsStandardError(this TextWriter writer)
        {
            try
            {
                return writer == System.Console.Error;
            }
            catch
            {
                return false;
            }
        }
    }
}
