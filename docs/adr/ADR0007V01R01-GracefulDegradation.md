<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Profile-driven graceful degradation|
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

  # ADR0007V01R01
</div>

[← ADR0006](ADR0006V01R01-AutoDetectTriState.md) • [ADR Index](README.md) • **Next:** [ADR0008 →](ADR0008V01R01-ColorDepthModel.md)

---



# ADR0007V01R01 — Profile-driven graceful degradation

## Context

The same application may run in Windows Terminal, an SSH session, a CI pipeline,
or with output redirected to a file. Output that assumes full ANSI/Unicode/color
would be broken or unreadable in the reduced environments.

## Decision

Use the immutable profile to **degrade gracefully**: when ANSI is unavailable
fall back to the classic console model, when Unicode is unavailable use ASCII
equivalents, and when color is limited map down to the available `ColorSystem`.
Application code stays the same; the driver and profile absorb the differences.

## Consequences

- **Positive:** one codebase renders acceptably everywhere from true-color
  terminals down to redirected files.
- **Negative / trade-off:** rich output is silently reduced in constrained
  environments; the mapping rules must be documented so results are predictable.

