<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0014V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0014V01R01
</div>

[← ADR0013](ADR0013V01R01-EmojiShortcodeModel.md) • [ADR Index](README.md) • **Next:** [ADR0015 →](ADR0015V01R01-GeneratedApiDocsOffLimits.md)

---



# ADR0014V01R01 — Low-level ANSI and alternate-screen API

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Most users need high-level writing and styling, but advanced scenarios (full
screen TUIs, custom cursor control, raw escape sequences) require direct,
lower-level access without abandoning ConsolePlus.

## Decision

Expose an **advanced/low-level API** alongside the high-level facade: direct ANSI
escape emission, cursor and screen control, and alternate-screen-buffer
enter/exit. This API is available only where ANSI is supported and is kept
separate from the everyday writing surface.

## Consequences

- **Positive:** advanced apps can build full-screen experiences on ConsolePlus
  primitives; the common API stays simple.
- **Negative / trade-off:** low-level use can bypass graceful-degradation
  guarantees, so callers become responsible for capability checks in that path.
