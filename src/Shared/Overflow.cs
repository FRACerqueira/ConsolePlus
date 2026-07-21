// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Specifies how text overflow should be handled.
    /// </summary>
    public enum Overflow
    {
        /// <summary>
        /// No overflow handling. Excess characters are placed on the next line.
        /// </summary>
        None = 0,

        /// <summary>
        /// Truncates the text at the end of the line.
        /// </summary>
        Crop = 1,

        /// <summary>
        /// Truncates the text at the end of the line and appends an ellipsis character.
        /// </summary>
        Ellipsis = 2,
    }
}
