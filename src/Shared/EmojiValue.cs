// ***************************************************************************************
// MIT LICENCE
// Copyright UNICODE (UNICODE LICENSE V3)
// https://www.unicode.org/license.txt
// ***************************************************************************************

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Wrapper type that enables implicit conversion from <see cref="EmojiName"/> to the
    /// real emoji string via <c>EmojiName</c> resolution.
    /// </summary>
    public readonly record struct EmojiValue(EmojiName Name)
    {
        /// <summary>
        /// Converts an <see cref="EmojiName"/> to <see cref="EmojiValue"/>.
        /// </summary>
        public static implicit operator EmojiValue(EmojiName name) => new(name);

        /// <summary>
        /// Converts an <see cref="EmojiValue"/> to the real emoji string.
        /// </summary>
        public static implicit operator string(EmojiValue value)
            => Emoji.GetByName(value.Name.ToString());

        /// <summary>
        /// Returns the resolved emoji string.
        /// </summary>
        public override string ToString() => Emoji.GetByName(Name.ToString());
    }
}

