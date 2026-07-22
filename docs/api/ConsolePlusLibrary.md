<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')

## ConsolePlusLibrary Namespace

| Classes | |
| :--- | :--- |
| [ColorExtensions](ColorExtensions.md 'ConsolePlusLibrary\.ColorExtensions') | Provides extension methods for [Color](Color.md 'ConsolePlusLibrary\.Color')\. |
| [ConsoleKeyInfoExtensions](ConsoleKeyInfoExtensions.md 'ConsolePlusLibrary\.ConsoleKeyInfoExtensions') | Provides extension methods for [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate specific key combinations, including standard keys and Emacs\-style shortcuts\. |
| [ConsolePlus](ConsolePlus.md 'ConsolePlusLibrary\.ConsolePlus') | Provides the global entry point for all console services\. |
| [ConsolePlusExtends](ConsolePlusExtends.md 'ConsolePlusLibrary\.ConsolePlusExtends') | Extension methods for ConsolePlus, providing additional functionality to the IConsole interface\. |
| [ConsoleSizeChangedEventArgs](ConsoleSizeChangedEventArgs.md 'ConsolePlusLibrary\.ConsoleSizeChangedEventArgs') | Represents a console size\-changed event\. |
| [CultureExtensions](CultureExtensions.md 'ConsolePlusLibrary\.CultureExtensions') | Provides extension methods for working with culture names\. |
| [EmacsConsoleBuffer](EmacsConsoleBuffer.md 'ConsolePlusLibrary\.EmacsConsoleBuffer') | Represents a buffer for console input that supports Emacs\-style keyboard shortcuts and editing capabilities\. |
| [EmojiActivities](EmojiActivities.md 'ConsolePlusLibrary\.EmojiActivities') | Strongly\-typed constants for the official Unicode emoji group "Activities"\. This mirrors the group\-qualified shortcode form \(for example `:activities/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiAnimalsAndNature](EmojiAnimalsAndNature.md 'ConsolePlusLibrary\.EmojiAnimalsAndNature') | Strongly\-typed constants for the official Unicode emoji group "AnimalsAndNature"\. This mirrors the group\-qualified shortcode form \(for example `:animalsandnature/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiComponent](EmojiComponent.md 'ConsolePlusLibrary\.EmojiComponent') | Strongly\-typed constants for the official Unicode emoji group "Component"\. This mirrors the group\-qualified shortcode form \(for example `:component/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiFlags](EmojiFlags.md 'ConsolePlusLibrary\.EmojiFlags') | Strongly\-typed constants for the official Unicode emoji group "Flags"\. This mirrors the group\-qualified shortcode form \(for example `:flags/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiFoodAndDrink](EmojiFoodAndDrink.md 'ConsolePlusLibrary\.EmojiFoodAndDrink') | Strongly\-typed constants for the official Unicode emoji group "FoodAndDrink"\. This mirrors the group\-qualified shortcode form \(for example `:foodanddrink/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiObjects](EmojiObjects.md 'ConsolePlusLibrary\.EmojiObjects') | Strongly\-typed constants for the official Unicode emoji group "Objects"\. This mirrors the group\-qualified shortcode form \(for example `:objects/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiPeopleAndBody](EmojiPeopleAndBody.md 'ConsolePlusLibrary\.EmojiPeopleAndBody') | Strongly\-typed constants for the official Unicode emoji group "PeopleAndBody"\. This mirrors the group\-qualified shortcode form \(for example `:peopleandbody/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiSmileysAndEmotion](EmojiSmileysAndEmotion.md 'ConsolePlusLibrary\.EmojiSmileysAndEmotion') | Strongly\-typed constants for the official Unicode emoji group "SmileysAndEmotion"\. This mirrors the group\-qualified shortcode form \(for example `:smileysandemotion/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiSymbols](EmojiSymbols.md 'ConsolePlusLibrary\.EmojiSymbols') | Strongly\-typed constants for the official Unicode emoji group "Symbols"\. This mirrors the group\-qualified shortcode form \(for example `:symbols/name:`\) with compile\-time safety and IntelliSense\. |
| [EmojiTravelAndPlaces](EmojiTravelAndPlaces.md 'ConsolePlusLibrary\.EmojiTravelAndPlaces') | Strongly\-typed constants for the official Unicode emoji group "TravelAndPlaces"\. This mirrors the group\-qualified shortcode form \(for example `:travelandplaces/name:`\) with compile\-time safety and IntelliSense\. |
| [Markup](Markup.md 'ConsolePlusLibrary\.Markup') | Provides functionality for working with markup text\. |
| [StringExtensions](StringExtensions.md 'ConsolePlusLibrary\.StringExtensions') | Provides extension methods for strings\. |
| [StyleExtensions](StyleExtensions.md 'ConsolePlusLibrary\.StyleExtensions') | Provides extension methods for creating modified [Style](Style.md 'ConsolePlusLibrary\.Style') instances by selectively changing foreground, background, or overflow strategy\. |

| Structs | |
| :--- | :--- |
| [Color](Color.md 'ConsolePlusLibrary\.Color') | Represents a color\. |
| [EmojiValue](EmojiValue.md 'ConsolePlusLibrary\.EmojiValue') | Wrapper type that enables implicit conversion from [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName') to the real emoji string via `EmojiName` resolution\. |
| [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') | Represents a rendered text fragment with optional style and semantic kind\. |
| [Style](Style.md 'ConsolePlusLibrary\.Style') | Represents a text rendering style consisting of a foreground color, background color and an overflow strategy\. |

| Interfaces | |
| :--- | :--- |
| [IAnsiCommands](IAnsiCommands.md 'ConsolePlusLibrary\.IAnsiCommands') | Provides methods for emitting ANSI escape codes to control the console output\. |
| [IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner') | Represents a banner that can be customized and displayed\. |
| [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole') | Interface for abstracting console operations\. |
| [IProfileReadOnly](IProfileReadOnly.md 'ConsolePlusLibrary\.IProfileReadOnly') | Defines a console profile describing capabilities, dimensions, colors and display behavior for the current console/terminal session\. |
| [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') | Interface for configuring console profiles, allowing for the setup of various console settings such as encoding, color, and interaction capabilities\. |
| [IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash') | Represents a banner that can be customized and displayed\. |
| [IWidgets](IWidgets.md 'ConsolePlusLibrary\.IWidgets') | Represents a collection of widgets that can be used in the console application\. |

| Enums | |
| :--- | :--- |
| [AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect') | Defines the ANSI escape sequence support detection mode for a console profile\. |
| [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions') | Contains options for transforming input characters\. |
| [ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem') | Represents the capacity of console color system\. |
| [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions') | Represents border options when writing a banner\. |
| [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName') | Strongly typed identifiers for all emoji constants in [ConsolePlusLibrary\.Emoji](https://learn.microsoft.com/en-us/dotnet/api/consolepluslibrary.emoji 'ConsolePlusLibrary\.Emoji')\. |
| [FragmentKind](FragmentKind.md 'ConsolePlusLibrary\.FragmentKind') | Identifies the semantic category of a [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') during rendering\. |
| [Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow') | Specifies how text overflow should be handled\. |
| [TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen') | Represents the Target Buffer |
