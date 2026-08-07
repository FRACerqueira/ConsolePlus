<div align="center">
  <img src="icon.png" alt="ConsolePlus" width="120" height="120" />

  # ConsolePlus

  **A modern .NET library for building beautiful, cross-platform console applications.**

  [![NuGet](https://img.shields.io/badge/NuGet-ConsolePlus.net-blue)](https://www.nuget.org/packages/ConsolePlus.net)
  [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
  [![.NET](https://img.shields.io/badge/.NET-8%20%7C%209%20%7C%2010-512BD4)](https://dotnet.microsoft.com/)
  [![NuGet](https://img.shields.io/nuget/v/ConsolePlus.net.svg?include_prereleases)](https://www.nuget.org/packages/ConsolePlus.net)
  [![Downloads](https://img.shields.io/nuget/dt/ConsolePlus.net)](https://www.nuget.org/packages/ConsolePlus.net)

</div>

> 🤖 **New:** pick the right ConsolePlus/PromptPlus layer and control conversationally with the [**ConsolePlus + PromptPlus Plugin**](https://github.com/FRACerqueira/ConsolePlus-PromptPlus-IA-Plugin) — works with Claude Code or GitHub Copilot to choose the layer, check whether an interactive control can run in your context, pick the right one of PromptPlus's 21 controls, implement it, and audit existing usage. [Learn more ↓](#-using-consoleplus-with-claude-code-or-github-copilot)

---

ConsolePlus is a .NET library that makes it easier to create **beautiful, cross-platform console
applications**. It provides a rich, styled output engine (colors, markup, emoji, banners), robust
input helpers, terminal-capability detection, ANSI escape sequence control, and screen/buffer
management — all behind one clean, static entry point: `ConsolePlus`.

> ConsolePlus is heavily inspired by the excellent [Spectre.Console](https://spectreconsole.net) and
> serves as the **core foundation for [PromptPlus](#-consoleplus--promptplus)**.

---

## ✨ Highlights

| Capability | What you get |
|------------|--------------|
| 🎨 **Rich colors** | 148 CSS named colors, HEX, RGB, 4-bit/8-bit/24-bit (TrueColor) with automatic down-sampling |
| 🏷️ **Markup** | Inline `[red]...[/]` style tags with auto-closing, background colors, hierarchical nesting, and raw fallback on errors |
| 😀 **Emoji** | `:smiley:` shortcodes, typed names via `EmojiName`/`EmojiValue`, and public group helpers (`EmojiTravelAndPlaces`, `EmojiSymbols`, etc.) |
| 🖋️ **Styling** | Foreground/background colors, inversion, and overflow strategies (crop / ellipsis) |
| 🧱 **Widgets** | FIGlet **banners** and **dash** separators |
| ⌨️ **Input** | Standard reads plus an **Emacs-style** line editor (sync & async) |
| 🖥️ **Screen control** | Cursor movement, alternate/secondary buffer, clear, resize events |
| 🧭 **Capabilities** | Automatic detection of ANSI, Unicode, color depth, TTY and CI environments |
| 🔤 **ANSI** | Low-level `IAnsiCommands` emitter for direct escape-sequence control |
| 🪟 **Legacy Windows** | Automatic ANSI support on pre-Windows 10 via bundled [ANSICON](https://github.com/adoxa/ansicon) |
| ♿ **Accessibility** | WCAG luminance/contrast helpers to keep text readable |
| 🎬 **Demo Mode** | Scripted keyboard input (opt-in) to auto-record GIFs/videos of console apps — see [Demo Mode](docs/demo-mode.md) |

---

## 📦 Installation

```bash
dotnet add package ConsolePlus.net
```

Or via the Package Manager Console:

```powershell
Install-Package ConsolePlus.net
```

**Supported target frameworks:** `.NET 8`, `.NET 9`, `.NET 10`.

---

## 🚀 Quick start

```csharp
using ConsolePlusLibrary;

// Everything is exposed through the static ConsolePlus class.
ConsolePlus.Clear();

// Markup: foreground, background ("on"/":") and nesting
ConsolePlus.WriteLine("[Yellow]Hello, [Red on White]ConsolePlus!");

// A FIGlet banner
ConsolePlus.Banner("ConsolePlus", Color.Teal, DashOptions.SingleBorderUpDown);

// Styled output with a Style object
ConsolePlus.WriteLine("Styled text", new Style(Color.White, Color.Navy));

// Emoji (3 equivalent approaches)
ConsolePlus.WriteLine(":rocket: Ready to launch!");                              // 1) Shortcode
ConsolePlus.WriteLine($"{EmojiTravelAndPlaces.Rocket} Ready to launch!");       // 2) Group helper class
ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.Rocket} Ready to launch!");      // 3) EmojiName + EmojiValue

// Another example with heart
ConsolePlus.WriteLine(":red_heart: I love ConsolePlus");
ConsolePlus.WriteLine($"{EmojiSmileysAndEmotion.RedHeart} I love ConsolePlus");
ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.RedHeart} I love ConsolePlus");

// Read a line using the Emacs-style editor
var name = ConsolePlus.ReadLineEmacs();
ConsolePlus.WriteLine($"Welcome, [Aqua]{name}[/]!");
```

---

## 📚 Documentation

Start here and follow the guides in order, or jump straight to the topic you need.

### API Reference
- **[API Documentation](docs/api/ConsolePlusLibrary.md)** — complete API reference (auto-generated from XML comments)

### Fundamentals
- **[Getting Started](docs/getting-started.md)** — install, first app, and how initialization works
- **[Writing Output](docs/writing-output.md)** — `Write`, `WriteLine`, `WriteFormat`, blank lines, clearing
- **[Reading Input](docs/reading-input.md)** — keys, lines, and the Emacs-style editor

### Styling & color
- **[Markup Language](docs/markup.md)** — inline color tags, escaping, and emoji
- **[Emoji](docs/emoji.md)** — `:shortcode:` tokens, typed names (`EmojiName`/`EmojiValue`), group helper classes (`EmojiActivities`, `EmojiTravelAndPlaces`, ...), and the **full emoji catalog by group**
- **[Colors](docs/colors.md)** — color systems, factory methods, contrast helpers, and the **full visual palette**
- **[Styles & Overflow](docs/styles.md)** — the `Style` struct and text overflow strategies

### Layout & terminal
- **[Widgets: Banners & Dashes](docs/widgets.md)** — FIGlet banners and separators
- **[Cursor & Screen Control](docs/cursor-and-screen.md)** — cursor, buffers, resize events, ANSI commands
- **[Profiles & Capabilities](docs/profiles-and-capabilities.md)** — capability detection and configuration
- **[Environment Detection](docs/environment-detection.md)** — automatic CI/CD and terminal detection

### Ecosystem
- **[ConsolePlus + PromptPlus](docs/promptplus.md)** — add intelligent, professional interactive controls

### Advanced
- **[Advanced API](docs/advanced-api.md)** — driver access, thread-safe output, fragments, the Emacs buffer, and string/culture/key helpers
- **[Demo Mode](docs/demo-mode.md)** — scripted keyboard input for recording GIFs/videos of console apps

### Development
- **[Test Driver Maintenance](docs/testing-driver-maintenance.md)** — how the `VirtualTerminal` test driver is kept in sync with PromptPlus (contributor-facing, not part of the public API)
- **[API Documentation Guide](docs/api-documentation-guide.md)** — how `docs/api/` is generated and regenerated (contributor-facing, not part of the public API)

---

## 🧩 ConsolePlus + PromptPlus

ConsolePlus focuses on **console fundamentals** — styled output, colors, capabilities and screen
control. When you need **intelligent, professional interactive controls** on top of that foundation
(select lists, multi-select, inputs with validation, masked secrets, confirmations, calendars,
progress bars, input history, and more), reach for **[PromptPlus](docs/promptplus.md)**.

PromptPlus is built directly on top of ConsolePlus and exposes it through `PromptPlus.Console` and
`PromptPlus.Widgets`, so everything documented here is available while you build fully interactive
command-line experiences.

```csharp
using PromptPlusLibrary;

// PromptPlus surfaces ConsolePlus through PromptPlus.Console / PromptPlus.Widgets
PromptPlus.Console.WriteLine("[Green]Powered by ConsolePlus[/]");
PromptPlus.Widgets.Banner("PromptPlus", Color.Bisque);
```

> 👉 Learn more in the **[ConsolePlus + PromptPlus](docs/promptplus.md)** guide.

---

## 🤖 Using ConsolePlus with Claude Code or GitHub Copilot

Prefer describing what you need in plain language instead of driving the API by hand? The official
[**ConsolePlus + PromptPlus Plugin**](https://github.com/FRACerqueira/ConsolePlus-PromptPlus-IA-Plugin)
lets [Claude Code](https://claude.com/claude-code) or [GitHub Copilot](https://github.com/features/copilot)
choose and implement the right control for you:

- A skill (`select-promptplus-control`) that decides whether the need is ConsolePlus rendering or a
  `PromptPlus.Controls` interactive control, checks whether that control can even run in the target
  context (redirected input, CI, hosted services), picks the right one of PromptPlus's 21 controls,
  and implements it against the real, version-pinned fluent API — not a guess from memory.
- A `promptplus-auditor` agent that audits existing ConsolePlus/PromptPlus usage in a codebase (the
  redirected-input guard gap, unchecked `IsAborted`, `IWidgets` namespace mix-ups, global `Config`
  vs. `.Options()`) and produces a read-only report.
- A `promptplus-precommit-check` agent that catches the two cheapest bug-risk patterns on just the
  pending diff, before a commit/PR.

Applies to console-type .NET projects only — enforced automatically by a hook on Claude Code, or
checked by the skill itself on Copilot, which has no hook mechanism.

---

## 📐 Architecture Decision Records (ADR)

ConsolePlus documents its significant architectural and design decisions as
**Architecture Decision Records (ADR)**, following the
[AdrPlus](https://github.com/FRACerqueira/AdrPlus) convention. Each record
captures the context, the decision, the alternatives considered, and the
consequences — so the reasoning behind the library's design stays traceable over
time.

👉 See the **[ADR index](docs/adr/indexadrs.md)** for the full list of decisions.

---

## 📄 License

ConsolePlus is licensed under the **[MIT License](https://opensource.org/licenses/MIT)**.

Portions are inspired by and adapted from **[Spectre.Console](https://spectreconsole.net)**
(© 2020 Patrik Svensson, Phil Scott, Nils Andresen), also under the MIT license.

Emoji-datasource is licensed under the **[UNICODE LICENSE V3](https://unicode.org/license.html)**.

---

<div align="center">
  <sub>Maintained by the PromptPlus project • © 2026 Fernando Cerqueira</sub>
</div>
