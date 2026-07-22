<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IBanner Interface

Represents a banner that can be customized and displayed\.

```csharp
public interface IBanner
```
### Methods

<a name='ConsolePlusLibrary.IBanner.Border(ConsolePlusLibrary.DashOptions)'></a>

## IBanner\.Border\(DashOptions\) Method

Set border options for the banner\.

```csharp
ConsolePlusLibrary.IBanner Border(ConsolePlusLibrary.DashOptions dashOptions);
```
#### Parameters

<a name='ConsolePlusLibrary.IBanner.Border(ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions') to apply\.

#### Returns
[IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner')  
The current [IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner') instance for method chaining\.

<a name='ConsolePlusLibrary.IBanner.FromFont(string)'></a>

## IBanner\.FromFont\(string\) Method

Load a font from a file\.

```csharp
ConsolePlusLibrary.IBanner FromFont(string filepathFont);
```
#### Parameters

<a name='ConsolePlusLibrary.IBanner.FromFont(string).filepathFont'></a>

`filepathFont` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to the font file\.

#### Returns
[IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner')  
The current [IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner') instance for method chaining\.

<a name='ConsolePlusLibrary.IBanner.FromFont(System.IO.Stream)'></a>

## IBanner\.FromFont\(Stream\) Method

Load a font from a stream\.

```csharp
ConsolePlusLibrary.IBanner FromFont(System.IO.Stream streamFont);
```
#### Parameters

<a name='ConsolePlusLibrary.IBanner.FromFont(System.IO.Stream).streamFont'></a>

`streamFont` [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream')

The stream containing the font data\.

#### Returns
[IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner')  
The current [IBanner](IBanner.md 'ConsolePlusLibrary\.IBanner') instance for method chaining\.

<a name='ConsolePlusLibrary.IBanner.Show()'></a>

## IBanner\.Show\(\) Method

Displays the Banner widget\.

```csharp
void Show();
```