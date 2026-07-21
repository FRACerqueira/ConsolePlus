// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsolePlusLibrary.ConsoleAbstractions
{

    internal static class AnsiColorBuilder
    {
        public static IEnumerable<byte> Build(ColorSystem system, Color color, bool foreground)
        {
            if (color == Color.Default)
            {
                return [];
            }

            return system switch
            {
                ColorSystem.NoColors => [], // No colors
                ColorSystem.TrueColor => GetTrueColor(color, foreground), // 24-bit
                ColorSystem.Standard => GetEightBit(color, foreground), // 8-bit
                ColorSystem.FourBit => GetFourBit(color, foreground), // 4-bit
                _ => throw new InvalidOperationException("Could not determine ANSI color oe legacy."),
            };
        }

        private static IEnumerable<byte> GetFourBit(Color color, bool foreground)
        {
            var number = color.Number;
            if (number == null || color.Number >= 16)
            {
                number = color.ExactOrClosest(ColorSystem.FourBit).Number;
            }

            Debug.Assert(number is >= 0 and < 16, "Invalid range for 4-bit color");

            var mod = number < 8 ? (foreground ? 30 : 40) : (foreground ? 82 : 92);
            return [(byte)(number.Value + mod)];
        }

        private static IEnumerable<byte> GetEightBit(Color color, bool foreground)
        {
            var number = color.Number ?? color.ExactOrClosest(ColorSystem.Standard).Number;
            Debug.Assert(number is >= 0, "Invalid range for 8-bit color");

            var mod = foreground ? (byte)38 : (byte)48;
            return [mod, 5, (byte)number];
        }

        private static IEnumerable<byte> GetTrueColor(Color color, bool foreground)
        {
            if (color.Number != null)
            {
                return GetEightBit(color, foreground);
            }

            var mod = foreground ? (byte)38 : (byte)48;
            return [mod, 2, color.R, color.G, color.B];
        }
    }
}
