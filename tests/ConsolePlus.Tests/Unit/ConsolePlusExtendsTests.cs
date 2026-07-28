using System;
using System.Threading.Tasks;
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

        // Ground truth: unlike the tests above, these go through the REAL static ConsolePlus
        // singleton (not VirtualTerminal, which is its own mock IConsole and never touches
        // NoAnsiConsoleAdapter). The xUnit test host runs with Console.IsOutputRedirected/
        // IsInputRedirected == true, so the real singleton picks NoAnsiConsoleAdapter, the same
        // adapter a headless/piped production process would get. Console.Clear() and
        // Console.SetCursorPosition() call into the real console handle and used to throw
        // IOException ("The handle is invalid") here uncaught — found via manual empirical
        // verification (redirected stdio), not covered by any prior test. Fixed by wrapping both
        // in the same catch-IOException "Safe" pattern already used by HideCursor/ShowCursor and
        // EnvironmentUtil's GetSafeWidth/GetSafeHeight/GetSafeTopCursor/etc.
        [Fact]
        public void Clear_does_not_throw_when_console_io_is_redirected()
        {
            var act = () => ConsolePlusLibrary.ConsolePlus.Clear();

            act.Should().NotThrow();
        }

        [Fact]
        public void SetCursorPosition_does_not_throw_when_console_io_is_redirected()
        {
            var act = () => ConsolePlusLibrary.ConsolePlus.SetCursorPosition(0, 0);

            act.Should().NotThrow();
        }

        [Fact]
        public void CursorLeft_and_CursorTop_setters_do_not_throw_when_console_io_is_redirected()
        {
            var act = () =>
            {
                ConsolePlusLibrary.ConsolePlus.CursorLeft = 0;
                ConsolePlusLibrary.ConsolePlus.CursorTop = 0;
            };

            act.Should().NotThrow();
        }

        [Fact]
        public void ClearLine_via_real_singleton_does_not_throw_when_console_io_is_redirected()
        {
            var act = () => ConsolePlusLibrary.ConsolePlus.ClearLine();

            act.Should().NotThrow();
        }

        // Ground truth: KeyAvailable/ReadKey(Async) call the raw Console.KeyAvailable/ReadKey APIs,
        // which require a live console input buffer and throw InvalidOperationException when input
        // is redirected. The pre-existing guard (`if (!_profile.Interactive) throw ...`) didn't catch
        // this because _profile.Interactive defaults to true everywhere except a short list of known
        // CI providers — a real redirected xUnit test host (confirmed empirically:
        // Console.IsInputRedirected == true here) doesn't match any of them, so the raw call was
        // reached and threw uncaught. Fixed by also checking Console.IsInputRedirected directly.
        [Fact]
        public void KeyAvailable_returns_false_instead_of_throwing_when_console_input_is_redirected()
        {
            var act = () => ConsolePlusLibrary.ConsolePlus.KeyAvailable;

            act.Should().NotThrow();
            ConsolePlusLibrary.ConsolePlus.KeyAvailable.Should().BeFalse();
        }

        [Fact]
        public async Task ReadKeyAsync_throws_InvalidOperationException_instead_of_the_raw_console_exception_when_input_is_redirected()
        {
            Func<Task> act = () => ConsolePlusLibrary.ConsolePlus.ReadKeyAsync(intercept: true);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Console is not interactive.");
        }
    }
}
