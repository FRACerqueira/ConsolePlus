<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Colors
</div>

[← Emoji](emoji.md) • [Back to Home](../README.md) • **Next:** [Styles & Overflow →](styles.md)

---

ConsolePlus has a first-class color model built around the `Color` struct. It supports **148 CSS
named colors**, HEX, RGB, weighted shades, and automatic down-sampling to whatever your terminal can
display. This page also includes accessibility helpers (WCAG luminance/contrast) and the **complete
visual palette**.

## Table of contents
- [Color systems (depth)](#color-systems-depth)
- [Creating colors](#creating-colors)
- [Named CSS colors](#named-css-colors)
- [Weighted (shaded) colors](#weighted-shaded-colors)
- [Console colors and RGB colors](#console-colors-and-rgb-colors)
- [Blending and conversion](#blending-and-conversion)
- [Accessibility: luminance & contrast](#accessibility-luminance--contrast)
- [Down-sampling to the terminal](#down-sampling-to-the-terminal)
- [Full color reference (visual)](#full-color-reference-visual)

---

## Color systems (depth)

Terminals differ in how many colors they can show. ConsolePlus detects this and exposes it via
`ConsolePlus.ColorDepth` (a `ColorSystem` value):

| `ColorSystem` | Colors | Description |
|---------------|--------|-------------|
| `NoColors` | 0 | No color support (plain text) |
| `FourBit` | 16 | Legacy 4-bit palette |
| `Standard` | 256 | 8-bit palette |
| `TrueColor` | 16.7M | 24-bit RGB |

```csharp
if (ConsolePlus.ColorDepth >= ColorSystem.TrueColor)
{
	ConsolePlus.WriteLine("[#1E90FF]TrueColor is available![/]");
}
```

Colors you specify are automatically mapped to the closest available color for the current depth, so
your code works everywhere without branching.

---

## Creating colors

```csharp
using ConsolePlusLibrary;

// From RGB components
var c1 = new Color(30, 144, 255);

// From a named CSS color (static properties)
var c2 = Color.DodgerBlue;

// From HEX (throws on invalid input)
var c3 = Color.FromHex("#1E90FF");
var c4 = Color.FromHex("#0af");           // 3-digit shorthand -> #00AAFF

// Safe HEX parse
if (Color.TryFromHex("#FF69B4", out var pink)) { /* use pink */ }

// From a CSS name string (returns null if unknown)
Color? c5 = Color.FromName("rebeccapurple");

// From an 8-bit palette index (0–255)
var c6 = Color.FromInt32(45);

// int implicitly converts to a palette Color
Color c7 = 200;
```

Convert a color back to text:

```csharp
var c = Color.FromHex("#1E90FF");
string hex    = c.ToHex();      // "1E90FF"
string markup = c.ToMarkup();   // "dodgerblue" (name) or "#1E90FF"
string full   = c.ToString();   // "dodgerblue" or "#1E90FF (RGB=30,144,255)"
```

---

## Named CSS colors

All 148 CSS colors are available as static `Color` properties (case-insensitive when used in
[markup](markup.md)). A few common ones:

| Property | Swatch | HEX |
|----------|--------|-----|
| `Color.Red` | ![](https://placehold.co/13x13/FF0000/FF0000.png) | `#FF0000` |
| `Color.Green` | ![](https://placehold.co/13x13/008000/008000.png) | `#008000` |
| `Color.Blue` | ![](https://placehold.co/13x13/0000FF/0000FF.png) | `#0000FF` |
| `Color.Teal` | ![](https://placehold.co/13x13/008080/008080.png) | `#008080` |
| `Color.Gold` | ![](https://placehold.co/13x13/FFD700/FFD700.png) | `#FFD700` |
| `Color.HotPink` | ![](https://placehold.co/13x13/FF69B4/FF69B4.png) | `#FF69B4` |
| `Color.RebeccaPurple` | ![](https://placehold.co/13x13/663399/663399.png) | `#663399` |

👉 Jump to the [Full color reference](#full-color-reference-visual) for all 148 with swatches.

---

## Weighted (shaded) colors

The `Weighted(weight)` extension produces a **shade** of a base CSS color, interpolating from black
(0) up to the full color (1000). This is great for building consistent tints/scales.

```csharp
using ConsolePlusLibrary;

Color light = Color.Blue.Weighted(300);
Color mid   = Color.Blue.Weighted(500);
Color deep  = Color.Blue.Weighted(844);
```

Visual scale for `Color.Blue.Weighted(...)`:

| Weight | 100 | 300 | 500 | 700 | 900 | 1000 |
|--------|-----|-----|-----|-----|-----|------|
| Swatch | ![](https://placehold.co/13x13/00001A/00001A.png) | ![](https://placehold.co/13x13/00004D/00004D.png) | ![](https://placehold.co/13x13/000080/000080.png) | ![](https://placehold.co/13x13/0000B3/0000B3.png) | ![](https://placehold.co/13x13/0000E6/0000E6.png) | ![](https://placehold.co/13x13/0000FF/0000FF.png) |

In [markup](markup.md), the same idea is written as a CSS name plus a weight, e.g. `[Blue500]` or
`[Red300]`.

> A `weight >= 1000` (or `< 0`) returns the original color unchanged.

---

## Console colors and RGB colors

ConsolePlus works with both the legacy `System.ConsoleColor` enum and full RGB `Color` values, and
converts between them automatically:

```csharp
// Legacy 16-color API
ConsolePlus.ForegroundColor = ConsoleColor.Green;
ConsolePlus.BackgroundColor = ConsoleColor.Black;

// Full RGB API
ConsolePlus.ForegroundRgbColor = Color.FromHex("#1E90FF");
ConsolePlus.BackgroundRgbColor = Color.Navy;

// Implicit conversions both ways
Color fromConsole = ConsoleColor.Red;   // -> Color
ConsoleColor toConsole = Color.Red;      // -> nearest ConsoleColor
```

Reset everything to the terminal defaults with:

```csharp
ConsolePlus.ResetColor();
```

---

## Blending and conversion

```csharp
// Blend two colors (factor 0.0 = this color, 1.0 = other color)
Color purpleish = Color.Red.Blend(Color.Blue, 0.5f);

// Nearest color within a color system
Color nearest = Color.FromHex("#1E90FF").ExactOrClosest(ColorSystem.FourBit);
```

| Expression | Result swatch |
|------------|---------------|
| `Color.Red` | ![](https://placehold.co/13x13/FF0000/FF0000.png) |
| `Color.Red.Blend(Color.Blue, 0.5f)` | ![](https://placehold.co/13x13/800080/800080.png) |
| `Color.Blue` | ![](https://placehold.co/13x13/0000FF/0000FF.png) |

---

## Accessibility: luminance & contrast

ConsolePlus includes WCAG-based helpers so your text stays readable on any background.

```csharp
// Relative luminance (0.0 dark – 1.0 light)
double lum = Color.Gold.GetLuminance();

// Contrast ratio between two colors (1.0 – 21.0)
double ratio = Color.White.GetContrast(Color.Navy);

// Pick black or white for best contrast on a given background
Color fg = Color.GetContrastForegroundColor(Color.Gold);   // -> black

// A quick "readable inverse" (black or white) based on brightness
Color inv = Color.SteelBlue.GetInvertedColor();

// Nudge a foreground color only if it fails a minimum contrast ratio
Color safe = Color.Yellow.AdjustForegroundColorForContrast(
	backgroundColor: Color.White,
	minimumContrastRatio: 4.5);   // 4.5 = WCAG AA, 7 = AAA
```

Practical example — always-readable label:

```csharp
Color bg = Color.FromHex("#2E8B57");             // some background
Color fg = Color.GetContrastForegroundColor(bg); // black or white
ConsolePlus.WriteLine("Readable label", new Style(fg, bg));
```

| Background | Auto foreground | Preview |
|-----------|-----------------|---------|
| ![](https://placehold.co/13x13/FFD700/FFD700.png) `Gold` | Black | ![](https://placehold.co/60x16/FFD700/000000.png?text=Abc) |
| ![](https://placehold.co/13x13/000080/000080.png) `Navy` | White | ![](https://placehold.co/60x16/000080/FFFFFF.png?text=Abc) |
| ![](https://placehold.co/13x13/2E8B57/2E8B57.png) `SeaGreen` | White | ![](https://placehold.co/60x16/2E8B57/FFFFFF.png?text=Abc) |

---

## Down-sampling to the terminal

When you use a color the terminal can't display exactly, ConsolePlus picks the **closest** available
color for the current `ColorSystem`. You usually don't need to think about it, but you can do it
explicitly:

```csharp
Color exact = Color.FromHex("#1E90FF");
Color forFourBit  = exact.ExactOrClosest(ColorSystem.FourBit);
Color forStandard = exact.ExactOrClosest(ColorSystem.Standard);
```

This is why the same markup produces great results on a modern terminal and still-sensible results
on a 16-color one.

---

## Full color reference (visual)

All **148** named CSS colors exposed as `Color.*` properties. Names are case-insensitive in
[markup](markup.md) (e.g., `[hotpink]`, `[HotPink]`, `[HOTPINK]` are equivalent).

| Swatch | Property | HEX | RGB |
|:------:|----------|-----|-----|
| ![](https://placehold.co/15x15/F0F8FF/F0F8FF.png) | `Color.Aliceblue` | `#F0F8FF` | `240, 248, 255` |
| ![](https://placehold.co/15x15/FAEBD7/FAEBD7.png) | `Color.Antiquewhite` | `#FAEBD7` | `250, 235, 215` |
| ![](https://placehold.co/15x15/00FFFF/00FFFF.png) | `Color.Aqua` | `#00FFFF` | `0, 255, 255` |
| ![](https://placehold.co/15x15/7FFFD4/7FFFD4.png) | `Color.Aquamarine` | `#7FFFD4` | `127, 255, 212` |
| ![](https://placehold.co/15x15/F0FFFF/F0FFFF.png) | `Color.Azure` | `#F0FFFF` | `240, 255, 255` |
| ![](https://placehold.co/15x15/F5F5DC/F5F5DC.png) | `Color.Beige` | `#F5F5DC` | `245, 245, 220` |
| ![](https://placehold.co/15x15/FFE4C4/FFE4C4.png) | `Color.Bisque` | `#FFE4C4` | `255, 228, 196` |
| ![](https://placehold.co/15x15/000000/000000.png) | `Color.Black` | `#000000` | `0, 0, 0` |
| ![](https://placehold.co/15x15/FFEBCD/FFEBCD.png) | `Color.Blanchedalmond` | `#FFEBCD` | `255, 235, 205` |
| ![](https://placehold.co/15x15/0000FF/0000FF.png) | `Color.Blue` | `#0000FF` | `0, 0, 255` |
| ![](https://placehold.co/15x15/8A2BE2/8A2BE2.png) | `Color.Blueviolet` | `#8A2BE2` | `138, 43, 226` |
| ![](https://placehold.co/15x15/A52A2A/A52A2A.png) | `Color.Brown` | `#A52A2A` | `165, 42, 42` |
| ![](https://placehold.co/15x15/DEB887/DEB887.png) | `Color.Burlywood` | `#DEB887` | `222, 184, 135` |
| ![](https://placehold.co/15x15/5F9EA0/5F9EA0.png) | `Color.Cadetblue` | `#5F9EA0` | `95, 158, 160` |
| ![](https://placehold.co/15x15/7FFF00/7FFF00.png) | `Color.Chartreuse` | `#7FFF00` | `127, 255, 0` |
| ![](https://placehold.co/15x15/D2691E/D2691E.png) | `Color.Chocolate` | `#D2691E` | `210, 105, 30` |
| ![](https://placehold.co/15x15/FF7F50/FF7F50.png) | `Color.Coral` | `#FF7F50` | `255, 127, 80` |
| ![](https://placehold.co/15x15/6495ED/6495ED.png) | `Color.Cornflowerblue` | `#6495ED` | `100, 149, 237` |
| ![](https://placehold.co/15x15/FFF8DC/FFF8DC.png) | `Color.Cornsilk` | `#FFF8DC` | `255, 248, 220` |
| ![](https://placehold.co/15x15/DC143C/DC143C.png) | `Color.Crimson` | `#DC143C` | `220, 20, 60` |
| ![](https://placehold.co/15x15/00FFFF/00FFFF.png) | `Color.Cyan` | `#00FFFF` | `0, 255, 255` |
| ![](https://placehold.co/15x15/00008B/00008B.png) | `Color.Darkblue` | `#00008B` | `0, 0, 139` |
| ![](https://placehold.co/15x15/008B8B/008B8B.png) | `Color.Darkcyan` | `#008B8B` | `0, 139, 139` |
| ![](https://placehold.co/15x15/B8860B/B8860B.png) | `Color.Darkgoldenrod` | `#B8860B` | `184, 134, 11` |
| ![](https://placehold.co/15x15/A9A9A9/A9A9A9.png) | `Color.Darkgray` | `#A9A9A9` | `169, 169, 169` |
| ![](https://placehold.co/15x15/006400/006400.png) | `Color.Darkgreen` | `#006400` | `0, 100, 0` |
| ![](https://placehold.co/15x15/A9A9A9/A9A9A9.png) | `Color.Darkgrey` | `#A9A9A9` | `169, 169, 169` |
| ![](https://placehold.co/15x15/BDB76B/BDB76B.png) | `Color.Darkkhaki` | `#BDB76B` | `189, 183, 107` |
| ![](https://placehold.co/15x15/8B008B/8B008B.png) | `Color.Darkmagenta` | `#8B008B` | `139, 0, 139` |
| ![](https://placehold.co/15x15/556B2F/556B2F.png) | `Color.Darkolivegreen` | `#556B2F` | `85, 107, 47` |
| ![](https://placehold.co/15x15/FF8C00/FF8C00.png) | `Color.Darkorange` | `#FF8C00` | `255, 140, 0` |
| ![](https://placehold.co/15x15/9932CC/9932CC.png) | `Color.Darkorchid` | `#9932CC` | `153, 50, 204` |
| ![](https://placehold.co/15x15/8B0000/8B0000.png) | `Color.Darkred` | `#8B0000` | `139, 0, 0` |
| ![](https://placehold.co/15x15/E9967A/E9967A.png) | `Color.Darksalmon` | `#E9967A` | `233, 150, 122` |
| ![](https://placehold.co/15x15/8FBC8F/8FBC8F.png) | `Color.Darkseagreen` | `#8FBC8F` | `143, 188, 143` |
| ![](https://placehold.co/15x15/483D8B/483D8B.png) | `Color.Darkslateblue` | `#483D8B` | `72, 61, 139` |
| ![](https://placehold.co/15x15/2F4F4F/2F4F4F.png) | `Color.Darkslategray` | `#2F4F4F` | `47, 79, 79` |
| ![](https://placehold.co/15x15/2F4F4F/2F4F4F.png) | `Color.Darkslategrey` | `#2F4F4F` | `47, 79, 79` |
| ![](https://placehold.co/15x15/00CED1/00CED1.png) | `Color.Darkturquoise` | `#00CED1` | `0, 206, 209` |
| ![](https://placehold.co/15x15/9400D3/9400D3.png) | `Color.Darkviolet` | `#9400D3` | `148, 0, 211` |
| ![](https://placehold.co/15x15/FF1493/FF1493.png) | `Color.Deeppink` | `#FF1493` | `255, 20, 147` |
| ![](https://placehold.co/15x15/00BFFF/00BFFF.png) | `Color.Deepskyblue` | `#00BFFF` | `0, 191, 255` |
| ![](https://placehold.co/15x15/696969/696969.png) | `Color.Dimgray` | `#696969` | `105, 105, 105` |
| ![](https://placehold.co/15x15/696969/696969.png) | `Color.Dimgrey` | `#696969` | `105, 105, 105` |
| ![](https://placehold.co/15x15/1E90FF/1E90FF.png) | `Color.Dodgerblue` | `#1E90FF` | `30, 144, 255` |
| ![](https://placehold.co/15x15/B22222/B22222.png) | `Color.Firebrick` | `#B22222` | `178, 34, 34` |
| ![](https://placehold.co/15x15/FFFAF0/FFFAF0.png) | `Color.Floralwhite` | `#FFFAF0` | `255, 250, 240` |
| ![](https://placehold.co/15x15/228B22/228B22.png) | `Color.Forestgreen` | `#228B22` | `34, 139, 34` |
| ![](https://placehold.co/15x15/FF00FF/FF00FF.png) | `Color.Fuchsia` | `#FF00FF` | `255, 0, 255` |
| ![](https://placehold.co/15x15/DCDCDC/DCDCDC.png) | `Color.Gainsboro` | `#DCDCDC` | `220, 220, 220` |
| ![](https://placehold.co/15x15/F8F8FF/F8F8FF.png) | `Color.Ghostwhite` | `#F8F8FF` | `248, 248, 255` |
| ![](https://placehold.co/15x15/FFD700/FFD700.png) | `Color.Gold` | `#FFD700` | `255, 215, 0` |
| ![](https://placehold.co/15x15/DAA520/DAA520.png) | `Color.Goldenrod` | `#DAA520` | `218, 165, 32` |
| ![](https://placehold.co/15x15/808080/808080.png) | `Color.Gray` | `#808080` | `128, 128, 128` |
| ![](https://placehold.co/15x15/008000/008000.png) | `Color.Green` | `#008000` | `0, 128, 0` |
| ![](https://placehold.co/15x15/ADFF2F/ADFF2F.png) | `Color.Greenyellow` | `#ADFF2F` | `173, 255, 47` |
| ![](https://placehold.co/15x15/808080/808080.png) | `Color.Grey` | `#808080` | `128, 128, 128` |
| ![](https://placehold.co/15x15/F0FFF0/F0FFF0.png) | `Color.Honeydew` | `#F0FFF0` | `240, 255, 240` |
| ![](https://placehold.co/15x15/FF69B4/FF69B4.png) | `Color.Hotpink` | `#FF69B4` | `255, 105, 180` |
| ![](https://placehold.co/15x15/CD5C5C/CD5C5C.png) | `Color.Indianred` | `#CD5C5C` | `205, 92, 92` |
| ![](https://placehold.co/15x15/4B0082/4B0082.png) | `Color.Indigo` | `#4B0082` | `75, 0, 130` |
| ![](https://placehold.co/15x15/FFFFF0/FFFFF0.png) | `Color.Ivory` | `#FFFFF0` | `255, 255, 240` |
| ![](https://placehold.co/15x15/F0E68C/F0E68C.png) | `Color.Khaki` | `#F0E68C` | `240, 230, 140` |
| ![](https://placehold.co/15x15/E6E6FA/E6E6FA.png) | `Color.Lavender` | `#E6E6FA` | `230, 230, 250` |
| ![](https://placehold.co/15x15/FFF0F5/FFF0F5.png) | `Color.Lavenderblush` | `#FFF0F5` | `255, 240, 245` |
| ![](https://placehold.co/15x15/7CFC00/7CFC00.png) | `Color.Lawngreen` | `#7CFC00` | `124, 252, 0` |
| ![](https://placehold.co/15x15/FFFACD/FFFACD.png) | `Color.Lemonchiffon` | `#FFFACD` | `255, 250, 205` |
| ![](https://placehold.co/15x15/ADD8E6/ADD8E6.png) | `Color.Lightblue` | `#ADD8E6` | `173, 216, 230` |
| ![](https://placehold.co/15x15/F08080/F08080.png) | `Color.Lightcoral` | `#F08080` | `240, 128, 128` |
| ![](https://placehold.co/15x15/E0FFFF/E0FFFF.png) | `Color.Lightcyan` | `#E0FFFF` | `224, 255, 255` |
| ![](https://placehold.co/15x15/FAFAD2/FAFAD2.png) | `Color.Lightgoldenrodyellow` | `#FAFAD2` | `250, 250, 210` |
| ![](https://placehold.co/15x15/D3D3D3/D3D3D3.png) | `Color.Lightgray` | `#D3D3D3` | `211, 211, 211` |
| ![](https://placehold.co/15x15/90EE90/90EE90.png) | `Color.Lightgreen` | `#90EE90` | `144, 238, 144` |
| ![](https://placehold.co/15x15/D3D3D3/D3D3D3.png) | `Color.Lightgrey` | `#D3D3D3` | `211, 211, 211` |
| ![](https://placehold.co/15x15/FFB6C1/FFB6C1.png) | `Color.Lightpink` | `#FFB6C1` | `255, 182, 193` |
| ![](https://placehold.co/15x15/FFA07A/FFA07A.png) | `Color.Lightsalmon` | `#FFA07A` | `255, 160, 122` |
| ![](https://placehold.co/15x15/20B2AA/20B2AA.png) | `Color.Lightseagreen` | `#20B2AA` | `32, 178, 170` |
| ![](https://placehold.co/15x15/87CEFA/87CEFA.png) | `Color.Lightskyblue` | `#87CEFA` | `135, 206, 250` |
| ![](https://placehold.co/15x15/778899/778899.png) | `Color.Lightslategray` | `#778899` | `119, 136, 153` |
| ![](https://placehold.co/15x15/778899/778899.png) | `Color.Lightslategrey` | `#778899` | `119, 136, 153` |
| ![](https://placehold.co/15x15/B0C4DE/B0C4DE.png) | `Color.Lightsteelblue` | `#B0C4DE` | `176, 196, 222` |
| ![](https://placehold.co/15x15/FFFFE0/FFFFE0.png) | `Color.Lightyellow` | `#FFFFE0` | `255, 255, 224` |
| ![](https://placehold.co/15x15/00FF00/00FF00.png) | `Color.Lime` | `#00FF00` | `0, 255, 0` |
| ![](https://placehold.co/15x15/32CD32/32CD32.png) | `Color.Limegreen` | `#32CD32` | `50, 205, 50` |
| ![](https://placehold.co/15x15/FAF0E6/FAF0E6.png) | `Color.Linen` | `#FAF0E6` | `250, 240, 230` |
| ![](https://placehold.co/15x15/FF00FF/FF00FF.png) | `Color.Magenta` | `#FF00FF` | `255, 0, 255` |
| ![](https://placehold.co/15x15/800000/800000.png) | `Color.Maroon` | `#800000` | `128, 0, 0` |
| ![](https://placehold.co/15x15/66CDAA/66CDAA.png) | `Color.Mediumaquamarine` | `#66CDAA` | `102, 205, 170` |
| ![](https://placehold.co/15x15/0000CD/0000CD.png) | `Color.Mediumblue` | `#0000CD` | `0, 0, 205` |
| ![](https://placehold.co/15x15/BA55D3/BA55D3.png) | `Color.Mediumorchid` | `#BA55D3` | `186, 85, 211` |
| ![](https://placehold.co/15x15/9370DB/9370DB.png) | `Color.Mediumpurple` | `#9370DB` | `147, 112, 219` |
| ![](https://placehold.co/15x15/3CB371/3CB371.png) | `Color.Mediumseagreen` | `#3CB371` | `60, 179, 113` |
| ![](https://placehold.co/15x15/7B68EE/7B68EE.png) | `Color.Mediumslateblue` | `#7B68EE` | `123, 104, 238` |
| ![](https://placehold.co/15x15/00FA9A/00FA9A.png) | `Color.Mediumspringgreen` | `#00FA9A` | `0, 250, 154` |
| ![](https://placehold.co/15x15/48D1CC/48D1CC.png) | `Color.Mediumturquoise` | `#48D1CC` | `72, 209, 204` |
| ![](https://placehold.co/15x15/C71585/C71585.png) | `Color.Mediumvioletred` | `#C71585` | `199, 21, 133` |
| ![](https://placehold.co/15x15/191970/191970.png) | `Color.Midnightblue` | `#191970` | `25, 25, 112` |
| ![](https://placehold.co/15x15/F5FFFA/F5FFFA.png) | `Color.Mintcream` | `#F5FFFA` | `245, 255, 250` |
| ![](https://placehold.co/15x15/FFE4E1/FFE4E1.png) | `Color.Mistyrose` | `#FFE4E1` | `255, 228, 225` |
| ![](https://placehold.co/15x15/FFE4B5/FFE4B5.png) | `Color.Moccasin` | `#FFE4B5` | `255, 228, 181` |
| ![](https://placehold.co/15x15/FFDEAD/FFDEAD.png) | `Color.Navajowhite` | `#FFDEAD` | `255, 222, 173` |
| ![](https://placehold.co/15x15/000080/000080.png) | `Color.Navy` | `#000080` | `0, 0, 128` |
| ![](https://placehold.co/15x15/FDF5E6/FDF5E6.png) | `Color.Oldlace` | `#FDF5E6` | `253, 245, 230` |
| ![](https://placehold.co/15x15/808000/808000.png) | `Color.Olive` | `#808000` | `128, 128, 0` |
| ![](https://placehold.co/15x15/6B8E23/6B8E23.png) | `Color.Olivedrab` | `#6B8E23` | `107, 142, 35` |
| ![](https://placehold.co/15x15/FFA500/FFA500.png) | `Color.Orange` | `#FFA500` | `255, 165, 0` |
| ![](https://placehold.co/15x15/FF4500/FF4500.png) | `Color.Orangered` | `#FF4500` | `255, 69, 0` |
| ![](https://placehold.co/15x15/DA70D6/DA70D6.png) | `Color.Orchid` | `#DA70D6` | `218, 112, 214` |
| ![](https://placehold.co/15x15/EEE8AA/EEE8AA.png) | `Color.Palegoldenrod` | `#EEE8AA` | `238, 232, 170` |
| ![](https://placehold.co/15x15/98FB98/98FB98.png) | `Color.Palegreen` | `#98FB98` | `152, 251, 152` |
| ![](https://placehold.co/15x15/AFEEEE/AFEEEE.png) | `Color.Paleturquoise` | `#AFEEEE` | `175, 238, 238` |
| ![](https://placehold.co/15x15/DB7093/DB7093.png) | `Color.Palevioletred` | `#DB7093` | `219, 112, 147` |
| ![](https://placehold.co/15x15/FFEFD5/FFEFD5.png) | `Color.Papayawhip` | `#FFEFD5` | `255, 239, 213` |
| ![](https://placehold.co/15x15/FFDAB9/FFDAB9.png) | `Color.Peachpuff` | `#FFDAB9` | `255, 218, 185` |
| ![](https://placehold.co/15x15/CD853F/CD853F.png) | `Color.Peru` | `#CD853F` | `205, 133, 63` |
| ![](https://placehold.co/15x15/FFC0CB/FFC0CB.png) | `Color.Pink` | `#FFC0CB` | `255, 192, 203` |
| ![](https://placehold.co/15x15/DDA0DD/DDA0DD.png) | `Color.Plum` | `#DDA0DD` | `221, 160, 221` |
| ![](https://placehold.co/15x15/B0E0E6/B0E0E6.png) | `Color.Powderblue` | `#B0E0E6` | `176, 224, 230` |
| ![](https://placehold.co/15x15/800080/800080.png) | `Color.Purple` | `#800080` | `128, 0, 128` |
| ![](https://placehold.co/15x15/663399/663399.png) | `Color.Rebeccapurple` | `#663399` | `102, 51, 153` |
| ![](https://placehold.co/15x15/FF0000/FF0000.png) | `Color.Red` | `#FF0000` | `255, 0, 0` |
| ![](https://placehold.co/15x15/BC8F8F/BC8F8F.png) | `Color.Rosybrown` | `#BC8F8F` | `188, 143, 143` |
| ![](https://placehold.co/15x15/4169E1/4169E1.png) | `Color.Royalblue` | `#4169E1` | `65, 105, 225` |
| ![](https://placehold.co/15x15/8B4513/8B4513.png) | `Color.Saddlebrown` | `#8B4513` | `139, 69, 19` |
| ![](https://placehold.co/15x15/FA8072/FA8072.png) | `Color.Salmon` | `#FA8072` | `250, 128, 114` |
| ![](https://placehold.co/15x15/F4A460/F4A460.png) | `Color.Sandybrown` | `#F4A460` | `244, 164, 96` |
| ![](https://placehold.co/15x15/2E8B57/2E8B57.png) | `Color.Seagreen` | `#2E8B57` | `46, 139, 87` |
| ![](https://placehold.co/15x15/FFF5EE/FFF5EE.png) | `Color.Seashell` | `#FFF5EE` | `255, 245, 238` |
| ![](https://placehold.co/15x15/A0522D/A0522D.png) | `Color.Sienna` | `#A0522D` | `160, 82, 45` |
| ![](https://placehold.co/15x15/C0C0C0/C0C0C0.png) | `Color.Silver` | `#C0C0C0` | `192, 192, 192` |
| ![](https://placehold.co/15x15/87CEEB/87CEEB.png) | `Color.Skyblue` | `#87CEEB` | `135, 206, 235` |
| ![](https://placehold.co/15x15/6A5ACD/6A5ACD.png) | `Color.Slateblue` | `#6A5ACD` | `106, 90, 205` |
| ![](https://placehold.co/15x15/708090/708090.png) | `Color.Slategray` | `#708090` | `112, 128, 144` |
| ![](https://placehold.co/15x15/708090/708090.png) | `Color.Slategrey` | `#708090` | `112, 128, 144` |
| ![](https://placehold.co/15x15/FFFAFA/FFFAFA.png) | `Color.Snow` | `#FFFAFA` | `255, 250, 250` |
| ![](https://placehold.co/15x15/00FF7F/00FF7F.png) | `Color.Springgreen` | `#00FF7F` | `0, 255, 127` |
| ![](https://placehold.co/15x15/4682B4/4682B4.png) | `Color.Steelblue` | `#4682B4` | `70, 130, 180` |
| ![](https://placehold.co/15x15/D2B48C/D2B48C.png) | `Color.Tan` | `#D2B48C` | `210, 180, 140` |
| ![](https://placehold.co/15x15/008080/008080.png) | `Color.Teal` | `#008080` | `0, 128, 128` |
| ![](https://placehold.co/15x15/D8BFD8/D8BFD8.png) | `Color.Thistle` | `#D8BFD8` | `216, 191, 216` |
| ![](https://placehold.co/15x15/FF6347/FF6347.png) | `Color.Tomato` | `#FF6347` | `255, 99, 71` |
| ![](https://placehold.co/15x15/40E0D0/40E0D0.png) | `Color.Turquoise` | `#40E0D0` | `64, 224, 208` |
| ![](https://placehold.co/15x15/EE82EE/EE82EE.png) | `Color.Violet` | `#EE82EE` | `238, 130, 238` |
| ![](https://placehold.co/15x15/F5DEB3/F5DEB3.png) | `Color.Wheat` | `#F5DEB3` | `245, 222, 179` |
| ![](https://placehold.co/15x15/FFFFFF/FFFFFF.png) | `Color.White` | `#FFFFFF` | `255, 255, 255` |
| ![](https://placehold.co/15x15/F5F5F5/F5F5F5.png) | `Color.Whitesmoke` | `#F5F5F5` | `245, 245, 245` |
| ![](https://placehold.co/15x15/FFFF00/FFFF00.png) | `Color.Yellow` | `#FFFF00` | `255, 255, 0` |
| ![](https://placehold.co/15x15/9ACD32/9ACD32.png) | `Color.Yellowgreen` | `#9ACD32` | `154, 205, 50` |

---

[← Emoji](emoji.md) • [Back to Home](../README.md) • **Next:** [Styles & Overflow →](styles.md)
