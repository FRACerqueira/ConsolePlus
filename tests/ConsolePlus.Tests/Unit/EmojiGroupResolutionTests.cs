using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Emoji.GetByName group-qualified shortcode resolution (Shared/Emoji.cs:51-78,104-157) —
    // camada 1, unidade pura. Deepens EmojiTests.cs (which only covers plain names) with the
    // "group/name" form and its compatibility aliases.
    public class EmojiGroupResolutionTests
    {
        [Fact]
        public void Group_qualified_name_resolves_within_its_declared_group()
        {
            // EmojiActivities is [EmojiGroup("Activities")] and declares Balloon = Emoji.Balloon.
            Emoji.GetByName("activities/balloon").Should().Be("\U0001F388");
        }

        [Fact]
        public void Group_qualified_lookup_is_case_insensitive_on_both_group_and_name()
        {
            Emoji.GetByName("Activities/Balloon").Should().Be("\U0001F388");
            Emoji.GetByName("ACTIVITIES/BALLOON").Should().Be("\U0001F388");
        }

        [Fact]
        public void Group_qualified_lookup_matches_the_plain_name_lookup_for_the_same_emoji()
        {
            Emoji.GetByName("activities/balloon").Should().Be(Emoji.GetByName("balloon"));
        }

        [Fact]
        public void Unknown_group_prefix_is_rejected_even_when_the_name_part_is_valid()
        {
            // GetByName treats an unrecognized prefix before '/' as an error, not as literal text
            // to search for — the whole lookup fails rather than falling back to a plain-name search.
            Emoji.GetByName("not-a-real-group/balloon").Should().BeEmpty();
        }

        [Fact]
        public void Valid_group_with_an_unknown_name_resolves_to_empty()
        {
            Emoji.GetByName("activities/this_emoji_does_not_exist").Should().BeEmpty();
        }

        [Fact]
        public void Group_alias_without_the_word_And_also_resolves()
        {
            // EmojiGroupAttribute("PeopleAndBody") registers both "peopleandbody" and the
            // "And"-stripped compatibility alias "peoplebody".
            Emoji.GetByName("peoplebody/thumbs_up").Should().Be(Emoji.GetByName("thumbs_up"));
        }

        [Fact]
        public void Slash_with_empty_name_part_resolves_to_empty()
        {
            Emoji.GetByName("activities/").Should().BeEmpty();
        }

        [Fact]
        public void Name_without_a_slash_is_looked_up_directly_ignoring_group_resolution()
        {
            Emoji.GetByName("balloon").Should().Be("\U0001F388");
        }
    }
}
