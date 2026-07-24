using ConsolePlusLibrary;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // ConsoleKeyInfoExtensions (Shared/ConsoleKeyInfoExtensions.cs) — camada 1, unidade pura.
    // Decide, para todo controle, se uma tecla "e" Enter/seta/Home/etc; ja tinha 1 bug real conhecido
    // (IsPressEnterKey diverge Windows/nao-Windows) que motivou esta suite completa.
    public class ConsoleKeyInfoExtensionsTests
    {
        private static ConsoleKeyInfo K(ConsoleKey key, ConsoleModifiers modifiers = 0, char keyChar = '\0')
            => new(keyChar, key,
                shift: modifiers.HasFlag(ConsoleModifiers.Shift),
                alt: modifiers.HasFlag(ConsoleModifiers.Alt),
                control: modifiers.HasFlag(ConsoleModifiers.Control));

        // ---- simple exact Key+Modifiers predicates (no OS branching, no Emacs alternate) ----
        public static IEnumerable<object[]> SimpleExactMatchCases()
        {
            yield return new object[] { "IsLowersCurrentWord", (Func<ConsoleKeyInfo, bool>)(k => k.IsLowersCurrentWord()), ConsoleKey.L, ConsoleModifiers.Alt };
            yield return new object[] { "IsClearBeforeCursor", (Func<ConsoleKeyInfo, bool>)(k => k.IsClearBeforeCursor()), ConsoleKey.U, ConsoleModifiers.Control };
            yield return new object[] { "IsClearAfterCursor", (Func<ConsoleKeyInfo, bool>)(k => k.IsClearAfterCursor()), ConsoleKey.K, ConsoleModifiers.Control };
            yield return new object[] { "IsClearWordBeforeCursor", (Func<ConsoleKeyInfo, bool>)(k => k.IsClearWordBeforeCursor()), ConsoleKey.W, ConsoleModifiers.Control };
            yield return new object[] { "IsClearWordAfterCursor", (Func<ConsoleKeyInfo, bool>)(k => k.IsClearWordAfterCursor()), ConsoleKey.D, ConsoleModifiers.Control };
            yield return new object[] { "IsCapitalizeOverCursor", (Func<ConsoleKeyInfo, bool>)(k => k.IsCapitalizeOverCursor()), ConsoleKey.C, ConsoleModifiers.Alt };
            yield return new object[] { "IsForwardWord", (Func<ConsoleKeyInfo, bool>)(k => k.IsForwardWord()), ConsoleKey.F, ConsoleModifiers.Alt };
            yield return new object[] { "IsBackwardWord", (Func<ConsoleKeyInfo, bool>)(k => k.IsBackwardWord()), ConsoleKey.B, ConsoleModifiers.Alt };
            yield return new object[] { "IsUppersCurrentWord", (Func<ConsoleKeyInfo, bool>)(k => k.IsUppersCurrentWord()), ConsoleKey.U, ConsoleModifiers.Alt };
            yield return new object[] { "IsTransposePrevious", (Func<ConsoleKeyInfo, bool>)(k => k.IsTransposePrevious()), ConsoleKey.T, ConsoleModifiers.Control };
            yield return new object[] { "IsClearContent", (Func<ConsoleKeyInfo, bool>)(k => k.IsClearContent()), ConsoleKey.L, ConsoleModifiers.Control };
            yield return new object[] { "IsPressTabKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressTabKey()), ConsoleKey.Tab, (ConsoleModifiers)0 };
            yield return new object[] { "IsPressCtrlTabKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlTabKey()), ConsoleKey.Tab, ConsoleModifiers.Control };
            yield return new object[] { "IsPressAltTabKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressAltTabKey()), ConsoleKey.Tab, ConsoleModifiers.Alt };
            yield return new object[] { "IsPressShiftTabKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressShiftTabKey()), ConsoleKey.Tab, ConsoleModifiers.Shift };
            yield return new object[] { "IsPressCtrlAltTabKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlAltTabKey()), ConsoleKey.Tab, ConsoleModifiers.Control | ConsoleModifiers.Alt };
            yield return new object[] { "IsPressCtrlHomeKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlHomeKey()), ConsoleKey.Home, ConsoleModifiers.Control };
            yield return new object[] { "IsPressCtrlEndKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlEndKey()), ConsoleKey.End, ConsoleModifiers.Control };
            yield return new object[] { "IsPressCtrlDeleteKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlDeleteKey()), ConsoleKey.Delete, ConsoleModifiers.Control };
            yield return new object[] { "IsPressSpaceKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressSpaceKey()), ConsoleKey.Spacebar, (ConsoleModifiers)0 };
            yield return new object[] { "IsPressCtrlAltSpaceKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlAltSpaceKey()), ConsoleKey.Spacebar, ConsoleModifiers.Control | ConsoleModifiers.Alt };
            yield return new object[] { "IsPressAltSpaceKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressAltSpaceKey()), ConsoleKey.Spacebar, ConsoleModifiers.Alt };
            yield return new object[] { "IsPressCtrlSpaceKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressCtrlSpaceKey()), ConsoleKey.Spacebar, ConsoleModifiers.Control };
            yield return new object[] { "IsPressEscKey", (Func<ConsoleKeyInfo, bool>)(k => k.IsPressEscKey()), ConsoleKey.Escape, (ConsoleModifiers)0 };
        }

        [Theory]
        [MemberData(nameof(SimpleExactMatchCases))]
        public void Matches_only_the_exact_key_and_modifier_combination(string name, Func<ConsoleKeyInfo, bool> predicate, ConsoleKey key, ConsoleModifiers modifiers)
        {
            predicate(K(key, modifiers)).Should().BeTrue(because: $"{name} should match {modifiers}+{key}");
            // Pick a modifier combo that actually differs from the expected one (when the expected
            // modifier is already None, Control is the "wrong" one to try instead).
            ConsoleModifiers wrongModifiers = modifiers == 0 ? ConsoleModifiers.Control : (ConsoleModifiers)0;
            predicate(K(key, wrongModifiers)).Should().BeFalse(because: $"{name} should require exactly the {modifiers} modifier");
            predicate(K(ConsoleKey.Z, modifiers)).Should().BeFalse(because: $"{name} should require the {key} key");
        }

        [Fact]
        public void IsPressSpecialKey_matches_the_given_key_and_modifier_exactly()
        {
            K(ConsoleKey.S, ConsoleModifiers.Control).IsPressSpecialKey(ConsoleKey.S, ConsoleModifiers.Control).Should().BeTrue();
            K(ConsoleKey.S, ConsoleModifiers.Alt).IsPressSpecialKey(ConsoleKey.S, ConsoleModifiers.Control).Should().BeFalse();
            K(ConsoleKey.X, ConsoleModifiers.Control).IsPressSpecialKey(ConsoleKey.S, ConsoleModifiers.Control).Should().BeFalse();
        }

        // ---- IsPressEnterKey: OS-dependent (the bug found in Fase 1) ----

        [Fact]
        public void Enter_key_alone_is_accepted_on_any_platform()
        {
            // KeyChar='\r' satisfies both branches: Windows ignores it and matches on Key==Enter;
            // non-Windows requires exactly this KeyChar.
            K(ConsoleKey.Enter, keyChar: '\r').IsPressEnterKey().Should().BeTrue();
        }

        [Fact]
        public void CtrlJ_is_accepted_as_enter_only_when_emacskeys_is_true()
        {
            var ctrlJ = K(ConsoleKey.J, ConsoleModifiers.Control);
            ctrlJ.IsPressEnterKey(emacskeys: true).Should().BeTrue();
            ctrlJ.IsPressEnterKey(emacskeys: false).Should().BeFalse();
        }

        [Fact]
        public void Enter_detection_matches_the_current_platforms_semantics()
        {
            // No Skippable-fact package here on purpose: this runs the branch matching whatever OS
            // executes it, and the project's own CI matrix (Windows + Linux, TEST-PLAN.md section 8)
            // exercises both branches across the two runners without adding a test dependency.
            if (OperatingSystem.IsWindows())
            {
                // KeyChar=13 with an unrelated Key must NOT be treated as Enter on Windows.
                K(ConsoleKey.A, keyChar: (char)13).IsPressEnterKey().Should().BeFalse();
                // Key=Enter with a modifier must NOT be treated as Enter.
                K(ConsoleKey.Enter, ConsoleModifiers.Shift).IsPressEnterKey().Should().BeFalse();
            }
            else
            {
                // KeyChar=13 (CR) or 10 (LF) with modifiers=0 is Enter regardless of the reported Key —
                // this is exactly the divergence InputQueue.DefaultCharFor (tests/_driver-src) works around.
                K(ConsoleKey.A, keyChar: (char)13).IsPressEnterKey().Should().BeTrue();
                K(ConsoleKey.A, keyChar: (char)10).IsPressEnterKey().Should().BeTrue();
                // Key=Enter with KeyChar='\0' (e.g. a synthetic ConsoleKeyInfo) is NOT recognized on
                // non-Windows: only KeyChar is checked, not Key.
                K(ConsoleKey.Enter, keyChar: '\0').IsPressEnterKey().Should().BeFalse();
            }
        }

        // ---- physical key + Emacs alternate pairs ----

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void End_or_CtrlE_moves_to_line_end(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.E, ConsoleModifiers.Control) : K(ConsoleKey.End);
            key.IsPressEndKey().Should().BeTrue();
        }

        [Fact]
        public void CtrlE_is_not_accepted_as_end_when_emacskeys_is_false()
        {
            K(ConsoleKey.E, ConsoleModifiers.Control).IsPressEndKey(emacskeys: false).Should().BeFalse();
            K(ConsoleKey.End).IsPressEndKey(emacskeys: false).Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Home_or_CtrlA_moves_to_line_start(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.A, ConsoleModifiers.Control) : K(ConsoleKey.Home);
            key.IsPressHomeKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Backspace_or_CtrlH_deletes_previous_character(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.H, ConsoleModifiers.Control) : K(ConsoleKey.Backspace);
            key.IsPressBackspaceKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Delete_or_CtrlD_deletes_forward(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.D, ConsoleModifiers.Control) : K(ConsoleKey.Delete);
            key.IsPressDeleteKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LeftArrow_or_CtrlB_moves_backward(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.B, ConsoleModifiers.Control) : K(ConsoleKey.LeftArrow);
            key.IsPressLeftArrowKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RightArrow_or_CtrlF_moves_forward(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.F, ConsoleModifiers.Control) : K(ConsoleKey.RightArrow);
            key.IsPressRightArrowKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void UpArrow_or_CtrlP_moves_up(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.P, ConsoleModifiers.Control) : K(ConsoleKey.UpArrow);
            key.IsPressUpArrowKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DownArrow_or_CtrlN_moves_down(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.N, ConsoleModifiers.Control) : K(ConsoleKey.DownArrow);
            key.IsPressDownArrowKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PageUp_or_AltP_pages_up(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.P, ConsoleModifiers.Alt) : K(ConsoleKey.PageUp);
            key.IsPressPageUpKey().Should().BeTrue();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PageDown_or_AltN_pages_down(bool useEmacsAlternate)
        {
            var key = useEmacsAlternate ? K(ConsoleKey.N, ConsoleModifiers.Alt) : K(ConsoleKey.PageDown);
            key.IsPressPageDownKey().Should().BeTrue();
        }

        [Fact]
        public void Emacs_alternates_are_ignored_when_emacskeys_is_false_but_physical_keys_still_work()
        {
            K(ConsoleKey.B, ConsoleModifiers.Control).IsPressLeftArrowKey(emacskeys: false).Should().BeFalse();
            K(ConsoleKey.LeftArrow).IsPressLeftArrowKey(emacskeys: false).Should().BeTrue();
        }

        // ---- dual-path predicates (Key OR KeyChar) ----

        [Fact]
        public void ExpandKey_accepts_numpad_plus_or_the_plus_character()
        {
            K(ConsoleKey.Add).IsPressExpandKey().Should().BeTrue();
            K(ConsoleKey.D1, keyChar: '+').IsPressExpandKey().Should().BeTrue();
            K(ConsoleKey.D1, keyChar: '1').IsPressExpandKey().Should().BeFalse();
        }

        [Fact]
        public void CollapseKey_accepts_numpad_minus_or_the_minus_character()
        {
            K(ConsoleKey.Subtract).IsPressCollapseKey().Should().BeTrue();
            K(ConsoleKey.OemMinus, keyChar: '-').IsPressCollapseKey().Should().BeTrue();
            K(ConsoleKey.OemMinus, keyChar: '_').IsPressCollapseKey().Should().BeFalse();
        }

        // ---- composite predicate ----

        [Fact]
        public void FilterActivationKey_accepts_either_CtrlAltSpace_or_CtrlSpace()
        {
            K(ConsoleKey.Spacebar, ConsoleModifiers.Control | ConsoleModifiers.Alt).IsPressFilterActivationKey().Should().BeTrue();
            K(ConsoleKey.Spacebar, ConsoleModifiers.Control).IsPressFilterActivationKey().Should().BeTrue();
            K(ConsoleKey.Spacebar, ConsoleModifiers.Alt).IsPressFilterActivationKey().Should().BeFalse();
            K(ConsoleKey.Spacebar).IsPressFilterActivationKey().Should().BeFalse();
        }
    }
}
