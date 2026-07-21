<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # PromptPlus — the complementary toolkit
</div>

[← Environment Detection](environment-detection.md) • [Back to Home](../README.md)

---

**ConsolePlus** gives you a rock-solid rendering foundation: styled output, markup, colors, widgets,
cursor/screen control, and capability detection. **[PromptPlus](https://github.com/FRACerqueira/PromptPlus)**
is the complementary product that builds **on top of** that foundation to deliver **intelligent,
professional, interactive console controls** — the kind of rich prompts you'd otherwise have to build
by hand.

> **In one sentence:** ConsolePlus is *how you render*; PromptPlus is *how you interact*.

---

## Table of contents
- [Why two products?](#why-two-products)
- [How they fit together](#how-they-fit-together)
- [The `PromptPlus` entry point](#the-promptplus-entry-point)
- [Interactive controls at a glance](#interactive-controls-at-a-glance)
- [Example: a guided flow](#example-a-guided-flow)
- [Widgets through PromptPlus](#widgets-through-promptplus)
- [When to use which](#when-to-use-which)

---

## Why two products?

ConsolePlus deliberately stays focused on **rendering primitives**. It ships the input building
blocks you need for simple scenarios — `ReadLine`, `ReadKey`, and even
[Emacs-style line editing](reading-input.md#the-emacs-style-line-editor) — but it intentionally stops
short of full interactive UI.

PromptPlus picks up exactly where those primitives end, adding **stateful, keyboard-driven controls**
with validation, paging, filtering, history, and theming — all rendered through the same ConsolePlus
engine, so colors, markup, and capability fallbacks behave identically.

---

## How they fit together

```text
┌──────────────────────────────────────────────┐
│                  Your app                    │
├────────────────────────┬─────────────────────┤
│      PromptPlus        │                     │
│  (interactive controls)│                     │
│  Input · Select · ...  │   ← optional layer  │
├────────────────────────┴─────────────────────┤
│                 ConsolePlus                  │
│  output · markup · colors · widgets · ANSI   │
│  cursor/screen · capability detection        │
└──────────────────────────────────────────────┘
```

PromptPlus references ConsolePlus and reuses its console driver directly. In fact,
`PromptPlus.Console` **is** the ConsolePlus driver — so anything you learned in the
[Writing Output](writing-output.md), [Markup](markup.md), and [Colors](colors.md) guides applies
unchanged inside PromptPlus.

---

## The `PromptPlus` entry point

Just like `ConsolePlus`, `PromptPlus` is a static facade. It exposes four members:

| Member | Type | Purpose |
|--------|------|---------|
| `PromptPlus.Console` | `IConsole` | The shared ConsolePlus console driver |
| `PromptPlus.Controls` | `IControls` | Factory for interactive controls |
| `PromptPlus.Widgets` | `IWidgets` | Banners, dashes, calendar and other visual widgets |
| `PromptPlus.Config` | `IPromptPlusConfig` | Global configuration (themes, behavior) |

```csharp
using ConsolePlusLibrary;
using PromptPlusLibrary;

// Rendering — identical to ConsolePlus
PromptPlus.Console.WriteLine("[Teal]Powered by ConsolePlus[/]");

// Widgets
PromptPlus.Widgets.Banner("PromptPlus", Color.Bisque);
```

---

## Interactive controls at a glance

`PromptPlus.Controls` is a fluent factory. Below, a small portion of the API is presented in a table for easier understanding. All controls are available on the [PromptPlus website](https://github.com/FRACerqueira/PromptPlus).

Each method returns a configurable control you finish with a run/read call:

| Control | Factory method | What it does |
|---------|----------------|--------------|
| **Input** | `Input(prompt, description)` | Single-line text input with validation |
| **Secret** | `Secret(prompt, description)` | Masked/password input |
| **Select** | `Select<T>(prompt, description)` | Choose one item from a list |
| **MultiSelect** | `MultiSelect<T>(prompt, description)` | Choose multiple items |
| **Confirm** | `Confirm(prompt, description)` | Yes/No confirmation |
| **KeyPress** | `KeyPress(prompt, description)` | Wait for a specific key |
| **Calendar** | `Calendar(prompt, description)` | Interactive date picker |
| **ProgressBar** | `ProgressBar(prompt, description)` | Determinate progress display |
| **History** | `History(filename)` | Persisted input history |

> Controls are strongly typed. `Select<T>`/`MultiSelect<T>` work with your own model types, returning
> the selected `T` value(s).

---

## Example: a guided flow

```csharp
using ConsolePlusLibrary;
using PromptPlusLibrary;

PromptPlus.Widgets.Banner("Setup Wizard", Color.Bisque);

var name = PromptPlus.Controls
	.Input("What's your name?")
	.Run();

var env = PromptPlus.Controls
	.Select<string>("Choose an environment")
	.AddItems(["Development", "Staging", "Production"])
	.Run();

var proceed = PromptPlus.Controls
	.Confirm($"Deploy [Yellow]{name.Value}[/] to [Aqua]{env.Value}[/]?")
	.Run();

PromptPlus.Console.WriteLine(proceed.Value
	? "[Green]:CheckMarkButton: Deploying...[/]"
	: "[Red]:CrossMark: Cancelled[/]");
```

> The exact fluent methods (`AddItems`, `Default`, `Validate`, …) vary per control — see the
> [PromptPlus documentation](https://github.com/FRACerqueira/PromptPlus) for the complete API. The
> point here is that the **rendering** (markup, colors, emoji) is pure ConsolePlus.

---

## Widgets through PromptPlus

`PromptPlus.Widgets` mirrors the ConsolePlus [widgets](widgets.md) and adds more (for example, an
interactive `Calendar`). Note the parameter order — **style before dash option**:

```csharp
// text, style, dashOptions, extralines
PromptPlus.Widgets.Dash("Results", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);

// text, style
PromptPlus.Widgets.Banner("PromptPlus", Color.Bisque);
```

---

## When to use which

| Scenario | Use |
|----------|-----|
| Styled logging, reports, colored/markup output | **ConsolePlus** |
| Banners, dashes, section headers | **ConsolePlus** (or `PromptPlus.Widgets`) |
| Cursor/screen control, alternate buffer, ANSI | **ConsolePlus** |
| Menus, selection lists, wizards | **PromptPlus** |
| Password/secret input, validation, masking | **PromptPlus** |
| Yes/No confirmations, key prompts | **PromptPlus** |
| Date pickers, progress bars, input history | **PromptPlus** |

You can always start with **ConsolePlus** for rendering and add **PromptPlus** the moment you need
interactivity — they share the same engine, so the two compose seamlessly.

---

<div align="center">

**Ready to add intelligent controls?**
Explore **[PromptPlus on GitHub →](https://github.com/FRACerqueira/PromptPlus)**

</div>

---

[← Environment Detection](environment-detection.md) • [Back to Home](../README.md) • **Next:** [Advanced API →](advanced-api.md)
