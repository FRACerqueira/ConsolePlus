<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
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