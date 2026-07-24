using ConsolePlusLibrary;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Fragment.FromText (Shared/Fragment.cs:74) — camada 1, sem VirtualTerminal.
    public class MarkupTests
    {
        private static readonly Style DefaultStyle = new(Color.White, Color.Black);

        [Fact]
        public void Named_color_tag_overrides_foreground_and_resets_on_close()
        {
            Fragment[] fragments = Fragment.FromText("[red]Hi[/]", DefaultStyle);

            fragments.Should().HaveCount(1);
            fragments[0].Text.Should().Be("Hi");
            fragments[0].Style!.Value.Foreground.Should().Be(new Color(255, 0, 0));
            fragments[0].Style!.Value.Background.Should().Be(DefaultStyle.Background);
        }

        [Fact]
        public void Hex_color_tag_sets_exact_rgb_foreground()
        {
            Fragment[] fragments = Fragment.FromText("[#00FF00]Hi[/]", DefaultStyle);

            fragments.Should().HaveCount(1);
            fragments[0].Style!.Value.Foreground.Should().Be(new Color(0, 255, 0));
        }

        [Fact]
        public void On_keyword_sets_background_instead_of_foreground()
        {
            Fragment[] fragments = Fragment.FromText("[red on #00FF00]Hi[/]", DefaultStyle);

            fragments[0].Style!.Value.Foreground.Should().Be(new Color(255, 0, 0));
            fragments[0].Style!.Value.Background.Should().Be(new Color(0, 255, 0));
        }

        [Fact]
        public void Plain_text_without_markup_delimiters_keeps_default_style()
        {
            Fragment[] fragments = Fragment.FromText("Hello", DefaultStyle);

            fragments.Should().HaveCount(1);
            fragments[0].Text.Should().Be("Hello");
            fragments[0].Style.Should().Be(DefaultStyle);
        }

        [Fact]
        public void Unknown_color_token_falls_back_to_raw_text_with_the_brackets_kept()
        {
            // ResolveColorToken("not-a-color") finds no match, and it's not color-like syntax
            // (no '#', no rgb(...)), so Fragment.FromText keeps the literal "[not-a-color]" as text.
            Fragment[] fragments = Fragment.FromText("[not-a-color]Hi[/]", DefaultStyle);

            string joined = string.Concat(fragments.Select(f => f.Text));
            joined.Should().Contain("[not-a-color]").And.Contain("Hi");
        }
    }
}
