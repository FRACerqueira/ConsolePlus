using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Emoji.GetByName (Shared/Emoji.cs:51)
    public class EmojiTests
    {
        [Theory]
        [InlineData("grinning_face", "\U0001F600")]
        [InlineData("thumbs_up", "\U0001F44D")]
        [InlineData("red_heart", "\U00002764")]
        public void Known_names_resolve_to_the_real_unicode_glyph(string name, string expected)
        {
            Emoji.GetByName(name).Should().Be(expected);
        }

        [Theory]
        [InlineData("1st_place_medal", "\U0001F947")]
        [InlineData("2nd_place_medal", "\U0001F948")]
        [InlineData("3rd_place_medal", "\U0001F949")]
        public void Ordinal_numeral_shortcodes_resolve_to_the_real_unicode_glyph(string name, string expected)
        {
            Emoji.GetByName(name).Should().Be(expected);
        }

        [Fact]
        public void Unknown_name_resolves_to_empty_string()
        {
            Emoji.GetByName("this_emoji_does_not_exist").Should().BeEmpty();
        }
    }
}
