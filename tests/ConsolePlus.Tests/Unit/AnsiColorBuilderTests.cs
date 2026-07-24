using ConsolePlusLibrary;
using ConsolePlusLibrary.ConsoleAbstractions;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // AnsiColorBuilder.Build (ConsoleAbstractions/AnsiColorBuilder.cs) — camada 1, sem VirtualTerminal.
    // Color(255,0,0) matches palette index 9 in both the Standard and FourBit tables
    // (ColorPalette.cs:128,140 — Color equality only compares R/G/B, ignoring Number).
    public class AnsiColorBuilderTests
    {
        private static readonly Color Red = new(255, 0, 0);

        [Fact]
        public void TrueColor_emits_38_2_and_48_2_rgb_bytes()
        {
            AnsiColorBuilder.Build(ColorSystem.TrueColor, Red, foreground: true).Should().Equal(38, 2, 255, 0, 0);
            AnsiColorBuilder.Build(ColorSystem.TrueColor, Red, foreground: false).Should().Equal(48, 2, 255, 0, 0);
        }

        [Fact]
        public void Standard_8bit_emits_38_5_and_48_5_with_palette_index_9()
        {
            AnsiColorBuilder.Build(ColorSystem.Standard, Red, foreground: true).Should().Equal(38, 5, 9);
            AnsiColorBuilder.Build(ColorSystem.Standard, Red, foreground: false).Should().Equal(48, 5, 9);
        }

        [Fact]
        public void FourBit_emits_bright_red_codes_91_foreground_101_background()
        {
            // Index 9 is "bright red" (indices 8-15) -> fg offset 82 (=90-8), bg offset 92 (=100-8).
            AnsiColorBuilder.Build(ColorSystem.FourBit, Red, foreground: true).Should().Equal(91);
            AnsiColorBuilder.Build(ColorSystem.FourBit, Red, foreground: false).Should().Equal(101);
        }

        [Fact]
        public void Default_color_emits_no_bytes_at_any_depth()
        {
            AnsiColorBuilder.Build(ColorSystem.TrueColor, Color.Default, foreground: true).Should().BeEmpty();
            AnsiColorBuilder.Build(ColorSystem.NoColors, Red, foreground: true).Should().BeEmpty();
        }
    }
}
