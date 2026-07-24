using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ColorExtensions.Weighted (Shared/ColorExtensions.cs) — camada 1, unidade pura.
    public class ColorExtensionsTests
    {
        private static readonly Color Base = new(200, 100, 50);

        [Fact]
        public void Weight_zero_interpolates_to_black()
        {
            Base.Weighted(0).Should().Be(new Color(0, 0, 0));
        }

        [Fact]
        public void Weight_500_is_the_rounded_midpoint_between_black_and_the_base_color()
        {
            // r=(200*500+500)/1000=100, g=(100*500+500)/1000=50, b=(50*500+500)/1000=25 (integer division)
            Base.Weighted(500).Should().Be(new Color(100, 50, 25));
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(1500)]
        [InlineData(-1)]
        public void Weight_at_or_above_1000_or_negative_returns_the_original_color_unchanged(int weight)
        {
            Base.Weighted(weight).Should().Be(Base);
        }
    }
}
