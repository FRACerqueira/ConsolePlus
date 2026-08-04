using ConsolePlusLibrary;
using ConsolePlusLibrary.Core;
using ConsolePlusLibrary.Testing;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ConsolePlusWidgets/BannerBuilder/StringDashBuilder (Core/ConsolePlusWidgets.cs), backing
    // ConsolePlus.Widgets — the fluent IWidgets factory declared in Shared/IWidgets.cs but,
    // until now, never implemented anywhere in ConsolePlus.
    public class ConsolePlusWidgetsTests
    {
        [Fact]
        public void Dash_builder_produces_the_same_output_as_the_direct_extension_method()
        {
            var viaBuilder = VirtualTerminal.Create();
            new ConsolePlusWidgets(viaBuilder).Dash("Test", new Style(Color.Red, Color.Black)).Show();

            var viaExtensionMethod = VirtualTerminal.Create();
            viaExtensionMethod.Dash("Test", DashOptions.SingleBorder, new Style(Color.Red, Color.Black));

            viaBuilder.Snapshot().Should().Be(viaExtensionMethod.Snapshot());
        }

        [Fact]
        public void Dash_builder_applies_Border_and_Extralines()
        {
            var viaBuilder = VirtualTerminal.Create();
            new ConsolePlusWidgets(viaBuilder).Dash("Test").Border(DashOptions.DoubleBorderUpDown).Extralines(1).Show();

            var viaExtensionMethod = VirtualTerminal.Create();
            viaExtensionMethod.Dash("Test", DashOptions.DoubleBorderUpDown, extralines: 1);

            viaBuilder.Snapshot().Should().Be(viaExtensionMethod.Snapshot());
        }

        [Fact]
        public void Banner_builder_produces_the_same_output_as_the_direct_extension_method()
        {
            var viaBuilder = VirtualTerminal.Create();
            new ConsolePlusWidgets(viaBuilder).Banner("Hi", Color.Teal).Border(DashOptions.SingleBorderUpDown).Show();

            var viaExtensionMethod = VirtualTerminal.Create();
            viaExtensionMethod.Banner("Hi", Color.Teal, DashOptions.SingleBorderUpDown);

            viaBuilder.Snapshot().Should().Be(viaExtensionMethod.Snapshot());
        }

        [Fact]
        public void ConsolePlus_Widgets_returns_a_working_IWidgets_factory()
        {
            // Regression: ConsolePlusLibrary.IWidgets/IBanner/IStringDash existed as public
            // interfaces with zero implementation or factory anywhere in ConsolePlus.
            ConsolePlusLibrary.ConsolePlus.Widgets.Should().NotBeNull();
            ConsolePlusLibrary.ConsolePlus.Widgets.Banner("Hi").Should().NotBeNull();
            ConsolePlusLibrary.ConsolePlus.Widgets.Dash("Hi").Should().NotBeNull();
        }
    }
}
