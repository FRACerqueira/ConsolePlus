using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // EmojiValue implicit conversions (Shared/EmojiValue.cs) and EmojiName completeness
    // (Shared/EmojiTypes/EmojiName.cs).
    public class EmojiValueTests
    {
        [Fact]
        public void EmojiValue_resolves_a_known_name_to_the_real_unicode_glyph()
        {
            EmojiValue value = EmojiName.GrinningFace;
            string resolved = value;
            resolved.Should().Be("\U0001F600");
        }

        [Fact]
        public void EmojiName_includes_Piñata_and_it_resolves_to_the_real_unicode_glyph()
        {
            // Regression: the auto-generated EmojiName enum previously omitted this member
            // (a non-ASCII identifier the generator failed to carry over), even though the
            // underlying Emoji.Piñata constant has always existed.
            EmojiValue value = EmojiName.Piñata;
            string resolved = value;
            resolved.Should().Be("\U0001FA85");
        }
    }
}
