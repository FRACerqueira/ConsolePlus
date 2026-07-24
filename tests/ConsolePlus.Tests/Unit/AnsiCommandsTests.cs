using ConsolePlusLibrary;
using ConsolePlusLibrary.ConsoleAbstractions;
using ConsolePlusLibrary.Core;
using FluentAssertions;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // AnsiCommands (ConsoleAbstractions/AnsiCommands.cs) — camada 1, unidade pura: verifica a
    // string ANSI literal emitida por cada comando. Usa um IConsolePlus fake mínimo em vez de
    // VirtualTerminal porque AnsiScreenInterpreter só reconhece o subconjunto que a produção
    // realmente emite (CUP/EL/ED/SGR/cursor/alt-screen) — vários comandos aqui (setas, tabulação,
    // scroll, save/restore cursor) não são interpretados e lançariam NotSupportedException.
    // AnsiCommands só toca Out/Error/WriteToErrorOutput em IConsolePlus; todo o resto é stub.
    public class AnsiCommandsTests
    {
        private sealed class RecordingConsole : IConsolePlus
        {
            public readonly StringWriter OutWriter = new();
            public readonly StringWriter ErrWriter = new();

            public bool WriteToErrorOutput { get; set; }
            public TextWriter Out => OutWriter;
            public TextWriter Error => ErrWriter;

            // ---- everything else is untouched by AnsiCommands ----
            public ConsoleWriter Writer => throw new NotImplementedException();
            public bool EnabledEmacs { get; set; }
            public CancellationToken CancelToken => throw new NotImplementedException();
            public IAnsiCommands Ansi => throw new NotImplementedException();
            public IProfileReadOnly Profile => throw new NotImplementedException();
            public int Width => throw new NotImplementedException();
            public int Height => throw new NotImplementedException();
            public bool SupportsAnsi => throw new NotImplementedException();
            public bool SupportsUnicode => throw new NotImplementedException();
            public ConsoleColor ForegroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public ConsoleColor BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public Color ForegroundRgbColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public Color BackgroundRgbColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public ColorSystem ColorDepth => throw new NotImplementedException();
            public event EventHandler<ConsoleSizeChangedEventArgs>? SizeChanged { add { } remove { } }
            public Style CurrentStyle => throw new NotImplementedException();
            public int CursorLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int CursorTop { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool CursorVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool IsInputRedirected => throw new NotImplementedException();
            public bool IsOutputRedirected => throw new NotImplementedException();
            public bool IsErrorRedirected => throw new NotImplementedException();
            public bool KeyAvailable => throw new NotImplementedException();
            public Encoding InputEncoding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public Encoding OutputEncoding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public TextReader In => throw new NotImplementedException();
            public TargetScreen CurrentBuffer => throw new NotImplementedException();

            public void Write(char value) => throw new NotImplementedException();
            public void Write(char value, Style style) => throw new NotImplementedException();
            public void Write(char value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(char value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(char[]? value) => throw new NotImplementedException();
            public void Write(char[]? value, Style style) => throw new NotImplementedException();
            public void Write(char[]? value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(char[]? value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(object? value) => throw new NotImplementedException();
            public void Write(object? value, Style style) => throw new NotImplementedException();
            public void Write(object? value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(object? value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(bool value) => throw new NotImplementedException();
            public void Write(bool value, Style style) => throw new NotImplementedException();
            public void Write(bool value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(bool value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(double value) => throw new NotImplementedException();
            public void Write(double value, Style style) => throw new NotImplementedException();
            public void Write(double value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(double value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(float value) => throw new NotImplementedException();
            public void Write(float value, Style style) => throw new NotImplementedException();
            public void Write(float value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(float value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(decimal value) => throw new NotImplementedException();
            public void Write(decimal value, Style style) => throw new NotImplementedException();
            public void Write(decimal value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(decimal value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(int value) => throw new NotImplementedException();
            public void Write(int value, Style style) => throw new NotImplementedException();
            public void Write(int value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(int value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(long value) => throw new NotImplementedException();
            public void Write(long value, Style style) => throw new NotImplementedException();
            public void Write(long value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(long value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void Write(string? value) => throw new NotImplementedException();
            public void Write(string? value, Style style) => throw new NotImplementedException();
            public void Write(string? value, bool clearrestofline) => throw new NotImplementedException();
            public void Write(string? value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteRaw(string? value, Style style, bool clearrestofline = false) => throw new NotImplementedException();
            public void WriteFormat(string format, params object?[] arg) => throw new NotImplementedException();
            public void WriteFormat(string format, Style style, params object?[] arg) => throw new NotImplementedException();
            public void WriteFormat(string format, bool clearrestofline, params object?[] arg) => throw new NotImplementedException();
            public void WriteFormat(string format, Style style, bool clearrestofline, params object?[] arg) => throw new NotImplementedException();
            public void WriteLine() => throw new NotImplementedException();
            public void WriteLine(char value) => throw new NotImplementedException();
            public void WriteLine(char value, Style style) => throw new NotImplementedException();
            public void WriteLine(char value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(char value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(char[]? value) => throw new NotImplementedException();
            public void WriteLine(char[]? value, Style style) => throw new NotImplementedException();
            public void WriteLine(char[]? value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(char[]? value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(bool value) => throw new NotImplementedException();
            public void WriteLine(bool value, Style style) => throw new NotImplementedException();
            public void WriteLine(bool value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(bool value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(double value) => throw new NotImplementedException();
            public void WriteLine(double value, Style style) => throw new NotImplementedException();
            public void WriteLine(double value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(double value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(float value) => throw new NotImplementedException();
            public void WriteLine(float value, Style style) => throw new NotImplementedException();
            public void WriteLine(float value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(float value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(decimal value) => throw new NotImplementedException();
            public void WriteLine(decimal value, Style style) => throw new NotImplementedException();
            public void WriteLine(decimal value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(decimal value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(int value) => throw new NotImplementedException();
            public void WriteLine(int value, Style style) => throw new NotImplementedException();
            public void WriteLine(int value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(int value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(long value) => throw new NotImplementedException();
            public void WriteLine(long value, Style style) => throw new NotImplementedException();
            public void WriteLine(long value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(long value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(object? value) => throw new NotImplementedException();
            public void WriteLine(object? value, Style style) => throw new NotImplementedException();
            public void WriteLine(object? value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(object? value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(string? value) => throw new NotImplementedException();
            public void WriteLine(string? value, Style style) => throw new NotImplementedException();
            public void WriteLine(string? value, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLine(string? value, Style style, bool clearrestofline) => throw new NotImplementedException();
            public void WriteLineFormat(string format, params object?[] arg) => throw new NotImplementedException();
            public void WriteLineFormat(string format, Style style, params object?[] arg) => throw new NotImplementedException();
            public void WriteLineFormat(string format, bool clearrestofline, params object?[] arg) => throw new NotImplementedException();
            public void WriteLineFormat(string format, Style style, bool clearrestofline, params object?[] arg) => throw new NotImplementedException();
            public void Clear(Color? backgroundcolor = null) => throw new NotImplementedException();
            public void SetCursorPosition(int left, int top) => throw new NotImplementedException();
            public (int Left, int Top) GetCursorPosition() => throw new NotImplementedException();
            public bool HideCursor() => throw new NotImplementedException();
            public bool ShowCursor() => throw new NotImplementedException();
            public string? ReadLine() => throw new NotImplementedException();
            public int Read() => throw new NotImplementedException();
            public ConsoleKeyInfo ReadKey(bool intercept = false) => throw new NotImplementedException();
            public Task<ConsoleKeyInfo?> ReadKeyAsync(bool intercept, CancellationToken cancellationToken) => throw new NotImplementedException();
            public void ResetColor() => throw new NotImplementedException();
            public void Beep() => throw new NotImplementedException();
            public void SetError(TextWriter value) => throw new NotImplementedException();
            public void SetIn(TextReader value) => throw new NotImplementedException();
            public void SetOut(TextWriter value) => throw new NotImplementedException();
            public bool SwapBuffer(TargetScreen value) => throw new NotImplementedException();
        }

        private readonly RecordingConsole _console = new();
        private readonly AnsiCommands _ansi;

        public AnsiCommandsTests()
        {
            _ansi = new AnsiCommands(_console);
        }

        [Fact]
        public void CursorPosition_emits_1_indexed_row_and_column()
        {
            _ansi.CursorPosition(row: 2, column: 4);
            _console.OutWriter.ToString().Should().Be("\x1b[3;5H");
        }

        [Theory]
        [InlineData(3, "\x1b[3A")]
        public void CursorUp_emits_the_step_count(int steps, string expected)
        {
            _ansi.CursorUp(steps);
            _console.OutWriter.ToString().Should().Be(expected);
        }

        [Fact]
        public void CursorUp_with_zero_steps_emits_nothing()
        {
            _ansi.CursorUp(0);
            _console.OutWriter.ToString().Should().BeEmpty();
        }

        [Fact]
        public void CursorDown_emits_the_step_count()
        {
            _ansi.CursorDown(2);
            _console.OutWriter.ToString().Should().Be("\x1b[2B");
        }

        [Fact]
        public void CursorForward_and_CursorRight_are_equivalent()
        {
            _ansi.CursorForward(5);
            _console.OutWriter.ToString().Should().Be("\x1b[5C");
        }

        [Fact]
        public void CursorRight_delegates_to_CursorForward()
        {
            _ansi.CursorRight(5);
            _console.OutWriter.ToString().Should().Be("\x1b[5C");
        }

        [Fact]
        public void CursorBackward_and_CursorLeft_are_equivalent()
        {
            _ansi.CursorLeft(5);
            _console.OutWriter.ToString().Should().Be("\x1b[5D");
        }

        [Fact]
        public void ShowCursor_and_HideCursor_use_DEC_private_mode_25()
        {
            _ansi.ShowCursor();
            _console.OutWriter.ToString().Should().Be("\x1b[?25h");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.HideCursor();
            _console.OutWriter.ToString().Should().Be("\x1b[?25l");
        }

        [Fact]
        public void EnterAltScreen_and_ExitAltScreen_use_DEC_private_mode_1049()
        {
            _ansi.EnterAltScreen();
            _console.OutWriter.ToString().Should().Be("\x1b[?1049h");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.ExitAltScreen();
            _console.OutWriter.ToString().Should().Be("\x1b[?1049l");
        }

        [Fact]
        public void EraseInLine_and_EraseInDisplay_default_to_mode_0()
        {
            _ansi.EraseInLine();
            _console.OutWriter.ToString().Should().Be("\x1b[0K");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.EraseInDisplay();
            _console.OutWriter.ToString().Should().Be("\x1b[0J");
        }

        [Fact]
        public void ClearScrollback_erases_the_whole_display_with_mode_3()
        {
            _ansi.ClearScrollback();
            _console.OutWriter.ToString().Should().Be("\x1b[3J");
        }

        [Fact]
        public void CursorHome_emits_bare_H_with_no_parameters()
        {
            _ansi.CursorHome();
            _console.OutWriter.ToString().Should().Be("\x1b[H");
        }

        [Fact]
        public void CursorHorizontalAbsolute_emits_the_target_column()
        {
            _ansi.CursorHorizontalAbsolute(10);
            _console.OutWriter.ToString().Should().Be("\x1b[10G");
        }

        [Fact]
        public void SaveCursor_and_RestoreCursor_emit_both_the_ANSI_and_DEC_sequences_by_default()
        {
            _ansi.SaveCursor();
            _console.OutWriter.ToString().Should().Be("\x1b[s\x1b" + "7");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.RestoreCursor();
            _console.OutWriter.ToString().Should().Be("\x1b[u\x1b" + "8");
        }

        [Fact]
        public void SaveCursor_without_stayOnPage_emits_only_the_DEC_sequence()
        {
            _ansi.SaveCursor(stayOnPage: false);
            _console.OutWriter.ToString().Should().Be("\x1b" + "7");
        }

        [Fact]
        public void DeleteCharacter_InsertCharacter_and_EraseCharacter_default_to_one()
        {
            _ansi.DeleteCharacter();
            _console.OutWriter.ToString().Should().Be("\x1b[1P");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.InsertCharacter();
            _console.OutWriter.ToString().Should().Be("\x1b[1@");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.EraseCharacter();
            _console.OutWriter.ToString().Should().Be("\x1b[1X");
        }

        [Fact]
        public void DeleteLine_defaults_to_zero_not_one()
        {
            // Unlike DeleteCharacter/InsertCharacter/EraseCharacter, DeleteLine's own default
            // parameter is 0, not 1 — emits "\e[0M" when called with no argument.
            _ansi.DeleteLine();
            _console.OutWriter.ToString().Should().Be("\x1b[0M");
        }

        [Fact]
        public void InsertLine_ScrollUp_and_ScrollDown_default_to_one()
        {
            _ansi.InsertLine();
            _console.OutWriter.ToString().Should().Be("\x1b[1L");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.ScrollUp();
            _console.OutWriter.ToString().Should().Be("\x1b[1T");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.ScrollDown();
            _console.OutWriter.ToString().Should().Be("\x1b[1S");
        }

        [Fact]
        public void CursorNextLine_and_CursorPreviousLine_default_to_one()
        {
            _ansi.CursorNextLine();
            _console.OutWriter.ToString().Should().Be("\x1b[1E");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.CursorPreviousLine();
            _console.OutWriter.ToString().Should().Be("\x1b[1F");
        }

        [Fact]
        public void Index_and_ReverseIndex_emit_bare_escape_sequences()
        {
            _ansi.Index();
            _console.OutWriter.ToString().Should().Be("\x1b" + "D");
            _console.OutWriter.GetStringBuilder().Clear();
            _ansi.ReverseIndex();
            _console.OutWriter.ToString().Should().Be("\x1bM");
        }

        [Fact]
        public void SetCursorStyle_defaults_to_style_0_with_a_trailing_space()
        {
            _ansi.SetCursorStyle();
            _console.OutWriter.ToString().Should().Be("\x1b[0 q");
        }

        [Fact]
        public void WriteToErrorOutput_routes_output_to_the_error_stream()
        {
            _console.WriteToErrorOutput = true;
            _ansi.CursorHome();

            _console.ErrWriter.ToString().Should().Be("\x1b[H");
            _console.OutWriter.ToString().Should().BeEmpty();
        }
    }
}
