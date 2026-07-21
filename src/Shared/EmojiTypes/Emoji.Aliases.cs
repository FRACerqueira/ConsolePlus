
// ***************************************************************************************
// MIT LICENCE
// Copyright UNICODE (UNICODE LICENSE V3)
// https://www.unicode.org/license.txt
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    // Legacy aliases kept for backward compatibility.
    internal static partial class Emoji
    {
        /// <summary>
        /// Gets the "Hugging face" emoji.
        /// </summary>
        /// <remarks>
        /// Lookup: <c>hugging_face</c><br/>
        /// This is a legacy alias for <see cref="SmilingFaceWithOpenHands"/>.
        /// </remarks>
        public const string HuggingFace = SmilingFaceWithOpenHands;

        /// <summary>
        /// Gets the "Knocked-out face" emoji.
        /// </summary>
        /// <remarks>
        /// Lookup: <c>knocked_out_face</c><br/>
        /// This is a legacy alias for <see cref="FaceWithCrossedOutEyes"/>.
        /// </remarks>
        public const string KnockedOutFace = FaceWithCrossedOutEyes;

        /// <summary>
        /// Gets the "Pouting face" emoji.
        /// </summary>
        /// <remarks>
        /// Lookup: <c>pouting_face</c><br/>
        /// This is a legacy alias for <see cref="EnragedFace"/>.
        /// </remarks>
        public const string PoutingFace = EnragedFace;
    }
}
