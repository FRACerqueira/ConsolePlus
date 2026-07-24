using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // StyleExtensions (Shared/StyleExtensions.cs) — camada 1, unidade pura. Fluent "with"-style
    // helpers used throughout production to derive one Style from another.
    public class StyleExtensionsTests
    {
        private static readonly Style Base = new(new Color(1, 2, 3), new Color(4, 5, 6), Overflow.Crop);

        [Fact]
        public void Colors_with_only_foreground_replaces_foreground_and_keeps_background_and_overflow()
        {
            var result = Base.Colors(new Color(9, 9, 9));

            result.Foreground.Should().Be(new Color(9, 9, 9));
            result.Background.Should().Be(Base.Background);
            result.OverflowStrategy.Should().Be(Base.OverflowStrategy);
        }

        [Fact]
        public void Colors_with_foreground_and_background_replaces_both_and_keeps_overflow()
        {
            var result = Base.Colors(new Color(9, 9, 9), new Color(8, 8, 8));

            result.Foreground.Should().Be(new Color(9, 9, 9));
            result.Background.Should().Be(new Color(8, 8, 8));
            result.OverflowStrategy.Should().Be(Base.OverflowStrategy);
        }

        [Fact]
        public void ForeGround_replaces_only_the_foreground()
        {
            var result = Base.ForeGround(new Color(9, 9, 9));

            result.Foreground.Should().Be(new Color(9, 9, 9));
            result.Background.Should().Be(Base.Background);
            result.OverflowStrategy.Should().Be(Base.OverflowStrategy);
        }

        [Fact]
        public void Background_replaces_only_the_background()
        {
            var result = Base.Background(new Color(9, 9, 9));

            result.Background.Should().Be(new Color(9, 9, 9));
            result.Foreground.Should().Be(Base.Foreground);
            result.OverflowStrategy.Should().Be(Base.OverflowStrategy);
        }

        [Fact]
        public void Overflow_replaces_only_the_overflow_strategy()
        {
            var result = Base.Overflow(Overflow.Ellipsis);

            result.OverflowStrategy.Should().Be(Overflow.Ellipsis);
            result.Foreground.Should().Be(Base.Foreground);
            result.Background.Should().Be(Base.Background);
        }

        [Fact]
        public void Original_style_is_never_mutated_by_any_extension()
        {
            var original = Base;

            _ = Base.Colors(new Color(9, 9, 9));
            _ = Base.ForeGround(new Color(9, 9, 9));
            _ = Base.Background(new Color(9, 9, 9));
            _ = Base.Overflow(Overflow.Ellipsis);

            Base.Should().Be(original);
        }
    }
}
