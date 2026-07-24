using ConsolePlusLibrary;
using FluentAssertions;
using System.Text;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // string.GetDisplayLength (Shared/StringExtensions.cs:59) — camada 1, sem VirtualTerminal.
    public class DisplayLengthTests
    {
        [Fact]
        public void Ascii_text_counts_one_column_per_character()
        {
            "abc".GetDisplayLength().Should().Equal(3);
        }

        [Fact]
        public void Cjk_character_counts_as_two_columns_wide()
        {
            // U+4E2D falls in the 0x3040-0xA4CF wide-rune range (StringExtensions.cs:112).
            "中".GetDisplayLength().Should().Equal(2);
        }

        [Fact]
        public void Multiline_text_returns_one_length_per_line()
        {
            "ab\ncd".GetDisplayLength().Should().Equal(2, 2);
        }

        [Fact]
        public void TruncateToDisplayWidth_keeps_ascii_text_unchanged_when_it_fits()
        {
            "abc".TruncateToDisplayWidth(10).Should().Be("abc");
        }

        [Fact]
        public void TruncateToDisplayWidth_never_splits_a_wide_rune_in_half()
        {
            // Each of these 8 Hangul syllables is 2 display columns. A budget of 5 columns must stop
            // at 2 whole syllables (4 columns) rather than including half of a third.
            "가나다라마바사아".TruncateToDisplayWidth(5).Should().Be("가나");
        }

        [Fact]
        public void TruncateToDisplayWidth_uses_the_full_budget_when_it_lands_on_a_rune_boundary()
        {
            "가나다라마바사아".TruncateToDisplayWidth(6).Should().Be("가나다");
        }

        [Fact]
        public void TruncateToDisplayWidth_returns_input_unchanged_when_it_already_fits()
        {
            "가나다".TruncateToDisplayWidth(10).Should().Be("가나다");
        }

        [Fact]
        public void TruncateToDisplayWidth_returns_empty_for_non_positive_budget()
        {
            "abc".TruncateToDisplayWidth(0).Should().Be("");
        }

        [Fact]
        public void TruncateToDisplayWidth_returns_empty_for_null_or_empty_input()
        {
            ((string?)null).TruncateToDisplayWidth(10).Should().Be("");
            "".TruncateToDisplayWidth(10).Should().Be("");
        }

        [Fact]
        public void GetRuneWidth_returns_one_for_an_ascii_rune()
        {
            new Rune('a').GetRuneWidth().Should().Be(1);
        }

        [Fact]
        public void GetRuneWidth_returns_two_for_a_cjk_wide_rune()
        {
            new Rune('가').GetRuneWidth().Should().Be(2);
        }

        [Fact]
        public void GetRuneWidth_returns_zero_for_a_non_spacing_combining_mark()
        {
            // U+0301 COMBINING ACUTE ACCENT — NonSpacingMark, occupies no column of its own.
            new Rune(0x0301).GetRuneWidth().Should().Be(0);
        }
    }
}
