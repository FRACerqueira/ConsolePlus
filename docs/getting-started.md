<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Getting Started
</div>

[← Back to Home](../README.md) • **Next:** [Writing Output →](writing-output.md)

---

This guide walks you through installing ConsolePlus, writing your first application, and
understanding how the library initializes itself and detects your terminal.

## Table of contents
- [Requirements](#requirements)
- [Installation](#installation)
- [Your first application](#your-first-application)
- [The `ConsolePlus` entry point](#the-consoleplus-entry-point)
- [How initialization works](#how-initialization-works)
- [Graceful exit and cleanup](#graceful-exit-and-cleanup)
- [Next steps](#next-steps)

---

## Requirements

| Requirement | Details |
|-------------|---------|
| **.NET SDK** | .NET 8, .NET 9, or .NET 10 |
| **OS** | Windows, Linux, macOS (cross-platform) |
| **Terminal** | Any terminal. ANSI/Unicode/color features are auto-detected and gracefully degraded |

ConsolePlus targets `net8.0`, `net9.0`, and `net10.0`, with nullable reference types enabled.

---

## Installation

Add the package with the .NET CLI:

```bash
dotnet add package ConsolePlus
```

Or with the Package Manager Console in Visual Studio:

```powershell
Install-Package ConsolePlus
```

---

## Your first application

Create a new console project and replace `Program.cs`:

```bash
dotnet new console -n HelloConsolePlus
cd HelloConsolePlus
dotnet add package ConsolePlus
```

```csharp
using ConsolePlusLibrary;

// Reset any inherited colors and clear the screen
ConsolePlus.ResetColor();
ConsolePlus.Clear();

// A banner to greet the user
ConsolePlus.Banner("ConsolePlus", Color.Teal, DashOptions.SingleBorderUpDown);

// Rich, colored output using markup
ConsolePlus.WriteLine("[Green]Your first ConsolePlus app is running![/]");
ConsolePlus.WriteLine("Color depth detected: [Yellow]" + ConsolePlus.ColorDepth + "[/]");

// Ask for input
ConsolePlus.Write("What is your name? ", Color.Aqua);
var name = ConsolePlus.ReadLine();

ConsolePlus.WriteLine($"Hello, [Fuchsia]{name}[/]! :wave:");
```

Run it:

```bash
dotnet run
```

You should see a banner, colored text, and an emoji — all adapted to your terminal's capabilities.

---

## The `ConsolePlus` entry point

Everything in the library is exposed through a single **static class**: `ConsolePlus`
(in the `ConsolePlusLibrary` namespace). You never need to instantiate anything.

```csharp
using ConsolePlusLibrary;

ConsolePlus.WriteLine("Output");            // write
ConsolePlus.ForegroundColor = ConsoleColor.Green;   // colors
var key = ConsolePlus.ReadKey(true);        // input
ConsolePlus.Ansi.CursorUp(1);               // low-level ANSI
var profile = ConsolePlus.Profile;          // capabilities
```

The API is organized into logical areas (each documented on its own page):

| Area | Members (examples) | Guide |
|------|--------------------|-------|
| Output | `Write`, `WriteLine`, `WriteFormat`, `WriteLines`, `ClearLine` | [Writing Output](writing-output.md) |
| Input | `Read`, `ReadKey`, `ReadLine`, `ReadLineEmacs` | [Reading Input](reading-input.md) |
| Colors | `ForegroundColor`, `ForegroundRgbColor`, `ColorDepth` | [Colors](colors.md) |
| Styles | `CurrentStyle`, `StyleForeground`, `StyleInvert` | [Styles](styles.md) |
| Widgets | `Banner`, `Dash` | [Widgets](widgets.md) |
| Screen | `Clear`, `SwapBuffer`, `SizeChanged`, cursor members | [Cursor & Screen](cursor-and-screen.md) |
| Capabilities | `Profile`, `SupportsAnsi`, `SupportsUnicode` | [Profiles & Capabilities](profiles-and-capabilities.md) |
| ANSI | `Ansi` (an `IAnsiCommands`) | [Cursor & Screen](cursor-and-screen.md#low-level-ansi-commands) |

---

## How initialization works

ConsolePlus initializes **automatically** the first time you touch the `ConsolePlus` class
(via its static constructor). During this one-time setup it:

1. **Attempts to enable ANSI** on legacy Windows versions (using a bundled helper when needed).
   - On legacy Windows systems (pre-Windows 10) that lack native ANSI support, ConsolePlus 
     automatically uses **[ANSICON](https://github.com/adoxa/ansicon)** (bundled with the library)
   - The injection uses the `LdrLoadDll` approach via `CreateRemoteThread` for 64-bit .NET AnyCPU 
     processes
   - This provides transparent ANSI escape sequence support without requiring manual installation 
     or configuration
2. **Captures the original console state** — culture, foreground/background colors, and input/output
   encodings — so it can be restored on exit.
3. **Builds a capability profile** by detecting:
   - ANSI escape sequence support
   - Unicode support
   - Color depth (`NoColors`, `FourBit`, `Standard`, `TrueColor`)
   - Whether the output is an interactive terminal (TTY)
   - Known CI providers (GitHub Actions, Azure Pipelines, GitLab, Travis, Jenkins, TeamCity,
     AppVeyor, Bamboo, Bitbucket, Bitrise, Continua CI, GoCD, MyGet, TFS/Azure DevOps)
   - See [Environment Detection](environment-detection.md) for the complete list of supported
     CI/CD providers and how detection works
4. **Selects the right driver** — an ANSI-capable renderer when supported, otherwise a safe
   non-ANSI fallback that still produces correct (uncolored) output.

Because detection is automatic, the same code produces rich output in a modern terminal and
clean, readable output in a plain or redirected one. See
[Profiles & Capabilities](profiles-and-capabilities.md) to inspect or override these values.

---

## Graceful exit and cleanup

ConsolePlus registers process-exit handlers so your terminal is **left in a clean state**:
original colors, culture, and encodings are restored automatically, and streams are flushed.

You can also register your own callback to run just before the process exits — for example, to
print a farewell message or persist state. The callback receives the console instance and a flag
indicating whether the exit was triggered by <kbd>Ctrl</kbd>+<kbd>C</kbd>:

```csharp
ConsolePlus.ActionBeforeExist((console, ctrlCPressed) =>
{
	console.WriteLine(ctrlCPressed
		? "[Red]Cancelled by user.[/]"
		: "[Green]Goodbye![/]");
});
```

---

## Next steps

- ▶️ **[Writing Output](writing-output.md)** — master `Write`/`WriteLine` and formatting
- 🎨 **[Markup Language](markup.md)** — colorize text inline
- 🌈 **[Colors](colors.md)** — see the full visual palette
- 🔍 **[Environment Detection](environment-detection.md)** — understand automatic CI/CD detection
- 🧩 **[ConsolePlus + PromptPlus](promptplus.md)** — add interactive controls

---

[← Back to Home](../README.md) • **Next:** [Writing Output →](writing-output.md)
