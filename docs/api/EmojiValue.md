<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## EmojiValue Struct

Wrapper type that enables implicit conversion from [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName') to the
real emoji string via `EmojiName` resolution\.

```csharp
public readonly record struct EmojiValue : System.IEquatable<ConsolePlusLibrary.EmojiValue>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[EmojiValue](EmojiValue.md 'ConsolePlusLibrary\.EmojiValue')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')
### Constructors

<a name='ConsolePlusLibrary.EmojiValue.EmojiValue(ConsolePlusLibrary.EmojiName)'></a>

## EmojiValue\(EmojiName\) Constructor

Wrapper type that enables implicit conversion from [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName') to the
real emoji string via `EmojiName` resolution\.

```csharp
public EmojiValue(ConsolePlusLibrary.EmojiName Name);
```
#### Parameters

<a name='ConsolePlusLibrary.EmojiValue.EmojiValue(ConsolePlusLibrary.EmojiName).Name'></a>

`Name` [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName')
### Methods

<a name='ConsolePlusLibrary.EmojiValue.ToString()'></a>

## EmojiValue\.ToString\(\) Method

Returns the resolved emoji string\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Operators

<a name='ConsolePlusLibrary.EmojiValue.op_ImplicitConsolePlusLibrary.EmojiValue(ConsolePlusLibrary.EmojiName)'></a>

## EmojiValue\.implicit operator EmojiValue\(EmojiName\) Operator

Converts an [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName') to [EmojiValue](EmojiValue.md 'ConsolePlusLibrary\.EmojiValue')\.

```csharp
public static ConsolePlusLibrary.EmojiValue implicit operator ConsolePlusLibrary.EmojiValue(ConsolePlusLibrary.EmojiName name);
```
#### Parameters

<a name='ConsolePlusLibrary.EmojiValue.op_ImplicitConsolePlusLibrary.EmojiValue(ConsolePlusLibrary.EmojiName).name'></a>

`name` [EmojiName](EmojiName.md 'ConsolePlusLibrary\.EmojiName')

#### Returns
[EmojiValue](EmojiValue.md 'ConsolePlusLibrary\.EmojiValue')

<a name='ConsolePlusLibrary.EmojiValue.op_Implicitstring(ConsolePlusLibrary.EmojiValue)'></a>

## EmojiValue\.implicit operator string\(EmojiValue\) Operator

Converts an [EmojiValue](EmojiValue.md 'ConsolePlusLibrary\.EmojiValue') to the real emoji string\.

```csharp
public static string implicit operator string(ConsolePlusLibrary.EmojiValue value);
```
#### Parameters

<a name='ConsolePlusLibrary.EmojiValue.op_Implicitstring(ConsolePlusLibrary.EmojiValue).value'></a>

`value` [EmojiValue](EmojiValue.md 'ConsolePlusLibrary\.EmojiValue')

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')