<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IConsole Interface

Interface for abstracting console operations\.

```csharp
public interface IConsole
```
### Properties

<a name='ConsolePlusLibrary.IConsole.Ansi'></a>

## IConsole\.Ansi Property

Gets the ANSI command emitter \([IAnsiCommands](IAnsiCommands.md 'ConsolePlusLibrary\.IAnsiCommands')\) for this console, allowing for emitting ANSI escape sequences to control the console output\.

```csharp
ConsolePlusLibrary.IAnsiCommands Ansi { get; }
```

#### Property Value
[IAnsiCommands](IAnsiCommands.md 'ConsolePlusLibrary\.IAnsiCommands')

<a name='ConsolePlusLibrary.IConsole.BackgroundColor'></a>

## IConsole\.BackgroundColor Property

Gets or sets the background color of the console\.

```csharp
System.ConsoleColor BackgroundColor { get; set; }
```

#### Property Value
[System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')

<a name='ConsolePlusLibrary.IConsole.BackgroundRgbColor'></a>

## IConsole\.BackgroundRgbColor Property

Gets or sets the background color of the console using RGB values\.

```csharp
ConsolePlusLibrary.Color BackgroundRgbColor { get; set; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')

<a name='ConsolePlusLibrary.IConsole.CancelToken'></a>

## IConsole\.CancelToken Property

Gets the cancellation token \([System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')\) that can be used to observe cancellation requests for console operations\.

```csharp
System.Threading.CancellationToken CancelToken { get; }
```

#### Property Value
[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

<a name='ConsolePlusLibrary.IConsole.ColorDepth'></a>

## IConsole\.ColorDepth Property

Gets the color depth \([ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')\) of the console, indicating the number of colors supported\.

```csharp
ConsolePlusLibrary.ColorSystem ColorDepth { get; }
```

#### Property Value
[ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')

<a name='ConsolePlusLibrary.IConsole.CurrentBuffer'></a>

## IConsole\.CurrentBuffer Property

Gets the current target buffer \([TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')\) : primary or secondary of the console\.

```csharp
ConsolePlusLibrary.TargetScreen CurrentBuffer { get; }
```

#### Property Value
[TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')

<a name='ConsolePlusLibrary.IConsole.CurrentStyle'></a>

## IConsole\.CurrentStyle Property

Gets the current style \([Style](Style.md 'ConsolePlusLibrary\.Style')\) of the console\.

```csharp
ConsolePlusLibrary.Style CurrentStyle { get; }
```

#### Property Value
[Style](Style.md 'ConsolePlusLibrary\.Style')

<a name='ConsolePlusLibrary.IConsole.CursorLeft'></a>

## IConsole\.CursorLeft Property

Gets or sets the column position of the cursor\.

```csharp
int CursorLeft { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.IConsole.CursorTop'></a>

## IConsole\.CursorTop Property

Gets or sets the row position of the cursor\.

```csharp
int CursorTop { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.IConsole.CursorVisible'></a>

## IConsole\.CursorVisible Property

Gets or sets a value indicating whether the cursor is visible\.

```csharp
bool CursorVisible { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.Error'></a>

## IConsole\.Error Property

Gets TextWriter \([System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')\) used for error output operations\.

```csharp
System.IO.TextWriter Error { get; }
```

#### Property Value
[System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

<a name='ConsolePlusLibrary.IConsole.ForegroundColor'></a>

## IConsole\.ForegroundColor Property

Gets or sets the foreground \([System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')\) color of the console\.

```csharp
System.ConsoleColor ForegroundColor { get; set; }
```

#### Property Value
[System\.ConsoleColor](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor 'System\.ConsoleColor')

<a name='ConsolePlusLibrary.IConsole.ForegroundRgbColor'></a>

## IConsole\.ForegroundRgbColor Property

Gets or sets the foreground color \([Color](Color.md 'ConsolePlusLibrary\.Color')\) of the console using RGB values\.

```csharp
ConsolePlusLibrary.Color ForegroundRgbColor { get; set; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')

<a name='ConsolePlusLibrary.IConsole.Height'></a>

## IConsole\.Height Property

Gets the current height of the console window\.

```csharp
int Height { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.IConsole.In'></a>

## IConsole\.In Property

Gets TextReader \([System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader')\) used for input operations\.

```csharp
System.IO.TextReader In { get; }
```

#### Property Value
[System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader')

<a name='ConsolePlusLibrary.IConsole.InputEncoding'></a>

## IConsole\.InputEncoding Property

Gets or sets the encoding \([System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')\) used for input operations\.

```csharp
System.Text.Encoding InputEncoding { get; set; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.IConsole.IsErrorRedirected'></a>

## IConsole\.IsErrorRedirected Property

Gets a value indicating whether error output is redirected to a file\.

```csharp
bool IsErrorRedirected { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.IsInputRedirected'></a>

## IConsole\.IsInputRedirected Property

Gets a value indicating whether input is redirected from a file\.

```csharp
bool IsInputRedirected { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.IsOutputRedirected'></a>

## IConsole\.IsOutputRedirected Property

Gets a value indicating whether output is redirected to a file\.

```csharp
bool IsOutputRedirected { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.KeyAvailable'></a>

## IConsole\.KeyAvailable Property

Gets a value indicating whether a key press is available in the input stream\.

```csharp
bool KeyAvailable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.Out'></a>

## IConsole\.Out Property

Gets TextWriter \([System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')\) used for output operations\.

```csharp
System.IO.TextWriter Out { get; }
```

#### Property Value
[System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

<a name='ConsolePlusLibrary.IConsole.OutputEncoding'></a>

## IConsole\.OutputEncoding Property

Gets encoding \([System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')\) used for output operations\.

```csharp
System.Text.Encoding OutputEncoding { get; set; }
```

#### Property Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

<a name='ConsolePlusLibrary.IConsole.Profile'></a>

## IConsole\.Profile Property

Gets the console profile \([IProfileReadOnly](IProfileReadOnly.md 'ConsolePlusLibrary\.IProfileReadOnly')\) describing the capabilities and configuration of the current console/terminal environment\.

```csharp
ConsolePlusLibrary.IProfileReadOnly Profile { get; }
```

#### Property Value
[IProfileReadOnly](IProfileReadOnly.md 'ConsolePlusLibrary\.IProfileReadOnly')

<a name='ConsolePlusLibrary.IConsole.SupportsAnsi'></a>

## IConsole\.SupportsAnsi Property

Gets a value indicating whether the console supports ANSI escape sequences\.

```csharp
bool SupportsAnsi { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.SupportsUnicode'></a>

## IConsole\.SupportsUnicode Property

Gets a value indicating whether the console supports Unicode characters\.

```csharp
bool SupportsUnicode { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='ConsolePlusLibrary.IConsole.Width'></a>

## IConsole\.Width Property

Gets the current width of the console window\.

```csharp
int Width { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')
### Methods

<a name='ConsolePlusLibrary.IConsole.Beep()'></a>

## IConsole\.Beep\(\) Method

Beeps the console speaker\.

```csharp
void Beep();
```

<a name='ConsolePlusLibrary.IConsole.Clear(System.Nullable_ConsolePlusLibrary.Color_)'></a>

## IConsole\.Clear\(Nullable\<Color\>\) Method

Clears the console buffer and corresponding console window of display information\.

```csharp
void Clear(System.Nullable<ConsolePlusLibrary.Color> backgroundcolor=null);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Clear(System.Nullable_ConsolePlusLibrary.Color_).backgroundcolor'></a>

`backgroundcolor` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Color](Color.md 'ConsolePlusLibrary\.Color')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The background color to use when clearing the console\.

<a name='ConsolePlusLibrary.IConsole.GetCursorPosition()'></a>

## IConsole\.GetCursorPosition\(\) Method

Gets the current position of the cursor as a tuple containing the left and top coordinates\.

```csharp
(int Left,int Top) GetCursorPosition();
```

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple containing the left and top coordinates of the cursor\.

<a name='ConsolePlusLibrary.IConsole.HideCursor()'></a>

## IConsole\.HideCursor\(\) Method

Hides the cursor\.

```csharp
bool HideCursor();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the cursor was successfully hidden; otherwise, false\.

<a name='ConsolePlusLibrary.IConsole.Read()'></a>

## IConsole\.Read\(\) Method

Reads the next character from the console\.

```csharp
int Read();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The next character read from the console, or \-1 if no input is available\.

<a name='ConsolePlusLibrary.IConsole.ReadKey(bool)'></a>

## IConsole\.ReadKey\(bool\) Method

Reads the next key press \([System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')\) from the console, optionally intercepting it so that it is not displayed on the console\.

```csharp
System.ConsoleKeyInfo ReadKey(bool intercept=false);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.ReadKey(bool).intercept'></a>

`intercept` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, the key press is not displayed on the console\.

#### Returns
[System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')  
The key press information\.

<a name='ConsolePlusLibrary.IConsole.ReadKeyAsync(bool,System.Threading.CancellationToken)'></a>

## IConsole\.ReadKeyAsync\(bool, CancellationToken\) Method

Asynchronously reads the next key press \([System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')\) from the console, optionally intercepting it so it is not displayed on the console\.

```csharp
System.Threading.Tasks.Task<System.Nullable<System.ConsoleKeyInfo>> ReadKeyAsync(bool intercept, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.ReadKeyAsync(bool,System.Threading.CancellationToken).intercept'></a>

`intercept` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, the key press is not displayed on the console\.

<a name='ConsolePlusLibrary.IConsole.ReadKeyAsync(bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The key press information\.

<a name='ConsolePlusLibrary.IConsole.ReadLine()'></a>

## IConsole\.ReadLine\(\) Method

Reads a line of characters from the console\.

```csharp
string? ReadLine();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The line of characters read from the console, or null if no input is available\.

<a name='ConsolePlusLibrary.IConsole.ResetColor()'></a>

## IConsole\.ResetColor\(\) Method

Resets the console colors to default\.

```csharp
void ResetColor();
```

<a name='ConsolePlusLibrary.IConsole.SetCursorPosition(int,int)'></a>

## IConsole\.SetCursorPosition\(int, int\) Method

Sets the position of the cursor\.

```csharp
void SetCursorPosition(int left, int top);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.SetCursorPosition(int,int).left'></a>

`left` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The column position of the cursor\.

<a name='ConsolePlusLibrary.IConsole.SetCursorPosition(int,int).top'></a>

`top` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The row position of the cursor\.

<a name='ConsolePlusLibrary.IConsole.SetError(System.IO.TextWriter)'></a>

## IConsole\.SetError\(TextWriter\) Method

Sets the error output to the specified TextWriter\.

```csharp
void SetError(System.IO.TextWriter value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.SetError(System.IO.TextWriter).value'></a>

`value` [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

The TextWriter to set as the error output\.

<a name='ConsolePlusLibrary.IConsole.SetIn(System.IO.TextReader)'></a>

## IConsole\.SetIn\(TextReader\) Method

Sets the input source to the specified TextReader\.

```csharp
void SetIn(System.IO.TextReader value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.SetIn(System.IO.TextReader).value'></a>

`value` [System\.IO\.TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader 'System\.IO\.TextReader')

The TextReader to set as the input source\.

<a name='ConsolePlusLibrary.IConsole.SetOut(System.IO.TextWriter)'></a>

## IConsole\.SetOut\(TextWriter\) Method

Sets the output destination to the specified TextWriter\.

```csharp
void SetOut(System.IO.TextWriter value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.SetOut(System.IO.TextWriter).value'></a>

`value` [System\.IO\.TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter 'System\.IO\.TextWriter')

The TextWriter to set as the output destination\.

<a name='ConsolePlusLibrary.IConsole.ShowCursor()'></a>

## IConsole\.ShowCursor\(\) Method

Shows the cursor\.

```csharp
bool ShowCursor();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the cursor was successfully shown; otherwise, false\.

<a name='ConsolePlusLibrary.IConsole.SwapBuffer(ConsolePlusLibrary.TargetScreen)'></a>

## IConsole\.SwapBuffer\(TargetScreen\) Method

Swaps the active console buffer to the specified target screen \(primary or secondary\)\.

```csharp
bool SwapBuffer(ConsolePlusLibrary.TargetScreen value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.SwapBuffer(ConsolePlusLibrary.TargetScreen).value'></a>

`value` [TargetScreen](TargetScreen.md 'ConsolePlusLibrary\.TargetScreen')

The target screen to switch to\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the buffer was successfully swapped; otherwise, false\.

<a name='ConsolePlusLibrary.IConsole.Write(bool)'></a>

## IConsole\.Write\(bool\) Method

Writes a boolean to the console\.

```csharp
void Write(bool value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,bool)'></a>

## IConsole\.Write\(bool, bool\) Method

Writes a boolean to the console and clears the rest of the line after writing\.

```csharp
void Write(bool value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(bool,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(bool, Style\) Method

Writes a boolean to the console with the specified style\.

```csharp
void Write(bool value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the boolean\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(bool, Style, bool\) Method

Writes a boolean to the console with the specified style and  clears the rest of the line after writing\.

```csharp
void Write(bool value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the boolean\.

<a name='ConsolePlusLibrary.IConsole.Write(bool,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(char)'></a>

## IConsole\.Write\(char\) Method

Writes a character to the console\.

```csharp
void Write(char value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char,bool)'></a>

## IConsole\.Write\(char, bool\) Method

Writes a character to the console and clears the rest of the line after writing\.

```csharp
void Write(char value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(char, Style\) Method

Writes a character to the console with the specified style\.

```csharp
void Write(char value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the character\.

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(char, Style, bool\) Method

Writes a character to the console with the specified style and clears the rest of the line after writing\.

```csharp
void Write(char value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the character\.

<a name='ConsolePlusLibrary.IConsole.Write(char,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(char[])'></a>

## IConsole\.Write\(char\[\]\) Method

Writes an array of characters to the console\.

```csharp
void Write(char[]? value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char[]).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],bool)'></a>

## IConsole\.Write\(char\[\], bool\) Method

Writes an array of characters to the console and  clears the rest of the line after writing\.

```csharp
void Write(char[]? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char[],bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(char\[\], Style\) Method

Writes an array of characters to the console with the specified style\.

```csharp
void Write(char[]? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the characters\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(char\[\], Style, bool\) Method

Writes an array of characters to the console with the specified style and clears the rest of the line after writing\.

```csharp
void Write(char[]? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the characters\.

<a name='ConsolePlusLibrary.IConsole.Write(char[],ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal)'></a>

## IConsole\.Write\(decimal\) Method

Writes a decimal to the console\.

```csharp
void Write(decimal value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(decimal).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal to write\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,bool)'></a>

## IConsole\.Write\(decimal, bool\) Method

Writes a decimal to the console and  clears the rest of the line after writing\.

```csharp
void Write(decimal value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(decimal,bool).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal to write\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(decimal, Style\) Method

Writes a decimal to the console with the specified style\.

```csharp
void Write(decimal value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal to write\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the decimal\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(decimal, Style, bool\) Method

Writes a decimal to the console with the specified style and  clears the rest of the line after writing\.

```csharp
void Write(decimal value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal 'System\.Decimal')

The decimal to write\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the decimal\.

<a name='ConsolePlusLibrary.IConsole.Write(decimal,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(double)'></a>

## IConsole\.Write\(double\) Method

Writes a double to the console\.

```csharp
void Write(double value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.Write(double,bool)'></a>

## IConsole\.Write\(double, bool\) Method

Writes a double to the console and optionally clears the rest of the line after writing\.

```csharp
void Write(double value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(double,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.Write(double,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(double, Style\) Method

Writes a double to the console with the specified style\.

```csharp
void Write(double value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the double\.

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(double, Style, bool\) Method

Writes a double to the console with the specified style and  clears the rest of the line after writing\.

```csharp
void Write(double value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the double\.

<a name='ConsolePlusLibrary.IConsole.Write(double,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(float)'></a>

## IConsole\.Write\(float\) Method

Writes a float to the console\.

```csharp
void Write(float value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(float).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.Write(float,bool)'></a>

## IConsole\.Write\(float, bool\) Method

Writes a float to the console and optionally clears the rest of the line after writing\.

```csharp
void Write(float value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(float,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.Write(float,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(float, Style\) Method

Writes a float to the console with the specified style\.

```csharp
void Write(float value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the float\.

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(float, Style, bool\) Method

Writes a float to the console with the specified style and clears the rest of the line after writing\.

```csharp
void Write(float value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the float\.

<a name='ConsolePlusLibrary.IConsole.Write(float,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(int)'></a>

## IConsole\.Write\(int\) Method

Writes an integer to the console\.

```csharp
void Write(int value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(int).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(int,bool)'></a>

## IConsole\.Write\(int, bool\) Method

Writes an integer to the console and optionally clears the rest of the line after writing\.

```csharp
void Write(int value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(int,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(int,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(int, Style\) Method

Writes an integer to the console with the specified style\.

```csharp
void Write(int value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the integer\.

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(int, Style, bool\) Method

Writes an integer to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void Write(int value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the integer\.

<a name='ConsolePlusLibrary.IConsole.Write(int,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(long)'></a>

## IConsole\.Write\(long\) Method

Writes a long integer to the console\.

```csharp
void Write(long value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(long).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(long,bool)'></a>

## IConsole\.Write\(long, bool\) Method

Writes a long integer to the console and optionally clears the rest of the line after writing\.

```csharp
void Write(long value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(long,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(long,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(long, Style\) Method

Writes a long integer to the console with the specified style\.

```csharp
void Write(long value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the long integer\.

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(long, Style, bool\) Method

Writes a long integer to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void Write(long value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long integer to write\.

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the long integer\.

<a name='ConsolePlusLibrary.IConsole.Write(long,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(object)'></a>

## IConsole\.Write\(object\) Method

Writes an object to the console\.

```csharp
void Write(object? value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.Write(object,bool)'></a>

## IConsole\.Write\(object, bool\) Method

Writes an object to the console and clears the rest of the line after writing\.

```csharp
void Write(object? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(object,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.Write(object,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(object, Style\) Method

Writes an object to the console with the specified style\.

```csharp
void Write(object? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the object\.

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(object, Style, bool\) Method

Writes an object to the console with the specified style and clears the rest of the line after writing\.

```csharp
void Write(object? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the object\.

<a name='ConsolePlusLibrary.IConsole.Write(object,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(string)'></a>

## IConsole\.Write\(string\) Method

Writes a string to the console\.

```csharp
void Write(string? value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.Write(string,bool)'></a>

## IConsole\.Write\(string, bool\) Method

Writes a string to the console and optionally clears the rest of the line after writing\.

```csharp
void Write(string? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(string,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.Write(string,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style)'></a>

## IConsole\.Write\(string, Style\) Method

Writes a string to the console with the specified style\.

```csharp
void Write(string? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the string\.

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.Write\(string, Style, bool\) Method

Writes a string to the console with the specified style and  clears the rest of the line after writing\.

```csharp
void Write(string? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the string\.

<a name='ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,bool,object[])'></a>

## IConsole\.WriteFormat\(string, bool, object\[\]\) Method

Writes a formatted string, using the specified format and arguments, and optionally clears the rest of the line after writing\.

```csharp
void WriteFormat(string format, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[])'></a>

## IConsole\.WriteFormat\(string, Style, bool, object\[\]\) Method

Writes a formatted string, using the specified format and arguments, with the specified style and clears the rest of the line after writing\.

```csharp
void WriteFormat(string format, ConsolePlusLibrary.Style style, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the formatted string\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,object[])'></a>

## IConsole\.WriteFormat\(string, Style, object\[\]\) Method

Writes a formatted string, using the specified format and arguments, with the specified style\.

```csharp
void WriteFormat(string format, ConsolePlusLibrary.Style style, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the formatted string\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,ConsolePlusLibrary.Style,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,object[])'></a>

## IConsole\.WriteFormat\(string, object\[\]\) Method

Writes a formatted string , using the specified format and arguments\.

```csharp
void WriteFormat(string format, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteFormat(string,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteLine()'></a>

## IConsole\.WriteLine\(\) Method

Writes a line terminator to the console\.

```csharp
void WriteLine();
```

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool)'></a>

## IConsole\.WriteLine\(bool\) Method

Writes a boolean followed by a line terminator to the console\.

```csharp
void WriteLine(bool value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,bool)'></a>

## IConsole\.WriteLine\(bool, bool\) Method

Writes a boolean followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(bool value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(bool, Style\) Method

Writes a boolean followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(bool value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the boolean\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(bool, Style, bool\) Method

Writes a boolean followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(bool value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The boolean to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the boolean\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(bool,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char)'></a>

## IConsole\.WriteLine\(char\) Method

Writes a character followed by a line terminator to the console\.

```csharp
void WriteLine(char value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,bool)'></a>

## IConsole\.WriteLine\(char, bool\) Method

Writes a character followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(char value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(char, Style\) Method

Writes a character followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(char value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the character\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(char, Style, bool\) Method

Writes a character followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(char value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the character\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[])'></a>

## IConsole\.WriteLine\(char\[\]\) Method

Writes an array of characters followed by a line terminator to the console\.

```csharp
void WriteLine(char[]? value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[]).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],bool)'></a>

## IConsole\.WriteLine\(char\[\], bool\) Method

Writes an array of characters followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(char[]? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(char\[\], Style\) Method

Writes an array of characters followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(char[]? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the characters\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(char\[\], Style, bool\) Method

Writes an array of characters followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(char[]? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of characters to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the characters\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(char[],ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double)'></a>

## IConsole\.WriteLine\(double\) Method

Writes a double followed by a line terminator to the console\.

```csharp
void WriteLine(double value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,bool)'></a>

## IConsole\.WriteLine\(double, bool\) Method

Writes a double followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(double value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(double, Style\) Method

Writes a double followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(double value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the double\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(double, Style, bool\) Method

Writes a double followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(double value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The double to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the double\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(double,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float)'></a>

## IConsole\.WriteLine\(float\) Method

Writes a float followed by a line terminator to the console\.

```csharp
void WriteLine(float value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(float).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,bool)'></a>

## IConsole\.WriteLine\(float, bool\) Method

Writes a float followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(float value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(float, Style\) Method

Writes a float followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(float value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the float\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(float, Style, bool\) Method

Writes a float followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(float value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The float to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the float\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(float,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int)'></a>

## IConsole\.WriteLine\(int\) Method

Writes an integer followed by a line terminator to the console\.

```csharp
void WriteLine(int value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(int).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,bool)'></a>

## IConsole\.WriteLine\(int, bool\) Method

Writes an integer followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(int value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(int, Style\) Method

Writes an integer followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(int value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the integer\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(int, Style, bool\) Method

Writes an integer followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(int value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the integer\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(int,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long)'></a>

## IConsole\.WriteLine\(long\) Method

Writes a long followed by a line terminator to the console\.

```csharp
void WriteLine(long value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(long).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,bool)'></a>

## IConsole\.WriteLine\(long, bool\) Method

Writes a long followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(long value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(long, Style\) Method

Writes a long followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(long value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the long\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(long, Style, bool\) Method

Writes a long followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(long value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The long to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the long\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(long,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object)'></a>

## IConsole\.WriteLine\(object\) Method

Writes an object followed by a line terminator to the console\.

```csharp
void WriteLine(object? value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,bool)'></a>

## IConsole\.WriteLine\(object, bool\) Method

Writes an object followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(object? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(object, Style\) Method

Writes an object followed by a line terminator to the console with the specified style\.

```csharp
void WriteLine(object? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the object\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(object, Style, bool\) Method

Writes an object followed by a line terminator to the console with the specified style and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(object? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the object\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(object,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string)'></a>

## IConsole\.WriteLine\(string\) Method

Writes a string to the console with the specified style\.

```csharp
void WriteLine(string? value);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,bool)'></a>

## IConsole\.WriteLine\(string, bool\) Method

Writes a string to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLine(string? value, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style)'></a>

## IConsole\.WriteLine\(string, Style\) Method

Writes a string to the console with the specified style\.

```csharp
void WriteLine(string? value, ConsolePlusLibrary.Style style);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the string\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteLine\(string, Style, bool\) Method

Writes a string to the console with the specified style and  clears the rest of the line after writing\.

```csharp
void WriteLine(string? value, ConsolePlusLibrary.Style style, bool clearrestofline);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the string\.

<a name='ConsolePlusLibrary.IConsole.WriteLine(string,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,bool,object[])'></a>

## IConsole\.WriteLineFormat\(string, bool, object\[\]\) Method

Writes a formatted string followed by a line terminator to the console and optionally clears the rest of the line after writing\.

```csharp
void WriteLineFormat(string format, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[])'></a>

## IConsole\.WriteLineFormat\(string, Style, bool, object\[\]\) Method

Writes a formatted string followed by a line terminator to the console with the specified style and clears the rest of the line after writing\.

```csharp
void WriteLineFormat(string format, ConsolePlusLibrary.Style style, bool clearrestofline, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the formatted string\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,bool,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,object[])'></a>

## IConsole\.WriteLineFormat\(string, Style, object\[\]\) Method

Writes a formatted string followed by a line terminator to the console with the specified style\.

```csharp
void WriteLineFormat(string format, ConsolePlusLibrary.Style style, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,object[]).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the formatted string\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,ConsolePlusLibrary.Style,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of objects to format\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,object[])'></a>

## IConsole\.WriteLineFormat\(string, object\[\]\) Method

Writes a formatted string followed by a line terminator to the console, using the specified format and arguments\.

```csharp
void WriteLineFormat(string format, params object?[] arg);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The composite format string\.

<a name='ConsolePlusLibrary.IConsole.WriteLineFormat(string,object[]).arg'></a>

`arg` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='ConsolePlusLibrary.IConsole.WriteRaw(string,ConsolePlusLibrary.Style,bool)'></a>

## IConsole\.WriteRaw\(string, Style, bool\) Method

Writes a string to the console as raw text \(without markup parsing\) using the specified style, optionally clearing the rest of the line after writing\.

```csharp
void WriteRaw(string? value, ConsolePlusLibrary.Style style, bool clearrestofline=false);
```
#### Parameters

<a name='ConsolePlusLibrary.IConsole.WriteRaw(string,ConsolePlusLibrary.Style,bool).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write verbatim\.

<a name='ConsolePlusLibrary.IConsole.WriteRaw(string,ConsolePlusLibrary.Style,bool).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to apply to the string\.

<a name='ConsolePlusLibrary.IConsole.WriteRaw(string,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to clear the rest of the line after writing\.

### Remarks
Unlike [Write\(string, Style, bool\)](IConsole.md#ConsolePlusLibrary.IConsole.Write(string,ConsolePlusLibrary.Style,bool) 'ConsolePlusLibrary\.IConsole\.Write\(string, ConsolePlusLibrary\.Style, bool\)'), markup tags such as `[red]` are not interpreted and are written verbatim\. The clear\-to\-end\-of\-line request is honored even when [value](IConsole.md#ConsolePlusLibrary.IConsole.WriteRaw(string,ConsolePlusLibrary.Style,bool).value 'ConsolePlusLibrary\.IConsole\.WriteRaw\(string, ConsolePlusLibrary\.Style, bool\)\.value') is empty or a line break\.

| Events | |
| :--- | :--- |
| [SizeChanged](IConsole.SizeChanged.md 'ConsolePlusLibrary\.IConsole\.SizeChanged') | Event raised when the console size changes\. |
