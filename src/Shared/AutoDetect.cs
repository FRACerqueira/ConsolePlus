// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Defines the ANSI escape sequence support detection mode for a console profile.
    /// </summary>
    public enum AutoDetect
    {
        /// <summary>
        /// support shouldbe detected by the system.
        /// </summary>
        Detect = 0,

        /// <summary>
        /// supported.
        /// </summary>
        Yes = 1,

        /// <summary>
        /// Not supported.
        /// </summary>
        No = 2,
    }
}
