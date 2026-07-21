<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Profiles & Capabilities
</div>

[← Cursor & Screen](cursor-and-screen.md) • [Back to Home](../README.md) • **Next:** [Environment Detection →](environment-detection.md)

---

When your app starts, ConsolePlus inspects the environment and builds a **profile** — an immutable
snapshot describing what the current terminal can do (ANSI support, Unicode support, color depth,
whether it's an interactive TTY, and more). ConsolePlus uses this profile to decide how to render,
so your code stays the same whether it runs in Windows Terminal, an SSH session, a CI pipeline, or a
redirected file.

## Table of contents
- [How detection works](#how-detection-works)
- [Reading the profile](#reading-the-profile)
- [Capability quick-checks](#capability-quick-checks)
- [Color depth](#color-depth)
- [The `AutoDetect` tri-state](#the-autodetect-tri-state)
- [Graceful degradation](#graceful-degradation)
- [Lifecycle & cleanup](#lifecycle--cleanup)
- [Environment detection](#environment-detection)
- [Cheat sheet](#cheat-sheet)

---

## How detection works

The static initializer runs **once**, the first time you touch `ConsolePlus`, and it:

1. **Attempts to enable ANSI on legacy Windows consoles.**
   - Modern Windows (Windows 10+) has native ANSI support via Virtual Terminal Processing
   - On legacy Windows systems (pre-Windows 10) that lack native ANSI support, ConsolePlus 
     automatically uses **[ANSICON](https://github.com/adoxa/ansicon)** (bundled with the library)
   - The ANSICON injection uses the `LdrLoadDll` approach via `CreateRemoteThread` for 64-bit 
     .NET AnyCPU processes, providing transparent ANSI escape sequence support
   - This happens automatically during initialization without requiring manual installation or 
     configuration
2. **Captures the original culture, colors, and input/output encodings** (so they can be restored on
   exit).
3. **Detects ANSI support, Unicode support, color depth, and terminal/redirection state.**
4. **Selects the rendering driver** — an **ANSI** adapter when escape sequences are supported, or a
   **non-ANSI** adapter that falls back to the classic `System.Console` color model.

Everything is automatic; you don't call an initialize method.

---

## Reading the profile

`ConsolePlus.Profile` returns an `IProfileReadOnly` describing the session:

```csharp
using ConsolePlusLibrary;

var p = ConsolePlus.Profile;

ConsolePlus.WriteLine($"Profile     : {p.ProfileName}");
ConsolePlus.WriteLine($"IsTerminal  : {p.IsTerminal}");
ConsolePlus.WriteLine($"Interactive : {p.Interactive}");
ConsolePlus.WriteLine($"Unicode     : {p.SupportUnicode}");   // AutoDetect
ConsolePlus.WriteLine($"ANSI        : {p.SupportsAnsi}");      // AutoDetect
ConsolePlus.WriteLine($"ColorDepth  : {p.ColorDepth}");        // ColorSystem
```

### `IProfileReadOnly` members

| Member | Type | Description |
|--------|------|-------------|
| `ProfileName` | `string` | Logical name of the detected terminal/config |
| `IsTerminal` | `bool` | `true` when the output is an interactive terminal (TTY) |
| `Interactive` | `bool` | `true` when the console supports interaction |
| `SupportUnicode` | `AutoDetect` | Whether Unicode output is supported |
| `SupportsAnsi` | `AutoDetect` | Whether ANSI escape sequences are supported |
| `ColorDepth` | `ColorSystem` | Detected color capability |
| `OriginalCulture` | `string` | Culture captured at startup |
| `DefaultForegroundColor` / `DefaultBackgroundColor` | `Color` | Default colors |
| `DefaultInputEncoding` / `DefaultOutputEncoding` | `Encoding` | Default encodings |
| `OriginalInputEncoding` / `OriginalOutputEncoding` | `Encoding` | Encodings captured at startup |

---

## Capability quick-checks

For the two most common checks, ConsolePlus exposes simple booleans directly on the facade — no need
to interpret the `AutoDetect` tri-state:

```csharp
if (ConsolePlus.SupportsUnicode)
{
	ConsolePlus.WriteLine("✓ Unicode ready");
}

if (ConsolePlus.SupportsAnsi)
{
	ConsolePlus.WriteLine("[Lime]True-color ANSI available[/]");
}
```

| Member | Type | Description |
|--------|------|-------------|
| `ConsolePlus.SupportsAnsi` | `bool` | Resolved ANSI support |
| `ConsolePlus.SupportsUnicode` | `bool` | Resolved Unicode support |

---

## Color depth

`ConsolePlus.ColorDepth` (and `Profile.ColorDepth`) return a [`ColorSystem`](colors.md#color-systems-depth)
value describing how many colors the terminal can render:

| `ColorSystem` | Mode | Colors | Typical environment |
|---------------|------|:------:|---------------------|
| `NoColors` | — | 1 | Redirected output / dumb terminal |
| `FourBit` | 4-bit | 16 | Classic Windows console |
| `Standard` | 8-bit | 256 | Most modern terminals |
| `TrueColor` | 24-bit | 16.7M | Windows Terminal, iTerm2, modern Linux terminals |

ConsolePlus automatically **down-samples** RGB colors to the nearest color the terminal supports, so
you can always write in true color and trust it to look right everywhere. See
[Colors → Color systems](colors.md#color-systems-depth) for details.

---

## The `AutoDetect` tri-state

Profile capability flags use the `AutoDetect` enum rather than a plain `bool`, so the profile can
distinguish "let the system decide" from an explicit yes/no:

| Value | Meaning |
|-------|---------|
| `Detect` | Let ConsolePlus detect support automatically (default) |
| `Yes` | Force support on |
| `No` | Force support off |

---

## Graceful degradation

Because rendering is profile-driven, the same code adapts automatically:

- **Markup and colors** — RGB colors are quantized to the terminal's `ColorDepth`; when output is
  redirected (`NoColors`), color codes are dropped and only plain text is written.
- **Unicode borders** — [dash and banner](widgets.md) borders fall back to ASCII characters
  (`-`, `=`, `*`) when Unicode isn't supported.
- **ANSI commands** — the [`Ansi`](cursor-and-screen.md#low-level-ansi-commands) emitter is a no-op
  on non-ANSI terminals, while high-level members keep working via the classic console driver.

This is why detecting the environment matters: you write rich output once, and ConsolePlus makes it
safe everywhere — from a developer's Windows Terminal to a headless CI log file.

```csharp
// Inspect how output will be handled
ConsolePlus.WriteLine($"Output redirected : {ConsolePlus.IsOutputRedirected}");
ConsolePlus.WriteLine($"Input redirected  : {ConsolePlus.IsInputRedirected}");
```

---

## Lifecycle & cleanup

ConsolePlus registers process-exit, unhandled-exception, and Ctrl+C handlers so the terminal is
always restored to its original culture, colors, and encodings when your app ends. You can hook into
shutdown to run final logic:

```csharp
ConsolePlus.ActionBeforeExist((console, ctrlCPressed) =>
{
	console.WriteLine(ctrlCPressed
		? "[Yellow]Cancelled by user (Ctrl+C).[/]"
		: "[Green]Goodbye![/]");
});
```

The callback receives the console instance and a `bool` indicating whether Ctrl+C triggered the exit.

---

## Environment detection

ConsolePlus automatically detects **14 major CI/CD providers** and adjusts its behavior accordingly.
This ensures your console application renders correctly whether it runs in an interactive terminal,
a CI/CD pipeline, or a redirected output stream.

Detected CI/CD providers include:
- **GitHub Actions**, **Azure Pipelines**, **GitLab CI**
- **Travis CI**, **Jenkins**, **TeamCity**
- **AppVeyor**, **Bamboo**, **Bitbucket Pipelines**
- **Bitrise**, **Continua CI**, **GoCD**
- **MyGet**, **TFS / Azure DevOps**

When a CI environment is detected, ConsolePlus:
- Disables interactive mode
- Sets the color depth to 4-bit
- Leaves ANSI support to auto-detection for most providers (GitHub Actions and Azure Pipelines
  force it on, AppVeyor forces it off)

For complete details about environment detection, including the specific environment variables
checked for each provider and how to verify the detected environment, see:

**👉 [Environment Detection →](environment-detection.md)**

---

## Cheat sheet

```csharp
// Read the profile
var p = ConsolePlus.Profile;
Console.WriteLine($"{p.ProfileName} | ANSI={p.SupportsAnsi} | {p.ColorDepth}");

// Quick capability checks
bool ansi    = ConsolePlus.SupportsAnsi;
bool unicode = ConsolePlus.SupportsUnicode;
ColorSystem depth = ConsolePlus.ColorDepth;

// Redirection
bool outRedirected = ConsolePlus.IsOutputRedirected;
bool inRedirected  = ConsolePlus.IsInputRedirected;

// Graceful shutdown hook
ConsolePlus.ActionBeforeExist((console, ctrlC) => console.WriteLine("Bye!"));
```

---

[← Cursor & Screen](cursor-and-screen.md) • [Back to Home](../README.md) • **Next:** [Environment Detection →](environment-detection.md)
