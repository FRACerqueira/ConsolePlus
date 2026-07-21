// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    /// <summary>
    /// Represents something that can enrich a profile.
    /// </summary>
    internal interface IProfileEnrich
    {
        /// <summary>
        /// Enriches the profile.
        /// </summary>
        /// <param name="profile">The profile to enrich.</param>
        /// <returns>True if the profile was successfully enriched; otherwise, false.</returns> 
        bool TryEnrich(ProfileConsole profile);
    }
}
