<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Widgets: Banners & Dashes
</div>

[← Styles & Overflow](styles.md) • [Back to Home](../README.md) • **Next:** [Cursor & Screen →](cursor-and-screen.md)

---

ConsolePlus ships two lightweight layout widgets for structuring console output: **banners**
(large FIGlet or simple headline text) and **dashes** (titled separator lines). Both are
style-aware and adapt their border characters to the terminal's Unicode support.

## Table of contents
- [Dash separators](#dash-separators)
  - [Dash options (borders)](#dash-options-borders)
  - [Extra lines and background fill](#extra-lines-and-background-fill)
- [Banners](#banners)
  - [Banner with the default (embedded) font](#banner-with-the-default-embedded-font)
  - [Banner with a custom font](#banner-with-a-custom-font)
- [Fluent widget builders](#fluent-widget-builders)
- [Widgets through PromptPlus](#widgets-through-promptplus)
- [Cheat sheet](#cheat-sheet)

---

## Dash separators

A **dash** renders text with a horizontal rule above and/or below it — perfect for section headings.

```csharp
using ConsolePlusLibrary;

ConsolePlus.Dash("Configuration");
ConsolePlus.Dash("Results", Color.Yellow, DashOptions.DoubleBorderUpDown);
```

Example output:

```text
Configuration
─────────────

═══════
Results
═══════
```

The full signature:

```csharp
ConsolePlus.Dash(
	string? text,
	Style? style = null,
	DashOptions dashOptions = DashOptions.SingleBorder,
	int extralines = 0,
	bool applycolorbackground = false);
```

### Dash options (borders)

`DashOptions` chooses the border character and whether the rule appears below the text only, or both
above and below. Non-Unicode terminals automatically fall back to ASCII equivalents.

| Option | Char | Position | Non-Unicode fallback |
|--------|:----:|----------|:--------------------:|
| `None` | — | No border | — |
| `AsciiSingleBorder` | `-` | Below | `-` |
| `AsciiDoubleBorder` | `=` | Below | `=` |
| `SingleBorder` | `─` | Below | `-` |
| `DoubleBorder` | `═` | Below | `=` |
| `HeavyBorder` | `━` | Below | `*` |
| `AsciiSingleBorderUpDown` | `-` | Above **and** below | `-` |
| `AsciiDoubleBorderUpDown` | `=` | Above **and** below | `=` |
| `SingleBorderUpDown` | `─` | Above **and** below | `-` |
| `DoubleBorderUpDown` | `═` | Above **and** below | `=` |
| `HeavyBorderUpDown` | `━` | Above **and** below | `*` |

```csharp
ConsolePlus.Dash("Heavy heading", Color.Teal, DashOptions.HeavyBorderUpDown);
```

```text
━━━━━━━━━━━━━
Heavy heading
━━━━━━━━━━━━━
```

### Extra lines and background fill

- **`extralines`** appends blank lines after the dash — handy for vertical spacing.
- **`applycolorbackground`** does **not** affect the dash line itself (its background already
  extends to the full line width by default, regardless of this flag). Instead, once the dash has
  been written, it sets the console's *ambient* foreground/background color to the given `style`'s
  colors — affecting whatever you write **next**. It's a silent no-op if you don't pass an explicit
  `style` (the default `null`, which falls back to `console.CurrentStyle`, doesn't count).

```csharp
ConsolePlus.Dash(
	"Section with spacing",
	new Style(Color.White, Color.DarkSlateGray),
	DashOptions.SingleBorderUpDown,
	extralines: 1,
	applycolorbackground: true);
```

> The dash width matches the longest line of `text`, and the text itself supports full
> [markup](markup.md), so you can color individual words inside a heading.

---

## Banners

A **banner** draws large, attention-grabbing text as multi-line [FIGlet](http://www.figlet.org/)
ASCII-art letters. Every overload renders FIGlet art, even without an explicit font argument — the
library embeds the **Standard** FIGlet font as the default, so there is no "plain single-line text"
banner mode.

### Banner with the default (embedded) font

```csharp
using ConsolePlusLibrary;

ConsolePlus.Banner("ConsolePlus");
ConsolePlus.Banner("ConsolePlus", Color.Teal, DashOptions.SingleBorderUpDown);
```

Signature:

```csharp
ConsolePlus.Banner(
	string? text,
	Style? style = null,
	DashOptions dashOptions = DashOptions.None);
```

### Banner with a custom font

Provide a [FIGlet](http://www.figlet.org/) font (a `.flf` file path or a `Stream`) to render with a
different letter style than the embedded default:

```csharp
// From a font file on disk
ConsolePlus.Banner("Hello", @"fonts/Standard.flf", Color.Gold, DashOptions.None);

// From a stream (e.g., an embedded resource)
using Stream fontStream = File.OpenRead("fonts/Standard.flf");
ConsolePlus.Banner("Hello", fontStream, Color.Gold, DashOptions.None);
```

Example (FIGlet "Standard" font):

```text
 _   _      _ _
| | | | ___| | | ___
| |_| |/ _ \ | |/ _ \
|  _  |  __/ | | (_) |
|_| |_|\___|_|_|\___/
```

> The library embeds this **Standard** FIGlet font as the default. For a different look, supply any
> `.flf` font file or stream. A null/empty/nonexistent **path** throws `ArgumentException` — but a
> path or stream that exists with **malformed** FIGlet content (e.g. a missing `flf2a` header) throws
> `FileNotFoundException` (path overload) or `InvalidDataException` (stream overload) instead.

---

## Fluent widget builders

`ConsolePlus.Widgets` exposes an alternative, fluent way to build the same two widgets, useful when
you want to configure a banner/dash conditionally across several steps instead of one static call:

```csharp
using ConsolePlusLibrary;

ConsolePlus.Widgets
    .Banner("ConsolePlus", Color.Teal)
    .Border(DashOptions.SingleBorderUpDown)
    .Show();

ConsolePlus.Widgets
    .Dash("Section", Color.Yellow)
    .Border(DashOptions.DoubleBorderUpDown)
    .Extralines(1)
    .Show();
```

| Type | Fluent methods | Purpose |
|------|-----------------|---------|
| `IBanner` | `FromFont(string)` / `FromFont(Stream)`, `Border(DashOptions)`, `Show()` | Builds and renders a banner |
| `IStringDash` | `Border(DashOptions)`, `Extralines(int)`, `Show()` | Builds and renders a dash separator |

Nothing renders until you call `Show()`. `ConsolePlus.Widgets.Banner(text, style)` and
`ConsolePlus.Widgets.Dash(text, style)` are the entry points (both take the text and an optional
`Style` up front); everything else is configured by chaining before `Show()`.

---

## Widgets through PromptPlus

[PromptPlus](promptplus.md) surfaces the same widgets (and more) through `PromptPlus.Widgets`,
which is convenient when you are already building interactive experiences. Both facades share the
same parameter order — the style comes **before** the dash option:

```csharp
using PromptPlusLibrary;

// Banner: text, style, dashOptions
PromptPlus.Widgets.Banner("PromptPlus", Color.Bisque);
PromptPlus.Widgets.Banner("PromptPlus", Color.Bisque, DashOptions.SingleBorderUpDown);

// Dash: text, style, dashOptions, extralines
PromptPlus.Widgets.Dash("Results", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
```

`PromptPlus.Widgets` also adds higher-level widgets such as `Calendar`, so it is the richer surface
when you have taken the [PromptPlus](promptplus.md) dependency.

---

## Cheat sheet

```csharp
// Dash (static ConsolePlus facade)
ConsolePlus.Dash("Title");
ConsolePlus.Dash("Title", Color.Yellow, DashOptions.DoubleBorderUpDown, extralines: 1);

// Banner (simple)
ConsolePlus.Banner("ConsolePlus", Color.Teal, DashOptions.SingleBorderUpDown);

// Banner (FIGlet)
ConsolePlus.Banner("HELLO", "fonts/Standard.flf", Color.Gold, DashOptions.None);

// Via PromptPlus (same order: style before dashOptions)
PromptPlus.Widgets.Banner("Hi", Color.Teal, DashOptions.SingleBorder);
PromptPlus.Widgets.Dash("Section", Color.Yellow, DashOptions.SingleBorder, 1);
```

---

[← Styles & Overflow](styles.md) • [Back to Home](../README.md) • **Next:** [Cursor & Screen →](cursor-and-screen.md)
