<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## StringExtensions Class

Provides extension methods for strings\.

```csharp
public static class StringExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StringExtensions
### Methods

<a name='ConsolePlusLibrary.StringExtensions.GetDisplayLength(thisstring)'></a>

## StringExtensions\.GetDisplayLength\(this string\) Method

Calculates the display length of each line in the specified text, taking into account the width of Unicode characters\.

```csharp
public static int[] GetDisplayLength(this string? text);
```
#### Parameters

<a name='ConsolePlusLibrary.StringExtensions.GetDisplayLength(thisstring).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to calculate the display length for\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array containing the display length of each line in the text\.

<a name='ConsolePlusLibrary.StringExtensions.GetRuneWidth(thisSystem.Text.Rune)'></a>

## StringExtensions\.GetRuneWidth\(this Rune\) Method

Returns the display width, in terminal columns, of a single rune \(0 for combining/control
runes, 2 for East Asian wide runes, 1 otherwise\)\.

```csharp
public static int GetRuneWidth(this System.Text.Rune rune);
```
#### Parameters

<a name='ConsolePlusLibrary.StringExtensions.GetRuneWidth(thisSystem.Text.Rune).rune'></a>

`rune` [System\.Text\.Rune](https://learn.microsoft.com/en-us/dotnet/api/system.text.rune 'System\.Text\.Rune')

The rune to measure\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The display width, in columns, of [rune](StringExtensions.md#ConsolePlusLibrary.StringExtensions.GetRuneWidth(thisSystem.Text.Rune).rune 'ConsolePlusLibrary\.StringExtensions\.GetRuneWidth\(this System\.Text\.Rune\)\.rune')\.

<a name='ConsolePlusLibrary.StringExtensions.NormalizeNewLines(thisstring)'></a>

## StringExtensions\.NormalizeNewLines\(this string\) Method

Normalizes the new lines in the specified text\.

```csharp
public static string NormalizeNewLines(this string? text);
```
#### Parameters

<a name='ConsolePlusLibrary.StringExtensions.NormalizeNewLines(thisstring).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to normalize\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The text with normalized new lines\.

<a name='ConsolePlusLibrary.StringExtensions.SplitLines(thisstring)'></a>

## StringExtensions\.SplitLines\(this string\) Method

Splits the specified text into lines, normalizing the new lines in the process\.

```csharp
public static string[] SplitLines(this string text);
```
#### Parameters

<a name='ConsolePlusLibrary.StringExtensions.SplitLines(thisstring).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='ConsolePlusLibrary.StringExtensions.TruncateToDisplayWidth(thisstring,int)'></a>

## StringExtensions\.TruncateToDisplayWidth\(this string, int\) Method

Returns the longest prefix of [text](StringExtensions.md#ConsolePlusLibrary.StringExtensions.TruncateToDisplayWidth(thisstring,int).text 'ConsolePlusLibrary\.StringExtensions\.TruncateToDisplayWidth\(this string, int\)\.text') whose display width does not exceed
[maxWidth](StringExtensions.md#ConsolePlusLibrary.StringExtensions.TruncateToDisplayWidth(thisstring,int).maxWidth 'ConsolePlusLibrary\.StringExtensions\.TruncateToDisplayWidth\(this string, int\)\.maxWidth') columns, without splitting a wide rune in half\.

```csharp
public static string TruncateToDisplayWidth(this string? text, int maxWidth);
```
#### Parameters

<a name='ConsolePlusLibrary.StringExtensions.TruncateToDisplayWidth(thisstring,int).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to truncate\.

<a name='ConsolePlusLibrary.StringExtensions.TruncateToDisplayWidth(thisstring,int).maxWidth'></a>

`maxWidth` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum display width, in columns, of the returned prefix\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The truncated text\. Empty when [maxWidth](StringExtensions.md#ConsolePlusLibrary.StringExtensions.TruncateToDisplayWidth(thisstring,int).maxWidth 'ConsolePlusLibrary\.StringExtensions\.TruncateToDisplayWidth\(this string, int\)\.maxWidth') is not positive\.