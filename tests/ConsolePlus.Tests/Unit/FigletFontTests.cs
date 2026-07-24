using ConsolePlusLibrary;
using ConsolePlusLibrary.Figlet;
using FluentAssertions;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // FigletFont (Figlet/FigletFont.cs) — camada 1, unidade pura. Parser do formato .flf (FIGlet
    // font). Fixtures são fontes .flf mínimas construídas em memória (Stream), sem tocar o recurso
    // embutido real nem o disco.
    public class FigletFontTests
    {
        // Minimal valid .flf: signature "flf2a", hardblank '$', Height=1 (one line per glyph),
        // CommentLines=0. Two glyphs defined: space (32) -> "..", '!' (33) -> "# #" (with a
        // hardblank in the middle, to verify substitution). Each raw line ends with the FIGlet
        // line-terminator '@', which GetCharacter strips via TrimEnd on the line's last char.
        private static Stream MinimalFont()
        {
            string flf = string.Join('\n',
                "flf2a$ 1 1 5 0 0 0 0 0",
                "..@",   // space (32)
                "#$#@"); // '!' (33), hardblank in the middle
            return new MemoryStream(Encoding.UTF8.GetBytes(flf));
        }

        [Fact]
        public void Loads_header_fields_from_the_config_line()
        {
            var font = new FigletFont(MinimalFont());

            font.Signature.Should().Be("flf2a");
            font.HardBlank.Should().Be("$");
            font.Height.Should().Be(1);
            font.BaseLine.Should().Be(1);
            font.MaxLenght.Should().Be(5);
            font.CommentLines.Should().Be(0);
        }

        [Fact]
        public void ToAsciiArt_renders_a_known_glyph_and_strips_the_line_terminator()
        {
            var font = new FigletFont(MinimalFont());

            string[] art = font.ToAsciiArt(" ");

            art.Should().HaveCount(1); // Height=1
            art[0].Should().Be(".."); // '@' terminator stripped
        }

        [Fact]
        public void ToAsciiArt_replaces_the_hardblank_character_with_a_space()
        {
            var font = new FigletFont(MinimalFont());

            string[] art = font.ToAsciiArt("!");

            art[0].Should().Be("# #"); // '$' (hardblank) -> ' '
        }

        [Fact]
        public void ToAsciiArt_concatenates_glyphs_for_each_character_in_order()
        {
            var font = new FigletFont(MinimalFont());

            string[] art = font.ToAsciiArt("! ");

            art[0].Should().Be("# #" + "..");
        }

        [Fact]
        public void ToAsciiArtMarkup_emits_one_content_fragment_per_input_segment_plus_a_line_break_per_row()
        {
            var font = new FigletFont(MinimalFont());
            var style = new Style(new Color(1, 2, 3), new Color(4, 5, 6));

            Fragment[] fragments = font.ToAsciiArtMarkup("!", style);

            fragments.Should().HaveCount(2); // 1 content row (Height=1) + 1 line break
            fragments[0].Type.Should().Be(FragmentKind.ContentText);
            fragments[0].Text.Should().Be("# #");
            fragments[0].Style.Should().Be(style);
            fragments[1].Type.Should().Be(FragmentKind.LineBreak);
        }

        [Fact]
        public void Stream_constructor_wraps_a_bad_signature_in_InvalidDataException()
        {
            var badFont = new MemoryStream(Encoding.UTF8.GetBytes("notflf 1 1 5 0 0 0 0 0\n"));

            Action act = () => new FigletFont(badFont);

            act.Should().Throw<InvalidDataException>()
                .WithInnerException<ArgumentException>();
        }

        [Fact]
        public void Path_constructor_throws_ArgumentNullException_for_null_or_empty_path()
        {
            Action act = () => new FigletFont(string.Empty);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Path_constructor_wraps_a_missing_file_in_FileNotFoundException()
        {
            // Cross-platform "definitely does not exist" path (random subfolder under temp),
            // avoiding a Windows-only drive letter so this holds on Linux too.
            string missingPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"), "font.flf");

            Action act = () => new FigletFont(missingPath);

            act.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void Parameterless_constructor_loads_the_embedded_Standard_font_and_renders_text()
        {
            var font = new FigletFont();

            font.Signature.Should().Be("flf2a");
            font.Height.Should().BeGreaterThan(0);

            string[] art = font.ToAsciiArt("Hi");
            art.Should().HaveCount(font.Height);
            art.Should().Contain(line => line.Trim().Length > 0);
        }

        [Fact]
        public void CommentLines_are_skipped_before_the_first_glyph_is_read()
        {
            string flf = string.Join('\n',
                "flf2a$ 1 1 5 0 2 0 0 0", // CommentLines=2
                "this is a comment",
                "so is this",
                "XX@"); // space glyph (32)
            var font = new FigletFont(new MemoryStream(Encoding.UTF8.GetBytes(flf)));

            font.ToAsciiArt(" ")[0].Should().Be("XX");
        }
    }
}
