<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IWidgets Interface

Represents a collection of widgets that can be used in the console application\.

```csharp
public interface IWidgets
```
### Methods

<a name='ConsolePlusLibrary.IWidgets.Banner(string,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## IWidgets\.Banner\(string, Nullable\<Style\>\) Method

Creates a banner widget with the specified text and optional style\.

```csharp
ConsolePlusLibrary.IBanner Banner(string text, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.IWidgets.Banner(string,System.Nullable_ConsolePlusLibrary.Style_).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display in the banner\.

<a name='ConsolePlusLibrary.IWidgets.Banner(string,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional style to apply to the banner\.

#### Returns
[IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner')  
The created [IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner') instance\.

<a name='ConsolePlusLibrary.IWidgets.Dash(string,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## IWidgets\.Dash\(string, Nullable\<Style\>\) Method

Creates a string dash widget with the specified text and optional style\.

```csharp
ConsolePlusLibrary.IStringDash Dash(string text, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.IWidgets.Dash(string,System.Nullable_ConsolePlusLibrary.Style_).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display in the string dash\.

<a name='ConsolePlusLibrary.IWidgets.Dash(string,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional style to apply to the string dash\.

#### Returns
[IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash')  
The created [IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash') instance\.