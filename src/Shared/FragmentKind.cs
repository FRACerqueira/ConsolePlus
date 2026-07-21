// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Identifies the semantic category of a <see cref="Fragment"/> during rendering.
    /// </summary>
    public enum FragmentKind
    {
        /// <summary>
        /// Regular text content that is written to the output as-is.
        /// </summary>
        ContentText,

        /// <summary>
        /// A line break that advances rendering to the next line.
        /// </summary>
        LineBreak,

        /// <summary>
        /// A directive to clear the remainder of the current line from the cursor position.
        /// </summary>
        ClearRestofline
    }
}
