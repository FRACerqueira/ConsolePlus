<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0010V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0010V01R01
</div>

[← ADR0009](ADR0009V01R01-StyleModelColorOnly.md) • [ADR Index](README.md) • **Next:** [ADR0011 →](ADR0011V01R01-SeparationFromPromptPlus.md)

---



# ADR0010V01R01 — Inline markup language for styling

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Applying color per span through explicit `Style` objects is verbose for common
messages. A concise, inline way to color and format text improves ergonomics.

## Decision

Provide an **inline markup language** using bracket tags, e.g.
`[Lime]True-color ANSI available[/]`, parsed at write time and translated to the
active driver's output (ANSI sequences or console colors). Markup honours the
resolved color depth and degrades with the profile.

## Consequences

- **Positive:** compact, readable styled output; no manual style plumbing for
  simple cases.
- **Negative / trade-off:** literal brackets must be escaped; malformed markup
  needs defined handling; the tag vocabulary becomes part of the public contract.
