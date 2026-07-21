================================================================================
ConsolePlus
================================================================================

A modern .NET library for building beautiful, cross-platform console 
applications.

NuGet: https://www.nuget.org/packages/ConsolePlus
License: MIT
Target Frameworks: .NET 8, .NET 9, .NET 10

================================================================================
OVERVIEW
================================================================================

ConsolePlus is a .NET library that makes it easier to create beautiful, 
cross-platform console applications. It provides a rich, styled output engine 
(colors, markup, emoji, banners), robust input helpers, terminal-capability 
detection, ANSI escape sequence control, and screen/buffer management - all 
behind one clean, static entry point: ConsolePlus.

ConsolePlus is heavily inspired by the excellent Spectre.Console 
(https://spectreconsole.net) and serves as the core foundation for PromptPlus 
(https://github.com/FRACerqueira/PromptPlus).

================================================================================
KEY FEATURES
================================================================================

* Rich colors
  - 148 CSS named colors, HEX, RGB, 4-bit/8-bit/24-bit (TrueColor) with 
	automatic down-sampling

* Markup
  - Inline [red]...[/] style tags with auto-closing, background colors, 
	hierarchical nesting, and raw fallback on errors

* Emoji
  - :smiley:-style shortcodes replaced with real Unicode glyphs
	- Typed-name facilitator: EmojiName + EmojiValue
  - Public group helper classes (EmojiActivities, EmojiTravelAndPlaces, EmojiSymbols, ...)

* Styling
  - Foreground/background colors, inversion, and overflow strategies 
	(crop / ellipsis)

* Widgets
  - FIGlet banners and dash separators

* Input
  - Standard reads plus an Emacs-style line editor (sync & async)

* Screen control
  - Cursor movement, alternate/secondary buffer, clear, resize events

* Capabilities
  - Automatic detection of ANSI, Unicode, color depth, TTY and CI environments

* ANSI
  - Low-level IAnsiCommands emitter for direct escape-sequence control

* Legacy Windows
  - Automatic ANSI support on pre-Windows 10 via bundled ANSICON
	(https://github.com/adoxa/ansicon)

* Accessibility
  - WCAG luminance/contrast helpers to keep text readable

================================================================================
INSTALLATION
================================================================================

Via .NET CLI:

	dotnet add package ConsolePlus

Via Package Manager Console:

	Install-Package ConsolePlus

Supported frameworks: .NET 8, .NET 9, .NET 10

================================================================================
QUICK START
================================================================================

using ConsolePlusLibrary;

// Clear and reset colors
ConsolePlus.Clear();

// Markup: foreground, background ("on"/":") and nesting
ConsolePlus.WriteLine("[Yellow]Hello[/], [Red on White]ConsolePlus[/]!");

// A FIGlet banner
ConsolePlus.Banner("ConsolePlus", Color.Teal, DashOptions.SingleBorderUpDown);

// Styled output with a Style object
ConsolePlus.WriteLine("Styled text", new Style(Color.White, Color.Navy));

// Emoji (3 equivalent approaches)
ConsolePlus.WriteLine(":rocket: Ready to launch!");                              // 1) Shortcode
ConsolePlus.WriteLine($"{EmojiTravelAndPlaces.Rocket} Ready to launch!");       // 2) Group helper class
ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.Rocket} Ready to launch!");      // 3) EmojiName + EmojiValue

// Read a line using the Emacs-style editor
var name = ConsolePlus.ReadLineEmacs();
ConsolePlus.WriteLine($"Welcome, [Aqua]{name}[/]!");

================================================================================
EXAMPLES
================================================================================

Markup and Colors:

	// Simple markup
	ConsolePlus.WriteLine("[Red]Error:[/] File not found");

	// Background colors
	ConsolePlus.WriteLine("[White on Red] CRITICAL [/]");

	// Nested styles with hierarchy
	ConsolePlus.WriteLine("[Yellow]Warning: [Red]Critical[/] issue[/]");

	// Auto-closing (no [/] needed at end)
	ConsolePlus.WriteLine("[Green]Success");

	// Emoji
	ConsolePlus.WriteLine(":warning: System temperature high :fire:");
	ConsolePlus.WriteLine($"{EmojiSymbols.Warning} System temperature high {EmojiTravelAndPlaces.Fire}");
	ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.Warning} System temperature high {(EmojiValue)EmojiName.Fire}");

Widgets:

	// FIGlet banner with border
	ConsolePlus.Banner("My App", Color.Cyan, DashOptions.DoubleBorderUpDown);

	// Separator with title
	ConsolePlus.Dash("Configuration", Color.Yellow, DashOptions.SingleBorder);

Input:

	// Standard readline
	var input = ConsolePlus.ReadLine();

	// Emacs-style editor with features
	var email = ConsolePlus.ReadLineEmacs(
		caseOptions: CaseOptions.Lowercase,
		acceptInput: c => char.IsLetterOrDigit(c) || c == '@' || c == '.'
	);

	// Async with cancellation
	var result = await ConsolePlus.ReadLineEmacsAsync(
		cancellationToken: token
	);

================================================================================
DOCUMENTATION
================================================================================

Complete documentation is available on GitHub:

	https://github.com/FRACerqueira/ConsolePlus

Quick Links:

* Getting Started
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/getting-started.md

* Writing Output
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/writing-output.md

* Reading Input
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/reading-input.md

* Markup Language
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/markup.md

* Colors
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/colors.md

* Widgets
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/widgets.md

* Cursor & Screen
  https://github.com/FRACerqueira/ConsolePlus/blob/main/docs/cursor-and-screen.md

================================================================================
CONSOLEPLUS + PROMPTPLUS
================================================================================

ConsolePlus focuses on console fundamentals - styled output, colors, 
capabilities and screen control.

When you need intelligent, professional interactive controls on top of that 
foundation (select lists, multi-select, inputs with validation, masked secrets, 
confirmations, calendars, progress bars, input history, and more), reach for 
PromptPlus:

	https://github.com/FRACerqueira/PromptPlus

Example:

	using PromptPlusLibrary;

	// PromptPlus surfaces ConsolePlus through PromptPlus.Console
	PromptPlus.Console.WriteLine("[Green]Powered by ConsolePlus[/]");
	PromptPlus.Widgets.Banner("PromptPlus", Color.Bisque);

================================================================================
LICENSE
================================================================================

ConsolePlus is licensed under the MIT License.
https://opensource.org/licenses/MIT

Portions are inspired by and adapted from Spectre.Console 
(https://spectreconsole.net) (c) 2020 Patrik Svensson, Phil Scott, 
Nils Andresen, also under the MIT license.

Emoji-datasource is licensed under the UNICODE LICENSE V3.
https://unicode.org/license.html

================================================================================

Project: https://github.com/FRACerqueira/ConsolePlus
Maintained by: Fernando Cerqueira
Copyright (c) 2026 Fernando Cerqueira

================================================================================
