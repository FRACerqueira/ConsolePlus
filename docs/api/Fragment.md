<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## Fragment Struct

Represents a rendered text fragment with optional style and semantic kind\.

```csharp
public readonly struct Fragment
```

### Remarks
Initializes a new instance of the [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') class\.
### Constructors

<a name='ConsolePlusLibrary.Fragment.Fragment(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.FragmentKind)'></a>

## Fragment\(string, Nullable\<Style\>, FragmentKind\) Constructor

Represents a rendered text fragment with optional style and semantic kind\.

```csharp
public Fragment(string text, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.FragmentKind type=ConsolePlusLibrary.FragmentKind.ContentText);
```
#### Parameters

<a name='ConsolePlusLibrary.Fragment.Fragment(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.FragmentKind).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Fragment content\.

<a name='ConsolePlusLibrary.Fragment.Fragment(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.FragmentKind).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Style applied to this fragment, when applicable\.

<a name='ConsolePlusLibrary.Fragment.Fragment(string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.FragmentKind).type'></a>

`type` [FragmentKind](FragmentKind.md 'ConsolePlusLibrary\.FragmentKind')

Fragment category \(raw text, line break, clear\-to\-end\-of\-line, etc\.\)\.

### Remarks
Initializes a new instance of the [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') class\.
### Properties

<a name='ConsolePlusLibrary.Fragment.Style'></a>

## Fragment\.Style Property

Gets the fragment style\.

```csharp
public System.Nullable<ConsolePlusLibrary.Style> Style { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='ConsolePlusLibrary.Fragment.Text'></a>

## Fragment\.Text Property

Gets the fragment text\.

```csharp
public string Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='ConsolePlusLibrary.Fragment.Type'></a>

## Fragment\.Type Property

Gets the fragment type\.

```csharp
public ConsolePlusLibrary.FragmentKind Type { get; }
```

#### Property Value
[FragmentKind](FragmentKind.md 'ConsolePlusLibrary\.FragmentKind')
### Methods

<a name='ConsolePlusLibrary.Fragment.Equals(object)'></a>

## Fragment\.Equals\(object\) Method

Indicates whether this instance and a specified object are equal\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='ConsolePlusLibrary.Fragment.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current instance\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [obj](Fragment.md#ConsolePlusLibrary.Fragment.Equals(object).obj 'ConsolePlusLibrary\.Fragment\.Equals\(object\)\.obj') and this instance are the same type and represent the same value; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='ConsolePlusLibrary.Fragment.FromText(string,ConsolePlusLibrary.Style,bool)'></a>

## Fragment\.FromText\(string, Style, bool\) Method

Parses input text \(with optional markup tags\) into styled fragments\.

```csharp
public static ConsolePlusLibrary.Fragment[] FromText(string? text, ConsolePlusLibrary.Style defaultstyletext, bool clearrestofline=false);
```
#### Parameters

<a name='ConsolePlusLibrary.Fragment.FromText(string,ConsolePlusLibrary.Style,bool).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Input text\. Markup tags such as `[red]` and `[/]` are supported\.

<a name='ConsolePlusLibrary.Fragment.FromText(string,ConsolePlusLibrary.Style,bool).defaultstyletext'></a>

`defaultstyletext` [Style](Style.md 'ConsolePlusLibrary\.Style')

Base style used before any markup tag is applied\.

<a name='ConsolePlusLibrary.Fragment.FromText(string,ConsolePlusLibrary.Style,bool).clearrestofline'></a>

`clearrestofline` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, inserts [ClearRestofline](FragmentKind.md#ConsolePlusLibrary.FragmentKind.ClearRestofline 'ConsolePlusLibrary\.FragmentKind\.ClearRestofline') fragments around line boundaries\.

#### Returns
[Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
Parsed fragments ready for rendering\.

<a name='ConsolePlusLibrary.Fragment.GetHashCode()'></a>

## Fragment\.GetHashCode\(\) Method

Returns the hash code for this instance\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer that is the hash code for this instance\.
### Operators

<a name='ConsolePlusLibrary.Fragment.op_Equality(ConsolePlusLibrary.Fragment,ConsolePlusLibrary.Fragment)'></a>

## Fragment\.operator ==\(Fragment, Fragment\) Operator

Determines whether two [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') values are equal\.

```csharp
public static bool operator ==(ConsolePlusLibrary.Fragment left, ConsolePlusLibrary.Fragment right);
```
#### Parameters

<a name='ConsolePlusLibrary.Fragment.op_Equality(ConsolePlusLibrary.Fragment,ConsolePlusLibrary.Fragment).left'></a>

`left` [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment')

The left operand\.

<a name='ConsolePlusLibrary.Fragment.op_Equality(ConsolePlusLibrary.Fragment,ConsolePlusLibrary.Fragment).right'></a>

`right` [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment')

The right operand\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when both fragments are equal; otherwise, `false`\.

<a name='ConsolePlusLibrary.Fragment.op_Inequality(ConsolePlusLibrary.Fragment,ConsolePlusLibrary.Fragment)'></a>

## Fragment\.operator \!=\(Fragment, Fragment\) Operator

Determines whether two [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') values are not equal\.

```csharp
public static bool operator !=(ConsolePlusLibrary.Fragment left, ConsolePlusLibrary.Fragment right);
```
#### Parameters

<a name='ConsolePlusLibrary.Fragment.op_Inequality(ConsolePlusLibrary.Fragment,ConsolePlusLibrary.Fragment).left'></a>

`left` [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment')

The left operand\.

<a name='ConsolePlusLibrary.Fragment.op_Inequality(ConsolePlusLibrary.Fragment,ConsolePlusLibrary.Fragment).right'></a>

`right` [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment')

The right operand\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the fragments differ; otherwise, `false`\.