<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Automatic initialization on first access|
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

  # ADR0003V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0003V01R01 — Automatic initialization on first access

## Context

Capability detection and driver selection must happen before any output, but
requiring an explicit `Init()` is easy to forget and produces confusing bugs
when skipped.

## Decision

Run a **static initializer once**, the first time any `ConsolePlus` member is
touched. It enables ANSI on legacy Windows, captures the original culture,
colors, and input/output encodings for later restoration, detects ANSI/Unicode
support, color depth, and terminal/redirection state, and selects the rendering
driver. No initialize method is exposed.

## Consequences

- **Positive:** zero-setup usage; capabilities are always resolved before the
  first render.
- **Negative / trade-off:** the one-time cost is hidden on first access; startup
  side effects (encoding capture) happen implicitly and must be documented.

