<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## ConsolePlus Class

Provides the global entry point for all console services\.

```csharp
public static class ConsolePlus
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ConsolePlus

### Remarks
The static initialization sequence detects terminal capabilities \(ANSI, Unicode, color depth, legacy mode\),
captures the original console state \(culture, encoding, colors\) and prepares an internal profile\.
Resources are restored automatically on process exit\.
### Properties

<a name='ConsolePlusLibrary.ConsolePlus.Ansi'></a>

## ConsolePlus\.Ansi Property

Gets the ANSI command emitter \([IAnsiCommands](IAnsiCommands.md 'ConsolePlusLibrary\.IAnsiCommands')\) for this console, allowing for emitting ANSI escape sequences to control the console output\.

```csharp
public static ConsolePlusLibrary.IAnsiCommands Ansi { get; }
```

#### Property Value
[IAnsiCommands](IAnsiCommands.md 'ConsolePlusLibrary\.IAnsiCommands')

<a name='ConsolePlusLibrary.ConsolePlus.BackgroundColor'></a>

## ConsolePlus\.BackgroundColor Property

Gets or sets the background color \([System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')\) of the console\.

```csharp
public static System.ConsoleColor BackgroundColor { get; set; }
```

#### Property Value
[System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')

<a name='ConsolePlusLibrary.ConsolePlus.BackgroundRgbColor'></a>

## ConsolePlus\.BackgroundRgbColor Property

Gets or sets the background color \([Color](Color.md 'ConsolePlusLibrary\.Color')\) of the console using RGB values\.

```csharp
public static ConsolePlusLibrary.Color BackgroundRgbColor { get; set; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')

<a name='ConsolePlusLibrary.ConsolePlus.ColorDepth'></a>

## ConsolePlus\.ColorDepth Property

Gets the color depth \([ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')\) of the console, indicating the number of colors supported\.

```csharp
public static ConsolePlusLibrary.ColorSystem ColorDepth { get; }
```

#### Property Value
[ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')

<a name='ConsolePlusLibrary.ConsolePlus.CurrentBuffer'></a>

## ConsolePlus\.CurrentBuffer Property

Gets the current target buffer \([TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')\), primary or secondary of the console\.

```csharp
public static ConsolePlusLibrary.TargetScreen CurrentBuffer { get; }
```

#### Property Value
[TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')

<a name='ConsolePlusLibrary.ConsolePlus.CurrentStyle'></a>

## ConsolePlus\.CurrentStyle Property

Gets the current console [Style](Style.md 'ConsolePlusLibrary\.Style'), reflecting the active foreground and background colors\.

```csharp
public static ConsolePlusLibrary.Style CurrentStyle { get; }
```

#### Property Value
[Style](Style.md 'ConsolePlusLibrary\.Style')

<a name='ConsolePlusLibrary.ConsolePlus.CursorLeft'></a>

## ConsolePlus\.CursorLeft Property

Gets or sets the column position of the cursor\.

```csharp
public static int CursorLeft { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.ConsolePlus.CursorTop'></a>

## ConsolePlus\.CursorTop Property

Gets or sets the row position of the cursor\.

```csharp
public static int CursorTop { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.ConsolePlus.CursorVisible'></a>

## ConsolePlus\.CursorVisible Property

Gets or sets a value indicating whether the cursor is visible\.

```csharp
public static bool CursorVisible { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.Driver'></a>

## ConsolePlus\.Driver Property

Gets the underlying [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole') driver instance backing the static console facade\.

```csharp
public static ConsolePlusLibrary.IConsole Driver { get; }
```

#### Property Value
[IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

<a name='ConsolePlusLibrary.ConsolePlus.EnabledEmacs'></a>

## ConsolePlus\.EnabledEmacs Property

Enables/Disable Emacs\-style key bindings in the console, allowing for standard Emacs key combinations to be used for text editing and navigation\.

```csharp
public static bool EnabledEmacs { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.Error'></a>

## ConsolePlus\.Error Property

Gets [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter') used for error output operations\.

```csharp
public static System.IO.TextWriter Error { get; }
```

#### Property Value
[System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

<a name='ConsolePlusLibrary.ConsolePlus.ForegroundColor'></a>

## ConsolePlus\.ForegroundColor Property

Gets or sets the foreground color \([System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')\) of the console\.

```csharp
public static System.ConsoleColor ForegroundColor { get; set; }
```

#### Property Value
[System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')

<a name='ConsolePlusLibrary.ConsolePlus.ForegroundRgbColor'></a>

## ConsolePlus\.ForegroundRgbColor Property

Gets or sets the foreground color \([Color](Color.md 'ConsolePlusLibrary\.Color')\) of the console using RGB values\.

```csharp
public static ConsolePlusLibrary.Color ForegroundRgbColor { get; set; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')

<a name='ConsolePlusLibrary.ConsolePlus.Height'></a>

## ConsolePlus\.Height Property

Gets the current height of the console window\.

```csharp
public static int Height { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.ConsolePlus.In'></a>

## ConsolePlus\.In Property

Gets [System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader') used for input operations\.

```csharp
public static System.IO.TextReader In { get; }
```

#### Property Value
[System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader')

<a name='ConsolePlusLibrary.ConsolePlus.InputEncoding'></a>

## ConsolePlus\.InputEncoding Property

Gets or sets the [System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding') used for input operations\.

```csharp
public static System.Text.Encoding InputEncoding { get; set; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.ConsolePlus.IsErrorRedirected'></a>

## ConsolePlus\.IsErrorRedirected Property

Gets a value indicating whether error output is redirected to a file\.

```csharp
public static bool IsErrorRedirected { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.IsInputRedirected'></a>

## ConsolePlus\.IsInputRedirected Property

Gets a value indicating whether input is redirected from a file\.

```csharp
public static bool IsInputRedirected { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.IsOutputRedirected'></a>

## ConsolePlus\.IsOutputRedirected Property

Gets a value indicating whether output is redirected to a file\.

```csharp
public static bool IsOutputRedirected { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.KeyAvailable'></a>

## ConsolePlus\.KeyAvailable Property

Gets a value indicating whether a key press is available in the input stream\.

```csharp
public static bool KeyAvailable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.Out'></a>

## ConsolePlus\.Out Property

Gets [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter') used for output operations\.

```csharp
public static System.IO.TextWriter Out { get; }
```

#### Property Value
[System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

<a name='ConsolePlusLibrary.ConsolePlus.OutputEncoding'></a>

## ConsolePlus\.OutputEncoding Property

Gets [System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding') used for output operations\.

```csharp
public static System.Text.Encoding OutputEncoding { get; set; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.ConsolePlus.Profile'></a>

## ConsolePlus\.Profile Property

Gets the console profile describing \([IProfileReadOnly](IProfileReadOnly.md 'ConsolePlusLibrary\.IProfileReadOnly')\) the capabilities and configuration of the current console/terminal environment\.

```csharp
public static ConsolePlusLibrary.IProfileReadOnly Profile { get; }
```

#### Property Value
[IProfileReadOnly](IProfileReadOnly.md 'ConsolePlusLibrary\.IProfileReadOnly')

<a name='ConsolePlusLibrary.ConsolePlus.SupportsAnsi'></a>

## ConsolePlus\.SupportsAnsi Property

Gets a value indicating whether the console supports ANSI escape sequences\.

```csharp
public static bool SupportsAnsi { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.SupportsUnicode'></a>

## ConsolePlus\.SupportsUnicode Property

Gets a value indicating whether the console supports Unicode characters\.

```csharp
public static bool SupportsUnicode { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.Width'></a>

## ConsolePlus\.Width Property

Gets the current width of the console window\.

```csharp
public static int Width { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')
### Methods

<a name='ConsolePlusLibrary.ConsolePlus.ActionBeforeExit(System.Action_ConsolePlusLibrary.IConsole,System.Exception,bool_)'></a>

## ConsolePlus\.ActionBeforeExit\(Action\<IConsole,Exception,bool\>\) Method

Registers a callback action to be invoked before the console exits, allowing for custom cleanup or final output\. 
The action receives the current console instance and a boolean indicating if Ctrl\+C was pressed as parameters\.

```csharp
public static void ActionBeforeExit(System.Action<ConsolePlusLibrary.IConsole,System.Exception?,bool> action);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ActionBeforeExit(System.Action_ConsolePlusLibrary.IConsole,System.Exception,bool_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')

The action to be invoked before the console exits\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions)'></a>

## ConsolePlus\.Banner\(string, string, Nullable\<Style\>, DashOptions\) Method

Displays a banner using the specified Figlet font, with optional dashed borders and style\.

```csharp
public static void Banner(string? text, string pathfontFiglet, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.None);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).pathfontFiglet'></a>

`pathfontFiglet` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to the Figlet font file\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The dash options to apply\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when the path to the Figlet font is null or empty\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions)'></a>

## ConsolePlus\.Banner\(string, Stream, Nullable\<Style\>, DashOptions\) Method

Displays a banner using the specified Figlet font, with optional dashed borders and style\.

```csharp
public static void Banner(string? text, System.IO.Stream streamFontFiglet, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.None);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).streamFontFiglet'></a>

`streamFontFiglet` [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream')

The stream to the Figlet font\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The dash options to apply\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when the stream to the Figlet font is null\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions)'></a>

## ConsolePlus\.Banner\(string, Nullable\<Style\>, DashOptions\) Method

Displays a banner with optional dashed borders and style\.

```csharp
public static void Banner(string? text, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.None);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply\.

<a name='ConsolePlusLibrary.ConsolePlus.Banner(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The dash options to apply\.

<a name='ConsolePlusLibrary.ConsolePlus.Beep()'></a>

## ConsolePlus\.Beep\(\) Method

Beeps the console speaker\.

```csharp
public static void Beep();
```

<a name='ConsolePlusLibrary.ConsolePlus.Clear(System.Nullable_ConsolePlusLibrary.Color_)'></a>

## ConsolePlus\.Clear\(Nullable\<Color\>\) Method

Clears the console buffer with [Color](Color.md 'ConsolePlusLibrary\.Color') and set BackgroundColor with [Color](Color.md 'ConsolePlusLibrary\.Color')

```csharp
public static void Clear(System.Nullable<ConsolePlusLibrary.Color> backcolor=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Clear(System.Nullable_ConsolePlusLibrary.Color_).backcolor'></a>

`backcolor` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Color](Color.md 'ConsolePlusLibrary\.Color')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The [Color](Color.md 'ConsolePlusLibrary\.Color') Background

<a name='ConsolePlusLibrary.ConsolePlus.ClearLine(System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## ConsolePlus\.ClearLine\(Nullable\<int\>, Nullable\<Style\>\) Method

Clear line

```csharp
public static void ClearLine(System.Nullable<int> row=null, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ClearLine(System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_).row'></a>

`row` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The row to clear

<a name='ConsolePlusLibrary.ConsolePlus.ClearLine(System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Optional [Style](Style.md 'ConsolePlusLibrary\.Style') overriding current output style\.

<a name='ConsolePlusLibrary.ConsolePlus.Dash(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions,int,bool)'></a>

## ConsolePlus\.Dash\(string, Nullable\<Style\>, DashOptions, int, bool\) Method

Displays a dashed line with optional style above and/or below the text\.

```csharp
public static void Dash(string? text, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.SingleBorder, int extralines=0, bool applycolorbackground=false);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Dash(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions,int,bool).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display\.

<a name='ConsolePlusLibrary.ConsolePlus.Dash(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions,int,bool).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply\.

<a name='ConsolePlusLibrary.ConsolePlus.Dash(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions,int,bool).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The dash options to apply\.

<a name='ConsolePlusLibrary.ConsolePlus.Dash(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions,int,bool).extralines'></a>

`extralines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Extra blank lines appended after the dash line \(default: 0\)\.

<a name='ConsolePlusLibrary.ConsolePlus.Dash(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions,int,bool).applycolorbackground'></a>

`applycolorbackground` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, applies background color across the full line \(default: `false`\)\.

<a name='ConsolePlusLibrary.ConsolePlus.GetCursorPosition()'></a>

## ConsolePlus\.GetCursorPosition\(\) Method

Gets the current position of the cursor as a tuple containing the left and top coordinates\.

```csharp
public static (int Left,int Top) GetCursorPosition();
```

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple with the left and top coordinates of the cursor\.

<a name='ConsolePlusLibrary.ConsolePlus.HideCursor()'></a>

## ConsolePlus\.HideCursor\(\) Method

Hides the cursor\.

```csharp
public static bool HideCursor();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.OutputError()'></a>

## ConsolePlus\.OutputError\(\) Method

Create context to write on standard error output stream for any output included until the 'dispose' is done\.

```csharp
public static System.IDisposable OutputError();
```

#### Returns
[System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')  
An [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') context that redirects output to the standard error stream when disposed\.

<a name='ConsolePlusLibrary.ConsolePlus.Read()'></a>

## ConsolePlus\.Read\(\) Method

Reads the next character from the console\.

```csharp
public static int Read();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The next character read from the console, or \-1 if no input is available\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## ConsolePlus\.ReadInlineEmacs\(Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>\) Method

Reads input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns input entered by the user as a string after the Enter key is pressed\.

```csharp
public static string ReadInlineEmacs(System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The line of input entered by the user as a string\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken)'></a>

## ConsolePlus\.ReadInlineEmacsAsync\(Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>, CancellationToken\) Method

Reads input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns the input entered by the user as a string after the Enter key is pressed\.

```csharp
public static System.Threading.Tasks.Task<string?> ReadInlineEmacsAsync(System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadInlineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The line of input entered by the user as a string\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadKey(bool)'></a>

## ConsolePlus\.ReadKey\(bool\) Method

Reads the next key press \([System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')\) from the console, optionally intercepting it so that it is not displayed on the console\.

```csharp
public static System.ConsoleKeyInfo ReadKey(bool intercept=false);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ReadKey(bool).intercept'></a>

`intercept` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, the key press is not displayed on the console\.

#### Returns
[System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')  
The key press information\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadKeyAsync(bool,System.Threading.CancellationToken)'></a>

## ConsolePlus\.ReadKeyAsync\(bool, CancellationToken\) Method

Reads the next key press \([System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')\) from the console, optionally intercepting it so that it is not displayed on the console\.

```csharp
public static System.Threading.Tasks.Task<System.Nullable<System.ConsoleKeyInfo>> ReadKeyAsync(bool intercept, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ReadKeyAsync(bool,System.Threading.CancellationToken).intercept'></a>

`intercept` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, the key press is not displayed on the console\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadKeyAsync(bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The key press information\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLine()'></a>

## ConsolePlus\.ReadLine\(\) Method

Reads a line of characters from the console\.

```csharp
public static string? ReadLine();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The line of characters read from the console, or null if no input is available\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## ConsolePlus\.ReadLineEmacs\(Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>\) Method

Reads a line of input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns the line of input entered by the user as a string after the Enter key is pressed\.

```csharp
public static string ReadLineEmacs(System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacs(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The line of input entered by the user as a string\.

### Remarks
the new line is not included in the result, but it is included in the console output\. 
If you want to read a line of input without including the new line in the console output, you can use the ReadInlineEmacs method instead\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken)'></a>

## ConsolePlus\.ReadLineEmacsAsync\(Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>, CancellationToken\) Method

Reads a line of input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns the line of input entered by the user as a string after the Enter key is pressed\.

```csharp
public static System.Threading.Tasks.Task<string?> ReadLineEmacsAsync(System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

<a name='ConsolePlusLibrary.ConsolePlus.ReadLineEmacsAsync(System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The line of input entered by the user as a string\.

### Remarks
the new line is not included in the result, but it is included in the console output\. 
If you want to read a line of input without including the new line in the console output, you can use the ReadInlineEmacs method instead\.

<a name='ConsolePlusLibrary.ConsolePlus.ResetColor()'></a>

## ConsolePlus\.ResetColor\(\) Method

Resets the console colors to default\.

```csharp
public static void ResetColor();
```

<a name='ConsolePlusLibrary.ConsolePlus.RunAtomic(System.Action)'></a>

## ConsolePlus\.RunAtomic\(Action\) Method

Runs the specified action inside the console's global synchronization scope, ensuring that
console output performed by the action is not interleaved with output from other threads\.

```csharp
public static void RunAtomic(System.Action action);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.RunAtomic(System.Action).action'></a>

`action` [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action')

The action to run atomically with respect to console output\.

<a name='ConsolePlusLibrary.ConsolePlus.SetCursorPosition(int,int)'></a>

## ConsolePlus\.SetCursorPosition\(int, int\) Method

Sets the position of the cursor\.

```csharp
public static void SetCursorPosition(int left, int top);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.SetCursorPosition(int,int).left'></a>

`left` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The column position of the cursor\.

<a name='ConsolePlusLibrary.ConsolePlus.SetCursorPosition(int,int).top'></a>

`top` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The row position of the cursor\.

<a name='ConsolePlusLibrary.ConsolePlus.SetError(System.IO.TextWriter)'></a>

## ConsolePlus\.SetError\(TextWriter\) Method

Sets the error output to the specified TextWriter\.

```csharp
public static void SetError(System.IO.TextWriter value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.SetError(System.IO.TextWriter).value'></a>

`value` [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

The TextWriter to set as the error output\.

<a name='ConsolePlusLibrary.ConsolePlus.SetIn(System.IO.TextReader)'></a>

## ConsolePlus\.SetIn\(TextReader\) Method

Sets the input source to the specified [System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader')\.

```csharp
public static void SetIn(System.IO.TextReader value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.SetIn(System.IO.TextReader).value'></a>

`value` [System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader')

The [System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader') to set as the input source\.

<a name='ConsolePlusLibrary.ConsolePlus.SetOut(System.IO.TextWriter)'></a>

## ConsolePlus\.SetOut\(TextWriter\) Method

Sets the output destination to the specified [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')\.

```csharp
public static void SetOut(System.IO.TextWriter value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.SetOut(System.IO.TextWriter).value'></a>

`value` [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

The [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter') to set as the output destination\.

<a name='ConsolePlusLibrary.ConsolePlus.ShowCursor()'></a>

## ConsolePlus\.ShowCursor\(\) Method

Shows the cursor\.

```csharp
public static bool ShowCursor();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.ConsolePlus.StyleBackground(ConsolePlusLibrary.Color)'></a>

## ConsolePlus\.StyleBackground\(Color\) Method

Creates a new [Style](Style.md 'ConsolePlusLibrary\.Style') instance with the specified background color and the current foreground color\.

```csharp
public static ConsolePlusLibrary.Style StyleBackground(ConsolePlusLibrary.Color value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.StyleBackground(ConsolePlusLibrary.Color).value'></a>

`value` [Color](Color.md 'ConsolePlusLibrary\.Color')

The background color \([Color](Color.md 'ConsolePlusLibrary\.Color')\) to apply\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') instance with the specified background color and the current foreground color\.

<a name='ConsolePlusLibrary.ConsolePlus.StyleForeground(ConsolePlusLibrary.Color)'></a>

## ConsolePlus\.StyleForeground\(Color\) Method

Creates a new [Style](Style.md 'ConsolePlusLibrary\.Style') instance with the specified foreground color and the current background color\.

```csharp
public static ConsolePlusLibrary.Style StyleForeground(ConsolePlusLibrary.Color value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.StyleForeground(ConsolePlusLibrary.Color).value'></a>

`value` [Color](Color.md 'ConsolePlusLibrary\.Color')

The foreground color \([Color](Color.md 'ConsolePlusLibrary\.Color')\) to apply\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') instance with the specified foreground color and the current background color\.

<a name='ConsolePlusLibrary.ConsolePlus.StyleInvert()'></a>

## ConsolePlus\.StyleInvert\(\) Method

Creates a new [Style](Style.md 'ConsolePlusLibrary\.Style') instance with the foreground and background colors inverted\.

```csharp
public static ConsolePlusLibrary.Style StyleInvert();
```

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') instance with the foreground and background colors inverted\.

<a name='ConsolePlusLibrary.ConsolePlus.SwapBuffer(ConsolePlusLibrary.TargetScreen)'></a>

## ConsolePlus\.SwapBuffer\(TargetScreen\) Method

Swaps the active console buffer to the specified target screen \([TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')\), primary or secondary\.

```csharp
public static bool SwapBuffer(ConsolePlusLibrary.TargetScreen value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.SwapBuffer(ConsolePlusLibrary.TargetScreen).value'></a>

`value` [TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')

The target screen \([TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')\) to switch to\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the buffer was successfully swapped; otherwise, false\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool)'></a>

## ConsolePlus\.Write\(bool\) Method

Writes a boolean to the console\.

```csharp
public static void Write(bool value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,bool)'></a>

## ConsolePlus\.Write\(bool, bool\) Method

Writes a boolean to the console\.

```csharp
public static void Write(bool value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(bool, Style\) Method

Writes a boolean to the console\.

```csharp
public static void Write(bool value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean  value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(bool, Style, bool\) Method

Writes a boolean to the console\.

```csharp
public static void Write(bool value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(bool,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char)'></a>

## ConsolePlus\.Write\(char\) Method

Writes a character to the console\.

```csharp
public static void Write(char value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,bool)'></a>

## ConsolePlus\.Write\(char, bool\) Method

Writes a character to the console\.

```csharp
public static void Write(char value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(char, Style\) Method

Writes a character to the console\.

```csharp
public static void Write(char value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(char, Style, bool\) Method

Writes a character to the console\.

```csharp
public static void Write(char value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[])'></a>

## ConsolePlus\.Write\(char\[\]\) Method

Writes a character array to the console\.

```csharp
public static void Write(char[]? value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[]).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],bool)'></a>

## ConsolePlus\.Write\(char\[\], bool\) Method

Writes a character array to the console\.

```csharp
public static void Write(char[]? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(char\[\], Style\) Method

Writes a character array to the console\.

```csharp
public static void Write(char[]? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(char\[\], Style, bool\) Method

Writes a character array to the console\.

```csharp
public static void Write(char[]? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(char[],ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal)'></a>

## ConsolePlus\.Write\(decimal\) Method

Writes a decimal to the console\.

```csharp
public static void Write(decimal value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,bool)'></a>

## ConsolePlus\.Write\(decimal, bool\) Method

Writes a decimal to the console\.

```csharp
public static void Write(decimal value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,bool).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal  value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(decimal, Style\) Method

Writes a decimal to the console\.

```csharp
public static void Write(decimal value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(decimal, Style, bool\) Method

Writes a decimal to the console\.

```csharp
public static void Write(decimal value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(decimal,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double)'></a>

## ConsolePlus\.Write\(double\) Method

Writes a double to the console\.

```csharp
public static void Write(double value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,bool)'></a>

## ConsolePlus\.Write\(double, bool\) Method

Writes a double to the console\.

```csharp
public static void Write(double value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(double, Style\) Method

Writes a double to the console\.

```csharp
public static void Write(double value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(double, Style, bool\) Method

Writes a double to the console\.

```csharp
public static void Write(double value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(double,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float)'></a>

## ConsolePlus\.Write\(float\) Method

Writes a float to the console\.

```csharp
public static void Write(float value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(float).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,bool)'></a>

## ConsolePlus\.Write\(float, bool\) Method

Writes a float to the console\.

```csharp
public static void Write(float value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(float, Style\) Method

Writes a float to the console\.

```csharp
public static void Write(float value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(float, Style, bool\) Method

Writes a float to the console\.

```csharp
public static void Write(float value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(float,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int)'></a>

## ConsolePlus\.Write\(int\) Method

Writes an integer to the console\.

```csharp
public static void Write(int value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(int).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,bool)'></a>

## ConsolePlus\.Write\(int, bool\) Method

Writes an integer to the console\.

```csharp
public static void Write(int value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(int, Style\) Method

Writes an integer to the console\.

```csharp
public static void Write(int value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(int, Style, bool\) Method

Writes an integer to the console\.

```csharp
public static void Write(int value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(int,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long)'></a>

## ConsolePlus\.Write\(long\) Method

Writes a long integer to the console\.

```csharp
public static void Write(long value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(long).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,bool)'></a>

## ConsolePlus\.Write\(long, bool\) Method

Writes a long integer to the console\.

```csharp
public static void Write(long value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(long, Style\) Method

Writes a long integer to the console\.

```csharp
public static void Write(long value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(long, Style, bool\) Method

Writes a long integer to the console\.

```csharp
public static void Write(long value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(long,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object)'></a>

## ConsolePlus\.Write\(object\) Method

Writes an object to the console\.

```csharp
public static void Write(object value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,bool)'></a>

## ConsolePlus\.Write\(object, bool\) Method

Writes an object to the console\.

```csharp
public static void Write(object value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(object, Style\) Method

Writes an object to the console\.

```csharp
public static void Write(object value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(object, Style, bool\) Method

Writes an object to the console\.

```csharp
public static void Write(object value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(object,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string)'></a>

## ConsolePlus\.Write\(string\) Method

Writes a string followed to the console\.

```csharp
public static void Write(string value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,bool)'></a>

## ConsolePlus\.Write\(string, bool\) Method

Writes a string followed to the console\.

```csharp
public static void Write(string value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.Write\(string, Style\) Method

Writes a string followed to the console\.

```csharp
public static void Write(string value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.Write\(string, Style, bool\) Method

Writes a string to the console\.

```csharp
public static void Write(string value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.Write(string,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,bool,object[])'></a>

## ConsolePlus\.WriteFormat\(string, bool, object\[\]\) Method

Writes a string followed to the console\.

```csharp
public static void WriteFormat(string format, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[])'></a>

## ConsolePlus\.WriteFormat\(string, Style, bool, object\[\]\) Method

Writes a string followed to the console\.

```csharp
public static void WriteFormat(string format, ConsolePlusLibrary.Style style, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,object[])'></a>

## ConsolePlus\.WriteFormat\(string, Style, object\[\]\) Method

Writes out a formatted string to the console\.  Uses the same semantics as string\.Format\.

```csharp
public static void WriteFormat(string format, ConsolePlusLibrary.Style style, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,ConsolePlusLibrary.Style,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,object[])'></a>

## ConsolePlus\.WriteFormat\(string, object\[\]\) Method

Writes out a formatted string to the console\.  Uses the same semantics as string\.Format\.

```csharp
public static void WriteFormat(string format, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteFormat(string,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine()'></a>

## ConsolePlus\.WriteLine\(\) Method

Writes a line terminator to the console\.

```csharp
public static void WriteLine();
```

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool)'></a>

## ConsolePlus\.WriteLine\(bool\) Method

Writes a boolean followed by a line terminator to the console\.

```csharp
public static void WriteLine(bool value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,bool)'></a>

## ConsolePlus\.WriteLine\(bool, bool\) Method

Writes a boolean followed by a line terminator to the console\.

```csharp
public static void WriteLine(bool value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(bool, Style\) Method

Writes a boolean followed by a line terminator to the console\.

```csharp
public static void WriteLine(bool value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean  value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(bool, Style, bool\) Method

Writes a boolean followed by a line terminator to the console\.

```csharp
public static void WriteLine(bool value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(bool,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char)'></a>

## ConsolePlus\.WriteLine\(char\) Method

Writes a character followed by a line terminator to the console\.

```csharp
public static void WriteLine(char value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,bool)'></a>

## ConsolePlus\.WriteLine\(char, bool\) Method

Writes a character followed by a line terminator to the console\.

```csharp
public static void WriteLine(char value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(char, Style\) Method

Writes a character followed by a line terminator to the console\.

```csharp
public static void WriteLine(char value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(char, Style, bool\) Method

Writes a character followed by a line terminator to the console\.

```csharp
public static void WriteLine(char value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[])'></a>

## ConsolePlus\.WriteLine\(char\[\]\) Method

Writes a character array followed by a line terminator to the console\.

```csharp
public static void WriteLine(char[]? value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[]).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],bool)'></a>

## ConsolePlus\.WriteLine\(char\[\], bool\) Method

Writes a character array followed by a line terminator to the console\.

```csharp
public static void WriteLine(char[]? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(char\[\], Style\) Method

Writes a character array followed by a line terminator to the console\.

```csharp
public static void WriteLine(char[]? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(char\[\], Style, bool\) Method

Writes a character array followed by a line terminator to the console\.

```csharp
public static void WriteLine(char[]? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The character array value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(char[],ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal)'></a>

## ConsolePlus\.WriteLine\(decimal\) Method

Writes a decimal followed by a line terminator to the console\.

```csharp
public static void WriteLine(decimal value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,bool)'></a>

## ConsolePlus\.WriteLine\(decimal, bool\) Method

Writes a decimal followed by a line terminator to the console\.

```csharp
public static void WriteLine(decimal value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,bool).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal  value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(decimal, Style\) Method

Writes a decimal followed by a line terminator to the console\.

```csharp
public static void WriteLine(decimal value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(decimal, Style, bool\) Method

Writes a decimal followed by a line terminator to the console\.

```csharp
public static void WriteLine(decimal value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(decimal,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double)'></a>

## ConsolePlus\.WriteLine\(double\) Method

Writes a double followed by a line terminator to the console\.

```csharp
public static void WriteLine(double value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,bool)'></a>

## ConsolePlus\.WriteLine\(double, bool\) Method

Writes a double followed by a line terminator to the console\.

```csharp
public static void WriteLine(double value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(double, Style\) Method

Writes a double followed by a line terminator to the console\.

```csharp
public static void WriteLine(double value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(double, Style, bool\) Method

Writes a double followed by a line terminator to the console\.

```csharp
public static void WriteLine(double value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(double,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float)'></a>

## ConsolePlus\.WriteLine\(float\) Method

Writes a float followed by a line terminator to the console\.

```csharp
public static void WriteLine(float value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,bool)'></a>

## ConsolePlus\.WriteLine\(float, bool\) Method

Writes a float followed by a line terminator to the console\.

```csharp
public static void WriteLine(float value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(float, Style\) Method

Writes a float followed by a line terminator to the console\.

```csharp
public static void WriteLine(float value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(float, Style, bool\) Method

Writes a float followed by a line terminator to the console\.

```csharp
public static void WriteLine(float value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(float,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int)'></a>

## ConsolePlus\.WriteLine\(int\) Method

Writes an integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(int value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,bool)'></a>

## ConsolePlus\.WriteLine\(int, bool\) Method

Writes an integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(int value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(int, Style\) Method

Writes an integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(int value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(int, Style, bool\) Method

Writes an integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(int value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(int,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long)'></a>

## ConsolePlus\.WriteLine\(long\) Method

Writes a long integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(long value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,bool)'></a>

## ConsolePlus\.WriteLine\(long, bool\) Method

Writes a long integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(long value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(long, Style\) Method

Writes a long integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(long value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(long, Style, bool\) Method

Writes a long integer followed by a line terminator to the console\.

```csharp
public static void WriteLine(long value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(long,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object)'></a>

## ConsolePlus\.WriteLine\(object\) Method

Writes an object followed by a line terminator to the console\.

```csharp
public static void WriteLine(object value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,bool)'></a>

## ConsolePlus\.WriteLine\(object, bool\) Method

Writes an object followed by a line terminator to the console\.

```csharp
public static void WriteLine(object value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(object, Style\) Method

Writes an object followed by a line terminator to the console\.

```csharp
public static void WriteLine(object value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(object, Style, bool\) Method

Writes an object followed by a line terminator to the console\.

```csharp
public static void WriteLine(object value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(object,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string)'></a>

## ConsolePlus\.WriteLine\(string\) Method

Writes a string followed by a line terminator to the console\.

```csharp
public static void WriteLine(string value);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,bool)'></a>

## ConsolePlus\.WriteLine\(string, bool\) Method

Writes a string followed by a line terminator with optional style and line clearing to the console\.

```csharp
public static void WriteLine(string value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style)'></a>

## ConsolePlus\.WriteLine\(string, Style\) Method

Writes a string followed by a line terminator to the console\.

```csharp
public static void WriteLine(string value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style,bool)'></a>

## ConsolePlus\.WriteLine\(string, Style, bool\) Method

Writes a string followed by a line terminator to the console\.

```csharp
public static void WriteLine(string value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string value to write\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLine(string,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,bool,object[])'></a>

## ConsolePlus\.WriteLineFormat\(string, bool, object\[\]\) Method

Writes a string followed by a line terminator with optional style and line clearing to the console\.

```csharp
public static void WriteLineFormat(string format, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[])'></a>

## ConsolePlus\.WriteLineFormat\(string, Style, bool, object\[\]\) Method

Writes a string followed by a line terminator with optional style and line clearing to the console\.

```csharp
public static void WriteLineFormat(string format, ConsolePlusLibrary.Style style, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, clears the rest of the line after writing\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,object[])'></a>

## ConsolePlus\.WriteLineFormat\(string, Style, object\[\]\) Method

Writes out a formatted string and a new line\.  Uses the same semantics as string\.Format\.

```csharp
public static void WriteLineFormat(string format, ConsolePlusLibrary.Style style, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the output\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,ConsolePlusLibrary.Style,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,object[])'></a>

## ConsolePlus\.WriteLineFormat\(string, object\[\]\) Method

Writes out a formatted string and a new line\.  Uses the same semantics as string\.Format\.

```csharp
public static void WriteLineFormat(string format, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A composite format string\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLineFormat(string,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.ConsolePlus.WriteLines(int)'></a>

## ConsolePlus\.WriteLines\(int\) Method

Write lines with line terminator

```csharp
public static void WriteLines(int steps=1);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlus.WriteLines(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Numbers de lines\.

| Events | |
| :--- | :--- |
| [SizeChanged](ConsolePlus.SizeChanged.md 'ConsolePlusLibrary\.ConsolePlus\.SizeChanged') | Event raised when the console size changes \([ConsoleSizeChangedEventArgs](ConsoleSizeChangedEventArgs.md 'ConsolePlusLibrary\.ConsoleSizeChangedEventArgs')\)\. |
