	<!-- Do not remove this comment, lines and table -->
	<!--
	| Fields | Values |
| --- | --- |
| ADR | ADR0001V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0001V01R01
</div>

[ADR Index](README.md) • **Next:** [ADR0002 →](ADR0002V01R01-ImmutableCapabilityProfile.md)

---



# ADR0001V01R01 — Split PromptPlus 5.x into two projects (ConsolePlus + PromptPlus)

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

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

## Consequences

- **Positive:** ConsolePlus can be consumed standalone for pure rendering; the
  rendering engine evolves and releases on its own cadence; the
  rendering/interaction boundary is explicit and independently testable.
- **Negative / trade-off:** two repositories to coordinate when the shared driver
  contract changes; PromptPlus consumers upgrading from 5.x must take on the
  ConsolePlus dependency.

## Related

- [ADR0011](ADR0011V01R01-SeparationFromPromptPlus.md) details the ongoing
  boundary and one-directional dependency between the two projects.
- PromptPlus ADR0001 records the same decision from the interaction side.
