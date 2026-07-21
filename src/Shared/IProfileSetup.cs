// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Text;
#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Interface for configuring console profiles, allowing for the setup of various console settings such as encoding, color, and interaction capabilities.
    /// </summary>
    public interface IProfileSetup
    {
        /// <summary>
        /// Default input encoding of the console at the time the profile was created.
        /// </summary>
        /// <param name="value">The encoding to set as the default input encoding.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup DefaultInputEncoding(Encoding value);

        /// <summary>
        /// Default output encoding of the console at the time the profile was created.
        /// </summary>
        /// <param name="value">The encoding to set as the default output encoding.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup DefaultOutputEncoding (Encoding value);

        /// <summary>
        /// Default background <see cref="Color"/> used when no explicit color is specified.
        /// </summary>
        /// <param name="value">The color to set as the default background color.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup DefaultBackgroundColor(Color value);

        /// <summary>
        ///Indicating whether or not the console supports interaction.
        /// </summary>
        /// <param name="value">A boolean value indicating whether the console supports interaction.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup Interactive(bool value);

        /// <summary>
        /// Indicates whether Unicode output is fully supported.
        /// </summary>
        /// <param name="value">An <see cref="AutoDetect"/> value indicating whether Unicode output is supported.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup SupportUnicode(AutoDetect value);

        /// <summary>
        /// Gets a value indicating whether ANSI escape sequences are supported for styling/output.
        /// </summary>
        /// <param name="value">An <see cref="AutoDetect"/> value indicating whether ANSI escape sequences are supported.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup SupportsAnsi(AutoDetect value);

        /// <summary>
        /// Color depth (capability) of the console.
        /// </summary>
        /// <param name="value">The color depth to set for the console.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup ColorDepth(ColorSystem value);


        /// <summary>
        /// Time taken for the console to trigger a resize event after the console window has been resized. 
        /// This can be used to optimize performance by reducing the frequency of resize events, especially in scenarios where rapid resizing may occur.
        /// Default value is 300 milliseconds, Range valid 100-1000 milliseconds. 
        /// </summary>
        /// <param name="value">The time in milliseconds to set for the resize event delay.</param>
        /// <returns>The current instance of <see cref="IProfileSetup"/> to allow for fluent configuration.</returns>
        IProfileSetup TimeMsResizeChange(int value);

        /// <summary>
        /// Applies the configured profile settings to the console environment. 
        /// This method should be called after all desired settings have been configured using the fluent interface methods.
        /// </summary>
        void Apply();
    }
}
