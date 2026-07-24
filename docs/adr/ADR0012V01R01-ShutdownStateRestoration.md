<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0012V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0012V01R01
</div>

[← ADR0011](ADR0011V01R01-SeparationFromPromptPlus.md) • [ADR Index](README.md) • **Next:** [ADR0013 →](ADR0013V01R01-EmojiShortcodeModel.md)

---



# ADR0012V01R01 — Shutdown state restoration

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

ConsolePlus changes terminal state during a run (colors, cursor, culture, input
and output encodings, possibly the alternate screen). Leaving those changes in
place would corrupt the user's shell after the program exits.

## Decision

**Capture the original culture, colors, and input/output encodings at startup**
and restore them on shutdown via lifecycle/cleanup handlers. The profile retains
`OriginalCulture`, `OriginalInputEncoding`, and `OriginalOutputEncoding` for this
purpose, so the terminal is returned to its pre-run state.

## Consequences

- **Positive:** the host shell is left clean; no color/encoding bleed after exit.
- **Negative / trade-off:** relies on cleanup handlers running; hard process
  kills may bypass restoration, an accepted limitation of console apps.
