<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0003V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0003V01R01
</div>

[← ADR0002](ADR0002V01R01-ImmutableCapabilityProfile.md) • [ADR Index](README.md) • **Next:** [ADR0004 →](ADR0004V01R01-AnsiVsNonAnsiDriverSelection.md)

---



# ADR0003V01R01 — Automatic initialization on first access

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

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
