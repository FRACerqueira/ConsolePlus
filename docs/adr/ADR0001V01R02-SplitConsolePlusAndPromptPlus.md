	<!-- Do not remove this comment, lines and table -->
	<!--
	| Fields | Values |
| --- | --- |
| ADR | ADR0001V01R02 |
| Version | 01 |
| Revision | 02 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-25 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0001V01R02
</div>

[ADR Index](README.md) • **Next:** [ADR0002 →](ADR0002V01R02-ImmutableCapabilityProfile.md)

---



# ADR0001V01R02 — Split PromptPlus 5.x into two projects (ConsolePlus + PromptPlus)

- **Status:** Accepted
- **Version:** V01 / Revision R02
- **Created:** 2026-07-24
- **Changed:** 2026-07-25

## Context

Up to version **5.x**, PromptPlus was a single library that bundled two very
different responsibilities:

- **Low-level console rendering** — writing styled output, colors, markup,
  cursor/screen control, terminal capability detection, and graceful degradation
  across terminals, SSH sessions, CI pipelines, and redirected output.
- **High-level interaction** — prompts and controls (input, select, confirm,
  etc.) that read the keyboard and return a user result.

Bundling both in one package meant that consumers who only needed **rendering**
were forced to depend on the entire interaction stack, and the rendering engine
could not be evolved, tested, or versioned independently of the interactive
controls.

## Decision

Starting after the 5.x line, **split PromptPlus into two separate projects, each
in its own repository**:

- **ConsolePlus** — the rendering foundation ("how you render"): the immutable
  capability profile, ANSI/non-ANSI drivers, colors, markup, styles,
  cursor/screen control, emoji, and low-level ANSI access.
- **PromptPlus** — the interactive toolkit ("how you interact"): controls and
  widgets layered on top of ConsolePlus.

ConsolePlus is the base layer and has **no dependency on PromptPlus**. PromptPlus
depends on ConsolePlus (one-directional) and reuses the same console driver
instance (`PromptPlus.Console` is the same as `ConsolePlus.Driver`).

**R02 — 2026-07-25:** this record absorbs the former ADR0011 ("Separation of
ConsolePlus and PromptPlus"), which restated the same split decision from the
ongoing-boundary angle without adding a distinct decision of its own. The
boundary must be kept clean going forward: neither project should leak
implementation details across the dependency direction established above.

## Consequences

- **Positive:** ConsolePlus can be consumed standalone for pure rendering; the
  rendering engine evolves and releases on its own cadence; the
  rendering/interaction boundary is explicit and independently testable.
- **Negative / trade-off:** two repositories to coordinate when the shared driver
  contract changes; PromptPlus consumers upgrading from 5.x must take on the
  ConsolePlus dependency; the boundary must be actively kept clean to avoid
  leakage in either direction.

## Related

- PromptPlus ADR0001 records the same decision from the interaction side.
