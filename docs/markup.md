<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Markup Language
</div>

[← Reading Input](reading-input.md) • [Back to Home](../README.md) • **Next:** [Emoji →](emoji.md)

---

ConsolePlus lets you colorize and style text **inline**, directly inside the strings you write,
using a lightweight, bracket-based markup language. Any `string` passed to `Write`, `WriteLine`,
`WriteFormat`, `Banner`, or `Dash` is parsed for markup and [emoji](#emoji).

## Table of contents
- [Basic syntax](#basic-syntax)
- [Foreground and background colors](#foreground-and-background-colors)
- [Color formats](#color-formats)
- [Nesting tags](#nesting-tags)
- [Color hierarchy and automatic closing](#color-hierarchy-and-automatic-closing)
- [Escaping brackets](#escaping-brackets)
- [Fault tolerance and raw output](#fault-tolerance-and-raw-output)
- [Emoji](#emoji)
- [The `Markup` helper class](#the-markup-helper-class)
- [Cheat sheet](#cheat-sheet)

---

## Basic syntax

Wrap text in an **open tag** `[color]` and a **close tag** `[/]`:

```csharp
ConsolePlus.WriteLine("[Red]This is red[/] and this is normal.");
```

- Open tags look like `[Yellow]`, `[#FF8C00]`, or `[RGB(255,0,0)]`.
- The close tag is always `[/]`. It closes the **most recent** open tag (tags are stacked).

---

## Foreground and background colors

Specify a background using either the keyword **`on`** or a **colon `:`** separator:

```csharp
// "on" keyword  -> foreground ON background
ConsolePlus.WriteLine("[Red on White]Red text on white background[/]");

// colon syntax  -> foreground:background
ConsolePlus.WriteLine("[Red:White]Same thing, shorter[/]");
```

Both forms are equivalent. Visual result (foreground/background):

| Markup | Renders as |
|--------|-----------|
| `[Red on White]ERROR[/]` | ![](https://placehold.co/13x13/FF0000/FF0000.png) text on ![](https://placehold.co/13x13/FFFFFF/FFFFFF.png) background |
| `[White:Navy]INFO[/]` | ![](https://placehold.co/13x13/FFFFFF/FFFFFF.png) text on ![](https://placehold.co/13x13/000080/000080.png) background |
| `[Black:Gold]WARN[/]` | ![](https://placehold.co/13x13/000000/000000.png) text on ![](https://placehold.co/13x13/FFD700/FFD700.png) background |

You can also set **only** a background by starting with `on`:

```csharp
ConsolePlus.WriteLine("[on Yellow]Highlighted[/]");
```

---

## Color formats

Inside a tag, a color can be written in any of these formats:

| Format | Example | Notes |
|--------|---------|-------|
| **CSS name** | `[Teal]`, `[HotPink]`, `[RebeccaPurple]` | 148 named colors, case-insensitive |
| **HEX** | `[#FF8C00]`, `[#0af]` | 6-digit or 3-digit shorthand |
| **RGB** | `[RGB(255,0,0)]` | `rgb(r,g,b)`, case-insensitive |
| **Weighted CSS** | `[Red500]`, `[Blue313]` | A CSS name + a 0–1000 weight |

```csharp
ConsolePlus.WriteLine("[Teal]Named CSS color[/]");
ConsolePlus.WriteLine("[#FF8C00]HEX color[/]");
ConsolePlus.WriteLine("[RGB(30,144,255)]RGB color[/]");
ConsolePlus.WriteLine("[Blue500]Weighted color[/]");
```

Examples with swatches:

| Markup | Swatch |
|--------|--------|
| `[Teal]` | ![](https://placehold.co/13x13/008080/008080.png) `#008080` |
| `[#FF8C00]` | ![](https://placehold.co/13x13/FF8C00/FF8C00.png) `#FF8C00` |
| `[RGB(30,144,255)]` | ![](https://placehold.co/13x13/1E90FF/1E90FF.png) `#1E90FF` |
| `[HotPink]` | ![](https://placehold.co/13x13/FF69B4/FF69B4.png) `#FF69B4` |

> See the [Colors guide](colors.md) for the **complete visual palette** and the weighted-color system.

---

## Nesting tags

Tags stack. Each `[/]` closes the innermost open tag and restores the previous style:

```csharp
ConsolePlus.WriteLine("[Green]Green [Yellow]then yellow[/] back to green[/] then default.");
```

Renders as:
`Green` → `then yellow` → `back to green` → `then default`, where each `[/]` pops one level.

Background and foreground both participate in nesting:

```csharp
ConsolePlus.WriteLine("[White:Navy]On navy [Gold]golden text[/] still on navy[/]");
```

---

## Color hierarchy and automatic closing

ConsolePlus supports **hierarchical color management** and **automatic tag closing**, making markup
more flexible and forgiving:

### Automatic closing of unclosed tags

You don't need to close every tag explicitly with `[/]`. Any unclosed tags are **automatically 
closed** at the end of the string:

```csharp
// These are equivalent - closing tag is optional
ConsolePlus.WriteLine("[Green]This is green text[/]");
ConsolePlus.WriteLine("[Green]This is green text");  // [/] is automatic
```

This is especially useful for simple single-color strings:

```csharp
ConsolePlus.WriteLine("[Red]Error: File not found");     // No [/] needed
ConsolePlus.WriteLine("[Yellow]Warning: Low disk space"); // No [/] needed
ConsolePlus.WriteLine("[Cyan]Info: Processing...");       // No [/] needed
```

### Hierarchical color inheritance

Colors form a **hierarchy** — inner tags inherit and override outer colors:

```csharp
// Outer color: Green, Inner color: Yellow
ConsolePlus.WriteLine("[Green]Start [Yellow]Middle[/] End");
// "Start" is green, "Middle" is yellow, "End" reverts to green
```

When you close a tag with `[/]`, the style **reverts to the previous level** in the hierarchy:

```csharp
ConsolePlus.WriteLine("[White:Navy]Outer [Red]Inner [Gold]Deep[/] Back to Red[/] Back to White");
// Hierarchy: White/Navy → Red/Navy → Gold/Navy → Red/Navy → White/Navy
```

### Practical examples

```csharp
// Simple case - no closing needed
ConsolePlus.WriteLine("[Green]SUCCESS");

// Nested with partial closing
ConsolePlus.WriteLine("[Blue]Prefix [Red]Important [Yellow]Very Important");
// Renders: Blue "Prefix", Red "Important", Yellow "Very Important"
// All tags auto-close at end

// Explicit hierarchy control
ConsolePlus.WriteLine("[White:Navy]Base [Red]Alert: [Yellow]Critical[/] still red[/] back to white");

// Background persistence through foreground changes
ConsolePlus.WriteLine("[White:DarkBlue]Base [Yellow]Changed foreground [Lime]Another change");
// Background (DarkBlue) persists while foreground changes
```

### Mixing explicit and automatic closing

You can mix explicit `[/]` closings with automatic ones:

```csharp
// Explicit close for "Red", automatic close for "Green"
ConsolePlus.WriteLine("[Green]Start [Red]Middle[/] End");

// Multiple levels with partial explicit closing
ConsolePlus.WriteLine("[A]Level1 [B]Level2 [C]Level3[/] Back to B");
// Level3 closed explicitly, Level2 and Level1 close automatically
```

> 💡 **Best practice:** Use explicit `[/]` when you need precise control over where colors change,
> and rely on automatic closing for simpler cases or when all text to the end should remain styled.

---

## Escaping brackets

Because `[` and `]` are special, escape literal brackets by **doubling** them — `[[` and `]]`:

```csharp
ConsolePlus.WriteLine("Array index [[0]] and [[1]]");   // -> Array index [0] and [1]
```

For dynamic values that may contain brackets (file paths, user input, JSON), use the
`EscapeMarkup()` extension so they are never interpreted as tags:

```csharp
string path = @"C:\[My Folder]\file.xml";
ConsolePlus.WriteLine($"Path: {path.EscapeMarkup()}");
```

---

## Fault tolerance and raw output

The markup parser is **fault-tolerant** and handles errors gracefully to ensure your application
never crashes due to invalid markup.

### When markup contains inconsistencies

**When markup contains any inconsistency or parsing error, the text is displayed in RAW format
without any color conversion.** This means the literal string, including all markup tags, is shown
as plain text:

```csharp
// Inconsistent/malformed markup - rendered as RAW text
ConsolePlus.WriteLine("[Red:Blue:Green]Invalid format");  
// Output: "[Red:Blue:Green]Invalid format" (literal text, no colors)

ConsolePlus.WriteLine("[NotAColor]Unknown color name");
// Output: "[NotAColor]Unknown color name" (literal text, no colors)

ConsolePlus.WriteLine("Text [/] with unexpected closing");
// Output: "Text [/] with unexpected closing" (literal text, no colors)

ConsolePlus.WriteLine("[RGB(999,999,999)]Out of range");
// Output: "[RGB(999,999,999)]Out of range" (literal text, no colors)
```

### Why raw output?

Rendering as raw text when errors occur has several benefits:

1. **No crashes** — Your application continues running normally
2. **Visible errors** — You can see exactly what went wrong in the output
3. **Debugging** — Easy to spot and fix markup mistakes
4. **Safety** — User-provided strings with accidental bracket characters won't break your UI

### Common markup errors that trigger raw output

| Error Type | Example | Result |
|------------|---------|--------|
| **Invalid color format** | `[Red:Blue:Green]` | Raw text (too many colors) |
| **Unknown color name** | `[NotARealColor]` | Raw text (color doesn't exist) |
| **Malformed RGB** | `[RGB(256,300,500)]` | Raw text (values out of range) |
| **Invalid HEX** | `[#GGGGGG]` | Raw text (invalid hex digits) |
| **Unbalanced brackets** | `[Red][Green]text[/]` | Raw text (mismatched tags) |
| **Empty tags** | `[]text[/]` | Raw text (no color specified) |

### Fault-tolerant features

Despite the raw output fallback, ConsolePlus markup is designed to be forgiving:

```csharp
// These work fine - parser is lenient
ConsolePlus.WriteLine("[red]Case insensitive[/]");           // ✅ Works
ConsolePlus.WriteLine("[Red ]Extra space[/]");                // ✅ Works
ConsolePlus.WriteLine("[ Red ]Extra spaces[/]");              // ✅ Works
ConsolePlus.WriteLine("[Red]Auto-close");                      // ✅ Works (auto-closes)
ConsolePlus.WriteLine("[Red on White]Background[/]");         // ✅ Works
ConsolePlus.WriteLine("[Red:White]Shorter syntax[/]");        // ✅ Works
```

### Testing markup before use

If you're generating dynamic markup or want to validate it before display, use the `Markup` helper
class:

```csharp
using ConsolePlusLibrary;

string markup = "[Red]Test[/]";
string withoutMarkup = markup.RemoveMarkup();  // Get plain text
int visualLength = markup.LengthMarkup();       // Get display length (ignoring tags)

// For user input or dynamic content
string userInput = GetUserInput();
string safe = userInput.EscapeMarkup();  // Escape brackets to prevent interpretation
ConsolePlus.WriteLine($"User said: {safe}");
```

### Best practices for robust markup

1. **Validate dynamic colors** — If building markup from variables, validate color values first
2. **Use constants** — Prefer the `Color` class constants over string literals
3. **Test in development** — Run your output once to verify markup renders correctly
4. **Escape user input** — Always `.EscapeMarkup()` on any user-provided strings
5. **Keep it simple** — Complex nested markup is harder to debug; consider using `Style` objects instead

```csharp
// Good - using Color constants
ConsolePlus.WriteLine($"[{Color.Red}]Error[/]");

// Good - escaping user input
string fileName = userInput.EscapeMarkup();
ConsolePlus.WriteLine($"[Yellow]File: {fileName}[/]");

// Good - testing markup in dev
#if DEBUG
ConsolePlus.WriteLine("[Red]Debug: Markup test");
#endif
```

> ⚠️ **Important:** While the parser is fault-tolerant and won't crash, invalid markup **will 
> render as literal text** (raw output). This is intentional to make errors visible rather than
> silently failing or producing incorrect colors.

---

## Emoji

ConsolePlus replaces `:shortcode:` tokens with real Unicode emoji. You can combine emoji with color
markup:

```csharp
ConsolePlus.WriteLine(":rocket: Launching...");
ConsolePlus.WriteLine("[Green]:check_mark_button: Success[/]");
ConsolePlus.WriteLine(":fire: :thumbs_up: :red_heart:");
```

You can also reference emoji as **strongly-typed constants** from the `Emoji` class:

```csharp
using ConsolePlusLibrary;

ConsolePlus.WriteLine($"{Emoji.Rocket} Launching...");
ConsolePlus.WriteLine($"{Emoji.Fire} {Emoji.ThumbsUp} {Emoji.RedHeart}");

// Or discover them by group with Emoji.Group.Name
ConsolePlus.WriteLine($"{Emoji.TravelAndPlaces.Rocket} {Emoji.Symbols.CheckMarkButton}");
```

| Shortcode | Constant | Glyph |
|-----------|----------|-------|
| `:rocket:` | `Emoji.Rocket` | 🚀 |
| `:fire:` | `Emoji.Fire` | 🔥 |
| `:thumbs_up:` | `Emoji.ThumbsUp` | 👍 |
| `:red_heart:` | `Emoji.RedHeart` | ❤️ |
| `:check_mark_button:` | `Emoji.CheckMarkButton` | ✅ |
| `:cross_mark:` | `Emoji.CrossMark` | ❌ |
| `:warning:` | `Emoji.Warning` | ⚠️ |

> ⚠️ **Important:** Emoji require Unicode support to display correctly. On terminals without Unicode
> or emoji-capable fonts, emoji will appear as monochrome symbols, placeholder boxes, or be silently
> removed. ConsolePlus automatically detects Unicode capability and strips unknown emoji shortcodes
> to keep text clean. See the [Emoji guide](emoji.md#compatibility-considerations) for detailed
> compatibility information and best practices.

You can optionally prefix a shortcode with its Unicode group, for example
`:activities/balloon:`. See [Emoji → Group-qualified shortcodes](emoji.md#group-qualified-shortcodes)
for the full list of groups and the complete catalog. The same grouping is available on the `Emoji`
class as [group-typed constants](emoji.md#group-typed-constants) (`Emoji.Activities.Balloon`).

---

## The `Markup` helper class

The static `Markup` class (and matching string extension methods) lets you work with markup
programmatically:

| Method | Extension form | Purpose |
|--------|----------------|---------|
| `Markup.Escape(text)` | `text.EscapeMarkup()` | Doubles `[`/`]` so text is treated literally |
| `Markup.Remove(text)` | `text.RemoveMarkup()` | Strips all markup, returning plain text |
| `Markup.Length(text)` | `text.LengthMarkup()` | Length of the text **without** markup tags |

```csharp
using ConsolePlusLibrary;

string tagged = "[Red]Error:[/] file [Yellow]data.json[/] not found";

string plain = tagged.RemoveMarkup();   // "Error: file data.json not found"
int visibleLength = tagged.LengthMarkup(); // length ignoring the tags
string safe = "[literal]".EscapeMarkup();  // "[[literal]]"
```

`LengthMarkup` is especially useful for alignment and layout, since it measures the *visible* width
rather than the raw string length.

---

## Cheat sheet

```csharp
// Foreground / background
"[Red]text[/]"
"[Red on White]text[/]"
"[Red:White]text[/]"
"[on Yellow]highlight[/]"

// Color formats
"[Teal]name[/]"  "[#FF8C00]hex[/]"  "[RGB(255,0,0)]rgb[/]"  "[Blue500]weighted[/]"

// Nesting with hierarchy
"[Green]a [Yellow]b[/] c[/]"
"[White:Navy]outer [Red]inner[/] outer again[/]"

// Auto-closing (no [/] needed at end)
"[Red]Error message"
"[Green]Success [Yellow]with nested auto-close"

// Escaping
"[[literal brackets]]"
value.EscapeMarkup()

// Emoji
":rocket:"   Emoji.Rocket   Emoji.TravelAndPlaces.Rocket

// Helpers
text.RemoveMarkup()   text.LengthMarkup()   text.EscapeMarkup()

// Raw output (on error)
"[InvalidColor]text"  // Renders as: "[InvalidColor]text" (literal)
```

---

[← Reading Input](reading-input.md) • [Back to Home](../README.md) • **Next:** [Emoji →](emoji.md)
