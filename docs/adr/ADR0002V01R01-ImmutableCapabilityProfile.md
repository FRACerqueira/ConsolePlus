<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0002V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0002V01R01
</div>

[← ADR0001](ADR0001V01R01-SplitConsolePlusAndPromptPlus.md) • [ADR Index](README.md) • **Next:** [ADR0003 →](ADR0003V01R01-AutomaticInitializationOnFirstAccess.md)

---



# ADR0002V01R01 — Immutable capability profile

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Rendering decisions (ANSI, Unicode, color depth, interactivity) must be
consistent for the whole process lifetime. Re-detecting per call would be slow
and could produce inconsistent output if the environment appears to change.

## Decision

Detect the environment **once** and expose it as an **immutable snapshot**,
`ConsolePlus.Profile` typed as `IProfileReadOnly`. The profile describes
`ProfileName`, `IsTerminal`, `Interactive`, `SupportUnicode`, `SupportsAnsi`,
`ColorDepth`, captured culture, default/original colors and encodings. Nothing
in the public API mutates the profile after initialization.

## Consequences

- **Positive:** stable, self-consistent rendering; detection cost paid once;
  read-only contract prevents accidental capability changes mid-run.
- **Negative / trade-off:** environment changes after startup (e.g. a resize of
  color support) are not reflected; acceptable because such changes are rare and
  restart-scoped.
