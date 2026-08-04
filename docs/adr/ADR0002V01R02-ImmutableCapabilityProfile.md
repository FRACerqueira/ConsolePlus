<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Immutable capability profile|
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

  # ADR0002V01R02
</div>

[↑ ADR Index](indexadrs.md)

---

# ADR0002V01R02 — Immutable capability profile

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

**R02 addendum — the one supported override path, and a correction:** callers who need to
override auto-detected values do so via an optional `ConsoleProfile.json` file next to the
executable, read once in `EnvironmentUtil.CreateProfile` **before** detection and before any
downstream caching (e.g. `ConsoleWriter` caches `Profile.ColorDepth` in a `readonly` field at
construction; the ANSI-vs-NoAnsi adapter choice is also made once, at startup — see
[ADR0004V01R01](ADR0004V01R01-AnsiVsNonAnsiDriverSelection.md)). This is why a JSON-file override
works fully while a hypothetical post-init C# mutation API could not — by the time user code could
call it, the values it would change are already cached elsewhere. See
`docs/environment-detection.md` → "Override detection" for the full JSON schema.

This addendum exists because a 2026-07-25 docs audit found a public interface, `IProfileSetup`
(a fluent builder with `SupportsAnsi(AutoDetect)`, `ColorDepth(ColorSystem)`, `Apply()`, etc.), that
had **zero implementers and zero callers anywhere in the repository** — `ProfileConsole` (the
concrete class backing `IProfileReadOnly`) never implemented it, and one of its members
(`TimeMsResizeChange`) was referenced nowhere else at all. It directly contradicted this ADR's
"nothing... mutates the profile after initialization" line. It has been **deleted outright** — the
JSON mechanism above already covered everything it promised, and does so correctly (unaffected by
the caching problem a post-init API would hit). No consumer depended on it (ConsolePlus is
pre-1.0/Beta, so this is not considered a breaking change).

## Consequences

- **Positive:** stable, self-consistent rendering; detection cost paid once;
  read-only contract prevents accidental capability changes mid-run; the one real override path
  (`ConsoleProfile.json`) is now documented where users would look for it, and no orphaned API
  contradicts the immutability guarantee.
- **Negative / trade-off:** environment changes after startup (e.g. a resize of
  color support) are not reflected; acceptable because such changes are rare and
  restart-scoped. Overriding via `ConsoleProfile.json` requires a restart to take effect (the file
  is only read at startup) — there is no live-reload.

