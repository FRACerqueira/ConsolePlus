// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************


#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Contains options for transforming input characters.
    /// </summary>
    public enum CaseOptions
    {
        /// <summary>
        /// Any input, no transform.
        /// </summary>
        Any,

        /// <summary>
        /// Transform input to Uppercase.
        /// </summary>
        Uppercase,

        /// <summary>
        /// Transform input to Lowercase.
        /// </summary>
        Lowercase
    }
}
