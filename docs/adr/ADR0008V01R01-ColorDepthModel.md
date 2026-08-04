<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Color depth model (`ColorSystem`)|
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

  # ADR0008V01R01
</div>

[← ADR0007](ADR0007V01R01-GracefulDegradation.md) • [ADR Index](README.md) • **Next:** [ADR0009 →](ADR0009V01R01-StyleModelColorOnly.md)

---



# ADR0008V01R01 — Color depth model (`ColorSystem`)

## Context

Terminals support very different numbers of colors, from monochrome redirected
output to 24-bit true color. Colors requested by the app must be reproduced as
faithfully as the terminal allows.

## Decision

Model color capability as a `ColorSystem` enum with four levels:

| `ColorSystem` | Mode | Colors |
| --- | --- | :---: |
| `NoColors` | — | 1 |
| `FourBit` | 4-bit | 16 |
| `Standard` | 8-bit | 256 |
| `TrueColor` | 24-bit | 16.7M |

`ConsolePlus.ColorDepth` (and `Profile.ColorDepth`) expose the detected level,
and requested colors are down-mapped to the terminal's supported depth.

## Consequences

- **Positive:** a single color API works across all depths; the enum makes the
  detected capability explicit and queryable.
- **Negative / trade-off:** color fidelity varies by terminal; the down-mapping
  from true color to 256/16 colors is approximate.

