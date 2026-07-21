// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Globalization;

namespace ConsolePlusLibrary
{
    /// <summary>
    /// Represents a color.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Color"/> struct.
    /// </remarks>
    /// <param name="red">The red component.</param>
    /// <param name="green">The green component.</param>
    /// <param name="blue">The blue component.</param>
    public readonly partial struct Color(byte red, byte green, byte blue) : IEquatable<Color>
    {
        /// <summary>
        /// Gets the default color.
        /// </summary>
        internal static Color Default { get; } = new(0, 0, 0, 0, true);

        /// <summary>
        /// Gets the red component.
        /// </summary>
        public byte R { get; } = red;

        /// <summary>
        /// Gets the green component.
        /// </summary>
        public byte G { get; } = green;

        /// <summary>
        /// Gets the blue component.
        /// </summary>
        public byte B { get; } = blue;

        /// <summary>
        /// Gets the number of the color, if any.
        /// </summary>
        internal byte? Number { get; } = null;

        /// <summary>
        /// Gets a value indicating whether or not this is the default color.
        /// </summary>
        internal bool IsDefault { get; } = false;

        internal Color(byte number, byte red, byte green, byte blue, bool isDefault = false) : this(red, green, blue)
        {
            Number = number;
            IsDefault = isDefault;
        }

        /// <summary>
        /// Blends two colors.
        /// </summary>
        /// <param name="other">The other color.</param>
        /// <param name="factor">The blend factor.</param>
        /// <returns>The resulting color.</returns>
        public Color Blend(Color other, float factor)
        {
            // https://github.com/willmcgugan/rich/blob/f092b1d04252e6f6812021c0f415dd1d7be6a16a/rich/color.py#L494
            return new Color(
                (byte)(R + ((other.R - R) * factor)),
                (byte)(G + ((other.G - G) * factor)),
                (byte)(B + ((other.B - B) * factor)));
        }

        /// <summary>
        /// Gets a contrasting color (black or white) based on luminance for readability.
        /// </summary>
        /// <returns><see cref="White"/> or <see cref="Black"/> depending on brightness.</returns>
        public readonly Color GetInvertedColor()
        {
            return GetLuminance() < 140 ? White : Black;
        }

        /// <summary>
        /// Gets the hexadecimal representation of the color.
        /// </summary>
        /// <returns>The hexadecimal representation of the color.</returns>
        public string ToHex()
        {
            // stackalloc: zero intermediate string allocations vs 3 × ToString("X2") + string.Format
            Span<char> buf = stackalloc char[6];
            R.TryFormat(buf[..2], out _, "X2", CultureInfo.InvariantCulture);
            G.TryFormat(buf[2..4], out _, "X2", CultureInfo.InvariantCulture);
            B.TryFormat(buf[4..], out _, "X2", CultureInfo.InvariantCulture);
            return new string(buf);
        }

        /// <summary>
        /// Gets the exact or closest color in the specified <see cref="ColorSystem"/>.
        /// </summary>
        /// <param name="system">The color system.</param>
        /// <returns>The exact or closest color in the specified <see cref="ColorSystem"/>.</returns>
        public Color ExactOrClosest(ColorSystem system)
        {
            return ColorPalette.ExactOrClosest(system, this);
        }

        /// <summary>
        /// Calculates the relative luminance of the color according to WCAG formula.
        /// </summary>
        /// <returns>The relative luminance value between 0 and 1.</returns>
        /// <remarks>
        /// Uses the formula from https://www.w3.org/TR/WCAG20/#relativeluminancedef
        /// </remarks>
        public double GetLuminance()
        {
            // Convert RGB from 0-255 to 0-1
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            // Apply gamma correction
            r = r <= 0.03928 ? r / 12.92 : Math.Pow((r + 0.055) / 1.055, 2.4);
            g = g <= 0.03928 ? g / 12.92 : Math.Pow((g + 0.055) / 1.055, 2.4);
            b = b <= 0.03928 ? b / 12.92 : Math.Pow((b + 0.055) / 1.055, 2.4);

            // Calculate relative luminance
            return 0.2126 * r + 0.7152 * g + 0.0722 * b;
        }

        /// <summary>
        /// Calculates the contrast ratio between this color and another color according to WCAG formula.
        /// </summary>
        /// <param name="other">The other color to compare with.</param>
        /// <returns>The contrast ratio between 1 and 21.</returns>
        /// <remarks>
        /// Uses the formula from https://www.w3.org/TR/WCAG20/#contrast-ratiodef
        /// The contrast ratio is defined as (L1 + 0.05) / (L2 + 0.05), where L1 is the lighter color luminance.
        /// </remarks>
        public double GetContrast(Color other)
        {
            double l1 = GetLuminance();
            double l2 = other.GetLuminance();

            // Ensure l1 is the lighter color
            if (l2 > l1)
            {
                (l1, l2) = (l2, l1);
            }

            return (l1 + 0.05) / (l2 + 0.05);
        }

        /// <summary>
        /// Gets the best foreground color (white or black) for adequate contrast with the specified background color.
        /// </summary>
        /// <param name="backgroundColor">The background color.</param>
        /// <returns>White color if the background is dark, Black color if the background is light.</returns>
        /// <remarks>
        /// This method uses the relative luminance of the background color to determine whether white or black text provides better contrast.
        /// A luminance threshold of 0.5 is used to decide between white and black foreground colors.
        /// </remarks>
        public static Color GetContrastForegroundColor(Color backgroundColor)
        {
            // Use relative luminance to determine if background is dark or light
            // If luminance is high (> 0.5), use black; otherwise use white
            double luminance = backgroundColor.GetLuminance();
            return luminance > 0.5 ? Black : White;
        }

        /// <summary>
        /// Adjusts the foreground color to ensure adequate contrast with the background color, only if necessary.
        /// </summary>
        /// <param name="backgroundColor">The background color.</param>
        /// <param name="minimumContrastRatio">The minimum acceptable contrast ratio (default: 2.5). Common values: 4.5 (AA), 7 (AAA).</param>
        /// <returns>The adjusted foreground color if contrast is inadequate, otherwise the original color.</returns>
        /// <remarks>
        /// This method evaluates the contrast ratio between the current color and the background.
        /// If the contrast is less than the minimum required, it returns either white or black, whichever provides better contrast.
        /// If the contrast is already adequate, the original color is returned unchanged.
        /// </remarks>
        public Color AdjustForegroundColorForContrast(Color backgroundColor, double minimumContrastRatio = 2.5)
        {
            // Calculate current contrast
            double currentContrast = GetContrast(backgroundColor);

            // If contrast is already adequate, return the original color
            if (currentContrast >= minimumContrastRatio)
            {
                return this;
            }

            // Find the closest palette color to the original foreground that meets the minimum contrast.
            // This keeps the visual identity of the foreground color while still improving readability.
            static double Distance(Color first, Color second)
            {
                float rmean = (first.R + second.R) / 2f;
                int r = first.R - second.R;
                int g = first.G - second.G;
                int b = first.B - second.B;
                return Math.Sqrt(
                    ((int)((512 + rmean) * r * r) >> 8)
                    + 4 * g * g
                    + ((int)((767 - rmean) * b * b) >> 8));
            }

            Color? closest = null;
            double closestDistance = double.MaxValue;

            for (int i = 0; i < ColorPalette.EightBit.Count; i++)
            {
                Color candidate = ColorPalette.EightBit[i];
                if (candidate.GetContrast(backgroundColor) < minimumContrastRatio)
                {
                    continue;
                }

                double distance = Distance(candidate, this);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = candidate;
                }
            }

            if (closest.HasValue)
            {
                return closest.Value;
            }

            // Fallback when no palette color reaches the required contrast.
            double whiteContrast = White.GetContrast(backgroundColor);
            double blackContrast = Black.GetContrast(backgroundColor);
            return whiteContrast > blackContrast ? White : Black;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(R, G, B);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Color color && Equals(color);
        }

        /// <inheritdoc/>
        public bool Equals(Color other)
        {
            return (IsDefault && other.IsDefault) ||
                   (IsDefault == other.IsDefault && R == other.R && G == other.G && B == other.B);
        }

        /// <summary>
        /// Checks if two <see cref="Color"/> instances are equal.
        /// </summary>
        /// <param name="left">The first color instance to compare.</param>
        /// <param name="right">The second color instance to compare.</param>
        /// <returns><c>true</c> if the two colors are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if two <see cref="Color"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first color instance to compare.</param>
        /// <param name="right">The second color instance to compare.</param>
        /// <returns><c>true</c> if the two colors are not equal, otherwise <c>false</c>.</returns>
        public static bool operator !=(Color left, Color right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="int"/> to a <see cref="Color"/>.
        /// </summary>
        /// <param name="number">The color number to convert.</param>
        public static implicit operator Color(int number)
        {
            return FromInt32(number);
        }

        /// <summary>
        /// Converts a <see cref="ConsoleColor"/> to a <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        public static implicit operator Color(ConsoleColor color)
        {
            return FromConsoleColor(color);
        }

        /// <summary>
        /// Converts a <see cref="Color"/> to a <see cref="ConsoleColor"/>.
        /// </summary>
        /// <param name="color">The console color to convert.</param>
        public static implicit operator ConsoleColor(Color color)
        {
            return ToConsoleColor(color);
        }

        /// <summary>
        /// Converts a <see cref="Color"/> to a <see cref="ConsoleColor"/>.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>A <see cref="ConsoleColor"/> representing the <see cref="Color"/>.</returns>
        public static ConsoleColor ToConsoleColor(Color color)
        {
            if (color.IsDefault)
            {
                return (ConsoleColor)(-1);
            }

            if (color.Number == null || color.Number.Value >= 16)
            {
                color = ColorPalette.ExactOrClosest(ColorSystem.FourBit, color);
            }

            // Defensive fallback: if Number is still null for any reason,
            // resolve against the first 16 standard entries in the palette.
            if (color.Number is null)
            {
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

                Color closest = ColorPalette.EightBit[0];
                double closestDistance = Distance(closest, color);
                for (int i = 1; i < 16; i++)
                {
                    Color candidate = ColorPalette.EightBit[i];
                    double distance = Distance(candidate, color);
                    if (distance < closestDistance)
                    {
                        closest = candidate;
                        closestDistance = distance;
                    }
                }

                color = closest;
            }

            byte number = color.Number ?? throw new InvalidOperationException("Cannot convert color to console color.");

            return number switch
            {
                0 => ConsoleColor.Black,
                1 => ConsoleColor.DarkRed,
                2 => ConsoleColor.DarkGreen,
                3 => ConsoleColor.DarkYellow,
                4 => ConsoleColor.DarkBlue,
                5 => ConsoleColor.DarkMagenta,
                6 => ConsoleColor.DarkCyan,
                7 => ConsoleColor.Gray,
                8 => ConsoleColor.DarkGray,
                9 => ConsoleColor.Red,
                10 => ConsoleColor.Green,
                11 => ConsoleColor.Yellow,
                12 => ConsoleColor.Blue,
                13 => ConsoleColor.Magenta,
                14 => ConsoleColor.Cyan,
                15 => ConsoleColor.White,
                _ => throw new InvalidOperationException("Cannot convert color to console color."),
            };
        }

        /// <summary>
        /// Converts a color number into a <see cref="Color"/>.
        /// </summary>
        /// <param name="number">The color number.</param>
        /// <returns>The color representing the specified color number.</returns>
        public static Color FromInt32(int number)
        {
            return number < 0 || number > 255
                ? throw new ArgumentException("ColorRGB number must be between 0 and 255")
                : ColorPalette.EightBit[number];
        }

        /// <summary>
        /// Creates a color from a hexadecimal string representation.
        /// </summary>
        /// <param name="hex">The hexadecimal string representation of the color.</param>
        /// <returns>The color created from the hexadecimal string.</returns>
        public static Color FromHex(string hex)
        {
            ArgumentNullException.ThrowIfNull(hex);

            if (hex.StartsWith('#'))
            {
                hex = hex[1..];
            }

            // 3 digit hex codes are expanded to 6 digits
            // by doubling each digit, conform to CSS color codes
            if (hex.Length == 3)
            {
                // string.Create: single allocation vs LINQ enumerator + 3 × new string(c,2)
                hex = string.Create(6, hex, static (span, h) =>
                {
                    span[0] = span[1] = h[0];
                    span[2] = span[3] = h[1];
                    span[4] = span[5] = h[2];
                });
            }

            var r = byte.Parse(hex[..2], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            var g = byte.Parse(hex.AsSpan(2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            var b = byte.Parse(hex.AsSpan(4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);

            return new Color(r, g, b);
        }

        /// <summary>
        /// Tries to convert a hexadecimal color code to a <see cref="Color"/> object.
        /// </summary>
        /// <param name="hex">The hexadecimal color code.</param>
        /// <param name="color">When this method returns, contains the <see cref="Color"/> equivalent of the hexadecimal color code, if the conversion succeeded, or <see cref="Color.Default"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the conversion succeeded; otherwise, <c>false</c>.</returns>
        public static bool TryFromHex(string hex, out Color color)
        {
            try
            {
                color = FromHex(hex);
                return true;
            }
            catch
            {
                color = Color.Default;
                return false;
            }
        }

        /// <summary>
        /// Gets a <see cref="Color"/> from its name.
        /// </summary>
        /// <param name="name">The name of the color.</param>
        /// <returns>The requested <see cref="Color"/> or <c>null</c> if not found.</returns>
        public static Color? FromName(string name)
        {
            return ColorTableCss.TryGetColor(name, out Color cssColor) ? cssColor : null;
        }

        /// <summary>
        /// Converts a <see cref="ConsoleColor"/> to a <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>A <see cref="Color"/> representing the <see cref="ConsoleColor"/>.</returns>
        public static Color FromConsoleColor(ConsoleColor color)
        {
            return color switch
            {
                ConsoleColor.Black => Black,
                ConsoleColor.Blue => Blue,
                ConsoleColor.Cyan => Aqua,
                ConsoleColor.DarkBlue => Navy,
                ConsoleColor.DarkCyan => Teal,
                ConsoleColor.DarkGray => Grey,
                ConsoleColor.DarkGreen => Green,
                ConsoleColor.DarkMagenta => Purple,
                ConsoleColor.DarkRed => Maroon,
                ConsoleColor.DarkYellow => Olive,
                ConsoleColor.Gray => Silver,
                ConsoleColor.Green => Lime,
                ConsoleColor.Magenta => Fuchsia,
                ConsoleColor.Red => Red,
                ConsoleColor.White => White,
                ConsoleColor.Yellow => Yellow,
                _ => Default,
            };
        }

        /// <summary>
        /// Converts the color to a markup string.
        /// </summary>
        /// <returns>A <see cref="string"/> representing the color as markup.</returns>
        public string ToMarkup()
        {
            if (IsDefault)
            {
                return "default";
            }

            if (TryGetCssName(this, out string name))
            {
                return name;
            }

            return $"#{R:X2}{G:X2}{B:X2}";
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (IsDefault)
            {
                return "default";
            }

            if (TryGetCssName(this, out string name))
            {
                return name;
            }

            return $"#{R:X2}{G:X2}{B:X2} (RGB={R},{G},{B})";
        }

        private static bool TryGetCssName(in Color color, out string name)
        {
            return ColorTableCss.TryGetName(color, out name);
        }

    }
}

