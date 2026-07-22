<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IStringDash Interface

Represents a banner that can be customized and displayed\.

```csharp
public interface IStringDash
```
### Methods

<a name='ConsolePlusLibrary.IStringDash.Border(ConsolePlusLibrary.DashOptions)'></a>

## IStringDash\.Border\(DashOptions\) Method

Set border options for the string dash\.

```csharp
ConsolePlusLibrary.IStringDash Border(ConsolePlusLibrary.DashOptions dashOptions);
```
#### Parameters

<a name='ConsolePlusLibrary.IStringDash.Border(ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions') to apply\.

#### Returns
[IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash')  
The current [IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash') instance for method chaining\.

<a name='ConsolePlusLibrary.IStringDash.Extralines(int)'></a>

## IStringDash\.Extralines\(int\) Method

Sets the number of extra lines to be added to the string dash\.

```csharp
ConsolePlusLibrary.IStringDash Extralines(int value);
```
#### Parameters

<a name='ConsolePlusLibrary.IStringDash.Extralines(int).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of extra lines to add\.

#### Returns
[IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash')  
The current [IStringDash](IStringDash.md 'ConsolePlusLibrary\.IStringDash') instance for method chaining\.

<a name='ConsolePlusLibrary.IStringDash.Show()'></a>

## IStringDash\.Show\(\) Method

Displays the string dash widget\.

```csharp
void Show();
```