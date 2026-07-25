using ConsolePlusLibrary;
using ConsolePlusLibrary.Testing;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ConsolePlusExtends.cs — extension methods on IConsole. Ground truth: ClearLine had a real
    // bug (self-recursive call with no base case, StackOverflowException on any real use) found
    // during a docs audit; this covers the fix. Touching any method here forces the static
    // ConsolePlusLibrary.ConsolePlus singleton to initialize for real (Envlock.Run is a static
    // member access) — that used to crash the whole test host with IOException ("The handle is
    // invalid") from NoAnsiConsoleAdapter's ctor calling ShowCursor() against a console-less test
    // process; fixed by making HideCursor/ShowCursor swallow IOException the same way
    // EnvironmentUtil's other Safe* console helpers already do.
    //
    // Real singleton init also runs EnvironmentUtil.CreateProfile -> EnrichersCI(), which populates
    // the process-wide static BaseClassCI._environmentVariables cache that ProfileExtensionsTests
    // manages by hand via reflection. Since xUnit parallelizes different test classes by default,
    // this class must share GlobalStateCollection with ProfileExtensionsTests or the two race on
    // that cache (confirmed: intermittent CI failure on macOS, 2026-07-25 — ProfileExtensionsTests
    // saw a stale/real-environment snapshot mid-reset because this class's singleton init ran
    // concurrently and repopulated the shared cache).
    [Collection(GlobalStateCollection.Name)]
    public class ConsolePlusExtendsTests
    {
        [Fact]
        public void ClearLine_blanks_the_current_row_without_recursing()
        {
            var vt = VirtualTerminal.Create();
            vt.SetCursorPosition(0, 0);
            vt.Write("hello");

            vt.ClearLine();

            vt.TextAt(0, 0, 5).Trim().Should().BeEmpty();
        }

        [Fact]
        public void ClearLine_targets_the_given_row_and_restores_the_cursor_style()
        {
            var vt = VirtualTerminal.Create();
            vt.SetCursorPosition(0, 2);
            vt.Write("world");
            var styleBefore = vt.CurrentStyle;

            vt.ClearLine(row: 2);

            vt.TextAt(2, 0, 5).Trim().Should().BeEmpty();
            vt.CurrentStyle.Should().Be(styleBefore);
        }
    }
}
