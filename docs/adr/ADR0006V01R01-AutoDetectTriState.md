<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0006V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0006V01R01
</div>

[← ADR0005](ADR0005V01R01-AnsiconLegacyWindowsSupport.md) • [ADR Index](README.md) • **Next:** [ADR0007 →](ADR0007V01R01-GracefulDegradation.md)

---



# ADR0006V01R01 — `AutoDetect` tri-state for capabilities

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Capabilities like Unicode and ANSI support are not always a clean boolean at the
configuration layer: the value may be explicitly on, explicitly off, or left for
the library to determine at runtime.

## Decision

Model capability configuration as an `AutoDetect` **tri-state** (on / off /
auto) on the profile (`SupportUnicode`, `SupportsAnsi`). For the two most common
checks, the facade also exposes already-resolved booleans
`ConsolePlus.SupportsUnicode` and `ConsolePlus.SupportsAnsi`, so callers never
have to interpret the tri-state themselves.

## Consequences

- **Positive:** configuration can express "let the library decide" distinctly
  from a forced value; simple boolean shortcuts cover the common path.
- **Negative / trade-off:** two representations (tri-state vs resolved bool) must
  stay coherent; the resolved booleans are the authoritative runtime answer.
