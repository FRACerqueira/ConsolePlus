// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Globalization;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Provides extension methods for working with culture names.
    /// </summary>
    public static class CultureExtensions
    {
        /// <summary>
        /// Determines whether the specified culture name corresponds to a valid culture recognized by the .NET
        /// framework.
        /// </summary>
        /// <remarks>This method does not throw an exception for invalid or unrecognized culture names.
        /// Use this method to safely check for culture existence before performing culture-specific
        /// operations.</remarks>
        /// <param name="name">The culture name to check.</param>
        /// <returns>true if the specified culture name is valid and recognized; otherwise, false.</returns>
        public static bool ExistsCulture(this string name)
        {
            try
            {
                // GetCultureInfo uses an internal hashtable — O(1) vs enumerating all cultures.
                CultureInfo.GetCultureInfo(name);
                return true;
            }
            catch (CultureNotFoundException)
            {
                return false;
            }
        }
    }
}
