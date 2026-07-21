// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents the capacity of console color system.
    /// </summary>
    public enum ColorSystem
    {
        /// <summary>
        /// No colors.
        /// </summary>
        NoColors = 0,

        /// <summary>
        /// 4-bit mode.
        /// </summary>
        FourBit = 2,

        /// <summary>
        /// 8-bit mode.
        /// </summary>
        Standard = 3,

        /// <summary>
        /// 24-bit mode.
        /// </summary>
        TrueColor = 4,
    }
}
