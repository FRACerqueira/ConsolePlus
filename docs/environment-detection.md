<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Environment Detection
</div>

[← Profiles & Capabilities](profiles-and-capabilities.md) • [Back to Home](../README.md)

---

ConsolePlus automatically detects the runtime environment during initialization and adjusts its
behavior accordingly. This ensures your console application renders correctly whether it runs in an
interactive terminal, a CI/CD pipeline, or a redirected output stream.

## Table of contents
- [How detection works](#how-detection-works)
- [Detected environments](#detected-environments)
- [CI/CD providers](#cicd-providers)
- [Environment-specific adjustments](#environment-specific-adjustments)
- [Terminal capabilities](#terminal-capabilities)
- [Override detection](#override-detection)
- [Checking the detected environment](#checking-the-detected-environment)

---

## How detection works

During the static initialization of `ConsolePlus`, the library performs automatic environment
detection by:

1. **Scanning environment variables** — Each CI/CD provider sets specific environment variables that
   ConsolePlus recognizes
2. **Detecting terminal capabilities** — Checks for TTY (interactive terminal), ANSI support, and
   Unicode support
3. **Determining color depth** — Automatically detects whether the environment supports no colors,
   4-bit, 8-bit (256 colors), or 24-bit TrueColor
4. **Enriching the profile** — Applies environment-specific settings to the console profile

The detection happens **once** and automatically; you don't need to configure anything manually.

```csharp
// Profile is automatically configured based on the detected environment
var profile = ConsolePlus.Profile;
Console.WriteLine($"Environment: {profile.ProfileName}");
Console.WriteLine($"Interactive: {profile.Interactive}");
Console.WriteLine($"ANSI Support: {profile.SupportsAnsi}");
Console.WriteLine($"Color Depth: {profile.ColorDepth}");
```

---

## Detected environments

ConsolePlus distinguishes between several types of environments:

| Environment Type | Characteristics | Example |
|-----------------|-----------------|---------|
| **Interactive Terminal** | User-facing, TTY detected, full capabilities | Windows Terminal, iTerm2, GNOME Terminal |
| **CI/CD Pipeline** | Automated build/test environment, non-interactive | GitHub Actions, Azure Pipelines, Jenkins |
| **Redirected Output** | Output piped to file or another process | `myapp.exe > output.txt` |
| **Legacy Console** | Pre-Windows 10 console without native ANSI | Windows 7/8 Command Prompt |
| **SSH Session** | Remote terminal session | PuTTY, SSH clients |
| **Docker Container** | Containerized environment | Docker, Kubernetes pods |

The detection process identifies which environment your application is running in and configures
output accordingly.

---

## CI/CD providers

ConsolePlus automatically detects **14 major CI/CD providers** by checking for their specific
environment variables. When a CI environment is detected, every provider detector:

- Disables interactive mode (`Interactive = false`)
- Sets color depth to 4-bit (`ColorSystem.FourBit`)

Most providers leave ANSI support at whatever the terminal auto-detection resolved. Only a few
force it explicitly: **GitHub Actions** and **Azure Pipelines** turn ANSI **on**, while **AppVeyor**
turns it **off**.

### Supported CI/CD providers

| Provider | Environment Variable | Color Depth | ANSI Support |
|----------|---------------------|-------------|--------------|
| **GitHub Actions** | `GITHUB_ACTIONS` | 4-bit | ✅ Forced on |
| **Azure Pipelines** | `AZURE_PIPELINES` | 4-bit | ✅ Forced on |
| **GitLab CI** | `CI_SERVER` (value `yes`) | 4-bit | Auto-detected |
| **Travis CI** | `TRAVIS` | 4-bit | Auto-detected |
| **Jenkins** | `JENKINS_URL` | 4-bit | Auto-detected |
| **TeamCity** | `TEAMCITY_VERSION` | 4-bit | Auto-detected |
| **AppVeyor** | `APPVEYOR` | 4-bit | ❌ Forced off |
| **Bamboo** | `bamboo_buildNumber` | 4-bit | Auto-detected |
| **Bitbucket Pipelines** | `BITBUCKET_REPO_OWNER`, `BITBUCKET_REPO_SLUG`, `BITBUCKET_COMMIT` | 4-bit | Auto-detected |
| **Bitrise** | `BITRISE_BUILD_URL` | 4-bit | Auto-detected |
| **Continua CI** | `ContinuaCI.Version` | 4-bit | Auto-detected |
| **GoCD** | `GO_SERVER_URL` | 4-bit | Auto-detected |
| **MyGet** | `BuildRunner` (value `MyGet`) | 4-bit | Auto-detected |
| **TFS / Azure DevOps** | `TF_BUILD` | 4-bit | Auto-detected |

> 💡 **Note:** A provider is matched when **any** of its environment variables is present (and, where
> a value is shown, matches that value). The detection logic lives in the `RuntimeEnvironment`
> namespace, with each provider having its own detector class implementing `IProfileEnrich`.

---

## Environment-specific adjustments

Based on the detected environment, ConsolePlus applies specific adjustments:

### Interactive terminals

```csharp
// Full capabilities enabled
profile.Interactive = true;
profile.SupportsAnsi = AutoDetect.Yes;  // if supported
profile.SupportUnicode = AutoDetect.Yes;  // if supported
profile.ColorDepth = ColorSystem.TrueColor;  // or Standard/FourBit based on detection
```

**Features:**
- Full color support (up to 24-bit TrueColor)
- ANSI escape sequences for cursor control and styling
- Unicode emoji and special characters
- Interactive input prompts

### CI/CD pipelines

```csharp
// Optimized for log output
profile.Interactive = false;
profile.ColorDepth = ColorSystem.FourBit;  // safe color level
// ANSI is usually left to auto-detection; GitHub Actions and Azure Pipelines
// force it on, while AppVeyor forces it off.
```

**Features:**
- Non-interactive mode (no prompts)
- ANSI colors for log readability
- Conservative color depth (16 colors)
- UTF-8 encoding for logs

### Redirected output

```csharp
// Minimal formatting, clean text output
profile.Interactive = false;
profile.SupportsAnsi = AutoDetect.No;
profile.ColorDepth = ColorSystem.NoColors;
```

**Features:**
- No colors (plain text)
- No ANSI escape sequences
- Clean, parseable output
- Suitable for file storage or piping

---

## Terminal capabilities

ConsolePlus detects several terminal capabilities automatically:

### ANSI support

Modern Windows (10+) and most Unix terminals support ANSI escape sequences natively. ConsolePlus
detects this and enables:

- Color output using ANSI codes
- Cursor positioning and movement
- Text styling (bold, underline, etc.)
- Screen buffer control

On **legacy Windows** (pre-Windows 10), ConsolePlus automatically injects
**[ANSICON](https://github.com/adoxa/ansicon)** (bundled) using `LdrLoadDll` via `CreateRemoteThread`
to provide transparent ANSI support.

### Unicode support

Unicode detection enables:

- Emoji rendering (`:rocket:`, `:fire:`, etc.)
- Unicode box-drawing characters
- International characters and symbols
- Full UTF-8 text output

### Color depth

ConsolePlus detects the terminal's color capabilities:

| Color System | Colors | Description |
|--------------|--------|-------------|
| `NoColors` | 0 | Plain text, no colors |
| `FourBit` | 16 | Standard console colors (ANSI 16) |
| `Standard` | 256 | 8-bit colors (ANSI 256) |
| `TrueColor` | 16.7M | 24-bit RGB colors |

Colors are automatically down-sampled if the terminal doesn't support the requested depth.

---

## Override detection

You can override the automatic detection if needed by modifying the profile after initialization:

```csharp
using ConsolePlusLibrary;
using ConsolePlusLibrary.Core;

// Force disable ANSI even if detected
ConsolePlus.Profile.SupportsAnsi = AutoDetect.No;

// Force specific color depth
ConsolePlus.Profile.ColorDepth = ColorSystem.FourBit;

// Force Unicode support
ConsolePlus.Profile.SupportUnicode = AutoDetect.Yes;

// Mark as interactive
ConsolePlus.Profile.Interactive = true;
```

> ⚠️ **Warning:** Overriding detection should be done carefully, as incorrect settings may result
> in garbled output or missing features. Use this only when you have specific knowledge about your
> deployment environment that the automatic detection cannot infer.

See [Profiles & Capabilities](profiles-and-capabilities.md) for more details on profile configuration.

---

## Checking the detected environment

You can query the detected environment at runtime:

```csharp
using ConsolePlusLibrary;

var profile = ConsolePlus.Profile;

// Check environment type
if (profile.Interactive)
{
	ConsolePlus.WriteLine("[Green]Running in interactive terminal[/]");
}
else
{
	ConsolePlus.WriteLine("Running in non-interactive environment (CI/CD or redirected)");
}

// Check capabilities
ConsolePlus.WriteLine($"ANSI Support: {profile.SupportsAnsi}");
ConsolePlus.WriteLine($"Unicode Support: {profile.SupportUnicode}");
ConsolePlus.WriteLine($"Color Depth: {profile.ColorDepth}");
ConsolePlus.WriteLine($"Is Terminal: {profile.IsTerminal}");

// Check for specific CI environments
bool isCI = !profile.Interactive && !ConsolePlus.IsOutputRedirected;
if (isCI)
{
	ConsolePlus.WriteLine("Detected CI/CD environment");
}

// Adapt behavior based on environment
if (profile.ColorDepth == ColorSystem.NoColors)
{
	ConsolePlus.WriteLine("Colors disabled - using plain text mode");
}
else
{
	ConsolePlus.WriteLine("[Cyan]Colors enabled[/]");
}
```

### Useful properties for environment detection

| Property | Type | Description |
|----------|------|-------------|
| `Profile.Interactive` | `bool` | Whether the console supports user interaction |
| `Profile.IsTerminal` | `bool` | Whether output is connected to a terminal (TTY) |
| `Profile.SupportsAnsi` | `AutoDetect` | ANSI escape sequence support |
| `Profile.SupportUnicode` | `AutoDetect` | Unicode character support |
| `Profile.ColorDepth` | `ColorSystem` | Detected color capability |
| `IsOutputRedirected` | `bool` | Whether output is redirected to a file/pipe |
| `IsInputRedirected` | `bool` | Whether input is redirected |
| `IsErrorRedirected` | `bool` | Whether error stream is redirected |

---

## Implementation details

The environment detection system is implemented in the `ConsolePlusLibrary.RuntimeEnvironment`
namespace. Each CI/CD provider has its own detector class implementing the `IProfileEnrich`
interface:

```csharp
internal interface IProfileEnrich
{
	bool TryEnrich(ProfileConsole profile);
}
```

During initialization, ConsolePlus queries all registered enrichers. The first enricher that
successfully matches the environment (returns `true`) enriches the profile with provider-specific
settings.

### Example: GitHub Actions detector

```csharp
internal sealed class GitHub : BaseClassCI, IProfileEnrich
{
	public bool TryEnrich(ProfileConsole profile)
	{
		if (Found((value) => !string.IsNullOrWhiteSpace(value), "GITHUB_ACTIONS"))
		{
			profile.ChangedColorDepth = true;
			profile.ChangedSupportsAnsi = true;
			profile.ColorDepth = ColorSystem.FourBit;
			profile.SupportsAnsi = AutoDetect.Yes;
			profile.Interactive = false;
			return true;
		}
		return false;
	}
}
```

This architecture makes it easy to add support for new CI/CD providers in the future.

---

**Related pages:**
- **[Profiles & Capabilities](profiles-and-capabilities.md)** — How to read and configure the profile
- **[Getting Started](getting-started.md)** — Initialization and automatic setup
- **[Cursor & Screen Control](cursor-and-screen.md)** — ANSI commands and terminal control

---

[← Profiles & Capabilities](profiles-and-capabilities.md) • [Back to Home](../README.md)
