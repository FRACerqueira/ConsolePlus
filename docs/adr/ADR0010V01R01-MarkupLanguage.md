<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Inline markup language for styling|
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

  # ADR0010V01R01
</div>

[↑ ADR Index](indexadrs.md)

---



# ADR0010V01R01 — Inline markup language for styling

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

