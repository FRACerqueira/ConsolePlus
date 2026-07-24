using ConsolePlusLibrary;
using ConsolePlusLibrary.Core;
using FluentAssertions;
using System;
using System.Text.Json;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ColorJsonConverter (Core/ColorJsonConverter.cs) — camada 1, unidade pura.
    public class ColorJsonConverterTests
    {
        private static JsonSerializerOptions Options() => new() { Converters = { new ColorJsonConverter() } };

        [Fact]
        public void Write_serializes_the_color_as_a_hash_prefixed_hex_string()
        {
            string json = JsonSerializer.Serialize(new Color(255, 0, 128), Options());
            json.Should().Be("\"#FF0080\"");
        }

        [Fact]
        public void Read_parses_a_hash_prefixed_hex_string()
        {
            Color color = JsonSerializer.Deserialize<Color>("\"#FF0080\"", Options());
            color.Should().Be(new Color(255, 0, 128));
        }

        [Fact]
        public void Round_trip_preserves_the_color()
        {
            var original = new Color(37, 201, 88);
            var options = Options();

            string json = JsonSerializer.Serialize(original, options);
            Color roundTripped = JsonSerializer.Deserialize<Color>(json, options);

            roundTripped.Should().Be(original);
        }

        // Regression for a real bug found while writing this suite: Color.FromHex throws
        // FormatException for non-hex digits (via byte.Parse), but Read only caught
        // ArgumentException — the raw FormatException leaked past the converter instead of the
        // intended JsonException with a readable message. Fixed to also catch FormatException.
        [Fact]
        public void Read_wraps_invalid_hex_digits_in_a_JsonException_instead_of_leaking_FormatException()
        {
            Action act = () => JsonSerializer.Deserialize<Color>("\"#GGGGGG\"", Options());

            act.Should().Throw<JsonException>()
                .WithInnerException<FormatException>();
        }

        [Fact]
        public void Read_throws_JsonException_for_an_empty_string()
        {
            Action act = () => JsonSerializer.Deserialize<Color>("\"\"", Options());

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void Read_throws_JsonException_for_a_non_string_token()
        {
            Action act = () => JsonSerializer.Deserialize<Color>("123", Options());

            act.Should().Throw<JsonException>();
        }
    }
}
