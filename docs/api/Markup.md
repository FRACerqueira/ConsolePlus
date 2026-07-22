<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## Markup Class

Provides functionality for working with markup text\.

```csharp
public static class Markup
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Markup
### Methods

<a name='ConsolePlusLibrary.Markup.Escape(string)'></a>

## Markup\.Escape\(string\) Method

Escapes the specified markup text\.

```csharp
public static string Escape(string? markup);
```
#### Parameters

<a name='ConsolePlusLibrary.Markup.Escape(string).markup'></a>

`markup` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The markup text to escape\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The escaped markup text\.

<a name='ConsolePlusLibrary.Markup.EscapeMarkup(thisstring)'></a>

## Markup\.EscapeMarkup\(this string\) Method

Escapes the specified markup text\.

```csharp
public static string EscapeMarkup(this string? markup);
```
#### Parameters

<a name='ConsolePlusLibrary.Markup.EscapeMarkup(thisstring).markup'></a>

`markup` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The markup text to escape\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The escaped markup text\.

<a name='ConsolePlusLibrary.Markup.Length(string)'></a>

## Markup\.Length\(string\) Method

Calculates the length of the text without markup in the specified markup text\.

```csharp
public static int Length(string? markup);
```
#### Parameters

<a name='ConsolePlusLibrary.Markup.Length(string).markup'></a>

`markup` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The markup text to calculate the length for\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the text without markup\.

<a name='ConsolePlusLibrary.Markup.LengthMarkup(thisstring)'></a>

## Markup\.LengthMarkup\(this string\) Method

Calculates the length of the text without markup in the specified markup text\.

```csharp
public static int LengthMarkup(this string? markup);
```
#### Parameters

<a name='ConsolePlusLibrary.Markup.LengthMarkup(thisstring).markup'></a>

`markup` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The markup text to calculate the length for\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the text without markup\.

<a name='ConsolePlusLibrary.Markup.Remove(string)'></a>

## Markup\.Remove\(string\) Method

Removes the markup from the specified text\.

```csharp
public static string Remove(string? markup);
```
#### Parameters

<a name='ConsolePlusLibrary.Markup.Remove(string).markup'></a>

`markup` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The markup text to remove\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The text without markup\.

<a name='ConsolePlusLibrary.Markup.RemoveMarkup(thisstring)'></a>

## Markup\.RemoveMarkup\(this string\) Method

Removes the markup from the specified text\.

```csharp
public static string RemoveMarkup(this string? markup);
```
#### Parameters

<a name='ConsolePlusLibrary.Markup.RemoveMarkup(thisstring).markup'></a>

`markup` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The markup text to remove\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The text without markup\.