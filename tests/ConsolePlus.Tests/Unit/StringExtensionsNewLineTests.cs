using ConsolePlusLibrary;
using FluentAssertions;
using System;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // StringExtensions.NormalizeNewLines/SplitLines (Shared/StringExtensions.cs) — behavior is
    // explicitly dependent on Environment.NewLine, so assertions use Environment.NewLine instead of
    // a hardcoded "\r\n" to work on both Windows and Linux.
    public class StringExtensionsNewLineTests
    {
        [Fact]
        public void Null_text_normalizes_to_empty_string()
        {
            ((string?)null).NormalizeNewLines().Should().Be("");
        }

        [Fact]
        public void Text_without_any_newline_is_returned_as_is()
        {
            "hello".NormalizeNewLines().Should().Be("hello");
        }

        [Fact]
        public void Bare_lf_is_converted_to_the_platform_newline()
        {
            "a\nb".NormalizeNewLines().Should().Be("a" + Environment.NewLine + "b");
        }

        [Fact]
        public void Crlf_is_converted_to_the_platform_newline()
        {
            "a\r\nb".NormalizeNewLines().Should().Be("a" + Environment.NewLine + "b");
        }

        [Fact]
        public void Lone_cr_is_stripped_without_being_replaced_by_a_newline()
        {
            // Old-Mac-style bare '\r' has no corresponding '\n' for the second Replace to act on,
            // so it is simply removed rather than converted — the line break is lost.
            "a\rb".NormalizeNewLines().Should().Be("ab");
        }

        [Fact]
        public void Mixed_line_endings_all_normalize_to_the_platform_newline()
        {
            string result = "a\r\nb\nc\r\nd".NormalizeNewLines();
            result.Should().Be(string.Join(Environment.NewLine, "a", "b", "c", "d"));
        }

        [Fact]
        public void SplitLines_splits_on_any_newline_style_regardless_of_platform()
        {
            "a\nb\r\nc".SplitLines().Should().Equal("a", "b", "c");
        }

        [Fact]
        public void SplitLines_of_a_single_line_returns_one_element()
        {
            "hello".SplitLines().Should().Equal("hello");
        }

        [Fact]
        public void SplitLines_of_null_does_not_throw_and_yields_one_empty_element()
        {
            ((string)null!).SplitLines().Should().Equal("");
        }
    }
}
