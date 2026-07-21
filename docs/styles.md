<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Styles & Overflow
</div>

[← Colors](colors.md) • [Back to Home](../README.md) • **Next:** [Widgets →](widgets.md)

---

A **`Style`** bundles the three things ConsolePlus needs to render text: a **foreground** color, a
**background** color, and an **overflow strategy**. Styles are immutable value types, so you compose
them with small, chainable helpers.

## Table of contents
- [The `Style` struct](#the-style-struct)
- [Creating styles](#creating-styles)
- [Modifying styles (builder methods)](#modifying-styles-builder-methods)
- [Styles from the current console](#styles-from-the-current-console)
- [Overflow strategies](#overflow-strategies)
- [Putting it together](#putting-it-together)
- [Cheat sheet](#cheat-sheet)

---

## The `Style` struct

```csharp
public readonly struct Style(Color foreground, Color background, Overflow overflowStrategy = Overflow.None)
```

| Member | Type | Description |
|--------|------|-------------|
| `Foreground` | `Color` | The text color |
| `Background` | `Color` | The color behind the text |
| `OverflowStrategy` | `Overflow` | What to do when content is wider than the line |

`Style` is a `readonly struct` and implements value equality (`==`, `!=`, `Equals`, `GetHashCode`).

---

## Creating styles

```csharp
using ConsolePlusLibrary;

// Explicit foreground + background
var s1 = new Style(Color.White, Color.Navy);

// With an overflow strategy
var s2 = new Style(Color.White, Color.Navy, Overflow.Ellipsis);

// A Color implicitly converts to a foreground-only Style
Style s3 = Color.Lime;   // background becomes the console default
```

Use them anywhere output is written:

```csharp
ConsolePlus.WriteLine("Hello", new Style(Color.Black, Color.Gold));
ConsolePlus.Banner("Title", new Style(Color.White, Color.DarkBlue), DashOptions.SingleBorder);
```

---

## Modifying styles (builder methods)

Because `Style` is immutable, `StyleExtensions` provides methods that return a **new** style with one
aspect changed. They are chainable:

| Method | Changes | Keeps |
|--------|---------|-------|
| `ForeGround(color)` | Foreground | Background + Overflow |
| `Background(color)` | Background | Foreground + Overflow |
| `Overflow(strategy)` | Overflow | Foreground + Background |
| `Colors(fore)` | Foreground | Background + Overflow |
| `Colors(fore, back)` | Foreground + Background | Overflow |

```csharp
using ConsolePlusLibrary;

Style baseStyle = ConsolePlus.CurrentStyle;

Style warning = baseStyle
	.ForeGround(Color.Black)
	.Background(Color.Gold)
	.Overflow(Overflow.Ellipsis);

ConsolePlus.WriteLine("Disk almost full", warning);
```

---

## Styles from the current console

The `ConsolePlus` class exposes helpers that build a style from the **currently active** colors:

| Member | Description |
|--------|-------------|
| `CurrentStyle` | The style reflecting the console's current foreground/background |
| `StyleForeground(color)` | Current style with a new foreground |
| `StyleBackground(color)` | Current style with a new background |
| `StyleInvert()` | Current style with foreground/background swapped |

```csharp
// Keep the current background, change only the foreground
ConsolePlus.WriteLine("Note", ConsolePlus.StyleForeground(Color.Aqua));

// Swap colors for emphasis (e.g., a selected row)
ConsolePlus.WriteLine("Selected", ConsolePlus.StyleInvert());
```

---

## Overflow strategies

`Overflow` controls what happens when a line of text is wider than the console:

| Value | Behavior | Illustration (narrow console) |
|-------|----------|-------------------------------|
| `None` | Wrap: extra characters continue on the next line | `A very long line that…` wraps to the next row |
| `Crop` | Truncate at the edge; extra characters are discarded | `A very long line that ` (cut off) |
| `Ellipsis` | Truncate and append `…` to signal more content | `A very long line th…` |

```csharp
using ConsolePlusLibrary;

string longText = "This is a very long status message that will not fit on one line";

ConsolePlus.WriteLine(longText, ConsolePlus.CurrentStyle.Overflow(Overflow.None));     // wraps
ConsolePlus.WriteLine(longText, ConsolePlus.CurrentStyle.Overflow(Overflow.Crop));     // cropped
ConsolePlus.WriteLine(longText, ConsolePlus.CurrentStyle.Overflow(Overflow.Ellipsis)); // …
```

> `Crop` and `Ellipsis` are ideal for single-line UI regions (status bars, table cells, list rows)
> where wrapping would break the layout.

---

## Putting it together

A small helper that renders a color-coded log level:

```csharp
using ConsolePlusLibrary;

void Log(string level, Color color, string message)
{
	var badge = new Style(Color.GetContrastForegroundColor(color), color);
	ConsolePlus.Write($" {level} ", badge);                 // colored badge
	ConsolePlus.Write(" ");
	ConsolePlus.WriteLine(message, ConsolePlus.CurrentStyle.Overflow(Overflow.Ellipsis));
}

Log("INFO", Color.SteelBlue, "Service started");
Log("WARN", Color.Gold, "Cache miss rate is high");
Log("ERR ", Color.Firebrick, "Connection reset by peer");
```

The badge foreground is picked automatically for readability using
[`GetContrastForegroundColor`](colors.md#accessibility-luminance--contrast).

---

## Cheat sheet

```csharp
// Create
new Style(Color.White, Color.Navy)
new Style(Color.White, Color.Navy, Overflow.Ellipsis)
Style s = Color.Lime;   // foreground-only

// Modify (immutable, chainable)
style.ForeGround(Color.Yellow)
style.Background(Color.Black)
style.Overflow(Overflow.Crop)
style.Colors(Color.White, Color.Blue)

// From current console
ConsolePlus.CurrentStyle
ConsolePlus.StyleForeground(Color.Aqua)
ConsolePlus.StyleBackground(Color.Navy)
ConsolePlus.StyleInvert()
```

---

[← Colors](colors.md) • [Back to Home](../README.md) • **Next:** [Widgets →](widgets.md)
