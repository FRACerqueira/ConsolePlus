using ConsolePlusLibrary;
using ConsolePlusLibrary.Core;
using ConsolePlusLibrary.Testing;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // DashUtil (Core/DashUtil.cs) — camada 1 lógica, mas depende de IConsole.SupportsUnicode,
    // por isso usa VirtualTerminal (camada 2 mínima) em vez de um double manual.
    public class DashUtilTests
    {
        private static VirtualTerminal Terminal(bool supportsUnicode) => VirtualTerminal.Create(o => o.SupportsUnicode = supportsUnicode);

        // GetBorderUp only returns non-null for the "*UpDown" variants — plain "*Border" options are
        // bottom-only by design and must NOT produce a top border.
        [Theory]
        [InlineData(DashOptions.None)]
        [InlineData(DashOptions.AsciiSingleBorder)]
        [InlineData(DashOptions.AsciiDoubleBorder)]
        [InlineData(DashOptions.SingleBorder)]
        [InlineData(DashOptions.DoubleBorder)]
        [InlineData(DashOptions.HeavyBorder)]
        public void GetBorderUp_is_null_for_bottom_only_and_none_options(DashOptions option)
        {
            DashUtil.GetBorderUp(Terminal(true), option).Should().BeNull();
        }

        [Theory]
        [InlineData(DashOptions.AsciiSingleBorderUpDown, "-")]
        [InlineData(DashOptions.AsciiDoubleBorderUpDown, "=")]
        public void GetBorderUp_ascii_variants_ignore_unicode_support(DashOptions option, string expected)
        {
            DashUtil.GetBorderUp(Terminal(true), option).Should().Be(expected);
            DashUtil.GetBorderUp(Terminal(false), option).Should().Be(expected);
        }

        [Theory]
        [InlineData(DashOptions.SingleBorderUpDown, "─", "-")]
        [InlineData(DashOptions.DoubleBorderUpDown, "═", "=")]
        [InlineData(DashOptions.HeavyBorderUpDown, "━", "*")]
        public void GetBorderUp_unicode_variants_fall_back_to_ascii(DashOptions option, string unicodeGlyph, string asciiFallback)
        {
            DashUtil.GetBorderUp(Terminal(true), option).Should().Be(unicodeGlyph);
            DashUtil.GetBorderUp(Terminal(false), option).Should().Be(asciiFallback);
        }

        [Fact]
        public void GetBorderDown_is_null_only_for_none()
        {
            DashUtil.GetBorderDown(Terminal(true), DashOptions.None).Should().BeNull();
        }

        [Theory]
        [InlineData(DashOptions.AsciiSingleBorder, "-")]
        [InlineData(DashOptions.AsciiSingleBorderUpDown, "-")]
        [InlineData(DashOptions.AsciiDoubleBorder, "=")]
        [InlineData(DashOptions.AsciiDoubleBorderUpDown, "=")]
        public void GetBorderDown_ascii_variants_ignore_unicode_support(DashOptions option, string expected)
        {
            DashUtil.GetBorderDown(Terminal(true), option).Should().Be(expected);
            DashUtil.GetBorderDown(Terminal(false), option).Should().Be(expected);
        }

        [Theory]
        [InlineData(DashOptions.SingleBorder, "─", "-")]
        [InlineData(DashOptions.SingleBorderUpDown, "─", "-")]
        [InlineData(DashOptions.DoubleBorder, "═", "=")]
        [InlineData(DashOptions.DoubleBorderUpDown, "═", "=")]
        [InlineData(DashOptions.HeavyBorder, "━", "*")]
        [InlineData(DashOptions.HeavyBorderUpDown, "━", "*")]
        public void GetBorderDown_unicode_variants_fall_back_to_ascii(DashOptions option, string unicodeGlyph, string asciiFallback)
        {
            DashUtil.GetBorderDown(Terminal(true), option).Should().Be(unicodeGlyph);
            DashUtil.GetBorderDown(Terminal(false), option).Should().Be(asciiFallback);
        }

        // Every bottom-border-bearing option must also produce a top border once paired with the
        // "UpDown" variant, and the glyph must be identical on both sides.
        [Theory]
        [InlineData(DashOptions.SingleBorderUpDown)]
        [InlineData(DashOptions.DoubleBorderUpDown)]
        [InlineData(DashOptions.HeavyBorderUpDown)]
        [InlineData(DashOptions.AsciiSingleBorderUpDown)]
        [InlineData(DashOptions.AsciiDoubleBorderUpDown)]
        public void UpDown_variants_use_the_same_glyph_on_both_sides(DashOptions option)
        {
            var vt = Terminal(true);
            DashUtil.GetBorderUp(vt, option).Should().Be(DashUtil.GetBorderDown(vt, option));
        }
    }
}
