using ConsolePlusLibrary;
using FluentAssertions;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // CultureExtensions.ExistsCulture (Shared/CultureExtensions.cs) — camada 1, unidade pura.
    public class CultureExtensionsTests
    {
        [Fact]
        public void Known_culture_name_exists()
        {
            "en-US".ExistsCulture().Should().BeTrue();
        }

        [Fact]
        public void Malformed_culture_name_does_not_exist_and_does_not_throw()
        {
            "!!invalid!!".ExistsCulture().Should().BeFalse();
        }
    }
}
