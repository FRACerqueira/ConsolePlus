<!-- Do not remove this comment, lines and table -->
<!--
| Fields | Values |
| --- | --- |
| ADR | ADR0014V01R02 |
| Version | 01 |
| Revision | 02 |
| Status | Accepted |
| Created | 2026-07-24 |
| Changed | 2026-07-25 |
| Superseded |  |
-->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0014V01R02
</div>

[← ADR0013](ADR0013V01R01-LowLevelAnsiAndAlternateScreen.md) • [ADR Index](README.md) • **Next:** [ADR0015 →](ADR0015V01R02-RedirectedConsoleIoContract.md)

---

# ADR0014V01R02 — Generated API docs are off-limits for manual edits; regeneration is gated on `ReleaseDoc`, not `Release`

- **Status:** Accepted
- **Version:** V01 / Revision R02
- **Created:** 2026-07-24
- **Changed:** 2026-07-25 (R02 — fixed the build-configuration gate that actually triggers
  regeneration)

## Context

The `docs/api/` folder is generated from XML doc comments by the documentation
tooling. Manual edits there are silently overwritten on the next build and give
a false impression of being authoritative.

`src/ConsolePlus.csproj` declares `<Configurations>Debug;Release;ReleaseDoc</Configurations>` — a
dedicated `ReleaseDoc` configuration exists precisely so that regenerating `docs/api/` (via
`DefaultDocumentation`) is a deliberate, separate step from `Release`, which is used to pack and
publish the NuGet package. This mirrors the sibling PromptPlus repository's already-correct setup.

**R02 finding:** while regenerating `docs/api/` for an unrelated change, `dotnet build -c
ReleaseDoc` produced no `DefaultDocumentation` output at all. The `PackageReference`/
`PropertyGroup`/`AddDocIconHeader` target conditions in the csproj all still checked
`'$(Configuration)' == 'Release'` — a leftover from before the `ReleaseDoc` configuration was
introduced into the `Configurations` list. `ReleaseDoc` existed as a buildable configuration name
but nothing was actually gated on it; `Release` builds were silently paying the
`DefaultDocumentation` cost that the dedicated configuration was supposed to isolate.

## Decision

`docs/api/` is **generated output** and must never be edited by hand. All API
documentation changes are made in the source XML doc comments. Narrative and
conceptual documentation lives in the hand-written `docs/*.md` files, which are
the only Markdown docs that may be edited directly. See
`docs/api-documentation-guide.md`.

**R02 addendum:** changed all three conditions (`ItemGroup` `PackageReference`, `PropertyGroup`
with the `DefaultDocumentation*` properties, and the `AddDocIconHeader` target) from
`'$(Configuration)' == 'Release'` to `'$(Configuration)' == 'ReleaseDoc'`. `docs/api/` regeneration
now requires `dotnet build src/ConsolePlus.csproj -c ReleaseDoc -f net10.0`; `-c Release` no longer
touches `docs/api/` at all. `docs/api-documentation-guide.md` updated to match.

## Consequences

- **Positive:** single source of truth for API docs (the code); no lost edits. `Release` builds
  (used for NuGet packing) no longer carry the `DefaultDocumentation` package/analysis cost;
  regeneration is now an explicit, intentional step, matching the sibling PromptPlus repo.
- **Negative / trade-off:** correcting API text requires a code change and a
  regeneration step rather than a quick Markdown edit. Anyone with a local habit of running
  `-c Release` to pick up doc changes must switch to `-c ReleaseDoc`. No CI workflow depended on
  the old behavior (verified: neither `ci.yml` nor `publish-nuget.yml` reference `docs/api` or
  `DefaultDocumentation`), so this has no automation impact.
