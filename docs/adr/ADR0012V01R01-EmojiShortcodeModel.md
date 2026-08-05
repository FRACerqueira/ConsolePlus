<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Emoji shortcode model with fallback|
|Version|01|
|Revision|01|
|Scope||
|Domain||
|Created|Proposed (2026-07-24)|
|Changed|Accepted (2026-07-24)|
|Superseded||
<!-- Do not remove this comment, lines and table (1-12) -->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0012V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0012V01R01 — Emoji shortcode model with fallback

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

