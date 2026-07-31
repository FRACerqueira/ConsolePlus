<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Demo Mode (Scripted Input)
</div>

[← Advanced API](advanced-api.md) • [Back to Home](../README.md)

---

**Demo Mode** lets you feed a console app pre-scripted key presses instead of waiting for a real
keyboard — with optional per-key delays that reproduce a natural typing rhythm. It exists to make
**recording** (GIFs, videos, screenshots) of interactive console apps reliable and repeatable, without
a human at the keyboard. It is purely additive and opt-in: when disabled, every input member behaves
exactly as if Demo Mode did not exist, even if scripted keys happen to be queued.

> 🎬 This is exactly how the demo GIF in [PromptPlus's README](https://github.com/FRACerqueira/PromptPlus)
> was produced (recorded as video, then converted to GIF for reliable autoplay/loop on GitHub) — see
> the runnable
> [`AutoDemoSamples`](https://github.com/FRACerqueira/PromptPlus/tree/main/samples/AutoDemoSamples)
> sample project and PromptPlus's own [Demo Mode guide](https://github.com/FRACerqueira/PromptPlus/blob/main/docs/demo-mode.md)
> for the control-level view.

## Table of contents
- [How it works](#how-it-works)
- [API reference](#api-reference)
- [Basic usage](#basic-usage)
- [Pacing scripted keys](#pacing-scripted-keys)
- [Scripting multiple controls in sequence](#scripting-multiple-controls-in-sequence)
- [Demo Mode and redirected/headless input](#demo-mode-and-redirectedheadless-input)
- [Live controls need no scripted keys](#live-controls-need-no-scripted-keys)

---

## How it works

`KeyAvailable`, `ReadKey`, and `ReadKeyAsync` all check the scripted-key queue **first**, before any
other logic (including the redirected-input checks described in
[ADR0015](adr/ADR0015V01R02-RedirectedConsoleIoContract.md)):

- If `DemoModeEnabled` is `true` **and** a key is queued, that key is dequeued and returned (after its
  configured delay, if any) — real console input is never touched for that read.
- Otherwise, execution falls through to the exact same behavior as if Demo Mode did not exist.

This means `DemoModeEnabled = true` by itself changes nothing observable — it only takes effect once a
key is actually enqueued. `DemoModeActive` reflects that combined state (`DemoModeEnabled &&` queue
non-empty), and is the flag PromptPlus's controls actually check.

---

## API reference

All members live on `IConsole`, so they're reachable through the static `ConsolePlus` facade (and
through `PromptPlus.Console`, since it *is* an `IConsole`):

| Member | Purpose |
|--------|---------|
| `DemoModeEnabled` (get/set) | Master opt-in switch. Default `false`. |
| `DemoModeActive` (get) | `true` when `DemoModeEnabled` is `true` **and** at least one scripted key is queued right now. |
| `HasScriptedInput` (get) | `true` when a scripted key is queued, regardless of `DemoModeEnabled`. |
| `ScriptedDelayMs` (get/set) | Default delay, in milliseconds, applied before a scripted key is consumed when the key itself didn't specify one. |
| `EnqueueKey(ConsoleKeyInfo key, int? delayMs = null)` | Enqueues one exact key press. |
| `EnqueueKey(ConsoleKey key, bool shift = false, bool alt = false, bool ctrl = false, int? delayMs = null)` | Enqueues one key press built from a `ConsoleKey` and modifiers; fills in the `KeyChar` a real console would report (e.g. `'\r'` for `Enter`), so controls that check `KeyChar` work correctly. |
| `EnqueueKeys(params ConsoleKeyInfo[] keys)` | Enqueues several key presses, in order, each using `ScriptedDelayMs`. |
| `EnqueueKeys(int delayMs, params ConsoleKeyInfo[] keys)` | Same, but every key shares the given explicit delay. |
| `EnqueueText(string text, int? delayMs = null)` | Enqueues one key press per character of `text` (letters, digits, space, `-`, `.`, `,` are mapped to their real key; anything else falls back to a generic key with the correct `KeyChar`). |
| `ClearScriptedInput()` | Discards all pending scripted keys. |

The queue is a thread-safe FIFO (`ConcurrentQueue`) — safe to enqueue from a different thread than the
one calling `Run()`/`ReadKey`, which matters for controls that read input on their own thread.

---

## Basic usage

```csharp
using ConsolePlusLibrary;

ConsolePlus.DemoModeEnabled = true;
ConsolePlus.ScriptedDelayMs = 180; // typing-effect pacing between keys

// Script the answer to a prompt before asking for it.
ConsolePlus.EnqueueText("Fulano", delayMs: 500);
ConsolePlus.EnqueueKey(ConsoleKey.Enter, delayMs: 500);

ConsolePlus.Write("Name: ");
var key = ConsolePlus.ReadKey();
// ... continue reading until Enter, exactly like real keyboard input

ConsolePlus.DemoModeEnabled = false; // back to real input
```

`EnqueueText`/`EnqueueKey` never block — they just add to the queue. The actual delay is applied
later, when that specific key is *consumed* by `ReadKey`/`ReadKeyAsync`.

---

## Pacing scripted keys

Every enqueue overload accepts an optional `delayMs`:

- If given, it wins for that key.
- If omitted (`null`), the current `ScriptedDelayMs` value is used **at consumption time**, not at
  enqueue time — so changing `ScriptedDelayMs` mid-script affects keys enqueued earlier but not yet
  consumed.
- A delay of `0` (or `ScriptedDelayMs = 0`) consumes the key immediately, with no pacing.

---

## Scripting multiple controls in sequence

Demo Mode makes no attempt to synchronize across controls — you enqueue what one control needs
immediately before running it:

```csharp
ConsolePlus.DemoModeEnabled = true;
ConsolePlus.ScriptedDelayMs = 180;

ConsolePlus.EnqueueText("Fulano", delayMs: 500);
ConsolePlus.EnqueueKey(ConsoleKey.Enter, delayMs: 500);
var name = PromptPlus.Controls.Input("Name").Run();

ConsolePlus.EnqueueKey(ConsoleKey.DownArrow, delayMs: 800);
ConsolePlus.EnqueueKey(ConsoleKey.Enter, delayMs: 800);
var color = PromptPlus.Controls.Select<string>("Color").AddItems(["Red", "Green", "Blue"]).Run();
```

This works without any extra coordination because `Run()` only returns after it has consumed its own
`Enter` (or whatever key finishes that control) — by the time the next `EnqueueKey` call runs, the
previous control's queue is guaranteed to be empty.

---

## Demo Mode and redirected/headless input

Because the scripted-key check happens *before* the redirected-input checks from
[ADR0015](adr/ADR0015V01R02-RedirectedConsoleIoContract.md), a queued scripted key is consumed even
when `Console.IsInputRedirected` is `true` — this is what lets an interactive control run inside an
automated recording pipeline (piped/redirected stdio) without hitting the "not interactive"/redirected
guards that would otherwise fire. PromptPlus's controls specifically check `DemoModeActive` for this
reason — see PromptPlus's [Demo Mode guide](https://github.com/FRACerqueira/PromptPlus/blob/main/docs/demo-mode.md).

> ⚠️ **This bypass is per-read-call, not a blanket immunity.** `DemoModeEnabled = true` alone does
> **not** make a redirected run safe — only `DemoModeActive` (enabled **and** a key currently queued)
> does. If the scripted queue runs dry while a control still needs another key, execution falls straight
> through to normal redirected-input handling — under genuine redirection, `KeyAvailable` starts
> returning `false` forever and any guard built on top of it (e.g. PromptPlus's) fires normally. A
> script driving a redirected run must queue **every** key each control needs before that control's
> `Run()` returns control back to you.

---

## Live controls need no scripted keys

Controls that complete on their own signal — a progress value reaching 100%, a wrapped task
finishing, a countdown elapsing — never call `ReadKey` to produce a result, so they run identically
under Demo Mode, redirected input, both, or neither. There is nothing to script for them.

---

[← Advanced API](advanced-api.md) • [Back to Home](../README.md)
