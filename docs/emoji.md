<div align="center">
  <img src="../icon.png" alt="ConsolePlus" width="120" height="120" />

  # Emoji
</div>

[← Markup Language](markup.md) • [Back to Home](../README.md) • **Next:** [Colors →](colors.md)

---

ConsolePlus ships with the full Unicode emoji catalog — **1,426** emoji across the **10 official
Unicode groups**, plus a few legacy aliases. You can drop them into any output using `:shortcode:`
tokens (just like [markup](markup.md#emoji)), an optional `:group/shortcode:` form, or reference
them as strongly-typed constants — one public static class per Unicode group (`EmojiActivities`,
`EmojiSymbols`, `EmojiTravelAndPlaces`, …).

## Table of contents
- [Compatibility considerations](#compatibility-considerations)
- [Two ways to use emoji](#two-ways-to-use-emoji)
- [Shortcodes and normalization](#shortcodes-and-normalization)
- [Group-qualified shortcodes](#group-qualified-shortcodes)
- [Strongly-typed constants](#strongly-typed-constants)
- [Group-typed constants](#group-typed-constants)
- [Emoji groups](#emoji-groups)
- [Legacy aliases](#legacy-aliases)
- [Terminal support](#terminal-support)
- [Cheat sheet](#cheat-sheet)

---

## Compatibility considerations

> ⚠️ **Important:** Emoji rendering depends on several factors beyond ConsolePlus control. While the
> library includes the full Unicode emoji catalog, whether you actually see color emoji depends on
> your environment.

### Unicode support required

**Emoji will not display (and will be ignored) if the terminal lacks Unicode support.** ConsolePlus
automatically detects Unicode capability during initialization and gracefully strips emoji shortcodes
when Unicode is unavailable. Check your terminal's Unicode status:

```csharp
bool hasUnicode = ConsolePlus.SupportsUnicode;
if (hasUnicode)
{
    ConsolePlus.WriteLine(":rocket: Unicode supported!");
}
else
{
    ConsolePlus.WriteLine("Unicode not supported - emoji will be stripped");
}
```

See [Profiles & Capabilities](profiles-and-capabilities.md) for detection details and how to
override the profile if needed.

### Font support

**Emoji rendering depends on your console's font.** Not all fonts include emoji glyphs, and even
fewer support **color emoji**:

- **Modern terminals** (Windows Terminal, iTerm2, Hyper) with emoji-capable fonts (Segoe UI Emoji,
  Noto Color Emoji, Apple Color Emoji) display rich, colorful icons
- **Traditional terminals** with standard monospace fonts (Consolas, Courier New) may display emoji
  as **monochrome symbols** or **placeholder boxes** (□ or ?)
- **Missing glyphs** appear as empty boxes, question marks, or are silently omitted

### Console support

**Some consoles display emoji as monochrome symbols instead of color icons:**

- Windows Command Prompt (cmd.exe) and older PowerShell versions often render black-and-white emoji
- Linux terminals vary widely — GNOME Terminal and Konsole generally support color emoji; xterm and
  rxvt typically do not
- SSH sessions inherit the remote server's font and terminal capabilities, which may differ from
  your local setup

### Cross-platform considerations

**Emoji support varies across different operating systems and terminal applications:**

| Platform | Common behavior |
|----------|----------------|
| **Windows 10+** | Windows Terminal supports color emoji; cmd.exe and older consoles show monochrome or boxes |
| **macOS** | Terminal.app and iTerm2 display full color emoji natively with system fonts |
| **Linux** | Highly variable — modern desktop terminals (GNOME Terminal, Konsole) support color emoji; server terminals often do not |
| **Docker/CI** | Typically no color emoji; may not support Unicode at all depending on base image |

### Best practices

When using emoji in your application:

1. **Test in your target environments** — emoji that work on your development machine may not work
   where your app is deployed
2. **Provide text fallbacks** — consider showing both emoji and text for critical information:
   ```csharp
   ConsolePlus.WriteLine($"{EmojiSymbols.Warning} Warning: Low disk space");
   // Fallback: "⚠️  Warning: Low disk space" or just "Warning: Low disk space"
   ```
3. **Use semantic color markup** — combine emoji with [markup colors](markup.md) for emphasis even
   when emoji render as monochrome
4. **Check Unicode support** — test `ConsolePlus.SupportsUnicode` before heavily relying on emoji
5. **Avoid essential information in emoji alone** — never rely solely on an emoji to convey critical
   status or instructions

---

## Two ways to use emoji

Emoji are available both inline (through markup parsing) and programmatically (through constants):

```csharp
using ConsolePlusLibrary;

// 1) Inline shortcodes — parsed anywhere markup is parsed
ConsolePlus.WriteLine(":rocket: Launching...");
ConsolePlus.WriteLine("[Green]:check_mark_button: Success[/]");

// 2) Strongly-typed constants — great for building strings in code
ConsolePlus.WriteLine($"{EmojiTravelAndPlaces.Rocket} Launching...");
ConsolePlus.WriteLine($"{EmojiTravelAndPlaces.Fire} {EmojiPeopleAndBody.ThumbsUp} {EmojiSmileysAndEmotion.RedHeart}");
```

Shortcodes are recognized by any method that parses markup — `Write`, `WriteLine`, `WriteFormat`,
`Banner`, and `Dash`. See the [Markup guide](markup.md#emoji) for how emoji combine with color tags.

> See [Strongly-typed constants](#strongly-typed-constants) below for the full list of per-group
> classes.

---

## Shortcodes and normalization

A shortcode is the emoji name wrapped in colons, for example `:red_heart:`. Lookups are
**case-insensitive** and ignore any separators, so all of these resolve to the same glyph:

```csharp
":red_heart:"   // snake_case (canonical shortcode)
":RedHeart:"    // PascalCase (matches the constant name)
":red-heart:"   // hyphenated
":Red Heart:"   // spaced
```

Internally every constant is indexed twice — under its **PascalCase** name (`RedHeart`) and its
**snake_case** shortcode (`red_heart`) — and each lookup key is normalized by lowercasing and
stripping non-alphanumeric characters. That is why the spacing/casing variants above are equivalent.

> Unknown shortcodes are removed (rendered as empty) so text stays clean on terminals that lack the
> glyph, exactly as described in [Markup → Emoji](markup.md#emoji).

---

## Group-qualified shortcodes

As a convenience, a shortcode may be **prefixed with its Unicode group** using a `/` separator. This
makes the intent explicit and mirrors the way this documentation is organized (one page per group):

```csharp
ConsolePlus.WriteLine(":activities/balloon:");            // 🎈
ConsolePlus.WriteLine(":symbols/check_mark_button:");     // ✅
ConsolePlus.WriteLine(":travel-and-places/rocket:");      // docs slug form → 🚀
```

The prefix must be **one of the 10 official groups**. When it matches, the group is stripped and the
emoji name itself is resolved, using the same case/separator-insensitive rules described above. The
prefix doesn't have to be the emoji's own group — any valid group is accepted, so it reads as a
helpful label rather than a strict filter. Both the `&` and the spelled-out `and` forms are
accepted, so all of these are equivalent:

```csharp
":activities/balloon:"        // group + name
":Activities/Balloon:"        // PascalCase everywhere
":food-and-drink/pizza:"      // docs slug form ("and")
":food & drink/pizza:"        // official "&" form
```

> **Backward compatible.** A plain `:balloon:` (no group) keeps working unchanged. If the text
> before `/` is **not** a known group, the token is rejected and treated as an unknown shortcode
> (rendered as empty) — and unknown names are still stripped the same way.

---

## Strongly-typed constants

Every emoji is a `public const string`, organized into **one public static class per Unicode
group** — there is no single flat "all emoji" class; the type that backs all of them internally
(`Emoji`) is an implementation detail and isn't part of the public API. You get IntelliSense,
compile-time safety, and no parsing overhead by referencing the group class directly:

```csharp
using ConsolePlusLibrary;

string status = $"{EmojiSymbols.CheckMarkButton} Done";
string alert  = $"{EmojiSymbols.Warning} Low disk space";
string love   = EmojiSmileysAndEmotion.RedHeart;
```

Each constant carries an XML-doc summary and its canonical `Lookup:` shortcode, so hovering a
constant shows both the glyph and the shortcode.

| Shortcode | Constant | Glyph |
|-----------|----------|-------|
| `:rocket:` | `EmojiTravelAndPlaces.Rocket` | 🚀 |
| `:fire:` | `EmojiTravelAndPlaces.Fire` | 🔥 |
| `:thumbs_up:` | `EmojiPeopleAndBody.ThumbsUp` | 👍 |
| `:red_heart:` | `EmojiSmileysAndEmotion.RedHeart` | ❤️ |
| `:check_mark_button:` | `EmojiSymbols.CheckMarkButton` | ✅ |
| `:cross_mark:` | `EmojiSymbols.CrossMark` | ❌ |
| `:warning:` | `EmojiSymbols.Warning` | ⚠️ |

---

## Group-typed constants

The per-group class name mirrors the [group-qualified shortcode](#group-qualified-shortcodes) form
`:group/name:` — pick the class matching the group, then the constant matching the name:

```csharp
using ConsolePlusLibrary;

// Group class constant  ↔  group-qualified shortcode
ConsolePlus.WriteLine($"{EmojiActivities.Balloon}");          // :activities/balloon:  → 🎈
ConsolePlus.WriteLine($"{EmojiSymbols.CheckMarkButton}");     // :symbols/check_mark_button: → ✅
ConsolePlus.WriteLine($"{EmojiTravelAndPlaces.Rocket}");      // :travel-and-places/rocket: → 🚀
```

Type `Emoji` then the group name to let IntelliSense narrow the catalog to that class.

The ten group classes use the PascalCase names of the official Unicode groups, prefixed with `Emoji`:

| Group class | Example |
|-------------|---------|
| `EmojiSmileysAndEmotion` | `EmojiSmileysAndEmotion.GrinningFace` 😀 |
| `EmojiPeopleAndBody` | `EmojiPeopleAndBody.ThumbsUp` 👍 |
| `EmojiComponent` | `EmojiComponent.LightSkinTone` 🏻 |
| `EmojiAnimalsAndNature` | `EmojiAnimalsAndNature.Dog` 🐶 |
| `EmojiFoodAndDrink` | `EmojiFoodAndDrink.Pizza` 🍕 |
| `EmojiTravelAndPlaces` | `EmojiTravelAndPlaces.Rocket` 🚀 |
| `EmojiActivities` | `EmojiActivities.Balloon` 🎈 |
| `EmojiObjects` | `EmojiObjects.Laptop` 💻 |
| `EmojiSymbols` | `EmojiSymbols.CheckMarkButton` ✅ |
| `EmojiFlags` | `EmojiFlags.ChequeredFlag` 🏁 |

---

## Emoji groups

The catalog follows the [official Unicode emoji ordering](https://www.unicode.org/emoji/charts/emoji-ordering.html).
Each group has its own reference page listing every glyph, constant, and shortcode.

| Group | Emoji | Sample | Reference |
|-------|:-----:|--------|-----------|
| **Smileys & Emotion** | 163 | 😀 😂 😍 😭 | [Browse →](emoji/smileys-and-emotion.md) |
| **People & Body** | 158 | 👍 🙏 👋 💪 | [Browse →](emoji/people-and-body.md) |
| **Component** | 9 | 🏻 🏽 🏿 🦰 | [Browse →](emoji/component.md) |
| **Animals & Nature** | 155 | 🐶 🐱 🌳 🌸 | [Browse →](emoji/animals-and-nature.md) |
| **Food & Drink** | 129 | 🍎 🍕 🍔 ☕ | [Browse →](emoji/food-and-drink.md) |
| **Travel & Places** | 219 | 🚀 🚗 🏠 🌍 | [Browse →](emoji/travel-and-places.md) |
| **Activities** | 85 | ⚽ 🎮 🎉 🎨 | [Browse →](emoji/activities.md) |
| **Objects** | 265 | 💻 📱 🔧 💡 | [Browse →](emoji/objects.md) |
| **Symbols** | 212 | ❤️ ✅ ⚠️ ❌ | [Browse →](emoji/symbols.md) |
| **Flags** | 31 | 🏴 🏁 🎌 🇧🇷 | [Browse →](emoji/flags.md) |
| **Total** | **1,426** | | |

> The **Component** group holds skin-tone and hair modifiers that combine with other emoji rather
> than standing alone.

---

## Legacy aliases

A few older names are preserved as **shortcode** aliases so existing text using them keeps
resolving to the current canonical emoji when parsed as markup:

| Alias shortcode | Resolves to | Glyph |
|-------|-----------|-------|
| `:hugging_face:` | `SmilingFaceWithOpenHands` | 🤗 |
| `:knocked_out_face:` | `FaceWithCrossedOutEyes` | 😵 |
| `:pouting_face:` | `EnragedFace` | 😡 |

> These aliases only exist as shortcodes today — the constants backing them live on the internal
> `Emoji` type, not on any of the public per-group classes above, so there is currently no
> strongly-typed way to reference `HuggingFace`/`KnockedOutFace`/`PoutingFace` in code. Use the
> canonical name's public constant instead (e.g. `EmojiSmileysAndEmotion.SmilingFaceWithOpenHands`),
> or the `:hugging_face:` shortcode form.

---

## Terminal support

Emoji rendering depends on the terminal's Unicode support, font capabilities, and platform. 
ConsolePlus automatically detects Unicode capability during initialization (see 
[Compatibility considerations](#compatibility-considerations) above for detailed information).

On terminals without Unicode support or emoji-capable fonts, unknown shortcodes are gracefully
stripped so your layout remains intact. See [Profiles & Capabilities](profiles-and-capabilities.md) 
for detection details and how to override the profile if needed.

---

## Cheat sheet

```csharp
// Inline shortcode (case/separator-insensitive)
":rocket:"   ":red_heart:"   ":RedHeart:"

// Group-qualified shortcode (prefix validated against the 10 groups)
":activities/balloon:"   ":symbols/check_mark_button:"

// Strongly-typed constant — one public class per group
EmojiTravelAndPlaces.Rocket   EmojiSmileysAndEmotion.RedHeart   EmojiSymbols.CheckMarkButton
EmojiActivities.Balloon

// Combine with markup
"[Green]:check_mark_button: Success[/]"
$"[Red]{EmojiSymbols.CrossMark} Failed[/]"
```

Jump to a group: [Smileys & Emotion](emoji/smileys-and-emotion.md) •
[People & Body](emoji/people-and-body.md) • [Component](emoji/component.md) •
[Animals & Nature](emoji/animals-and-nature.md) • [Food & Drink](emoji/food-and-drink.md) •
[Travel & Places](emoji/travel-and-places.md) • [Activities](emoji/activities.md) •
[Objects](emoji/objects.md) • [Symbols](emoji/symbols.md) • [Flags](emoji/flags.md)

---

[← Markup Language](markup.md) • [Back to Home](../README.md) • **Next:** [Colors →](colors.md)
