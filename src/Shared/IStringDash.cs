// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Represents a banner that can be customized and displayed.
    /// </summary>
    public interface IStringDash
    {

        /// <summary>
        /// Set border options for the string dash.
        /// </summary>
        /// <param name="dashOptions">The <see cref="DashOptions"/> to apply.</param>
        /// <returns>The current <see cref="IStringDash"/> instance for method chaining.</returns>
        IStringDash Border(DashOptions dashOptions);

        /// <summary>
        /// Sets the number of extra lines to be added to the string dash.
        /// </summary>
        /// <param name="value">The number of extra lines to add.</param>
        /// <returns>The current <see cref="IStringDash"/> instance for method chaining.</returns>
        IStringDash Extralines(int value);

        /// <summary>
        /// Displays the string dash widget.
        /// </summary>
        void Show();
    }
}
