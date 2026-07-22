<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IProfileReadOnly Interface

Defines a console profile describing capabilities, dimensions, colors and display behavior
for the current console/terminal session\.

```csharp
public interface IProfileReadOnly
```

### Remarks
An implementation should provide immutable \(snapshot\) values representing the environment
at the time it was created\. These values can be used to adapt rendering \(color depth,
ANSI/Unicode support, margins, buffer size and overflow strategy\)\.
### Properties

<a name='ConsolePlusLibrary.IProfileReadOnly.ColorDepth'></a>

## IProfileReadOnly\.ColorDepth Property

Gets the color depth \([ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')\) of the console\.

```csharp
ConsolePlusLibrary.ColorSystem ColorDepth { get; }
```

#### Property Value
[ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')

<a name='ConsolePlusLibrary.IProfileReadOnly.DefaultBackgroundColor'></a>

## IProfileReadOnly\.DefaultBackgroundColor Property

Gets the default background [Color](Color.md 'ConsolePlusLibrary\.Color') used when no explicit color is specified\.

```csharp
ConsolePlusLibrary.Color DefaultBackgroundColor { get; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')  
The default background color\.

<a name='ConsolePlusLibrary.IProfileReadOnly.DefaultForegroundColor'></a>

## IProfileReadOnly\.DefaultForegroundColor Property

Gets the default foreground [Color](Color.md 'ConsolePlusLibrary\.Color') used when no explicit color is specified\.

```csharp
ConsolePlusLibrary.Color DefaultForegroundColor { get; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')  
The default foreground color\.

<a name='ConsolePlusLibrary.IProfileReadOnly.DefaultInputEncoding'></a>

## IProfileReadOnly\.DefaultInputEncoding Property

Gets the default input encoding \([System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')\) of the console at the time the profile was created\.

```csharp
System.Text.Encoding DefaultInputEncoding { get; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.IProfileReadOnly.DefaultOutputEncoding'></a>

## IProfileReadOnly\.DefaultOutputEncoding Property

Gets the default output encoding \([System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')\) of the console at the time the profile was created\.

```csharp
System.Text.Encoding DefaultOutputEncoding { get; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.IProfileReadOnly.DetectedAnsiSupport'></a>

## IProfileReadOnly\.DetectedAnsiSupport Property

Gets a value indicating whether ANSI escape sequences are detected as supported in the current environment\.

```csharp
bool DetectedAnsiSupport { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IProfileReadOnly.DetectedUnicodeSupport'></a>

## IProfileReadOnly\.DetectedUnicodeSupport Property

Gets a value indicating whether Unicode output is detected as supported in the current environment\.

```csharp
bool DetectedUnicodeSupport { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IProfileReadOnly.Interactive'></a>

## IProfileReadOnly\.Interactive Property

Gets a value indicating whether or not the console supports interaction\.

```csharp
bool Interactive { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IProfileReadOnly.IsTerminal'></a>

## IProfileReadOnly\.IsTerminal Property

Gets a value indicating whether the output device is a terminal \(TTY\)\.

```csharp
bool IsTerminal { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if running on an interactive terminal; otherwise `false`\.

<a name='ConsolePlusLibrary.IProfileReadOnly.OriginalCulture'></a>

## IProfileReadOnly\.OriginalCulture Property

Gets the original culture of the console at the time the profile was created\.

```csharp
string OriginalCulture { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='ConsolePlusLibrary.IProfileReadOnly.OriginalInputEncoding'></a>

## IProfileReadOnly\.OriginalInputEncoding Property

Gets the original input encoding \([System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')\) of the console at the time the profile was created\.

```csharp
System.Text.Encoding OriginalInputEncoding { get; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.IProfileReadOnly.OriginalOutputEncoding'></a>

## IProfileReadOnly\.OriginalOutputEncoding Property

Gets the original output encoding \([System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')\) of the console at the time the profile was created\.

```csharp
System.Text.Encoding OriginalOutputEncoding { get; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.IProfileReadOnly.ProfileName'></a>

## IProfileReadOnly\.ProfileName Property

Gets the profile name \(e\.g\. an identifier for the terminal type or configuration\)\.

```csharp
string ProfileName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The logical name of this profile\.

<a name='ConsolePlusLibrary.IProfileReadOnly.SupportsAnsi'></a>

## IProfileReadOnly\.SupportsAnsi Property

Gets a value \([AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect')\) indicating whether ANSI escape sequences are supported for styling/output\.

```csharp
ConsolePlusLibrary.AutoDetect SupportsAnsi { get; }
```

#### Property Value
[AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect')  
The level of ANSI escape sequence support\.

<a name='ConsolePlusLibrary.IProfileReadOnly.SupportUnicode'></a>

## IProfileReadOnly\.SupportUnicode Property

Gets a value \([AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect')\) indicating whether Unicode output is fully supported\.

```csharp
ConsolePlusLibrary.AutoDetect SupportUnicode { get; }
```

#### Property Value
[AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect')  
`true` if Unicode is supported; otherwise `false`\.