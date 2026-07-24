using ConsolePlusLibrary;
using ConsolePlusLibrary.Testing;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    public class HelloVirtualTerminalTests
    {
        [Fact]
        public void Writes_text_with_color_into_the_grid()
        {
            var vt = VirtualTerminal.Create(o => { o.ColorDepth = ColorSystem.TrueColor; });

            vt.WriteRaw("Ola", new Style(new Color(255, 0, 0), new Color(0, 0, 0)));

            vt.TextAt(0, 0, 3).Should().Be("Ola");
            vt.StyleAt(0, 0).Foreground.Should().Be(new Color(255, 0, 0));
            vt.CursorLeft.Should().Be(3);
        }
    }
}
