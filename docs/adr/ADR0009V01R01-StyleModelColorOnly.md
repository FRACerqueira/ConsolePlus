<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0009V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0009V01R01
</div>

[← ADR0008](ADR0008V01R01-ColorDepthModel.md) • [ADR Index](README.md) • **Next:** [ADR0010 →](ADR0010V01R01-MarkupLanguage.md)

---



# ADR0009V01R01 — Style model: color + overflow only

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

A styling type is needed for output. The question is whether to model text
attributes (bold, underline, italic) alongside color, given that not all
terminals support attributes and production only emits color.

## Decision

Model `Style` as **`Foreground`, `Background`, and `OverflowStrategy` only** — no
text attributes. Output emits SGR color sequences only. This keeps the style
grid aligned with what the library actually produces and matches the test
driver's ANSI interpreter (see PromptPlus ADR0017 / the shared `Style.cs`).

## Consequences

- **Positive:** small, predictable style surface; color renders consistently
  across terminals; snapshots stay simple.
- **Negative / risk:** if attributes are needed later, `Style` and the driver
  must be revised in a new version of this ADR.
