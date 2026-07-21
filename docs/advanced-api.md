<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Advanced API
</div>

[← ConsolePlus + PromptPlus](promptplus.md) • [Back to Home](../README.md)

---

Most applications only need the high-level facade (`ConsolePlus.WriteLine`, `ReadLineEmacs`,
`Banner`, and so on). This page documents the **lower-level building blocks** that ConsolePlus also
exposes as public API. They are useful when you are building your own renderers, custom input
editors, or thread-safe output pipelines on top of ConsolePlus.

> 💡 You do **not** need any of these for everyday output and input. Reach for them only when you
> need fine-grained control or want to reuse ConsolePlus internals in your own components.

## Table of contents
- [Accessing the underlying driver (`ConsolePlus.Driver`)](#accessing-the-underlying-driver-consoleplusdriver)
- [Thread-safe output (`ConsolePlus.RunAtomic`)](#thread-safe-output-consoleplusrunatomic)
- [Text fragments (`Fragment` and `FragmentKind`)](#text-fragments-fragment-and-fragmentkind)
- [The Emacs input buffer (`EmacsConsoleBuffer`)](#the-emacs-input-buffer-emacsconsolebuffer)
- [String helpers (`StringExtensions`)](#string-helpers-stringextensions)
- [Culture helpers (`CultureExtensions`)](#culture-helpers-cultureextensions)
- [Key helpers (`ConsoleKeyInfoExtensions`)](#key-helpers-consolekeyinfoextensions)
- [Cheat sheet](#cheat-sheet)

---

## Accessing the underlying driver (`ConsolePlus.Driver`)

The static `ConsolePlus` facade forwards every call to a single **driver** — an `IConsole`
implementation chosen at startup (an ANSI adapter or a classic-console adapter, depending on the
detected [profile](profiles-and-capabilities.md)). `ConsolePlus.Driver` exposes that instance so you
can pass it to components that accept an `IConsole` directly.

```csharp
using ConsolePlusLibrary;

// The same driver the static facade uses under the hood
IConsole console = ConsolePlus.Driver;

// Anything written through the driver goes to the same output as ConsolePlus.WriteLine
console.WriteLine("Written through the driver", (Style)Color.Aqua);
```

| Member | Type | Description |
|--------|------|-------------|
| `ConsolePlus.Driver` | `IConsole` | The console driver backing the static facade |

> ℹ️ This is exactly the instance that **PromptPlus** consumes as `PromptPlus.Console`, which is why
> the two libraries render to the same output seamlessly. See
> [ConsolePlus + PromptPlus](promptplus.md).

---

## Thread-safe output (`ConsolePlus.RunAtomic`)

When multiple threads write to the console at the same time, their output can interleave mid-line.
`ConsolePlus.RunAtomic(Action)` runs your output block inside the console's **global
synchronization scope**, so everything the action writes is emitted as one uninterrupted unit.

```csharp
using ConsolePlusLibrary;

// Guarantees these three writes are not split by output from other threads
ConsolePlus.RunAtomic(() =>
{
	ConsolePlus.Write("[Yellow]Progress:[/] ");
	ConsolePlus.Write("42%");
	ConsolePlus.WriteLine(" (working...)");
});
```

| Member | Signature | Description |
|--------|-----------|-------------|
| `ConsolePlus.RunAtomic` | `void RunAtomic(Action action)` | Runs `action` atomically with respect to console output |

> ⚠️ Keep the action **short** — it holds the console lock while it runs. Do slow work (I/O,
> computation) *before* entering `RunAtomic`, then only write inside it.

---

## Text fragments (`Fragment` and `FragmentKind`)

Internally, ConsolePlus turns a marked-up string into a sequence of **fragments** before rendering.
A `Fragment` is an immutable piece of text paired with an optional [`Style`](styles.md) and a
semantic `FragmentKind`. `Fragment.FromText` is the same parser the facade uses, so you can reuse it
to inspect or transform output before writing it yourself.

### `FragmentKind`

| Value | Meaning |
|-------|---------|
| `ContentText` | Regular text written to the output as-is |
| `LineBreak` | A line break that advances to the next line |
| `ClearRestofline` | A directive to clear the rest of the current line from the cursor |

### `Fragment`

| Member | Type | Description |
|--------|------|-------------|
| `Fragment(text, style?, type)` | constructor | Creates a fragment; `type` defaults to `ContentText` |
| `Text` | `string` | The fragment content (new lines normalized for content text) |
| `Style` | `Style?` | The style applied to this fragment, when any |
| `Type` | `FragmentKind` | The semantic category of the fragment |
| `Fragment.FromText(text, defaultStyle, clearRestOfLine)` | `static Fragment[]` | Parses markup text into styled fragments |

```csharp
using ConsolePlusLibrary;

// Parse a marked-up string into its styled parts
Fragment[] parts = Fragment.FromText("[Red]Error:[/] disk full", ConsolePlus.CurrentStyle);

foreach (Fragment part in parts)
{
	if (part.Type == FragmentKind.ContentText)
	{
		ConsolePlus.WriteLine($"text='{part.Text}' style={part.Style}");
	}
}
```

---

## The Emacs input buffer (`EmacsConsoleBuffer`)

`EmacsConsoleBuffer` is the editable text buffer that powers
[`ReadLineEmacs` / `ReadInlineEmacs`](reading-input.md#the-emacs-style-line-editor). It applies
Emacs-style editing semantics (cursor movement, word operations, kill/yank, case transforms) to an
in-memory string. Expose it directly when you are building a **custom input loop** and want the same
editing behavior ConsolePlus uses.

Create one with three options:

- `isreadlonly` — when `true`, the buffer rejects edits (useful for read-only display).
- `caseOption` — a [`CaseOptions`](reading-input.md#case-transformation-and-length-limits) value
  (`Any`, `Uppercase`, or `Lowercase`) applied to typed characters.
- `validate` — an optional `Func<char, bool>` that filters which characters are accepted.

```csharp
using ConsolePlusLibrary;
using System;

// A digit-only, upper-case buffer
var buffer = new EmacsConsoleBuffer(
	isreadlonly: false,
	caseOption: CaseOptions.Uppercase,
	validate: char.IsLetterOrDigit);

// Feed keys from your own read loop
ConsoleKeyInfo key = Console.ReadKey(intercept: true);
buffer.TryAcceptedReadlineConsoleKey(key, maxlength: 20);

// Inspect the result
Console.WriteLine($"Text='{buffer}' Position={buffer.Position} Length={buffer.Length}");
```

### Key members

| Member | Description |
|--------|-------------|
| `Position` | Current cursor position within the buffer |
| `Length` | Number of characters currently in the buffer |
| `TryAcceptedReadlineConsoleKey(keyinfo, maxlength)` | Processes a key press with Emacs semantics; returns `true` when handled |
| `LoadPrintable(value, maxlength)` | Replaces the content with the printable characters of `value` (chainable) |
| `Clear()` | Clears the buffer and resets the cursor (chainable) |
| `ToHome()` | Moves the cursor to the beginning of the buffer |
| `ToBackward()` | Returns the text before the cursor |
| `ToForward()` | Returns the text from the cursor onward |
| `ToString()` | Returns the full buffer content |
| `IsPrintable(char)` / `IsPrintable(ConsoleKeyInfo)` | Tests whether a character/key is renderable |

> 💡 For ordinary line input you should prefer the ready-made
> [`ReadLineEmacs`](reading-input.md#the-emacs-style-line-editor) helpers — they already wire this
> buffer to the terminal, rendering, and cancellation for you.

---

## String helpers (`StringExtensions`)

`StringExtensions` provides small, allocation-conscious helpers that ConsolePlus uses to lay out
text. They are handy whenever you need to measure or normalize strings the same way the renderer
does — for example when aligning columns that may contain wide (CJK) characters or emoji.

| Extension | Returns | Description |
|-----------|---------|-------------|
| `NormalizeNewLines()` | `string` | Converts all line endings to `Environment.NewLine` |
| `SplitLines()` | `string[]` | Splits text into lines after normalizing line endings |
| `GetDisplayLength()` | `int[]` | Display width of each line, counting wide characters as 2 columns |

```csharp
using ConsolePlusLibrary;

string text = "Hello\n世界";       // second line has two wide characters

string[] lines = text.SplitLines();       // ["Hello", "世界"]
int[] widths = text.GetDisplayLength();    // [5, 4]  (世界 = 4 display columns)
```

> 💡 Use `GetDisplayLength()` instead of `string.Length` when aligning text in the terminal —
> emoji and CJK glyphs occupy two columns, so `string.Length` would misalign them.

---

## Culture helpers (`CultureExtensions`)

`CultureExtensions.ExistsCulture` safely checks whether a culture name is recognized by .NET,
**without throwing** for invalid names. It is a fast, O(1) lookup — useful before switching cultures
based on user input or configuration.

| Extension | Returns | Description |
|-----------|---------|-------------|
| `ExistsCulture()` | `bool` | `true` when the string is a valid, recognized culture name |

```csharp
using ConsolePlusLibrary;

if ("pt-BR".ExistsCulture())
{
	ConsolePlus.WriteLine("[Green]Culture is available[/]");
}

bool invalid = "xx-YY".ExistsCulture();   // false — no exception thrown
```

---

## Key helpers (`ConsoleKeyInfoExtensions`)

`ConsoleKeyInfoExtensions` adds convenience methods on `ConsoleKeyInfo` for the key combinations
that ConsolePlus uses internally (including Emacs-style shortcuts). They help you keep your custom
input loops readable instead of repeating raw key/modifier checks.

| Extension | Returns | Description |
|-----------|---------|-------------|
| `IsPressEnterKey(emacskeys: true)` | `bool` | `Enter` (and optionally `Ctrl+J`) |
| `IsPressTabKey()` | `bool` | `Tab` with no modifiers |
| `IsPressHomeKey(emacskeys: true)` | `bool` | `Home` (and optionally `Ctrl+A`) |
| `IsPressEndKey(emacskeys: true)` | `bool` | `End` (and optionally `Ctrl+E`) |
| `IsPressSpecialKey(key, modifier)` | `bool` | Generic key+modifier matcher |

```csharp
using ConsolePlusLibrary;

ConsoleKeyInfo key = Console.ReadKey(intercept: true);

if (key.IsPressEnterKey())
{
	ConsolePlus.WriteLine("submit");
}
else if (key.IsPressHomeKey())
{
	ConsolePlus.WriteLine("go to start");
}
else if (key.IsPressEndKey())
{
	ConsolePlus.WriteLine("go to end");
}
```

> 💡 There are many additional helpers for Emacs editing actions (word movement, clear word,
> transpose, etc.) in `ConsoleKeyInfoExtensions`.

---

## Cheat sheet

```csharp
using ConsolePlusLibrary;

// Underlying driver
IConsole console = ConsolePlus.Driver;

// Atomic (thread-safe) output block
ConsolePlus.RunAtomic(() => ConsolePlus.WriteLine("one uninterrupted unit"));

// Parse markup into fragments
Fragment[] parts = Fragment.FromText("[Red]hi[/]", ConsolePlus.CurrentStyle);

// Custom Emacs input buffer
var buffer = new EmacsConsoleBuffer(false, CaseOptions.Any, char.IsLetterOrDigit);

// String measuring/normalizing (wide-char aware)
int[] widths = "Hello\n世界".GetDisplayLength();   // [5, 4]
string[] lines = "a\r\nb".SplitLines();            // ["a", "b"]

// Culture check (no exception)
bool ok = "pt-BR".ExistsCulture();
```

---

[← ConsolePlus + PromptPlus](promptplus.md) • [Back to Home](../README.md)
