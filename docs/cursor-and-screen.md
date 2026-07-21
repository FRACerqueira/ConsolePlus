<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Cursor & Screen Control
</div>

[← Widgets](widgets.md) • [Back to Home](../README.md) • **Next:** [Profiles & Capabilities →](profiles-and-capabilities.md)

---

Beyond writing text, ConsolePlus gives you precise control over the cursor, the screen buffer, and
the terminal size — plus a low-level ANSI command emitter for advanced scenarios.

## Table of contents
- [Cursor position](#cursor-position)
- [Cursor visibility](#cursor-visibility)
- [Clearing the screen](#clearing-the-screen)
- [Window size and resize events](#window-size-and-resize-events)
- [Alternate/secondary screen buffer](#alternatesecondary-screen-buffer)
- [Beep](#beep)
- [Low-level ANSI commands](#low-level-ansi-commands)
- [Cheat sheet](#cheat-sheet)

---

## Cursor position

```csharp
// Absolute positioning (column, row) — 0-based
ConsolePlus.SetCursorPosition(left: 10, top: 5);

// Read the current position
(int Left, int Top) pos = ConsolePlus.GetCursorPosition();

// Or use the individual properties
int col = ConsolePlus.CursorLeft;
int row = ConsolePlus.CursorTop;
ConsolePlus.CursorTop = 0;   // jump to the top row
```

| Member | Type | Description |
|--------|------|-------------|
| `SetCursorPosition(left, top)` | method | Move the cursor to an absolute position |
| `GetCursorPosition()` | `(int Left, int Top)` | Read the current position as a tuple |
| `CursorLeft` | `int` (get/set) | Column position |
| `CursorTop` | `int` (get/set) | Row position |

---

## Cursor visibility

```csharp
ConsolePlus.HideCursor();     // returns bool (success)
// ... draw something ...
ConsolePlus.ShowCursor();

// Or toggle via the property
ConsolePlus.CursorVisible = false;
```

| Member | Description |
|--------|-------------|
| `CursorVisible` | `bool` get/set for cursor visibility |
| `HideCursor()` | Hides the cursor; returns `true` on success |
| `ShowCursor()` | Shows the cursor; returns `true` on success |

> Hiding the cursor while rendering animations or progress avoids a distracting flicker.

---

## Clearing the screen

```csharp
// Clear using the current background
ConsolePlus.Clear();

// Clear and set a new background color at the same time
ConsolePlus.Clear(Color.Navy);
ConsolePlus.Clear(ConsoleColor.Blue);   // ConsoleColor implicitly converts to Color
```

`Clear(Color?)` fills the buffer and sets the background color in one step. See also
[`ClearLine`](writing-output.md#blank-lines-and-clearing-lines) to clear a single row.

---

## Window size and resize events

```csharp
int width  = ConsolePlus.Width;
int height = ConsolePlus.Height;

ConsolePlus.WriteLine($"Terminal is {width} x {height}");
```

Subscribe to `SizeChanged` to react when the user resizes the window (great for redrawing layouts):

```csharp
ConsolePlus.SizeChanged += (sender, e) =>
{
	ConsolePlus.WriteLine($"Resized to {e.Width} x {e.Height}");
	RedrawUi();
};
```

| Member | Description |
|--------|-------------|
| `Width` | Current console width (columns) |
| `Height` | Current console height (rows) |
| `SizeChanged` | Event raised (with `ConsoleSizeChangedEventArgs`) when the size changes |

> The resize event is debounced. The delay (default **300 ms**, range 100–1000 ms) is part of the
> [profile configuration](profiles-and-capabilities.md).

---

## Alternate/secondary screen buffer

Terminals support a **secondary** (alternate) screen buffer — a separate full-screen canvas you can
switch to, draw on, and then switch back from, restoring the original screen exactly as it was
(this is how editors like `vim` leave your scrollback intact).

```csharp
using ConsolePlusLibrary;

// Check which buffer is active
TargetScreen active = ConsolePlus.CurrentBuffer;   // Primary or Secondary

// Switch to the secondary buffer for a full-screen view
if (ConsolePlus.SwapBuffer(TargetScreen.Secondary))
{
	ConsolePlus.Clear(Color.Black);
	ConsolePlus.WriteLine("[Lime]Full-screen mode![/]");
	ConsolePlus.ReadKey(true);

	// Return to the primary buffer — previous content is restored
	ConsolePlus.SwapBuffer(TargetScreen.Primary);
}
```

| Member | Description |
|--------|-------------|
| `CurrentBuffer` | The active `TargetScreen` (`Primary` or `Secondary`) |
| `SwapBuffer(TargetScreen)` | Switches buffers; returns `true` on success |

`TargetScreen` values: `Primary`, `Secondary`.

---

## Beep

```csharp
ConsolePlus.Beep();   // audible bell
```

---

## Low-level ANSI commands

For direct terminal control, `ConsolePlus.Ansi` exposes an `IAnsiCommands` emitter that writes raw
ANSI/VT escape sequences. This is an advanced surface — most apps only need the high-level members
above — but it is invaluable for custom renderers.

```csharp
var ansi = ConsolePlus.Ansi;

ansi.SaveCursor();
ansi.CursorPosition(row: 1, column: 1);   // 1-indexed
ansi.EraseInLine(2);                       // clear the whole line
ConsolePlus.Write("Status: OK");
ansi.RestoreCursor();
```

A selection of what `IAnsiCommands` offers:

| Category | Methods (examples) |
|----------|--------------------|
| **Cursor move** | `CursorPosition(row, col)`, `CursorHome()`, `CursorUp/Down/Left/Right(n)`, `CursorHorizontalAbsolute(n)`, `CursorNextLine(n)`, `CursorPreviousLine(n)` |
| **Cursor save/style** | `SaveCursor()`, `RestoreCursor()`, `ShowCursor()`, `HideCursor()`, `SetCursorStyle(n)` |
| **Erase** | `EraseInLine(mode)`, `EraseInDisplay(mode)`, `EraseCharacter(n)`, `ClearScrollback()` |
| **Edit** | `InsertCharacter(n)`, `DeleteCharacter(n)`, `InsertLine(n)`, `DeleteLine(n)` |
| **Scroll** | `ScrollUp(n)`, `ScrollDown(n)`, `Index()`, `ReverseIndex()` |
| **Screen** | `EnterAltScreen()`, `ExitAltScreen()` |
| **Tabs** | `CursorHorizontalTabulation(n)`, `CursorBackwardTabulation(n)` |

> The ANSI emitter only produces effects on ANSI-capable terminals. On non-ANSI terminals the
> high-level members (`Clear`, `SetCursorPosition`, `SwapBuffer`, …) remain the safe choice, because
> the [driver falls back](profiles-and-capabilities.md) automatically.

---

## Cheat sheet

```csharp
// Cursor
ConsolePlus.SetCursorPosition(10, 5);
var (l, t) = ConsolePlus.GetCursorPosition();
ConsolePlus.HideCursor(); ConsolePlus.ShowCursor();

// Screen
ConsolePlus.Clear(Color.Navy);
int w = ConsolePlus.Width, h = ConsolePlus.Height;
ConsolePlus.SizeChanged += (s, e) => RedrawUi();

// Buffers
ConsolePlus.SwapBuffer(TargetScreen.Secondary);
ConsolePlus.SwapBuffer(TargetScreen.Primary);

// ANSI
ConsolePlus.Ansi.CursorPosition(1, 1);
ConsolePlus.Ansi.EraseInDisplay(2);
```

---

[← Widgets](widgets.md) • [Back to Home](../README.md) • **Next:** [Profiles & Capabilities →](profiles-and-capabilities.md)
