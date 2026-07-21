<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## EmacsConsoleBuffer Class

Represents a buffer for console input that supports Emacs\-style keyboard shortcuts and editing capabilities\.

```csharp
public sealed class EmacsConsoleBuffer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EmacsConsoleBuffer
### Constructors

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.EmacsConsoleBuffer(bool,ConsolePlusLibrary.CaseOptions,bool,System.Func_char,bool_)'></a>

## EmacsConsoleBuffer\(bool, CaseOptions, bool, Func\<char,bool\>\) Constructor

Represents a buffer for console input that supports Emacs\-style keyboard shortcuts and editing capabilities\.

```csharp
public EmacsConsoleBuffer(bool isreadlonly, ConsolePlusLibrary.CaseOptions caseOption, bool enableEmacsKeys, System.Func<char,bool>? validate=null);
```
#### Parameters

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.EmacsConsoleBuffer(bool,ConsolePlusLibrary.CaseOptions,bool,System.Func_char,bool_).isreadlonly'></a>

`isreadlonly` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Indicates whether the buffer is read\-only\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.EmacsConsoleBuffer(bool,ConsolePlusLibrary.CaseOptions,bool,System.Func_char,bool_).caseOption'></a>

`caseOption` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case transformation options for the input\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.EmacsConsoleBuffer(bool,ConsolePlusLibrary.CaseOptions,bool,System.Func_char,bool_).enableEmacsKeys'></a>

`enableEmacsKeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

\<param name="validate"\>A function to validate each input character\.\</param\>
            When `true` \(default\) the Emacs letter shortcuts \(Ctrl/Alt \+ letter, e\.g\. Ctrl\+A, Ctrl\+E,
            Ctrl\+K, Alt\+F, \.\.\.\) are recognized\. When `false` those shortcuts are ignored, which is useful
            on terminals that capture Ctrl/Alt combinations themselves \(common on Linux\)\. Dedicated physical
            keys \(arrows, Home, End, Delete, Backspace, Insert\) keep working regardless of this flag\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.EmacsConsoleBuffer(bool,ConsolePlusLibrary.CaseOptions,bool,System.Func_char,bool_).validate'></a>

`validate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')
### Properties

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.Length'></a>

## EmacsConsoleBuffer\.Length Property

Gets the number of characters currently in the buffer\.

```csharp
public int Length { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.Position'></a>

## EmacsConsoleBuffer\.Position Property

Gets the current cursor position within the buffer\.

```csharp
public int Position { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')
### Methods

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.Clear()'></a>

## EmacsConsoleBuffer\.Clear\(\) Method

Clears all content from the buffer and resets the cursor position\.

```csharp
public ConsolePlusLibrary.EmacsConsoleBuffer Clear();
```

#### Returns
[EmacsConsoleBuffer](EmacsConsoleBuffer.md 'ConsolePlusLibrary\.EmacsConsoleBuffer')  
The current [EmacsConsoleBuffer](EmacsConsoleBuffer.md 'ConsolePlusLibrary\.EmacsConsoleBuffer') instance, to allow chaining\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.IsPrintable(char)'></a>

## EmacsConsoleBuffer\.IsPrintable\(char\) Method

Determines whether the specified character is printable \(renderable\) in the console\.

```csharp
public bool IsPrintable(char c);
```
#### Parameters

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.IsPrintable(char).c'></a>

`c` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the character is printable; otherwise, `false`\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.IsPrintable(System.ConsoleKeyInfo)'></a>

## EmacsConsoleBuffer\.IsPrintable\(ConsoleKeyInfo\) Method

Determines whether the character produced by the specified key press is printable and
not combined with a Control or Alt modifier\.

```csharp
public bool IsPrintable(System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.IsPrintable(System.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The key press to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the key produces a printable character; otherwise, `false`\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.LoadPrintable(string,int)'></a>

## EmacsConsoleBuffer\.LoadPrintable\(string, int\) Method

Replaces the buffer content with the printable characters from [value](EmacsConsoleBuffer.md#ConsolePlusLibrary.EmacsConsoleBuffer.LoadPrintable(string,int).value 'ConsolePlusLibrary\.EmacsConsoleBuffer\.LoadPrintable\(string, int\)\.value')\.

```csharp
public ConsolePlusLibrary.EmacsConsoleBuffer LoadPrintable(string? value, int maxlength=int.MaxValue);
```
#### Parameters

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.LoadPrintable(string,int).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to load, or `null` to leave the buffer unchanged\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.LoadPrintable(string,int).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of characters the buffer may hold\.

#### Returns
[EmacsConsoleBuffer](EmacsConsoleBuffer.md 'ConsolePlusLibrary\.EmacsConsoleBuffer')  
The current [EmacsConsoleBuffer](EmacsConsoleBuffer.md 'ConsolePlusLibrary\.EmacsConsoleBuffer') instance, to allow chaining\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.ToBackward()'></a>

## EmacsConsoleBuffer\.ToBackward\(\) Method

Gets the buffer content from the beginning up to the current cursor position\.

```csharp
public string ToBackward();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The text before the cursor, or an empty string when the buffer is empty\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.ToForward()'></a>

## EmacsConsoleBuffer\.ToForward\(\) Method

Gets the buffer content from the current cursor position to the end\.

```csharp
public string ToForward();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The text from the cursor onward, or an empty string when the buffer is empty\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.ToHome()'></a>

## EmacsConsoleBuffer\.ToHome\(\) Method

Moves the cursor to the beginning of the buffer\.

```csharp
public void ToHome();
```

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.ToString()'></a>

## EmacsConsoleBuffer\.ToString\(\) Method

Returns a string that represents the current object\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string that represents the current object\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.TryAcceptedReadlineConsoleKey(System.ConsoleKeyInfo,int)'></a>

## EmacsConsoleBuffer\.TryAcceptedReadlineConsoleKey\(ConsoleKeyInfo, int\) Method

Processes a key press using Emacs\-style editing semantics and updates the buffer accordingly\.

```csharp
public bool TryAcceptedReadlineConsoleKey(System.ConsoleKeyInfo keyinfo, int maxlength=int.MaxValue);
```
#### Parameters

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.TryAcceptedReadlineConsoleKey(System.ConsoleKeyInfo,int).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The key that was pressed\.

<a name='ConsolePlusLibrary.EmacsConsoleBuffer.TryAcceptedReadlineConsoleKey(System.ConsoleKeyInfo,int).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of characters the buffer may hold\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the key was accepted and handled; otherwise, `false`\.