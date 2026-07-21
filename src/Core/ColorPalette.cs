// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Collections.Generic;

namespace ConsolePlusLibrary.Core
{
    internal static class ColorPalette
    {
        private static List<Color> Legacy { get; }
        private static List<Color> Standard { get; }
        public static List<Color> EightBit { get; }

        static ColorPalette()
        {
            Legacy = [.. GenerateLegacyPalette()];
            Standard = [.. GenerateStandardPalette(Legacy)];
            EightBit = [.. GenerateEightBitPalette(Standard)];
        }

        /// <summary>
        /// Gets an exact match for <paramref name="colorRgb"/> in the specified color system,
        /// or the closest available color when an exact match does not exist.
        /// </summary>
        /// <param name="system">Target color system.</param>
        /// <param name="colorRgb">Source RGB color.</param>
        /// <returns>The exact or nearest color from the selected palette.</returns>
        internal static Color ExactOrClosest(ColorSystem system, Color colorRgb)
        {
            Color? exact = Exact(system, colorRgb);
            return exact ?? Closest(system, colorRgb);
        }

        private static Color? Exact(ColorSystem system, Color colorRgb)
        {
            if (system == ColorSystem.TrueColor)
            {
                return colorRgb;
            }

            List<Color> palette = system switch
            {
                ColorSystem.FourBit => Standard,
                ColorSystem.Standard => EightBit,
                _ => throw new ArgumentException("Not Supported ColorSystem"),
            };

            for (int i = 0; i < palette.Count; i++)
            {
                if (palette[i].Equals(colorRgb))
                {
                    return palette[i];
                }
            }

            return null;
        }

        private static Color Closest(ColorSystem system, Color colorRgb)
        {
            if (system == ColorSystem.TrueColor)
            {
                return colorRgb;
            }

            List<Color> palette = system switch
            {
                ColorSystem.FourBit => Standard,
                ColorSystem.Standard => EightBit,
                _ => throw new ArgumentException($"Not Supported ColorSystem"),
            };

            // https://stackoverflow.com/a/9085524
            static double Distance(Color first, Color second)
            {
                float rmean = ((float)first.R + second.R) / 2;
                int r = first.R - second.R;
                int g = first.G - second.G;
                int b = first.B - second.B;
                return Math.Sqrt(
                    ((int)((512 + rmean) * r * r) >> 8)
                    + 4 * g * g
                    + ((int)((767 - rmean) * b * b) >> 8));
            }

            Color closest = palette[0];
            double closestDistance = Distance(closest, colorRgb);

            for (int i = 1; i < palette.Count; i++)
            {
                Color candidate = palette[i];
                double distance = Distance(candidate, colorRgb);
                if (distance < closestDistance)
                {
                    closest = candidate;
                    closestDistance = distance;
                }
            }

            return closest;
        }


        private static List<Color> GenerateLegacyPalette()
        {
            return
            [
                new Color(0, 0, 0, 0),
                new Color(1, 128, 0, 0),
                new Color(2, 0, 128, 0),
                new Color(3, 128, 128, 0),
                new Color(4, 0, 0, 128),
                new Color(5, 128, 0, 128),
                new Color(6, 0, 128, 128),
                new Color(7, 192, 192, 192),
            ];
        }

        private static List<Color> GenerateStandardPalette(IReadOnlyList<Color> legacy)
        {
            return
            [
                .. legacy,
                new Color(8, 128, 128, 128),
                new Color(9, 255, 0, 0),
                new Color(10, 0, 255, 0),
                new Color(11, 255, 255, 0),
                new Color(12, 0, 0, 255),
                new Color(13, 255, 0, 255),
                new Color(14, 0, 255, 255),
                new Color(15, 255, 255, 255),
            ];
        }

        private static List<Color> GenerateEightBitPalette(IReadOnlyList<Color> standard)
        {
            List<Color> palette = [.. standard];

            // xterm 256-color cube (indexes 16-231).
            int[] levels = [0, 95, 135, 175, 215, 255];
            int index = 16;
            for (int r = 0; r < levels.Length; r++)
            {
                for (int g = 0; g < levels.Length; g++)
                {
                    for (int b = 0; b < levels.Length; b++)
                    {
                        palette.Add(new Color((byte)index++, (byte)levels[r], (byte)levels[g], (byte)levels[b]));
                    }
                }
            }

            // grayscale ramp (indexes 232-255): 8,18,...,238
            for (int gray = 8; gray <= 238; gray += 10)
            {
                palette.Add(new Color((byte)index++, (byte)gray, (byte)gray, (byte)gray));
            }

            return palette;
        }
    }
}
