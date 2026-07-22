<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Reading Input
</div>

[← Writing Output](writing-output.md) • [Back to Home](../README.md) • **Next:** [Markup Language →](markup.md)

---

ConsolePlus offers both the familiar `Console`-style reads and an enhanced **Emacs-style line
editor** with in-place editing, input filtering, case transformation, and async/cancellation
support.

## Table of contents
- [Basic reads](#basic-reads)
- [Reading keys](#reading-keys)
- [Asynchronous key reads](#asynchronous-key-reads)
- [The Emacs-style line editor](#the-emacs-style-line-editor)
  - [Key bindings](#key-bindings)
  - [ReadLineEmacs vs. ReadInlineEmacs](#readlineemacs-vs-readinlineemacs)
  - [Filtering input](#filtering-input)
  - [Case transformation and length limits](#case-transformation-and-length-limits)
  - [Async and cancellation](#async-and-cancellation)
- [Detecting available input](#detecting-available-input)
- [Cheat sheet](#cheat-sheet)

---

## Basic reads

```csharp
// Read a whole line (until Enter). Returns null at end of input.
string? line = ConsolePlus.ReadLine();

// Read the next character code (-1 if none).
int ch = ConsolePlus.Read();
```

These behave like their `System.Console` counterparts, but honor the ConsolePlus profile and
encoding settings.

---

## Reading keys

`ReadKey` returns a `ConsoleKeyInfo`. Pass `intercept: true` to prevent the key from being echoed to
the screen (useful for menus, hotkeys, or password entry):

```csharp
ConsolePlus.WriteLine("Press any key to continue...");
ConsoleKeyInfo key = ConsolePlus.ReadKey(intercept: true);

if (key.Key == ConsoleKey.Escape)
{
	ConsolePlus.WriteLine("[Yellow]Escaped![/]");
}
```

---

## Asynchronous key reads

`ReadKeyAsync` lets you await a key press without blocking a thread, and supports cancellation:

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

ConsoleKeyInfo? key = await ConsolePlus.ReadKeyAsync(intercept: true, cts.Token);

if (key is null)
{
	ConsolePlus.WriteLine("[Red]Timed out waiting for a key.[/]");
}
```

The result is `null` when cancellation occurs before a key is pressed.

---

## The Emacs-style line editor

The Emacs editor provides a richer input experience than `ReadLine`, with familiar in-line editing
key bindings, live styling, input filtering, and optional case forcing. It comes in four flavors:

| Method | Returns | New line echoed? | Async |
|--------|---------|------------------|-------|
| `ReadLineEmacs(...)` | `string` | ✅ Yes | ❌ |
| `ReadInlineEmacs(...)` | `string` | ❌ No | ❌ |
| `ReadLineEmacsAsync(...)` | `Task<string?>` | ✅ Yes | ✅ |
| `ReadInlineEmacsAsync(...)` | `Task<string?>` | ❌ No | ✅ |

All variants share the same optional parameters:

```csharp
string ReadLineEmacs(
	Func<char, bool>? acceptInput = null,   // filter which characters are allowed
	CaseOptions caseOptions = CaseOptions.Any, // Any | Uppercase | Lowercase
	int maxlength = int.MaxValue,           // maximum number of characters
	Style? style = null);                   // rendering style for the input
```

### Key bindings

While editing, the following Emacs-style shortcuts are available. Most of them also have an
equivalent standard editing key. Case-changing, deletion, and clearing commands only take effect
when there is text in the buffer.

**Cursor movement**

| Shortcut | Equivalent | Action |
|----------|------------|--------|
| `Ctrl+A` | `Home` | Move the cursor to the start of the line |
| `Ctrl+E` | `End` | Move the cursor to the end of the line |
| `Ctrl+B` | `←` | Move the cursor back one character |
| `Ctrl+F` | `→` | Move the cursor forward one character |
| `Alt+B` | — | Move the cursor back one word |
| `Alt+F` | — | Move the cursor forward one word |

**Editing and deletion**

| Shortcut | Equivalent | Action |
|----------|------------|--------|
| `Ctrl+H` | `Backspace` | Delete the character before the cursor |
| `Ctrl+D` | `Delete` | Delete the character under the cursor |
| `Ctrl+W` | — | Delete the word before the cursor |
| `Alt+D` | — | Delete the word after the cursor |
| `Ctrl+U` | — | Clear the line content before the cursor |
| `Ctrl+K` | — | Clear the line content after the cursor |
| `Ctrl+L` | — | Clear the whole line |
| `Ctrl+T` | — | Transpose (swap) the previous two characters |
| `Insert` | — | Toggle between insert and overwrite mode |

**Case transformation**

| Shortcut | Equivalent | Action |
|----------|------------|--------|
| `Alt+U` | — | Uppercase from the cursor to the end of the current word |
| `Alt+L` | — | Lowercase from the cursor to the end of the current word |
| `Ctrl+C` | — | Uppercase the character under the cursor and move to the end of the word |

> ℹ️ The `caseOptions` parameter forces the case of newly typed characters, while `Alt+U`, `Alt+L`,
> and `Ctrl+C` transform characters that are already in the buffer.

### Enable or disable Emacs letter shortcuts

If your terminal captures `Ctrl`/`Alt` combinations (common on some Linux terminal setups), you can
globally disable Emacs **letter** shortcuts for ConsolePlus input editors:

```csharp
// Disable Emacs letter shortcuts (Ctrl+A, Ctrl+E, Ctrl+K, Alt+F, ...)
ConsolePlus.EnabledEmacs = false;

// Re-enable Emacs letter shortcuts
ConsolePlus.EnabledEmacs = true;
```

When disabled, only Emacs-style letter combinations are ignored. Dedicated editing/navigation keys
such as arrows, `Home`, `End`, `Delete`, `Backspace`, and `Insert` continue to work normally.

### ReadLineEmacs vs. ReadInlineEmacs

- **`ReadLineEmacs`** moves to a new line after the user presses Enter (the newline is part of the
  console output but not the returned string). Use it for standalone prompts.
- **`ReadInlineEmacs`** does **not** emit a trailing newline, so the cursor stays on the same line.
  Use it when you want to keep drawing on the same row (e.g., inline labels).

```csharp
ConsolePlus.Write("Name: ");
string name = ConsolePlus.ReadLineEmacs();

ConsolePlus.Write("Inline: ");
string inline = ConsolePlus.ReadInlineEmacs();
ConsolePlus.WriteLine("  <-- cursor stayed on this line");
```

### Filtering input

`acceptInput` is a predicate invoked per character. Return `true` to accept the character, `false`
to reject it. This is perfect for constraining input to digits, letters, etc.

```csharp
// Only allow digits
string digits = ConsolePlus.ReadLineEmacs(acceptInput: char.IsDigit);

// Only allow letters and spaces
string letters = ConsolePlus.ReadLineEmacs(
	acceptInput: c => char.IsLetter(c) || c == ' ');
```

### Case transformation and length limits

Force the case of accepted characters and cap the length:

```csharp
using ConsolePlusLibrary;

// Force uppercase, max 10 characters, styled input
string code = ConsolePlus.ReadLineEmacs(
	acceptInput: char.IsLetterOrDigit,
	caseOptions: CaseOptions.Uppercase,
	maxlength: 10,
	style: new Style(Color.Black, Color.Gold));
```

`CaseOptions` values:

| Value | Effect |
|-------|--------|
| `Any` | No transformation (default) |
| `Uppercase` | Converts accepted characters to uppercase |
| `Lowercase` | Converts accepted characters to lowercase |

### Async and cancellation

The async variants accept a `CancellationToken` and return `null` if canceled:

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

string? answer = await ConsolePlus.ReadLineEmacsAsync(
	acceptInput: char.IsLetterOrDigit,
	caseOptions: CaseOptions.Any,
	maxlength: 50,
	style: null,
	cancellationToken: cts.Token);

if (answer is null)
	ConsolePlus.WriteLine("[Red]Input canceled or timed out.[/]");
```

---

## Detecting available input

| Member | Purpose |
|--------|---------|
| `KeyAvailable` | `true` if a key press is waiting in the input buffer (non-blocking) |
| `IsInputRedirected` | `true` if input is coming from a file/pipe instead of the keyboard |
| `In` | The underlying input `TextReader` |
| `SetIn(reader)` | Replace the input source (useful for tests) |
| `InputEncoding` | Get/set the input encoding |

```csharp
// Poll without blocking
while (!ConsolePlus.KeyAvailable)
{
	DoBackgroundWork();
}
var key = ConsolePlus.ReadKey(intercept: true);
```

---

## Cheat sheet

```csharp
// Basic
string? line = ConsolePlus.ReadLine();
int ch       = ConsolePlus.Read();
var key      = ConsolePlus.ReadKey(intercept: true);

// Async key with timeout
var k = await ConsolePlus.ReadKeyAsync(true, token);

// Emacs editor
string name  = ConsolePlus.ReadLineEmacs();
string digits = ConsolePlus.ReadLineEmacs(acceptInput: char.IsDigit, maxlength: 4);
string upper = ConsolePlus.ReadLineEmacs(caseOptions: CaseOptions.Uppercase);
string? a    = await ConsolePlus.ReadLineEmacsAsync(cancellationToken: token);
```

> 🧩 Need full-featured prompts — validation, defaults, masking, autocomplete, lists, and more?
> That is exactly what **[PromptPlus](promptplus.md)** adds on top of ConsolePlus.

> 🛠️ Building a **custom input loop**? The same buffer that powers `ReadLineEmacs` is public as
> [`EmacsConsoleBuffer`](advanced-api.md#the-emacs-input-buffer-emacsconsolebuffer). See the
> [Advanced API](advanced-api.md) guide.

---

[← Writing Output](writing-output.md) • [Back to Home](../README.md) • **Next:** [Markup Language →](markup.md)
