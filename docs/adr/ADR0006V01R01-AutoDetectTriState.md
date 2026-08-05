<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|`AutoDetect` tri-state for capabilities|
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

  # ADR0006V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0006V01R01 — `AutoDetect` tri-state for capabilities

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

