<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Shutdown state restoration|
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

  # ADR0011V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0011V01R01 — Shutdown state restoration

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

