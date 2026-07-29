using ConsolePlusLibrary;
using ConsolePlusLibrary.Figlet;
using ConsolePlusLibrary.Testing;
using FluentAssertions;
using System.IO;
using System.Text;
using Xunit;

namespace ConsolePlus.Tests.Rendering
{
    // BannerWidget (Figlet/BannerWidget.cs) needs IConsolePlus for Show() and uses VirtualTerminal.
    // Focus is on the border-width calculation in GetSegments (width = widest rendered line), using
    // the same minimal .flf font as FigletFontTests for predictable output.
    public class BannerWidgetTests
    {
        private static Stream MinimalFont() => new MemoryStream(Encoding.UTF8.GetBytes(
            string.Join('\n', "flf2a$ 1 1 5 0 0 0 0 0", "..@", "#$#@"))); // space->"..", '!'->"# #"

        [Fact]
        public void Show_writes_the_rendered_glyph_to_the_grid()
        {
            var vt = VirtualTerminal.Create();
            var widget = new BannerWidget(vt, "!", vt.CurrentStyle);
            widget.FromFont(MinimalFont());

            widget.Show();

            vt.TextAt(0, 0, 3).Should().Be("# #");
        }

        [Fact]
        public void Border_adds_a_top_and_bottom_line_matching_the_widest_rendered_row()
        {
            var vt = VirtualTerminal.Create();
            var widget = new BannerWidget(vt, "!", vt.CurrentStyle);
            widget.FromFont(MinimalFont());
            widget.Border(DashOptions.AsciiSingleBorderUpDown);

            widget.Show();

            vt.TextAt(0, 0, 3).Should().Be("---"); // border matches the 3-column-wide glyph "# #"
            vt.TextAt(1, 0, 3).Should().Be("# #");
            vt.TextAt(2, 0, 3).Should().Be("---");
        }

        [Fact]
        public void No_border_by_default_writes_only_the_glyph_row()
        {
            var vt = VirtualTerminal.Create();
            var widget = new BannerWidget(vt, "!", vt.CurrentStyle);
            widget.FromFont(MinimalFont());

            widget.Show();

            vt.TextAt(0, 0, 3).Should().Be("# #");
            vt.TextAt(1, 0, 3).Trim().Should().BeEmpty(); // untouched cells render as spaces, not ""
        }

        [Fact]
        public void Empty_text_renders_nothing()
        {
            var vt = VirtualTerminal.Create();
            var widget = new BannerWidget(vt, "", vt.CurrentStyle);
            widget.FromFont(MinimalFont());

            widget.Show();

            vt.TextAt(0, 0, 5).Trim().Should().BeEmpty(); // untouched cells render as spaces, not ""
            vt.GetCursorPosition().Should().Be((0, 0));
        }
    }
}
