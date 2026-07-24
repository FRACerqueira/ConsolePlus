<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0015V01R01 |
| Version | 01 |
| Revision | 01 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-24 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0015V01R01
</div>

[← ADR0014](ADR0014V01R01-LowLevelAnsiAndAlternateScreen.md) • [ADR Index](README.md)

---



# ADR0015V01R01 — Generated API docs are off-limits for manual edits

- **Status:** Accepted
- **Version:** V01 / Revision R01
- **Created:** 2026-07-24

## Context

The `docs/api/` folder is generated from XML doc comments by the documentation
tooling. Manual edits there are silently overwritten on the next build and give
a false impression of being authoritative.

## Decision

`docs/api/` is **generated output** and must never be edited by hand. All API
documentation changes are made in the source XML doc comments. Narrative and
conceptual documentation lives in the hand-written `docs/*.md` files, which are
the only Markdown docs that may be edited directly. See
`docs/api-documentation-guide.md`.

## Consequences

- **Positive:** single source of truth for API docs (the code); no lost edits.
- **Negative / trade-off:** correcting API text requires a code change and a
  regeneration step rather than a quick Markdown edit.
