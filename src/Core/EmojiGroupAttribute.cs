// ***************************************************************************************
// MIT LICENCE
// Copyright UNICODE (UNICODE LICENSE V3)
// https://www.unicode.org/license.txt
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary.Core
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Marks a public static helper class as an emoji group provider for shortcode group validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class EmojiGroupAttribute(string groupName) : Attribute
    {
        /// <summary>
        /// Gets the logical emoji group name (for example <c>TravelAndPlaces</c> or <c>Smileys &amp; Emotion</c>).
        /// </summary>
        public string GroupName { get; } = groupName;
    }
}
