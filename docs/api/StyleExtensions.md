<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## StyleExtensions Class

Provides extension methods for creating modified [Style](Style.md 'ConsolePlusLibrary\.Style') instances
by selectively changing foreground, background, or overflow strategy\.

```csharp
public static class StyleExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StyleExtensions
### Methods

<a name='ConsolePlusLibrary.StyleExtensions.Background(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color)'></a>

## StyleExtensions\.Background\(this Style, Color\) Method

Creates a new [Style](Style.md 'ConsolePlusLibrary\.Style') based on [style](StyleExtensions.md#ConsolePlusLibrary.StyleExtensions.Background(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).style 'ConsolePlusLibrary\.StyleExtensions\.Background\(this ConsolePlusLibrary\.Style, ConsolePlusLibrary\.Color\)\.style') with a replaced background color\.
Foreground color and overflow strategy are preserved\.

```csharp
public static ConsolePlusLibrary.Style Background(this ConsolePlusLibrary.Style style, ConsolePlusLibrary.Color color);
```
#### Parameters

<a name='ConsolePlusLibrary.StyleExtensions.Background(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The original style\.

<a name='ConsolePlusLibrary.StyleExtensions.Background(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).color'></a>

`color` [Color](Color.md 'ConsolePlusLibrary\.Color')

The new background [Color](Color.md 'ConsolePlusLibrary\.Color')\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') with the updated background color\.

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color)'></a>

## StyleExtensions\.Colors\(this Style, Color\) Method

Creates a style with an explicit foreground color and current background color\.

```csharp
public static ConsolePlusLibrary.Style Colors(this ConsolePlusLibrary.Style style, ConsolePlusLibrary.Color forecolor);
```
#### Parameters

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The original style\.

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).forecolor'></a>

`forecolor` [Color](Color.md 'ConsolePlusLibrary\.Color')

The foreground [Color](Color.md 'ConsolePlusLibrary\.Color')\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') with the specified colors\.

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color,ConsolePlusLibrary.Color)'></a>

## StyleExtensions\.Colors\(this Style, Color, Color\) Method

Creates a style with an explicit foreground color and an optional background color\.
If no background color is provided, the current console background color is used\.

```csharp
public static ConsolePlusLibrary.Style Colors(this ConsolePlusLibrary.Style style, ConsolePlusLibrary.Color forecolor, ConsolePlusLibrary.Color backcolor);
```
#### Parameters

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color,ConsolePlusLibrary.Color).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The original style\.

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color,ConsolePlusLibrary.Color).forecolor'></a>

`forecolor` [Color](Color.md 'ConsolePlusLibrary\.Color')

The foreground [Color](Color.md 'ConsolePlusLibrary\.Color')\.

<a name='ConsolePlusLibrary.StyleExtensions.Colors(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color,ConsolePlusLibrary.Color).backcolor'></a>

`backcolor` [Color](Color.md 'ConsolePlusLibrary\.Color')

Optional background [Color](Color.md 'ConsolePlusLibrary\.Color'); if `null`, console background is used\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') with the specified colors\.

<a name='ConsolePlusLibrary.StyleExtensions.ForeGround(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color)'></a>

## StyleExtensions\.ForeGround\(this Style, Color\) Method

Creates a new [Style](Style.md 'ConsolePlusLibrary\.Style') based on [style](StyleExtensions.md#ConsolePlusLibrary.StyleExtensions.ForeGround(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).style 'ConsolePlusLibrary\.StyleExtensions\.ForeGround\(this ConsolePlusLibrary\.Style, ConsolePlusLibrary\.Color\)\.style') with a replaced foreground color\.
Background and overflow strategy are preserved\.

```csharp
public static ConsolePlusLibrary.Style ForeGround(this ConsolePlusLibrary.Style style, ConsolePlusLibrary.Color color);
```
#### Parameters

<a name='ConsolePlusLibrary.StyleExtensions.ForeGround(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The original style\.

<a name='ConsolePlusLibrary.StyleExtensions.ForeGround(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Color).color'></a>

`color` [Color](Color.md 'ConsolePlusLibrary\.Color')

The new foreground [Color](Color.md 'ConsolePlusLibrary\.Color')\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') with the updated foreground color\.

<a name='ConsolePlusLibrary.StyleExtensions.Overflow(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Overflow)'></a>

## StyleExtensions\.Overflow\(this Style, Overflow\) Method

Creates a new [Style](Style.md 'ConsolePlusLibrary\.Style') based on [style](StyleExtensions.md#ConsolePlusLibrary.StyleExtensions.Overflow(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Overflow).style 'ConsolePlusLibrary\.StyleExtensions\.Overflow\(this ConsolePlusLibrary\.Style, ConsolePlusLibrary\.Overflow\)\.style') with a replaced overflow strategy\.
Foreground and background colors are preserved\.

```csharp
public static ConsolePlusLibrary.Style Overflow(this ConsolePlusLibrary.Style style, ConsolePlusLibrary.Overflow overflow);
```
#### Parameters

<a name='ConsolePlusLibrary.StyleExtensions.Overflow(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Overflow).style'></a>

`style` [Style](Style.md 'ConsolePlusLibrary\.Style')

The original style\.

<a name='ConsolePlusLibrary.StyleExtensions.Overflow(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Overflow).overflow'></a>

`overflow` [Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow')

The new [Overflow\(this Style, Overflow\)](StyleExtensions.md#ConsolePlusLibrary.StyleExtensions.Overflow(thisConsolePlusLibrary.Style,ConsolePlusLibrary.Overflow) 'ConsolePlusLibrary\.StyleExtensions\.Overflow\(this ConsolePlusLibrary\.Style, ConsolePlusLibrary\.Overflow\)') strategy\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')  
A new [Style](Style.md 'ConsolePlusLibrary\.Style') with the updated overflow strategy\.