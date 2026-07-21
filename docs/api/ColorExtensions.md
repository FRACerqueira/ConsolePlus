<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## ColorExtensions Class

Provides extension methods for [Color](Color.md 'ConsolePlusLibrary\.Color')\.

```csharp
public static class ColorExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ColorExtensions
### Methods

<a name='ConsolePlusLibrary.ColorExtensions.Weighted(thisConsolePlusLibrary.Color,int)'></a>

## ColorExtensions\.Weighted\(this Color, int\) Method

Gets a weighted variation of a CSS base color\.

```csharp
public static ConsolePlusLibrary.Color Weighted(this ConsolePlusLibrary.Color color, int weight);
```
#### Parameters

<a name='ConsolePlusLibrary.ColorExtensions.Weighted(thisConsolePlusLibrary.Color,int).color'></a>

`color` [Color](Color.md 'ConsolePlusLibrary\.Color')

Base color instance \(must map to a CSS named color\)\.

<a name='ConsolePlusLibrary.ColorExtensions.Weighted(thisConsolePlusLibrary.Color,int).weight'></a>

`weight` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Weight in the range 0\-1000\. The value is mapped to the nearest proportional weighted step\.
Values greater than or equal to 1000 return the original color\.

#### Returns
[Color](Color.md 'ConsolePlusLibrary\.Color')  
The weighted variation, or the original color if weight is out of range\.