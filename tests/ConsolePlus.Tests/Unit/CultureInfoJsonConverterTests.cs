using ConsolePlusLibrary.Core;
using FluentAssertions;
using System;
using System.Globalization;
using System.Text.Json;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // CultureInfoJsonConverter (Core/CultureInfoJsonConverter.cs) — camada 1, unidade pura.
    public class CultureInfoJsonConverterTests
    {
        private static JsonSerializerOptions Options() => new() { Converters = { new CultureInfoJsonConverter() } };

        [Fact]
        public void Read_parses_a_known_culture_name()
        {
            CultureInfo culture = JsonSerializer.Deserialize<CultureInfo>("\"en-US\"", Options())!;
            culture.Name.Should().Be("en-US");
        }

        [Fact]
        public void Read_falls_back_to_invariant_culture_for_an_unknown_name()
        {
            // ".NET's CultureInfo ctor is lenient about BCP-47-ish syntax (e.g. "not-a-real-culture"
            // resolves instead of throwing); "!!invalid!!" reliably throws CultureNotFoundException.
            CultureInfo culture = JsonSerializer.Deserialize<CultureInfo>("\"!!invalid!!\"", Options())!;
            culture.Should().Be(CultureInfo.InvariantCulture);
        }

        [Fact]
        public void Read_falls_back_to_invariant_culture_for_null_or_whitespace()
        {
            JsonSerializer.Deserialize<CultureInfo>("\"\"", Options())!.Should().Be(CultureInfo.InvariantCulture);
            JsonSerializer.Deserialize<CultureInfo>("\"   \"", Options())!.Should().Be(CultureInfo.InvariantCulture);
        }

        [Fact]
        public void Read_throws_JsonException_for_a_non_string_token()
        {
            Action act = () => JsonSerializer.Deserialize<CultureInfo>("42", Options());
            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void Write_serializes_the_culture_name()
        {
            string json = JsonSerializer.Serialize(CultureInfo.GetCultureInfo("fr-FR"), Options());
            json.Should().Be("\"fr-FR\"");
        }

        [Fact]
        public void Write_serializes_null_as_json_null()
        {
            string json = JsonSerializer.Serialize<CultureInfo?>(null, Options());
            json.Should().Be("null");
        }

        [Fact]
        public void Round_trip_preserves_a_known_culture()
        {
            var options = Options();
            var original = CultureInfo.GetCultureInfo("pt-BR");

            string json = JsonSerializer.Serialize(original, options);
            CultureInfo roundTripped = JsonSerializer.Deserialize<CultureInfo>(json, options)!;

            roundTripped.Should().Be(original);
        }
    }
}
