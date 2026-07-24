using ConsolePlusLibrary;
using ConsolePlusLibrary.ConsoleAbstractions;
using ConsolePlusLibrary.Core;
using ConsolePlusLibrary.RuntimeEnvironment;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ProfileExtensions.EnrichersCI (ConsoleAbstractions/ProfileExtensions.cs) — despacha para 14
    // detectores de CI (RuntimeEnvironment/*.cs), cada um IProfileEnrich.TryEnrich checando uma ou
    // mais env vars; o primeiro que der match "ganha" e interrompe o loop.
    //
    // Blocker de testabilidade: BaseClassCI cacheia Environment.GetEnvironmentVariables() num campo
    // private static compartilhado por TODAS as subclasses, populado uma vez e nunca invalidado
    // (confirmado por probe empírico). Isso impede testar múltiplos cenários de CI no mesmo processo
    // de teste sem resetar o cache manualmente — daqui o uso de reflection (mesmo padrão já usado
    // para métodos privados estáticos, ex. MaskEditControl.NormalizeStringMask) para zerar o campo
    // antes de cada cenário, sem alterar o código de produção.
    public class ProfileExtensionsTests : IDisposable
    {
        // Todas as env vars conhecidas pelos 14 detectores, para isolar cada teste do ambiente real
        // (inclusive quando este próprio test suite roda dentro de um CI real).
        private static readonly string[] AllKnownCiVars =
        [
            "APPVEYOR", "AZURE_PIPELINES", "bamboo_buildNumber",
            "BITBUCKET_REPO_OWNER", "BITBUCKET_REPO_SLUG", "BITBUCKET_COMMIT",
            "BITRISE_BUILD_URL", "ContinuaCI.Version", "GITHUB_ACTIONS", "CI_SERVER",
            "GO_SERVER_URL", "JENKINS_URL", "BuildRunner", "TEAMCITY_VERSION", "TF_BUILD", "TRAVIS",
        ];

        private readonly Dictionary<string, string?> _originalValues = [];

        public ProfileExtensionsTests()
        {
            foreach (var key in AllKnownCiVars)
            {
                _originalValues[key] = Environment.GetEnvironmentVariable(key);
                Environment.SetEnvironmentVariable(key, null);
            }
            ResetCiCache();
        }

        public void Dispose()
        {
            foreach (var (key, value) in _originalValues)
            {
                Environment.SetEnvironmentVariable(key, value);
            }
            ResetCiCache();
        }

        private static void ResetCiCache()
        {
            var field = typeof(BaseClassCI).GetField("_environmentVariables", BindingFlags.NonPublic | BindingFlags.Static)!;
            field.SetValue(null, null);
        }

        private static ProfileConsole EnrichWith(string key, string value)
        {
            Environment.SetEnvironmentVariable(key, value);
            ResetCiCache();
            var profile = new ProfileConsole();
            profile.EnrichersCI();
            return profile;
        }

        [Fact]
        public void No_known_CI_environment_variable_leaves_the_profile_at_its_defaults()
        {
            var profile = new ProfileConsole();

            profile.EnrichersCI();

            profile.ChangedColorDepth.Should().BeFalse();
            profile.ChangedSupportsAnsi.Should().BeFalse();
            profile.Interactive.Should().BeTrue();
            profile.ColorDepth.Should().Be(ColorSystem.FourBit);
        }

        [Fact]
        public void AppVeyor_is_detected_from_the_APPVEYOR_variable()
        {
            var profile = EnrichWith("APPVEYOR", "True");

            profile.ChangedSupportsAnsi.Should().BeTrue();
            profile.SupportsAnsi.Should().Be(AutoDetect.No);
            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void AzurePipelines_is_detected_from_a_non_blank_AZURE_PIPELINES_variable()
        {
            var profile = EnrichWith("AZURE_PIPELINES", "true");

            profile.ChangedSupportsAnsi.Should().BeTrue();
            profile.SupportsAnsi.Should().Be(AutoDetect.Yes);
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void AzurePipelines_ignores_a_whitespace_only_variable()
        {
            var profile = EnrichWith("AZURE_PIPELINES", "   ");

            profile.ChangedColorDepth.Should().BeFalse();
            profile.Interactive.Should().BeTrue();
        }

        [Fact]
        public void Bamboo_is_detected_from_the_bamboo_buildNumber_variable()
        {
            var profile = EnrichWith("bamboo_buildNumber", "42");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Theory]
        [InlineData("BITBUCKET_REPO_OWNER")]
        [InlineData("BITBUCKET_REPO_SLUG")]
        [InlineData("BITBUCKET_COMMIT")]
        public void Bitbucket_is_detected_from_any_one_of_its_three_variables(string variable)
        {
            var profile = EnrichWith(variable, "value");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void Bitrise_is_detected_from_the_BITRISE_BUILD_URL_variable()
        {
            var profile = EnrichWith("BITRISE_BUILD_URL", "https://app.bitrise.io/build/x");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void Continua_is_detected_from_the_ContinuaCI_Version_variable_and_marks_ChangedColorDepth()
        {
            // Regression: Continua.cs originally forgot to set ChangedColorDepth, so the FourBit it
            // forces here was silently overwritten later by EnvironmentUtil's auto-detection
            // (`if (!profile.ChangedColorDepth) { profile.ColorDepth = colordetect; }`).
            var profile = EnrichWith("ContinuaCI.Version", "1.0");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.ColorDepth.Should().Be(ColorSystem.FourBit);
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void GitHub_is_detected_from_a_non_blank_GITHUB_ACTIONS_variable()
        {
            var profile = EnrichWith("GITHUB_ACTIONS", "true");

            profile.ChangedSupportsAnsi.Should().BeTrue();
            profile.SupportsAnsi.Should().Be(AutoDetect.Yes);
            profile.ColorDepth.Should().Be(ColorSystem.FourBit);
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void GitHub_ignores_a_whitespace_only_variable()
        {
            var profile = EnrichWith("GITHUB_ACTIONS", " ");

            profile.ChangedColorDepth.Should().BeFalse();
        }

        [Fact]
        public void GitLab_is_detected_only_when_CI_SERVER_is_exactly_yes_case_insensitive()
        {
            var profile = EnrichWith("CI_SERVER", "YES");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.ChangedSupportsAnsi.Should().BeFalse(); // GitLab does not touch SupportsAnsi
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void GitLab_does_not_match_a_CI_SERVER_value_other_than_yes()
        {
            var profile = EnrichWith("CI_SERVER", "true");

            profile.ChangedColorDepth.Should().BeFalse();
            profile.Interactive.Should().BeTrue();
        }

        [Fact]
        public void GoCD_is_detected_from_the_GO_SERVER_URL_variable()
        {
            var profile = EnrichWith("GO_SERVER_URL", "https://gocd.example.com");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void Jenkins_is_detected_from_the_JENKINS_URL_variable()
        {
            var profile = EnrichWith("JENKINS_URL", "https://jenkins.example.com");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void MyGet_is_detected_only_when_BuildRunner_is_exactly_MyGet_case_insensitive()
        {
            var profile = EnrichWith("BuildRunner", "myget");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void MyGet_does_not_match_a_different_BuildRunner_value()
        {
            var profile = EnrichWith("BuildRunner", "SomeOtherRunner");

            profile.ChangedColorDepth.Should().BeFalse();
            profile.Interactive.Should().BeTrue();
        }

        [Fact]
        public void TeamCity_is_detected_from_the_TEAMCITY_VERSION_variable()
        {
            var profile = EnrichWith("TEAMCITY_VERSION", "2024.1");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void Tfs_is_detected_from_the_TF_BUILD_variable()
        {
            var profile = EnrichWith("TF_BUILD", "True");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void Travis_is_detected_from_the_TRAVIS_variable()
        {
            var profile = EnrichWith("TRAVIS", "true");

            profile.ChangedColorDepth.Should().BeTrue();
            profile.Interactive.Should().BeFalse();
        }

        [Fact]
        public void The_first_matching_enricher_in_priority_order_wins_and_stops_the_loop()
        {
            // AppVeyor is checked before GitHub in EnrichersCI's fixed list; if both variables are
            // present, AppVeyor's distinct signature (SupportsAnsi = No) must win.
            Environment.SetEnvironmentVariable("GITHUB_ACTIONS", "true");
            var profile = EnrichWith("APPVEYOR", "True");

            profile.SupportsAnsi.Should().Be(AutoDetect.No); // AppVeyor's value, not GitHub's (Yes)
        }
    }
}
