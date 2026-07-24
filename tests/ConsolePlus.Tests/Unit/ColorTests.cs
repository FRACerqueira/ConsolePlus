using ConsolePlusLibrary;
using FluentAssertions;
using System;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Color (Shared/Color.cs) — camada 1, unidade pura: Blend, luminance/contrast (WCAG), hex
    // parsing, numeric/ConsoleColor conversions.
    public class ColorTests
    {
        [Fact]
        public void Blend_at_factor_zero_returns_the_original_color()
        {
            var black = new Color(0, 0, 0);
            black.Blend(new Color(255, 255, 255), 0f).Should().Be(black);
        }

        [Fact]
        public void Blend_at_factor_one_returns_the_other_color()
        {
            var black = new Color(0, 0, 0);
            var white = new Color(255, 255, 255);
            black.Blend(white, 1f).Should().Be(white);
        }

        [Fact]
        public void Blend_at_half_factor_returns_the_midpoint()
        {
            new Color(0, 0, 0).Blend(new Color(255, 255, 255), 0.5f).Should().Be(new Color(127, 127, 127));
        }

        [Fact]
        public void Pure_black_has_zero_luminance_and_pure_white_has_full_luminance()
        {
            new Color(0, 0, 0).GetLuminance().Should().Be(0);
            new Color(255, 255, 255).GetLuminance().Should().Be(1);
        }

        [Fact]
        public void Black_and_white_have_the_maximum_WCAG_contrast_ratio_of_21()
        {
            new Color(0, 0, 0).GetContrast(new Color(255, 255, 255)).Should().BeApproximately(21.0, 0.0001);
        }

        [Fact]
        public void GetContrast_is_symmetric_regardless_of_which_color_is_lighter()
        {
            var black = new Color(0, 0, 0);
            var white = new Color(255, 255, 255);
            black.GetContrast(white).Should().Be(white.GetContrast(black));
        }

        [Fact]
        public void A_color_has_no_contrast_against_itself()
        {
            new Color(120, 40, 200).GetContrast(new Color(120, 40, 200)).Should().BeApproximately(1.0, 0.0001);
        }

        // Regression for a real bug found while writing this suite: GetInvertedColor compared
        // GetLuminance() (WCAG scale, 0-1) against a 0-255-scale threshold (140), so the condition
        // was always true and it returned White for every color. Fixed to use the same 0.5
        // threshold GetContrastForegroundColor already used correctly on the same scale.
        [Fact]
        public void GetInvertedColor_returns_black_for_a_light_background_and_white_for_a_dark_one()
        {
            new Color(255, 255, 255).GetInvertedColor().Should().Be(new Color(0, 0, 0));
            new Color(0, 0, 0).GetInvertedColor().Should().Be(new Color(255, 255, 255));
        }

        [Fact]
        public void GetContrastForegroundColor_picks_black_on_light_backgrounds_and_white_on_dark_ones()
        {
            Color.GetContrastForegroundColor(new Color(255, 255, 255)).Should().Be(new Color(0, 0, 0));
            Color.GetContrastForegroundColor(new Color(0, 0, 0)).Should().Be(new Color(255, 255, 255));
        }

        [Fact]
        public void AdjustForegroundColorForContrast_keeps_the_original_color_when_contrast_is_already_adequate()
        {
            var white = new Color(255, 255, 255);
            var black = new Color(0, 0, 0);

            white.AdjustForegroundColorForContrast(black, minimumContrastRatio: 2.5).Should().Be(white);
        }

        [Fact]
        public void AdjustForegroundColorForContrast_returns_a_color_that_meets_the_minimum_ratio_when_inadequate()
        {
            // Two very close grays start with poor contrast; the adjusted result must clear the bar.
            var foreground = new Color(130, 130, 130);
            var background = new Color(120, 120, 120);
            foreground.GetContrast(background).Should().BeLessThan(2.5);

            Color adjusted = foreground.AdjustForegroundColorForContrast(background, minimumContrastRatio: 2.5);

            adjusted.GetContrast(background).Should().BeGreaterThanOrEqualTo(2.5);
        }

        [Fact]
        public void ToHex_formats_each_channel_as_two_uppercase_hex_digits()
        {
            new Color(255, 0, 128).ToHex().Should().Be("FF0080");
        }

        [Fact]
        public void FromHex_parses_a_six_digit_code_with_or_without_the_hash()
        {
            Color.FromHex("#FF0080").Should().Be(new Color(255, 0, 128));
            Color.FromHex("FF0080").Should().Be(new Color(255, 0, 128));
        }

        [Fact]
        public void FromHex_expands_a_three_digit_shorthand_by_doubling_each_digit()
        {
            // "F08" -> "FF0088"
            Color.FromHex("F08").Should().Be(new Color(255, 0, 136));
        }

        [Fact]
        public void TryFromHex_returns_false_and_the_default_color_for_invalid_input()
        {
            bool ok = Color.TryFromHex("not-a-color", out Color color);

            ok.Should().BeFalse();
            color.Should().Be(Color.Default);
        }

        [Fact]
        public void FromInt32_out_of_range_throws()
        {
            Action tooLow = () => Color.FromInt32(-1);
            Action tooHigh = () => Color.FromInt32(256);

            tooLow.Should().Throw<ArgumentException>();
            tooHigh.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void FromConsoleColor_and_ToConsoleColor_round_trip_for_all_16_standard_colors()
        {
            foreach (ConsoleColor cc in Enum.GetValues<ConsoleColor>())
            {
                Color color = Color.FromConsoleColor(cc);
                Color.ToConsoleColor(color).Should().Be(cc, because: $"{cc} should round-trip through Color");
            }
        }
    }
}
