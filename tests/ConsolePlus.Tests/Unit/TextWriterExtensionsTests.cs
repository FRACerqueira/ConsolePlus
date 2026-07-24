using ConsolePlusLibrary.Core;
using FluentAssertions;
using System.IO;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // TextWriterExtensions (Core/TextWriterExtensions.cs) — camada 1, unidade pura: pure reference
    // comparison against System.Console.Out/Error. Only reads the singleton (no redirection), so
    // it is safe against the "avoid touching the ConsolePlus singleton" rule in TEST-PLAN.md — this
    // is System.Console, a different singleton, and only its getter is read, never mutated.
    public class TextWriterExtensionsTests
    {
        [Fact]
        public void Console_Out_is_recognized_as_standard_out()
        {
            System.Console.Out.IsStandardOut().Should().BeTrue();
        }

        [Fact]
        public void Console_Error_is_recognized_as_standard_error()
        {
            System.Console.Error.IsStandardError().Should().BeTrue();
        }

        [Fact]
        public void An_unrelated_writer_is_neither_standard_out_nor_standard_error()
        {
            using var writer = new StringWriter();

            writer.IsStandardOut().Should().BeFalse();
            writer.IsStandardError().Should().BeFalse();
        }

        [Fact]
        public void Console_Out_is_not_mistaken_for_standard_error_and_vice_versa()
        {
            System.Console.Out.IsStandardError().Should().BeFalse();
            System.Console.Error.IsStandardOut().Should().BeFalse();
        }
    }
}
