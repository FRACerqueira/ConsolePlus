// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Provides extension methods for <see cref="Color"/>.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Gets a weighted variation of a CSS base color.
        /// </summary>
        /// <param name="color">Base color instance (must map to a CSS named color).</param>
        /// <param name="weight">
        /// Weight in the range 0-1000. The value is mapped to the nearest proportional weighted step.
        /// Values greater than or equal to 1000 return the original color.
        /// </param>
        /// <returns>The weighted variation, or the original color if weight is out of range.</returns>
        public static Color Weighted(this Color color, int weight)
        {
            if (weight >= 1000 || weight < 0)
            {
                return color;
            }
            // Weighted interpolation from black (0) to base color (1000).
            byte r = (byte)Math.Clamp((color.R * weight + 500) / 1000, 0, 255);
            byte g = (byte)Math.Clamp((color.G * weight + 500) / 1000, 0, 255);
            byte b = (byte)Math.Clamp((color.B * weight + 500) / 1000, 0, 255);
            return new Color(r, g, b);
        }
    }
}
