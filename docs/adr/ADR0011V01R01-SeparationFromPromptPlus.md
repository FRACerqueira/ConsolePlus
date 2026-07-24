<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0011V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0011V01R01
</div>

[← ADR0010](ADR0010V01R01-MarkupLanguage.md) • [ADR Index](README.md) • **Next:** [ADR0012 →](ADR0012V01R01-ShutdownStateRestoration.md)

---



# ADR0011V01R01 — Separation of ConsolePlus and PromptPlus

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

Rendering (writing styled output, managing the screen) and interaction
(prompts, controls) are distinct concerns. Combining them in one library would
force interaction dependencies on users who only need rendering.

## Decision

Keep two separate products in two repositories: **ConsolePlus is the rendering
foundation** ("how you render") and **PromptPlus is the interactive toolkit**
("how you interact") layered on top. PromptPlus reuses the same console driver —
`PromptPlus.Console` is the same instance as `ConsolePlus.Driver`. ConsolePlus
has no dependency on PromptPlus.

## Consequences

- **Positive:** rendering can be used standalone; clear one-directional
  dependency; each product versions independently.
- **Negative / trade-off:** cross-repo coordination is needed when the shared
  driver contract changes; the boundary must be kept clean to avoid leakage.
