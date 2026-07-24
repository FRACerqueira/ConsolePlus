using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Markup.Escape/Remove/Length (Shared/Markup.cs) — camada 1, unidade pura. Built on top of
    // MarkupColorTokenizer (already covered in MarkupColorTokenizerTests).
    public class MarkupHelperTests
    {
        [Fact]
        public void Escape_doubles_every_bracket_character()
        {
            Markup.Escape("[hello]").Should().Be("[[hello]]");
        }

        [Fact]
        public void Escape_returns_plain_text_unchanged_when_there_are_no_brackets()
        {
            Markup.Escape("hello").Should().Be("hello");
        }

        [Fact]
        public void Escape_of_null_is_empty_string()
        {
            Markup.Escape(null).Should().Be("");
        }

        [Fact]
        public void Remove_strips_a_real_color_tag_and_keeps_the_inner_text()
        {
            Markup.Remove("[red]Hi[/]").Should().Be("Hi");
        }

        [Fact]
        public void Remove_of_plain_text_without_brackets_returns_it_unchanged()
        {
            Markup.Remove("hello").Should().Be("hello");
        }

        [Fact]
        public void Remove_undoes_Escape_for_text_that_contains_literal_brackets()
        {
            string original = "[hello]";
            Markup.Remove(Markup.Escape(original)).Should().Be(original);
        }

        [Fact]
        public void Remove_of_null_or_whitespace_is_empty_string()
        {
            Markup.Remove(null).Should().Be("");
            Markup.Remove("   ").Should().Be("");
        }

        [Fact]
        public void Length_of_a_tagged_string_counts_only_the_visible_text()
        {
            Markup.Length("[red]Hi[/]").Should().Be(2);
        }

        [Fact]
        public void Length_of_plain_text_equals_its_raw_length()
        {
            Markup.Length("hello").Should().Be(5);
        }

        [Fact]
        public void Length_matches_the_length_of_Remove_for_escaped_brackets()
        {
            string escaped = Markup.Escape("[hello]");
            Markup.Length(escaped).Should().Be(Markup.Remove(escaped).Length);
        }

        [Fact]
        public void Extension_method_aliases_delegate_to_the_static_helpers()
        {
            "[red]Hi[/]".RemoveMarkup().Should().Be(Markup.Remove("[red]Hi[/]"));
            "[hello]".EscapeMarkup().Should().Be(Markup.Escape("[hello]"));
            "[red]Hi[/]".LengthMarkup().Should().Be(Markup.Length("[red]Hi[/]"));
        }
    }
}
