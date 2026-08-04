<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Architecture Decision Records (ADR)
</div>

[Back to Home](../../README.md) • **First:** [ADR0001 →](ADR0001V01R02-SplitConsolePlusAndPromptPlus.md)

---

This folder holds the **Architecture Decision Records** for ConsolePlus. Each
record captures one architectural decision, including its context, the decision
itself, alternatives, and consequences.

The records follow the [AdrPlus](https://github.com/FRACerqueira/AdrPlus)
convention, **profile 3 — "Product team with frequent revisions"**, which keeps
revision metadata visible and standardized:

```json
{
  "lenseq": 4,
  "lenversion": 2,
  "lenrevision": 2
}
```

## Naming convention

```
ADR{seq:0000}V{version:00}R{revision:00}-DecisionTitle.md
```

- `ADR0001V01R01-...` — created
- `ADR0001V02R01-...` — after a version bump (a new decision that replaces the prior version)
- `ADR0001V03R02-...` — after a revision within a version

Status labels: **Proposed** → **Accepted** / **Rejected**. **Superseded** is set by the
`supersede` command — a *different* decision, under a new sequence number, entirely
replacing this one — not by a version bump. Verified against `adrplus` v1.0.0-beta4: a
version bump (`version` command) leaves the predecessor's header at its last real status
(Accepted/Rejected) with a blank `Superseded` field; only the successor sequence-number
case populates it. The succession from a version bump is documented in prose only (the
predecessor's `Status:` bullet and this index's Status column), not in its machine-readable
header table.

Numbering is **per project** and independent from the PromptPlus ADR sequence.
ADR0001 records the foundational decision to split PromptPlus 5.x into two
projects (ConsolePlus + PromptPlus).

## Index

| ADR | Title | Version | Status |
| --- | --- | --- | --- |
| [ADR0001V01R02](ADR0001V01R02-SplitConsolePlusAndPromptPlus.md) | Split PromptPlus 5.x into two projects (ConsolePlus + PromptPlus) | V01 (R02) | Accepted |
| [ADR0002V01R02](ADR0002V01R02-ImmutableCapabilityProfile.md) | Immutable capability profile | V01 (R02) | Accepted |
| [ADR0003V01R01](ADR0003V01R01-AutomaticInitializationOnFirstAccess.md) | Automatic initialization on first access | V01 | Accepted |
| [ADR0004V01R01](ADR0004V01R01-AnsiVsNonAnsiDriverSelection.md) | ANSI vs non-ANSI driver selection | V01 | Accepted |
| [ADR0005V01R02](ADR0005V01R02-AnsiconLegacyWindowsSupport.md) | ANSICON launch (not injection) for legacy Windows | V01 (R02) | Accepted |
| [ADR0006V01R01](ADR0006V01R01-AutoDetectTriState.md) | `AutoDetect` tri-state for capabilities | V01 | Accepted |
| [ADR0007V01R01](ADR0007V01R01-GracefulDegradation.md) | Profile-driven graceful degradation | V01 | Accepted |
| [ADR0008V01R01](ADR0008V01R01-ColorDepthModel.md) | Color depth model (`ColorSystem`) | V01 | Accepted |
| [ADR0009V01R01](ADR0009V01R01-StyleModelColorOnly.md) | Style model: color + overflow only | V01 | Accepted |
| [ADR0010V01R01](ADR0010V01R01-MarkupLanguage.md) | Inline markup language for styling | V01 | Accepted |
| [ADR0011V01R01](ADR0011V01R01-ShutdownStateRestoration.md) | Shutdown state restoration | V01 | Accepted |
| [ADR0012V01R01](ADR0012V01R01-EmojiShortcodeModel.md) | Emoji shortcode model with fallback | V01 | Accepted |
| [ADR0013V01R01](ADR0013V01R01-LowLevelAnsiAndAlternateScreen.md) | Low-level ANSI and alternate-screen API | V01 | Accepted |
| [ADR0014V01R02](ADR0014V01R02-GeneratedApiDocsOffLimits.md) | Generated API docs are off-limits for manual edits; regeneration is gated on `ReleaseDoc`, not `Release` | V01 (R02) | Accepted |
| [ADR0015V01R02](ADR0015V01R02-RedirectedConsoleIoContract.md) | Redirected/headless console I/O: fail-safe writes, fail-loud reads | V01 (R02) | Accepted |
