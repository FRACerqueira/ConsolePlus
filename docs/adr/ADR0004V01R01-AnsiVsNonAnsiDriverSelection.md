<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|ANSI vs non-ANSI driver selection|
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

  # ADR0004V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0004V01R01 — ANSI vs non-ANSI driver selection

## Context

Terminals differ: some understand ANSI escape sequences (colors, cursor moves,
alternate screen), others only support the classic `System.Console` color API.
The rendering code should not branch on this at every call site.

## Decision

Select a **rendering driver at initialization** based on detected ANSI support:

- **ANSI adapter** when escape sequences are supported — emits SGR/CSI sequences.
- **non-ANSI adapter** that falls back to the classic `System.Console` color
  model when ANSI is not available.

All higher-level output goes through the selected driver, so application code is
identical regardless of terminal.

## Consequences

- **Positive:** one code path for callers; terminal-specific concerns are
  isolated in the driver.
- **Negative / trade-off:** two adapters to maintain; feature parity between them
  is limited by what the non-ANSI console can express.

