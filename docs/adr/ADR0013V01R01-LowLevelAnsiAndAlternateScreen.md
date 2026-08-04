<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Low-level ANSI and alternate-screen API|
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

  # ADR0013V01R01
</div>

[← ADR0012](ADR0012V01R01-EmojiShortcodeModel.md) • [ADR Index](README.md) • **Next:** [ADR0014 →](ADR0014V01R02-GeneratedApiDocsOffLimits.md)

---



# ADR0013V01R01 — Low-level ANSI and alternate-screen API

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

