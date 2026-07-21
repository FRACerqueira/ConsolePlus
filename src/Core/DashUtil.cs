// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

namespace ConsolePlusLibrary.Core
{
    internal static class DashUtil
    {

        public static string? GetBorderUp(IConsole console, DashOptions dashOptions)
        {
            return dashOptions switch
            {
                DashOptions.AsciiSingleBorderUpDown => "-",
                DashOptions.AsciiDoubleBorderUpDown => "=",
                DashOptions.SingleBorderUpDown => console.SupportsUnicode ? "─" : "-",
                DashOptions.DoubleBorderUpDown => console.SupportsUnicode ? "═" : "=",
                DashOptions.HeavyBorderUpDown => console.SupportsUnicode ? "━" : "*",
                _ => null,
            };
        }

        public static string? GetBorderDown(IConsole console, DashOptions dashOptions)
        {
            return dashOptions switch
            {
                DashOptions.AsciiSingleBorder => "-",
                DashOptions.AsciiSingleBorderUpDown => "-",
                DashOptions.AsciiDoubleBorder => "=",
                DashOptions.AsciiDoubleBorderUpDown => "=",
                DashOptions.SingleBorder => console.SupportsUnicode ? "─" : "-",
                DashOptions.SingleBorderUpDown => console.SupportsUnicode ? "─" : "-",
                DashOptions.DoubleBorder => console.SupportsUnicode ? "═" : "=",
                DashOptions.DoubleBorderUpDown => console.SupportsUnicode ? "═" : "=",
                DashOptions.HeavyBorder => console.SupportsUnicode ? "━" : "*",
                DashOptions.HeavyBorderUpDown => console.SupportsUnicode ? "━" : "*",
                _ => null,
            };
        }
    }
}
