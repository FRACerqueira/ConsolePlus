using ConsolePlusLibrary;
using ConsolePlusLibrary.Testing;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Rendering
{
    // ConsoleWriter.WriteOutput(Fragment[]) overflow handling (ConsoleAbstractions/ConsoleWriter.cs:98-181).
    // Needs a real Width/CursorLeft, hence VirtualTerminal (camada 2) rather than a pure unit test.
    public class OverflowTests
    {
        private static VirtualTerminal MakeTerminal(bool supportsUnicode) => VirtualTerminal.Create(o =>
        {
            o.Width = 10;
            o.Height = 3;
            o.SupportsUnicode = supportsUnicode;
        });

        [Fact]
        public void Crop_truncates_text_to_the_remaining_width()
        {
            var vt = MakeTerminal(supportsUnicode: true);

            vt.WriteRaw("Hello World", new Style(vt.CurrentStyle.Foreground, vt.CurrentStyle.Background, Overflow.Crop));

            vt.TextAt(0, 0, 10).Should().Be("Hello Worl");
        }

        [Fact]
        public void Ellipsis_replaces_the_tail_with_the_unicode_ellipsis_when_supported()
        {
            var vt = MakeTerminal(supportsUnicode: true);

            vt.WriteRaw("Hello World", new Style(vt.CurrentStyle.Foreground, vt.CurrentStyle.Background, Overflow.Ellipsis));

            vt.TextAt(0, 0, 10).Should().Be("Hello Wor…");
        }

        [Fact]
        public void Ellipsis_falls_back_to_the_ascii_marker_when_unicode_is_not_supported()
        {
            var vt = MakeTerminal(supportsUnicode: false);

            vt.WriteRaw("Hello World", new Style(vt.CurrentStyle.Foreground, vt.CurrentStyle.Background, Overflow.Ellipsis));

            vt.TextAt(0, 0, 10).Should().Be("Hello Wor_");
        }

        [Fact]
        public void Crop_does_not_throw_when_content_is_made_of_wide_runes()
        {
            // Regression for a real bug: the overflow budget is computed in DISPLAY COLUMNS
            // (GetDisplayLength), but used to be applied as a character index via plain Substring.
            // 8 Hangul syllables = 8 chars but 16 display columns into a 10-column terminal used to
            // throw ArgumentOutOfRangeException in ConsoleWriter.WriteOutput before this fix.
            var vt = MakeTerminal(supportsUnicode: true);
            string wide = "가나다라마바사아";

            var act = () => vt.WriteRaw(wide, new Style(vt.CurrentStyle.Foreground, vt.CurrentStyle.Background, Overflow.Crop));

            act.Should().NotThrow();
        }

        [Fact]
        public void Ellipsis_does_not_throw_when_content_is_made_of_wide_runes()
        {
            var vt = MakeTerminal(supportsUnicode: true);
            string wide = "가나다라마바사아";

            var act = () => vt.WriteRaw(wide, new Style(vt.CurrentStyle.Foreground, vt.CurrentStyle.Background, Overflow.Ellipsis));

            act.Should().NotThrow();
        }
    }
}
