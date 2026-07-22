<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## Style Struct

Represents a text rendering style consisting of a foreground color, background color and an overflow strategy\.

```csharp
public readonly struct Style : System.IEquatable<ConsolePlusLibrary.Style>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
Use the primary constructor to specify explicit colors and an [Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow') strategy, or the
### Constructors

<a name='ConsolePlusLibrary.Style.Style(ConsolePlusLibrary.Color,ConsolePlusLibrary.Color,ConsolePlusLibrary.Overflow)'></a>

## Style\(Color, Color, Overflow\) Constructor

Represents a text rendering style consisting of a foreground color, background color and an overflow strategy\.

```csharp
public Style(ConsolePlusLibrary.Color foreground, ConsolePlusLibrary.Color background, ConsolePlusLibrary.Overflow overflowStrategy=ConsolePlusLibrary.Overflow.None);
```
#### Parameters

<a name='ConsolePlusLibrary.Style.Style(ConsolePlusLibrary.Color,ConsolePlusLibrary.Color,ConsolePlusLibrary.Overflow).foreground'></a>

`foreground` [Color](Color.md 'ConsolePlusLibrary\.Color')

Foreground [Color](Color.md 'ConsolePlusLibrary\.Color') used when writing content\.

<a name='ConsolePlusLibrary.Style.Style(ConsolePlusLibrary.Color,ConsolePlusLibrary.Color,ConsolePlusLibrary.Overflow).background'></a>

`background` [Color](Color.md 'ConsolePlusLibrary\.Color')

Background [Color](Color.md 'ConsolePlusLibrary\.Color') used behind the content\.

<a name='ConsolePlusLibrary.Style.Style(ConsolePlusLibrary.Color,ConsolePlusLibrary.Color,ConsolePlusLibrary.Overflow).overflowStrategy'></a>

`overflowStrategy` [Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow')

Overflow handling strategy applied when content exceeds the target width\.

### Remarks
Use the primary constructor to specify explicit colors and an [Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow') strategy, or the
### Properties

<a name='ConsolePlusLibrary.Style.Background'></a>

## Style\.Background Property

Gets the background [Color](Color.md 'ConsolePlusLibrary\.Color')\.

```csharp
public ConsolePlusLibrary.Color Background { get; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')

<a name='ConsolePlusLibrary.Style.Foreground'></a>

## Style\.Foreground Property

Gets the foreground [Color](Color.md 'ConsolePlusLibrary\.Color')\.

```csharp
public ConsolePlusLibrary.Color Foreground { get; }
```

#### Property Value
[Color](Color.md 'ConsolePlusLibrary\.Color')

<a name='ConsolePlusLibrary.Style.OverflowStrategy'></a>

## Style\.OverflowStrategy Property

Gets the [Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow') strategy applied when content exceeds the available width\.

```csharp
public ConsolePlusLibrary.Overflow OverflowStrategy { get; }
```

#### Property Value
[Overflow](Overflow.md 'ConsolePlusLibrary\.Overflow')
### Methods

<a name='ConsolePlusLibrary.Style.Equals(ConsolePlusLibrary.Style)'></a>

## Style\.Equals\(Style\) Method

Determines whether this instance is equal to another [Style](Style.md 'ConsolePlusLibrary\.Style')\.

```csharp
public bool Equals(ConsolePlusLibrary.Style other);
```
#### Parameters

<a name='ConsolePlusLibrary.Style.Equals(ConsolePlusLibrary.Style).other'></a>

`other` [Style](Style.md 'ConsolePlusLibrary\.Style')

The style to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if all components match; otherwise, `false`\.

<a name='ConsolePlusLibrary.Style.Equals(object)'></a>

## Style\.Equals\(object\) Method

Indicates whether this instance and a specified object are equal\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='ConsolePlusLibrary.Style.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current instance\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [obj](Style.md#ConsolePlusLibrary.Style.Equals(object).obj 'ConsolePlusLibrary\.Style\.Equals\(object\)\.obj') and this instance are the same type and represent the same value; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='ConsolePlusLibrary.Style.GetHashCode()'></a>

## Style\.GetHashCode\(\) Method

Returns the hash code for this instance\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer that is the hash code for this instance\.
### Operators

<a name='ConsolePlusLibrary.Style.op_Equality(ConsolePlusLibrary.Style,ConsolePlusLibrary.Style)'></a>

## Style\.operator ==\(Style, Style\) Operator

Determines whether two [Style](Style.md 'ConsolePlusLibrary\.Style') instances are equal\.

```csharp
public static bool operator ==(ConsolePlusLibrary.Style left, ConsolePlusLibrary.Style right);
```
#### Parameters

<a name='ConsolePlusLibrary.Style.op_Equality(ConsolePlusLibrary.Style,ConsolePlusLibrary.Style).left'></a>

`left` [Style](Style.md 'ConsolePlusLibrary\.Style')

The first style\.

<a name='ConsolePlusLibrary.Style.op_Equality(ConsolePlusLibrary.Style,ConsolePlusLibrary.Style).right'></a>

`right` [Style](Style.md 'ConsolePlusLibrary\.Style')

The second style\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if equal; otherwise, `false`\.

<a name='ConsolePlusLibrary.Style.op_ImplicitConsolePlusLibrary.Style(ConsolePlusLibrary.Color)'></a>

## Style\.implicit operator Style\(Color\) Operator

Converts a [Color](Color.md 'ConsolePlusLibrary\.Color') to a [Style](Style.md 'ConsolePlusLibrary\.Style') using the color as foreground\.

```csharp
public static ConsolePlusLibrary.Style implicit operator ConsolePlusLibrary.Style(ConsolePlusLibrary.Color color);
```
#### Parameters

<a name='ConsolePlusLibrary.Style.op_ImplicitConsolePlusLibrary.Style(ConsolePlusLibrary.Color).color'></a>

`color` [Color](Color.md 'ConsolePlusLibrary\.Color')

The foreground color\.

#### Returns
[Style](Style.md 'ConsolePlusLibrary\.Style')

<a name='ConsolePlusLibrary.Style.op_Inequality(ConsolePlusLibrary.Style,ConsolePlusLibrary.Style)'></a>

## Style\.operator \!=\(Style, Style\) Operator

Determines whether two [Style](Style.md 'ConsolePlusLibrary\.Style') instances are not equal\.

```csharp
public static bool operator !=(ConsolePlusLibrary.Style left, ConsolePlusLibrary.Style right);
```
#### Parameters

<a name='ConsolePlusLibrary.Style.op_Inequality(ConsolePlusLibrary.Style,ConsolePlusLibrary.Style).left'></a>

`left` [Style](Style.md 'ConsolePlusLibrary\.Style')

The first style\.

<a name='ConsolePlusLibrary.Style.op_Inequality(ConsolePlusLibrary.Style,ConsolePlusLibrary.Style).right'></a>

`right` [Style](Style.md 'ConsolePlusLibrary\.Style')

The second style\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if not equal; otherwise, `false`\.