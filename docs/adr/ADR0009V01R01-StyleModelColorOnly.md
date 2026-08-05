<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Style model: color + overflow only|
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

  # ADR0009V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0009V01R01 — Style model: color + overflow only

## Context

A styling type is needed for output. The question is whether to model text
attributes (bold, underline, italic) alongside color, given that not all
terminals support attributes and production only emits color.

## Decision

Model `Style` as **`Foreground`, `Background`, and `OverflowStrategy` only** — no
text attributes. Output emits SGR color sequences only. This keeps the style
grid aligned with what the library actually produces and matches the test
driver's ANSI interpreter (see PromptPlus ADR0017 — "ANSI style model: color only" —
and the shared `Style.cs`).

## Consequences

- **Positive:** small, predictable style surface; color renders consistently
  across terminals; snapshots stay simple.
- **Negative / trade-off:** if attributes are needed later, `Style` and the driver
  must be revised in a new version of this ADR.

