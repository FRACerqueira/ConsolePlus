using ConsolePlusLibrary;
using FluentAssertions;
using System;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // EmacsConsoleBuffer (Shared/EmacsConsoleBuffer.cs) — camada 1, unidade pura. Backs the answer
    // buffer of most interactive controls (Input, and others via BaseControlPrompt's answer viewport).
    // Every Emacs key binding implemented by TryAcceptedReadlineConsoleKey is covered; exact
    // expected values were confirmed by running each operation and observing the real output
    // (Ctrl+W/Ctrl+T/Alt+U/Alt+L/Alt+D/Alt+F/Alt+B/Ctrl+C have non-obvious boundary behavior that
    // is easy to get wrong by hand-tracing).
    public class EmacsConsoleBufferTests
    {
        private static ConsoleKeyInfo Ch(char c) => new(c, ConsoleKey.A, false, false, false);
        private static ConsoleKeyInfo Ctrl(ConsoleKey k) => new('\0', k, false, false, true);
        private static ConsoleKeyInfo Alt(ConsoleKey k) => new('\0', k, false, true, false);
        private static ConsoleKeyInfo Plain(ConsoleKey k) => new('\0', k, false, false, false);

        private static EmacsConsoleBuffer NewBuffer(
            bool readOnly = false, CaseOptions caseOption = CaseOptions.Any, bool enableEmacsKeys = true, Func<char, bool>? validate = null)
            => new(readOnly, caseOption, enableEmacsKeys, validate);

        private static void Type(EmacsConsoleBuffer b, string s)
        {
            foreach (char c in s)
            {
                b.TryAcceptedReadlineConsoleKey(Ch(c));
            }
        }

        [Fact]
        public void Typing_inserts_printable_characters_at_the_cursor()
        {
            var b = NewBuffer();
            Type(b, "helo");

            b.ToString().Should().Be("helo");
            b.Length.Should().Be(4);
            b.Position.Should().Be(4);
        }

        [Fact]
        public void Enter_is_always_rejected_and_leaves_the_buffer_untouched()
        {
            var b = NewBuffer();
            Type(b, "hi");

            bool accepted = b.TryAcceptedReadlineConsoleKey(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));

            accepted.Should().BeFalse();
            b.ToString().Should().Be("hi");
        }

        [Theory]
        [InlineData(true)]  // Ctrl+A
        [InlineData(false)] // Home
        public void CtrlA_or_Home_moves_the_cursor_to_the_start(bool useEmacsShortcut)
        {
            var b = NewBuffer();
            Type(b, "hello");

            bool accepted = b.TryAcceptedReadlineConsoleKey(useEmacsShortcut ? Ctrl(ConsoleKey.A) : Plain(ConsoleKey.Home));

            accepted.Should().BeTrue();
            b.Position.Should().Be(0);
        }

        [Theory]
        [InlineData(true)]  // Ctrl+E
        [InlineData(false)] // End
        public void CtrlE_or_End_moves_the_cursor_to_the_end(bool useEmacsShortcut)
        {
            var b = NewBuffer();
            Type(b, "hello");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            bool accepted = b.TryAcceptedReadlineConsoleKey(useEmacsShortcut ? Ctrl(ConsoleKey.E) : Plain(ConsoleKey.End));

            accepted.Should().BeTrue();
            b.Position.Should().Be(5);
        }

        [Theory]
        [InlineData(true)]  // Ctrl+B
        [InlineData(false)] // LeftArrow
        public void CtrlB_or_LeftArrow_moves_the_cursor_back_one_character(bool useEmacsShortcut)
        {
            var b = NewBuffer();
            Type(b, "hello");

            b.TryAcceptedReadlineConsoleKey(useEmacsShortcut ? Ctrl(ConsoleKey.B) : Plain(ConsoleKey.LeftArrow));

            b.Position.Should().Be(4);
        }

        [Theory]
        [InlineData(true)]  // Ctrl+F
        [InlineData(false)] // RightArrow
        public void CtrlF_or_RightArrow_moves_the_cursor_forward_one_character(bool useEmacsShortcut)
        {
            var b = NewBuffer();
            Type(b, "hello");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            b.TryAcceptedReadlineConsoleKey(useEmacsShortcut ? Ctrl(ConsoleKey.F) : Plain(ConsoleKey.RightArrow));

            b.Position.Should().Be(1);
        }

        [Theory]
        [InlineData(true)]  // Ctrl+H
        [InlineData(false)] // Backspace
        public void CtrlH_or_Backspace_removes_the_previous_character(bool useEmacsShortcut)
        {
            var b = NewBuffer();
            Type(b, "hello");

            b.TryAcceptedReadlineConsoleKey(useEmacsShortcut ? Ctrl(ConsoleKey.H) : Plain(ConsoleKey.Backspace));

            b.ToString().Should().Be("hell");
            b.Position.Should().Be(4);
        }

        [Theory]
        [InlineData(true)]  // Ctrl+D
        [InlineData(false)] // Delete
        public void CtrlD_or_Delete_removes_the_character_under_the_cursor(bool useEmacsShortcut)
        {
            var b = NewBuffer();
            Type(b, "hello");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            b.TryAcceptedReadlineConsoleKey(useEmacsShortcut ? Ctrl(ConsoleKey.D) : Plain(ConsoleKey.Delete));

            b.ToString().Should().Be("ello");
            b.Position.Should().Be(0);
        }

        [Fact]
        public void CtrlK_clears_from_the_cursor_to_the_end()
        {
            var b = NewBuffer();
            Type(b, "hello world");
            for (int i = 0; i < 6; i++) b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.B)); // position 5

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.K));

            b.ToString().Should().Be("hello");
            b.Position.Should().Be(5);
        }

        [Fact]
        public void CtrlU_clears_from_the_start_to_the_cursor()
        {
            var b = NewBuffer();
            Type(b, "hello world");
            for (int i = 0; i < 6; i++) b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.B)); // position 5

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.U));

            b.ToString().Should().Be(" world");
            b.Position.Should().Be(0);
        }

        [Fact]
        public void CtrlL_clears_the_whole_buffer()
        {
            var b = NewBuffer();
            Type(b, "hello");

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.L));

            b.ToString().Should().Be("");
            b.Position.Should().Be(0);
        }

        [Fact]
        public void CtrlW_removes_the_word_before_the_cursor_when_at_the_end()
        {
            var b = NewBuffer();
            Type(b, "hello world");

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.W));

            b.ToString().Should().Be("hello ");
            b.Position.Should().Be(6);
        }

        [Fact]
        public void CtrlW_removes_only_the_word_fragment_before_the_cursor_mid_word()
        {
            var b = NewBuffer();
            Type(b, "hello world"); // cursor at 11
            for (int i = 0; i < 3; i++) b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.B)); // position 8, before 'r'

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.W));

            b.ToString().Should().Be("hello ld");
            b.Position.Should().Be(6);
        }

        [Fact]
        public void CtrlT_transposes_the_two_characters_before_the_cursor_at_the_end()
        {
            var b = NewBuffer();
            Type(b, "ab");

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.T));

            b.ToString().Should().Be("ba");
            b.Position.Should().Be(2);
        }

        [Fact]
        public void CtrlT_transposes_the_character_at_the_cursor_with_the_previous_one_mid_text()
        {
            var b = NewBuffer();
            Type(b, "abc");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.B)); // position 2, before 'c'

            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.T));

            b.ToString().Should().Be("acb");
            b.Position.Should().Be(2);
        }

        [Fact]
        public void CtrlT_does_nothing_when_the_buffer_has_one_character_or_fewer()
        {
            var b = NewBuffer();
            Type(b, "a");

            bool accepted = b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.T));

            accepted.Should().BeFalse();
            b.ToString().Should().Be("a");
        }

        [Fact]
        public void AltU_uppercases_from_the_cursor_to_the_end_of_the_current_word()
        {
            var b = NewBuffer();
            Type(b, "hello world");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.U));

            b.ToString().Should().Be("HELLO world");
            b.Position.Should().Be(6);
        }

        [Fact]
        public void AltL_lowercases_from_the_cursor_to_the_end_of_the_current_word()
        {
            var b = NewBuffer();
            Type(b, "HELLO WORLD");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.L));

            b.ToString().Should().Be("hello WORLD");
            b.Position.Should().Be(6);
        }

        [Fact]
        public void AltD_removes_the_word_after_the_cursor()
        {
            var b = NewBuffer();
            Type(b, "hello world");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.D));

            b.ToString().Should().Be(" world");
            b.Position.Should().Be(0);
        }

        [Fact]
        public void AltF_moves_the_cursor_forward_one_word_at_a_time()
        {
            var b = NewBuffer();
            Type(b, "hello world foo");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.F));
            b.Position.Should().Be(6);

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.F));
            b.Position.Should().Be(12);
        }

        [Fact]
        public void AltB_from_the_end_needs_two_word_boundaries_and_lands_two_words_back()
        {
            // BackwardWord only stops once it has crossed TWO space-to-non-space transitions
            // (confirmed empirically): starting at the very end of "hello world foo", a single
            // Alt+B skips "foo" entirely and lands at the start of "world", not at "foo"'s start.
            var b = NewBuffer();
            Type(b, "hello world foo"); // cursor at end (15)

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.B));

            b.Position.Should().Be(6); // start of "world"
        }

        [Fact]
        public void AltB_after_AltF_returns_past_the_start_for_the_same_reason()
        {
            var b = NewBuffer();
            Type(b, "hello world foo");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));
            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.F)); // position 6, start of "world"
            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.F)); // position 12, start of "foo"

            b.TryAcceptedReadlineConsoleKey(Alt(ConsoleKey.B));

            b.Position.Should().Be(0);
        }

        [Fact]
        public void CtrlC_capitalizes_the_current_character_and_moves_to_the_end_of_the_word()
        {
            var b = NewBuffer();
            Type(b, "hello world");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));

            bool accepted = b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.C));

            accepted.Should().BeTrue();
            b.ToString().Should().Be("Hello world");
            b.Position.Should().Be(5);
        }

        [Fact]
        public void Insert_toggles_overwrite_mode()
        {
            var b = NewBuffer();
            Type(b, "hello");
            b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));
            b.TryAcceptedReadlineConsoleKey(Plain(ConsoleKey.Insert));

            b.TryAcceptedReadlineConsoleKey(Ch('X'));

            b.ToString().Should().Be("Xello");
            b.Position.Should().Be(1);
        }

        [Fact]
        public void Disabling_emacs_keys_ignores_the_modifier_shortcuts_but_keeps_physical_keys()
        {
            var b = NewBuffer(enableEmacsKeys: false);
            Type(b, "hello");

            bool acceptedCtrlA = b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.A));
            acceptedCtrlA.Should().BeFalse();
            b.Position.Should().Be(5);

            bool acceptedHome = b.TryAcceptedReadlineConsoleKey(Plain(ConsoleKey.Home));
            acceptedHome.Should().BeTrue();
            b.Position.Should().Be(0);
        }

        [Fact]
        public void ReadOnly_buffer_rejects_typed_characters()
        {
            var b = NewBuffer(readOnly: true);

            bool accepted = b.TryAcceptedReadlineConsoleKey(Ch('x'));

            accepted.Should().BeFalse();
            b.Length.Should().Be(0);
        }

        [Fact]
        public void MaxLength_is_enforced_even_though_the_key_is_still_reported_as_accepted()
        {
            var b = NewBuffer();
            b.TryAcceptedReadlineConsoleKey(Ch('a'), maxlength: 2);
            b.TryAcceptedReadlineConsoleKey(Ch('b'), maxlength: 2);

            bool acceptedThird = b.TryAcceptedReadlineConsoleKey(Ch('c'), maxlength: 2);

            acceptedThird.Should().BeTrue();
            b.ToString().Should().Be("ab");
        }

        [Fact]
        public void Uppercase_case_option_transforms_typed_characters()
        {
            var b = NewBuffer(caseOption: CaseOptions.Uppercase);
            Type(b, "abc");

            b.ToString().Should().Be("ABC");
        }

        [Fact]
        public void Lowercase_case_option_transforms_typed_characters()
        {
            var b = NewBuffer(caseOption: CaseOptions.Lowercase);
            Type(b, "ABC");

            b.ToString().Should().Be("abc");
        }

        [Fact]
        public void Validate_function_rejects_disallowed_characters_without_inserting_them()
        {
            var b = NewBuffer(validate: c => c != 'x');

            bool acceptedA = b.TryAcceptedReadlineConsoleKey(Ch('a'));
            bool acceptedX = b.TryAcceptedReadlineConsoleKey(Ch('x'));

            acceptedA.Should().BeTrue();
            acceptedX.Should().BeFalse();
            b.ToString().Should().Be("a");
        }

        [Fact]
        public void Tab_is_inserted_like_a_printable_character()
        {
            var b = NewBuffer();

            bool accepted = b.TryAcceptedReadlineConsoleKey(new ConsoleKeyInfo('\t', ConsoleKey.Tab, false, false, false));

            accepted.Should().BeTrue();
            b.Length.Should().Be(1);
        }

        [Fact]
        public void LoadPrintable_replaces_the_buffer_content_and_resets_the_cursor()
        {
            var b = NewBuffer();
            Type(b, "old");

            b.LoadPrintable("new value");

            b.ToString().Should().Be("new value");
        }

        [Fact]
        public void ToForward_and_ToBackward_split_the_buffer_at_the_cursor()
        {
            var b = NewBuffer();
            Type(b, "hello world");
            for (int i = 0; i < 6; i++) b.TryAcceptedReadlineConsoleKey(Ctrl(ConsoleKey.B)); // position 5

            b.ToBackward().Should().Be("hello");
            b.ToForward().Should().Be(" world");
        }
    }
}
