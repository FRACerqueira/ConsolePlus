<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|ANSICON launch (not injection) for legacy Windows|
|Version|01|
|Revision|02|
|Scope||
|Domain||
|Created|Proposed (2026-07-24)|
|Changed|Accepted (2026-07-25)|
|Superseded||
<!-- Do not remove this comment, lines and table (1-12) -->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0005V01R02
</div>

[← ADR0004](ADR0004V01R01-AnsiVsNonAnsiDriverSelection.md) • [ADR Index](README.md) • **Next:** [ADR0006 →](ADR0006V01R01-AutoDetectTriState.md)

---

# ADR0005V01R02 — ANSICON launch (not injection) for legacy Windows

## Context

Modern Windows (10+) supports ANSI via Virtual Terminal Processing, but
pre-Windows 10 consoles do not. Requiring users to install a third-party tool
would break the "just works" promise on legacy systems.

**R02 correction:** the original (R01) text of this ADR described the mechanism as DLL injection
(`LdrLoadDll` via `CreateRemoteThread`). A 2026-07-25 docs audit traced the real implementation in
`src/Core/LegacyAnsiBootstrapper.cs` and found no DLL injection or remote-thread APIs anywhere in
this codebase — the R01 description was inaccurate from the start (the same inaccurate claim had
also propagated into 3 hand-written docs, corrected in the same pass).

## Decision

Bundle [ANSICON](https://github.com/adoxa/ansicon) and **launch it
automatically** on legacy Windows consoles that lack native ANSI support.
`LegacyAnsiBootstrapper` runs the bundled `ansicon.exe` (matching the process
architecture, x86 or x64) via `Process.Start(..., "-p")` and waits for it to
exit — no DLL injection or remote-thread APIs are involved — providing
transparent ANSI escape-sequence support with no manual installation or
configuration.

## Consequences

- **Positive:** ANSI rendering works transparently on old Windows without user
  action.
- **Negative / trade-off:** ships a native third-party executable per
  architecture, which some environments/AV tooling may flag merely for being an
  unfamiliar bundled binary; scoped strictly to legacy Windows where native
  ANSI is absent.

