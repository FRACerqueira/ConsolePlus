<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0013V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0013V01R01
</div>

[← ADR0012](ADR0012V01R01-ShutdownStateRestoration.md) • [ADR Index](README.md) • **Next:** [ADR0014 →](ADR0014V01R01-LowLevelAnsiAndAlternateScreen.md)

---



# ADR0013V01R01 — Emoji shortcode model with fallback

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Emoji improve console UX but are not renderable on every terminal or code page.
Embedding raw emoji literals would produce mojibake where Unicode is
unsupported.

## Decision

Expose emoji through **named shortcodes** resolved at render time, gated by the
profile's Unicode support. When Unicode is unavailable, emoji are omitted or
replaced with a plain-text fallback rather than emitted as broken glyphs.

## Consequences

- **Positive:** emoji-rich output on capable terminals, legible output
  everywhere else; authors use stable names instead of raw code points.
- **Negative / trade-off:** the shortcode catalog is a maintained mapping; a
  shortcode with no fallback would degrade poorly, so fallbacks are required.
