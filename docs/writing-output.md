<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Writing Output
</div>

[← Getting Started](getting-started.md) • [Back to Home](../README.md) • **Next:** [Reading Input →](reading-input.md)

---

ConsolePlus provides a complete, style-aware output API. Every overload accepts an optional
[`Style`](styles.md) and an optional `clearrestofline` flag, and all text supports the
[markup language](markup.md) and [emoji shortcodes](markup.md#emoji).

## Table of contents
- [Write vs. WriteLine](#write-vs-writeline)
- [Supported value types](#supported-value-types)
- [Applying a style](#applying-a-style)
- [Clearing the rest of the line](#clearing-the-rest-of-the-line)
- [Formatted output](#formatted-output)
- [Blank lines and clearing lines](#blank-lines-and-clearing-lines)
- [Writing to the error stream](#writing-to-the-error-stream)
- [Encoding and redirection](#encoding-and-redirection)
- [Cheat sheet](#cheat-sheet)

---

## Write vs. WriteLine

| Method | Behavior |
|--------|----------|
| `Write(...)` | Writes the value at the cursor, no line terminator |
| `WriteLine(...)` | Writes the value followed by a line terminator |
| `WriteLine()` | Writes just a line terminator (blank line) |

```csharp
ConsolePlus.Write("Loading");
ConsolePlus.Write("...");
ConsolePlus.WriteLine(" done!");   // -> "Loading... done!"
```

---

## Supported value types

Both `Write` and `WriteLine` have overloads for the common .NET primitive types, so you rarely need
manual `ToString()` calls:

`char` • `char[]` • `string` • `bool` • `int` • `long` • `double` • `float` • `decimal` • `object`

```csharp
ConsolePlus.WriteLine('A');
ConsolePlus.WriteLine(42);
ConsolePlus.WriteLine(3.14159);
ConsolePlus.WriteLine(true);
ConsolePlus.WriteLine(new[] { 'H', 'i' });
ConsolePlus.WriteLine(DateTime.Now);   // object overload
```

> 💡 `string` values are parsed for [markup](markup.md) and [emoji](markup.md#emoji).
> Other types are converted to text and written verbatim.

---

## Applying a style

Every overload has a companion that takes a [`Style`](styles.md). A `Style` bundles a foreground
color, a background color, and an [overflow strategy](styles.md#overflow-strategies).

```csharp
using ConsolePlusLibrary;

// Explicit style
ConsolePlus.WriteLine("Important", new Style(Color.White, Color.Red));

// A single Color implicitly becomes a foreground Style
ConsolePlus.WriteLine("Just a foreground color", Color.Aqua);

// Derive a style from the current one
ConsolePlus.WriteLine("Warning", ConsolePlus.CurrentStyle.ForeGround(Color.Yellow));
```

There are also helpers to build styles from the current console colors:

```csharp
ConsolePlus.WriteLine("Foreground swap", ConsolePlus.StyleForeground(Color.Lime));
ConsolePlus.WriteLine("Background swap", ConsolePlus.StyleBackground(Color.Navy));
ConsolePlus.WriteLine("Inverted colors", ConsolePlus.StyleInvert());
```

See the [Styles guide](styles.md) for the full builder API.

---

## Clearing the rest of the line

Pass `clearrestofline: true` to erase everything from the written text to the end of the line.
This is ideal for **in-place updates** (status lines, counters, progress text) where a previous,
longer message might otherwise leave leftover characters behind.

```csharp
ConsolePlus.Write("Progress: 100%", clearrestofline: true);
```

The flag is available on every `Write`/`WriteLine`/`WriteFormat` overload, and can be combined with
a style:

```csharp
ConsolePlus.Write("Status: OK", new Style(Color.Black, Color.Green), clearrestofline: true);
```

---

## Formatted output

`WriteFormat` and `WriteLineFormat` use composite formatting (the same `{0}`, `{1}` placeholders as
`string.Format`), with optional style and `clearrestofline`:

```csharp
ConsolePlus.WriteLineFormat("User {0} has {1} points", user.Name, user.Score);

ConsolePlus.WriteLineFormat(
	"Elapsed: {0:F2}s",
	ConsolePlus.CurrentStyle.ForeGround(Color.Gold),
	elapsedSeconds);
```

> ⚠️ **Markup + format strings:** literal `[` and `]` in your *data* can look like markup tags.
> If a value may contain brackets, escape it with `.EscapeMarkup()` before formatting. Invalid markup
> will render as raw text (literal output with no color conversion). See
> [Markup → Escaping](markup.md#escaping-brackets) and 
> [Markup → Fault tolerance](markup.md#fault-tolerance-and-raw-output).

---

## Blank lines and clearing lines

```csharp
// Write one or more blank lines
ConsolePlus.WriteLines();     // 1 blank line
ConsolePlus.WriteLines(3);    // 3 blank lines

// Clear the current line (or a specific row), optionally with a style
ConsolePlus.ClearLine();
ConsolePlus.ClearLine(row: 10);
ConsolePlus.ClearLine(row: 10, style: new Style(Color.White, Color.DarkSlateGray));
```

`WriteLines` is handy for vertical spacing; `ClearLine` repaints a line to a blank state using the
given style's background, which is useful for redrawing dynamic UI regions.

---

## Writing to the error stream

Use `OutputError()` to redirect output to **standard error** for the duration of a `using` block.
This keeps error messages separate from normal output (so they can be piped/filtered independently)
while preserving all styling and markup.

```csharp
using (ConsolePlus.OutputError())
{
	ConsolePlus.WriteLine("[Red]A recoverable error occurred[/]");
	ConsolePlus.WriteLine("See the log for details.");
}
// Output is back on the standard stream here.
```

Related members: `Error` (the error `TextWriter`), `SetError(...)`, and `IsErrorRedirected`.

---

## Encoding and redirection

ConsolePlus surfaces the standard stream plumbing so you can integrate with files, pipes, and tests:

| Member | Purpose |
|--------|---------|
| `Out` / `In` / `Error` | The underlying `TextWriter`/`TextReader` instances |
| `SetOut(writer)` / `SetIn(reader)` / `SetError(writer)` | Redirect a stream |
| `OutputEncoding` / `InputEncoding` | Get/set encodings (UTF-8 is used by default) |
| `IsOutputRedirected` / `IsInputRedirected` / `IsErrorRedirected` | Detect redirection |

```csharp
if (!ConsolePlus.IsOutputRedirected)
{
	ConsolePlus.WriteLine("[Green]Interactive terminal detected[/]");
}
```

> 🛠️ Writing from **multiple threads** or need the raw `IConsole` driver? See
> [`ConsolePlus.RunAtomic`](advanced-api.md#thread-safe-output-consoleplusrunatomic) and
> [`ConsolePlus.Driver`](advanced-api.md#accessing-the-underlying-driver-consoleplusdriver) in the
> [Advanced API](advanced-api.md) guide.

---

## Cheat sheet

```csharp
// Plain
ConsolePlus.WriteLine("Hello");

// Markup
ConsolePlus.WriteLine("[Yellow]Hello[/]");

// Styled
ConsolePlus.WriteLine("Hello", new Style(Color.White, Color.Blue));

// In-place update
ConsolePlus.Write("Working...", clearrestofline: true);

// Formatted
ConsolePlus.WriteLineFormat("Total: {0:C}", amount);

// Blank lines
ConsolePlus.WriteLines(2);

// Error stream
using (ConsolePlus.OutputError()) ConsolePlus.WriteLine("[Red]Oops[/]");
```

---

[← Getting Started](getting-started.md) • [Back to Home](../README.md) • **Next:** [Reading Input →](reading-input.md)
