<!-- Do not remove this comment, lines and table (1-12) -->
|Adr-Plus Fields|Values Migrated <!-- Migrated -->|
|--|--|
|ADR|Redirected/headless console I/O: fail-safe writes, fail-loud reads|
|Version|01|
|Revision|02|
|Scope||
|Domain||
|Created|Proposed (2026-07-28)|
|Changed|Accepted (2026-07-31)|
|Superseded||
<!-- Do not remove this comment, lines and table (1-12) -->

<div align="center">
  <img src="../../icon.png" alt="ConsolePlus" width="120" height="120" />

  # ADR0015V01R02
</div>

[← ADR0014](ADR0014V01R02-GeneratedApiDocsOffLimits.md) • [ADR Index](README.md)

---

# ADR0015V01R02 — Redirected/headless console I/O: fail-safe writes, fail-loud reads

## Context

A process whose console I/O is redirected (a file, a pipe, a CI runner, or a test host such as
`dotnet test` itself) has no live OS console handle. Two classes of member are affected differently,
and two real bugs (found 2026-07-28 while auditing whether ConsolePlus's public API runs error-free
under redirection) showed the driver was inconsistent about which failure mode applies where:

1. **Cursor/screen writes** — `Clear()`, `SetCursorPosition()`, the `CursorLeft`/`CursorTop` setters —
   called the raw `Console.*` API unguarded in `NoAnsiConsoleAdapter`. Under a redirected/headless
   process this threw `IOException: "The handle is invalid."`, even though `HideCursor()`/
   `ShowCursor()` and `EnvironmentUtil.GetSafeWidth`/`GetSafeHeight`/`GetSafeTopCursor` already had an
   established "Safe" pattern (catch `IOException`/`PlatformNotSupportedException`, degrade quietly)
   for exactly this situation.
2. **Key reads** — `KeyAvailable`, `ReadKey`, `ReadKeyAsync` — only guarded on `_profile.Interactive`,
   which reflects a **hardcoded list of known CI providers** (see
   [Environment Detection](../environment-detection.md)), not the real `Console.IsInputRedirected`.
   Any redirected process outside that list (including this project's own local `dotnet test` run)
   hit the raw `Console.KeyAvailable`/`ReadKey` call, which throws a raw, undocumented
   `InvalidOperationException` for `ReadKey` or behaves unpredictably for `KeyAvailable`.

`Read()`/`ReadLine()` were not part of this problem: they read from the input **text stream**, which
a redirected file/pipe legitimately provides — `Console.ReadLine()` works correctly against redirected
input. Only key-based reads need a **live interactive input buffer**, which redirection does not have.

## Decision

Establish one explicit, documented contract for every member that touches the console under
redirected/headless I/O, split by what the member does:

- **Presentation-only writes** (`Clear`, `SetCursorPosition`, `CursorLeft`/`CursorTop` setters,
  `HideCursor`/`ShowCursor`) — **fail safe**. Wrap the raw `Console.*` call in
  `catch (Exception ex) when (ex is PlatformNotSupportedException or IOException)` and silently
  no-op (or return `false` for the two members that already have a boolean success contract). These
  calls only affect what is visually drawn; there is nothing meaningful to report when there is no
  screen to draw on, and forcing every caller to guard every cursor/clear call would be unreasonable.
- **Blocking/consuming reads** (`Read`, `ReadLine`, `ReadKey`, `ReadKeyAsync`) — **fail loud, predictably**.
  Throw `InvalidOperationException("Console is not interactive.")` — the same message and type for
  all four — instead of letting a raw platform exception (or an inconsistent one) leak through. A
  read that cannot happen is a real logic error the caller must handle, not something to swallow.
- **The non-blocking probe** `KeyAvailable` — **fails safe**, returning `false` instead of throwing.
  It already has a non-throwing contract (`while (!KeyAvailable) { ... }` is the documented polling
  idiom in [Reading Input](../reading-input.md)); making it throw would break every such loop.
- `ReadKey`/`ReadKeyAsync`/`KeyAvailable` check **both** `_profile.Interactive` **and**
  `Console.IsInputRedirected` explicitly — `Interactive` alone only reflects the CI-provider
  heuristic and does not catch plain redirection outside that list. `Read()`/`ReadLine()` keep
  checking `Interactive` only, since redirected input is a valid source for them.

> **R02 amendment:** all three of `ReadKey`/`ReadKeyAsync`/`KeyAvailable` now check the
> [Demo Mode](../demo-mode.md) scripted-key queue **before** any of the logic above. When
> `DemoModeEnabled` is `true` and a scripted key is queued, `ReadKey`/`ReadKeyAsync` return that key
> instead of throwing, and `KeyAvailable` returns `true` instead of `false` — regardless of
> `IsInputRedirected`. This decision's fail-loud/fail-safe split is therefore the behavior once the
> scripted queue is empty (or Demo Mode is disabled), not an unconditional guarantee for these three
> members. Demo Mode is opt-in and additive: no caller that never enables it is affected.

## Consequences

- **Positive:** one predictable rule instead of case-by-case behavior — "does this member draw, or
  does it consume a real keystroke?" answers which failure mode applies. No raw platform exceptions
  (`IOException`, undocumented `InvalidOperationException` text) leak to callers. Matches the
  project's existing "Safe" pattern (`EnvironmentUtil.GetSafe*`) instead of adding a second one.
- **Negative / trade-off:** a caller polling `KeyAvailable` in a loop with no independent exit
  condition (no `CancellationToken`, no timeout) will now loop forever under redirected input instead
  of crashing, because `KeyAvailable` no longer throws — it simply never becomes `true`, **unless**
  Demo Mode is active and keys are queued, in which case it becomes `true` exactly as scripted. This
  is correct for `KeyAvailable`'s own non-throwing contract, but any code built on top of it (such as
  PromptPlus's interactive controls) must add its **own** upfront `IsInputRedirected` check if it
  wants to fail fast instead of hanging — see PromptPlus's ADR0023 — "Guard interactive
  controls against redirected console input" — which does exactly that on top of this
  contract (and itself carves out the same Demo Mode exception).
- **Dependency (R02):** a script driving a redirected/headless run under Demo Mode must keep the
  scripted-key queue non-empty for the entire duration a consuming control needs it — the exception
  above is evaluated per read call, not latched for the whole run. See
  [Demo Mode → Demo Mode and redirected/headless input](../demo-mode.md#demo-mode-and-redirectedheadless-input).

