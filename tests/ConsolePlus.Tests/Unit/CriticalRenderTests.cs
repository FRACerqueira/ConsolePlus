using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // BeginCriticalRender/EndCriticalRender (ConsolePlus.Startup.cs) — the nesting counter that
    // gates Console_CancelKeyPress's bounded wait before Environment.Exit. That CancelKeyPress
    // path itself can't be safely tested in-process (it calls Environment.Exit), but the counter
    // logic it depends on is plain, deterministic state with no such excuse — flagged as an
    // untested gap in a pre-release audit. IsCriticalRenderIdle/CriticalRenderCount are
    // internal-only test seams added alongside this, not part of the public API surface.
    //
    // Fully-qualifies ConsolePlusLibrary.ConsolePlus throughout instead of a `using
    // ConsolePlusLibrary;` + bare `ConsolePlus` reference: this test project's own root
    // namespace is `ConsolePlus`, so an unqualified `ConsolePlus` here would collide with it.
    [Collection(GlobalStateCollection.Name)]
    public class CriticalRenderTests
    {
        [Fact]
        public void A_single_scope_marks_not_idle_then_idle_again_on_dispose()
        {
            ConsolePlusLibrary.ConsolePlus.IsCriticalRenderIdle.Should().BeTrue();

            var scope = ConsolePlusLibrary.ConsolePlus.BeginCriticalRender();
            ConsolePlusLibrary.ConsolePlus.IsCriticalRenderIdle.Should().BeFalse();
            ConsolePlusLibrary.ConsolePlus.CriticalRenderCount.Should().Be(1);

            scope.Dispose();
            ConsolePlusLibrary.ConsolePlus.IsCriticalRenderIdle.Should().BeTrue();
            ConsolePlusLibrary.ConsolePlus.CriticalRenderCount.Should().Be(0);
        }

        [Fact]
        public void Nested_scopes_only_go_idle_once_every_scope_is_disposed()
        {
            var outer = ConsolePlusLibrary.ConsolePlus.BeginCriticalRender();
            var inner = ConsolePlusLibrary.ConsolePlus.BeginCriticalRender();
            ConsolePlusLibrary.ConsolePlus.CriticalRenderCount.Should().Be(2);

            inner.Dispose();
            ConsolePlusLibrary.ConsolePlus.IsCriticalRenderIdle.Should().BeFalse("the outer scope is still active");
            ConsolePlusLibrary.ConsolePlus.CriticalRenderCount.Should().Be(1);

            outer.Dispose();
            ConsolePlusLibrary.ConsolePlus.IsCriticalRenderIdle.Should().BeTrue();
            ConsolePlusLibrary.ConsolePlus.CriticalRenderCount.Should().Be(0);
        }

        [Fact]
        public void Disposing_a_scope_twice_does_not_go_negative()
        {
            var scope = ConsolePlusLibrary.ConsolePlus.BeginCriticalRender();
            scope.Dispose();
            scope.Dispose();

            ConsolePlusLibrary.ConsolePlus.CriticalRenderCount.Should().Be(0);
            ConsolePlusLibrary.ConsolePlus.IsCriticalRenderIdle.Should().BeTrue();
        }
    }
}
