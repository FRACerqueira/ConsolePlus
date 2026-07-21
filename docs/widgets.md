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
  - [Simple banners](#simple-banners)
  - [FIGlet banners](#figlet-banners)
- [Fluent widget builders](#fluent-widget-builders)
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
- **`applycolorbackground`** paints the style's background color across the full width of the line.

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

A **banner** draws large, attention-grabbing text. Without a FIGlet font it renders the text on a
single line (optionally bordered); with a font it renders multi-line ASCII-art letters.

### Simple banners

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

### FIGlet banners

Provide a [FIGlet](http://www.figlet.org/) font (a `.flf` file path or a `Stream`) to render
stylized letter art:

```csharp
// From a font file on disk
ConsolePlus.Banner("HELLO", @"fonts/Standard.flf", Color.Gold, DashOptions.None);

// From a stream (e.g., an embedded resource)
using Stream fontStream = File.OpenRead("fonts/Standard.flf");
ConsolePlus.Banner("HELLO", fontStream, Color.Gold, DashOptions.None);
```

Example (FIGlet "Standard" font):

```text
 _   _      _ _
| | | | ___| | | ___
| |_| |/ _ \ | |/ _ \
|  _  |  __/ | | (_) |
|_| |_|\___|_|_|\___/
```

> The library embeds the **Standard** FIGlet font, which is used for simple banners. For custom
> looks, supply any `.flf` font file or stream. Invalid/missing font paths throw an
> `ArgumentException`.

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
