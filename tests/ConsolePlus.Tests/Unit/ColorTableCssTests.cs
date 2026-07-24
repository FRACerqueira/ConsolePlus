using ConsolePlusLibrary;
using ConsolePlusLibrary.Core;
using FluentAssertions;
using System;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ColorTableCss (Core/ColorTableCss.cs) — camada 1, unidade pura. Tabela de nomes CSS e
    // resolução de variantes com peso (ex.: "red500").
    public class ColorTableCssTests
    {
        [Fact]
        public void TryGetColor_resolves_a_known_css_name()
        {
            ColorTableCss.TryGetColor("red", out Color color).Should().BeTrue();
            color.Should().Be(new Color(255, 0, 0));
        }

        [Fact]
        public void TryGetColor_is_case_insensitive()
        {
            ColorTableCss.TryGetColor("RED", out Color color).Should().BeTrue();
            color.Should().Be(new Color(255, 0, 0));
        }

        [Fact]
        public void TryGetColor_returns_false_for_an_unknown_name()
        {
            ColorTableCss.TryGetColor("not-a-real-color", out _).Should().BeFalse();
        }

        [Fact]
        public void TryGetColor_throws_on_null_name()
        {
            Action act = () => ColorTableCss.TryGetColor(null!, out _);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TryGetName_round_trips_through_TryGetColor_even_for_rgb_values_shared_by_multiple_names()
        {
            // aqua and cyan share the exact same RGB (0,255,255); whichever name TryGetName picks,
            // it must resolve back to that same color via TryGetColor (no assumption about which wins).
            ColorTableCss.TryGetColor("aqua", out Color aqua).Should().BeTrue();

            ColorTableCss.TryGetName(aqua, out string name).Should().BeTrue();
            ColorTableCss.TryGetColor(name, out Color resolved).Should().BeTrue();
            resolved.Should().Be(aqua);
        }

        [Fact]
        public void TryGetName_returns_false_for_a_color_with_no_css_name()
        {
            ColorTableCss.TryGetName(new Color(1, 2, 3), out _).Should().BeFalse();
        }

        [Fact]
        public void TryGetWeightedColor_at_weight_1000_matches_the_base_color()
        {
            ColorTableCss.TryGetWeightedColor("red1000", out Color color).Should().BeTrue();
            color.Should().Be(new Color(255, 0, 0));
        }

        [Fact]
        public void TryGetWeightedColor_at_weight_0_is_black()
        {
            ColorTableCss.TryGetWeightedColor("red0", out Color color).Should().BeTrue();
            color.Should().Be(new Color(0, 0, 0));
        }

        [Fact]
        public void TryGetWeightedColor_at_weight_500_is_the_rounded_midpoint()
        {
            // r=(255*500+500)/1000=128 (integer division); g and b stay 0 for pure red.
            ColorTableCss.TryGetWeightedColor("red500", out Color color).Should().BeTrue();
            color.Should().Be(new Color(128, 0, 0));
        }

        [Fact]
        public void TryGetWeightedColor_clamps_weight_above_1000_to_the_base_color()
        {
            ColorTableCss.TryGetWeightedColor("red9999", out Color color).Should().BeTrue();
            color.Should().Be(new Color(255, 0, 0));
        }

        [Fact]
        public void TryGetWeightedColor_returns_false_without_a_trailing_numeric_weight()
        {
            ColorTableCss.TryGetWeightedColor("darkred", out _).Should().BeFalse();
        }

        [Fact]
        public void TryGetWeightedColor_returns_false_for_an_unknown_base_name()
        {
            ColorTableCss.TryGetWeightedColor("notacolor500", out _).Should().BeFalse();
        }

        [Fact]
        public void TryGetWeightedColor_returns_false_for_names_shorter_than_four_characters()
        {
            ColorTableCss.TryGetWeightedColor("red", out _).Should().BeFalse();
        }
    }
}
