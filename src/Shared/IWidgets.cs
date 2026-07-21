// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents a collection of widgets that can be used in the console application.
    /// </summary>
    public interface IWidgets
    {
        /// <summary>
        /// Creates a banner widget with the specified text and optional style.
        /// </summary>
        /// <param name="text">The text to display in the banner.</param>
        /// <param name="style">The optional style to apply to the banner.</param>
        /// <returns>The created <see cref="IBanner"/> instance.</returns>
        IBanner Banner(string text, Style? style = null);

        /// <summary>
        /// Creates a string dash widget with the specified text and optional style.
        /// </summary>
        /// <param name="text">The text to display in the string dash.</param>
        /// <param name="style">The optional style to apply to the string dash.</param>
        /// <returns>The created <see cref="IStringDash"/> instance.</returns>
        IStringDash Dash(string text, Style? style = null);
    }
}
