// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents a text rendering style consisting of a foreground color, background color and an overflow strategy.
    /// </summary>
    /// <remarks>
    /// Use the primary constructor to specify explicit colors and an <see cref="Overflow"/> strategy, or the
    /// </remarks>
    /// <param name="foreground">Foreground <see cref="Color"/> used when writing content.</param>
    /// <param name="background">Background <see cref="Color"/> used behind the content.</param>
    /// <param name="overflowStrategy">Overflow handling strategy applied when content exceeds the target width.</param>
    public readonly struct Style(Color foreground, Color background , Overflow overflowStrategy = Overflow.None) : IEquatable<Style>
    {
        /// <summary>
        /// Gets the foreground <see cref="Color"/>.
        /// </summary>
        public Color Foreground { get; } = foreground;

        /// <summary>
        /// Gets the background <see cref="Color"/>.
        /// </summary>
        public Color Background { get; } = background;

        /// <summary>
        /// Gets the <see cref="Overflow"/> strategy applied when content exceeds the available width.
        /// </summary>
        public Overflow OverflowStrategy { get; } = overflowStrategy;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Foreground, Background, OverflowStrategy);

        /// <summary>
        /// Determines whether this instance is equal to another <see cref="Style"/>.
        /// </summary>
        /// <param name="other">The style to compare.</param>
        /// <returns><c>true</c> if all components match; otherwise, <c>false</c>.</returns>
        public bool Equals(Style other) => Foreground.Equals(other.Foreground) &&
                                           Background.Equals(other.Background) &&
                                           OverflowStrategy == other.OverflowStrategy;

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Style style && Equals(style);

        /// <summary>
        /// Determines whether two <see cref="Style"/> instances are equal.
        /// </summary>
        /// <param name="left">The first style.</param>
        /// <param name="right">The second style.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Style left, Style right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="Style"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first style.</param>
        /// <param name="right">The second style.</param>
        /// <returns><c>true</c> if not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Style left, Style right) => !(left == right);

        /// <summary>
        /// Converts a <see cref="Color"/> to a <see cref="Style"/> using the color as foreground.
        /// </summary>
        /// <param name="color">The foreground color.</param>
        public static implicit operator Style(Color color) => new(color, Color.Default);
    }
}
