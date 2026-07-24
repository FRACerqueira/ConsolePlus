using ConsolePlusLibrary;
using ConsolePlusLibrary.Core;
using FluentAssertions;
using System;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ColorPalette (Core/ColorPalette.cs) — camada 1, unidade pura. Casamento exato/mais próximo
    // de cor para as profundidades FourBit/Standard/TrueColor.
    public class ColorPaletteTests
    {
        [Fact]
        public void EightBit_palette_has_exactly_256_entries()
        {
            ColorPalette.EightBit.Should().HaveCount(256);
        }

        [Fact]
        public void TrueColor_returns_the_input_color_unchanged()
        {
            var color = new Color(37, 201, 88);
            ColorPalette.ExactOrClosest(ColorSystem.TrueColor, color).Should().Be(color);
        }

        [Fact]
        public void Exact_match_is_found_for_a_color_already_in_the_Standard_palette()
        {
            var red = new Color(255, 0, 0);
            ColorPalette.ExactOrClosest(ColorSystem.FourBit, red).Should().Be(red);
        }

        [Fact]
        public void Exact_match_is_found_for_a_color_already_in_the_EightBit_palette()
        {
            var red = new Color(255, 0, 0);
            ColorPalette.ExactOrClosest(ColorSystem.Standard, red).Should().Be(red);
        }

        [Fact]
        public void Closest_match_snaps_a_near_black_color_to_pure_black_on_FourBit()
        {
            ColorPalette.ExactOrClosest(ColorSystem.FourBit, new Color(1, 1, 1)).Should().Be(new Color(0, 0, 0));
        }

        [Fact]
        public void Closest_match_snaps_a_color_to_its_nearest_EightBit_cube_entry()
        {
            // xterm cube levels are [0,95,135,175,215,255]; 96 rounds to the 95 level on every channel.
            ColorPalette.ExactOrClosest(ColorSystem.Standard, new Color(96, 96, 96)).Should().Be(new Color(95, 95, 95));
        }

        [Fact]
        public void Unsupported_color_system_throws()
        {
            Action act = () => ColorPalette.ExactOrClosest(ColorSystem.NoColors, new Color(1, 2, 3));
            act.Should().Throw<ArgumentException>();
        }
    }
}
