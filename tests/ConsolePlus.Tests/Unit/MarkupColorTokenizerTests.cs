using ConsolePlusLibrary.Core;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // MarkupColorTokenizer (Core/MarkupColorTokenizer.cs) — camada 1, unidade pura. Parser
    // caractere-a-caractere por trás de Fragment.FromText; fault-tolerant por design (markup
    // malformado degrada para texto puro em vez de lançar).
    public class MarkupColorTokenizerTests
    {
        [Fact]
        public void Empty_text_has_no_tokens()
        {
            var tokenizer = new MarkupColorTokenizer("");
            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Null_text_is_treated_as_empty()
        {
            var tokenizer = new MarkupColorTokenizer(null!);
            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Plain_text_without_brackets_is_a_single_text_token()
        {
            var tokenizer = new MarkupColorTokenizer("hello");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("hello");
            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Well_formed_tag_is_an_open_token_with_the_tag_content()
        {
            var tokenizer = new MarkupColorTokenizer("[red]");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Open);
            tokenizer.Current.Value.Should().Be("red");
        }

        [Fact]
        public void Empty_tag_brackets_produce_an_open_token_with_empty_content()
        {
            var tokenizer = new MarkupColorTokenizer("[]");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Open);
            tokenizer.Current.Value.Should().Be("");
        }

        [Fact]
        public void Close_tag_is_a_close_token_with_empty_value()
        {
            var tokenizer = new MarkupColorTokenizer("[/]");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Close);
            tokenizer.Current.Value.Should().Be("");
        }

        [Fact]
        public void Full_sequence_yields_open_text_close_in_order()
        {
            var tokenizer = new MarkupColorTokenizer("[red]Hi[/]");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Open);
            tokenizer.Current.Value.Should().Be("red");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("Hi");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Close);

            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Double_open_bracket_is_an_escaped_literal_open_bracket()
        {
            var tokenizer = new MarkupColorTokenizer("[[");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("[");
            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Double_close_bracket_inside_text_collapses_to_a_single_literal_close_bracket()
        {
            var tokenizer = new MarkupColorTokenizer("a]]b");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("a]b");
        }

        [Fact]
        public void Single_unescaped_close_bracket_mid_text_is_kept_as_is()
        {
            var tokenizer = new MarkupColorTokenizer("a]b");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Value.Should().Be("a]b");
        }

        [Fact]
        public void Trailing_lone_close_bracket_is_treated_as_normal_text()
        {
            var tokenizer = new MarkupColorTokenizer("abc]");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("abc]");
        }

        [Fact]
        public void Open_bracket_at_end_of_input_is_literal_text()
        {
            var tokenizer = new MarkupColorTokenizer("hi[");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Value.Should().Be("hi");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("[");

            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Slash_at_end_of_input_right_after_open_bracket_is_literal_text()
        {
            var tokenizer = new MarkupColorTokenizer("[/");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("[/");
        }

        [Fact]
        public void Malformed_close_tag_not_immediately_followed_by_bracket_is_swallowed_as_literal_text()
        {
            // "[/x]" is not a valid close tag ('/' must be followed immediately by ']'); the whole
            // malformed run, including its own closing bracket, is emitted as one text token.
            var tokenizer = new MarkupColorTokenizer("[/x][y]");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("[/x]");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Open);
            tokenizer.Current.Value.Should().Be("y");
        }

        [Fact]
        public void Unterminated_open_tag_at_end_of_input_is_literal_text()
        {
            var tokenizer = new MarkupColorTokenizer("[tag");
            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("[tag");
        }

        [Fact]
        public void Open_tag_interrupted_by_another_bracket_recovers_on_the_next_token()
        {
            // "[tag[next]" is malformed (no closing ']' for "tag" before the next '['); the partial
            // run becomes text, and tokenization resumes cleanly from the following '['.
            var tokenizer = new MarkupColorTokenizer("[tag[next]");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Text);
            tokenizer.Current.Value.Should().Be("[tag");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Kind.Should().Be(MarkupColorKind.Open);
            tokenizer.Current.Value.Should().Be("next");

            tokenizer.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void Token_position_points_at_the_start_of_the_token_in_the_source_text()
        {
            var tokenizer = new MarkupColorTokenizer("ab[red]");

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Position.Should().Be(0);

            tokenizer.MoveNext().Should().BeTrue();
            tokenizer.Current!.Position.Should().Be(2);
        }
    }
}
