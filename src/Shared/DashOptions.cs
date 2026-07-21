// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents border options when writing a banner.
    /// </summary>
    public enum DashOptions
    {
        /// <summary>
        /// No border.
        /// </summary>
        None,

        /// <summary>
        /// Border '-' after text. If not unicode supported, writes '-'.
        /// </summary>
        AsciiSingleBorder, 
        
        /// <summary>
        /// Border '=' after text. If not unicode supported, writes '='.
        /// </summary>
        AsciiDoubleBorder,

        /// <summary>
        /// Border '─' after text. If not unicode supported, writes '-'.
        /// </summary>
        SingleBorder,

        /// <summary>
        /// Border '═' after text. If not unicode supported, writes '='.
        /// </summary>
        DoubleBorder,

        /// <summary>
        /// Border '━' after text. If not Unicode supported, writes '*'.
        /// </summary>
        HeavyBorder,

        /// <summary>
        /// Border '-' before and after text. If not unicode supported, writes '-'.
        /// </summary>
        AsciiSingleBorderUpDown,

        /// <summary>
        /// Border '=' before and after text. If not unicode supported, writes '='.
        /// </summary>
        AsciiDoubleBorderUpDown,

        /// <summary>
        /// Border '─' before and after text. If not unicode supported, writes '-'.
        /// </summary>
        SingleBorderUpDown,

        /// <summary>
        /// Border '═' before and after text. If not unicode supported, writes '='.
        /// </summary>
        DoubleBorderUpDown,

        /// <summary>
        /// Border '━' before and after text. If not unicode supported, writes '*'.
        /// </summary>
        HeavyBorderUpDown
    }
}
