<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0005V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0005V01R01
</div>

[← ADR0004](ADR0004V01R01-AnsiVsNonAnsiDriverSelection.md) • [ADR Index](README.md) • **Next:** [ADR0006 →](ADR0006V01R01-AutoDetectTriState.md)

---



# ADR0005V01R01 — ANSICON injection for legacy Windows

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Modern Windows (10+) supports ANSI via Virtual Terminal Processing, but
pre-Windows 10 consoles do not. Requiring users to install a third-party tool
would break the "just works" promise on legacy systems.

## Decision

Bundle [ANSICON](https://github.com/adoxa/ansicon) and **inject it
automatically** on legacy Windows consoles that lack native ANSI support. The
injection uses the `LdrLoadDll` approach via `CreateRemoteThread` for 64-bit
.NET AnyCPU processes, providing transparent ANSI escape-sequence support with
no manual installation or configuration.

## Consequences

- **Positive:** ANSI rendering works transparently on old Windows without user
  action.
- **Negative / trade-off:** ships a native dependency and performs process
  injection, which some environments/AV tooling may flag; scoped strictly to
  legacy Windows where native ANSI is absent.
