<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IProfileSetup Interface

Interface for configuring console profiles, allowing for the setup of various console settings such as encoding, color, and interaction capabilities\.

```csharp
public interface IProfileSetup
```
### Methods

<a name='ConsolePlusLibrary.IProfileSetup.Apply()'></a>

## IProfileSetup\.Apply\(\) Method

Applies the configured profile settings to the console environment\. 
This method should be called after all desired settings have been configured using the fluent interface methods\.

```csharp
void Apply();
```

<a name='ConsolePlusLibrary.IProfileSetup.ColorDepth(ConsolePlusLibrary.ColorSystem)'></a>

## IProfileSetup\.ColorDepth\(ColorSystem\) Method

Color depth \(capability\) of the console\.

```csharp
ConsolePlusLibrary.IProfileSetup ColorDepth(ConsolePlusLibrary.ColorSystem value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.ColorDepth(ConsolePlusLibrary.ColorSystem).value'></a>

`value` [ColorSystem](ColorSystem.md 'ConsolePlusLibrary\.ColorSystem')

The color depth to set for the console\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.DefaultBackgroundColor(ConsolePlusLibrary.Color)'></a>

## IProfileSetup\.DefaultBackgroundColor\(Color\) Method

Default background [Color](Color.md 'ConsolePlusLibrary\.Color') used when no explicit color is specified\.

```csharp
ConsolePlusLibrary.IProfileSetup DefaultBackgroundColor(ConsolePlusLibrary.Color value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.DefaultBackgroundColor(ConsolePlusLibrary.Color).value'></a>

`value` [Color](Color.md 'ConsolePlusLibrary\.Color')

The color to set as the default background color\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.DefaultInputEncoding(System.Text.Encoding)'></a>

## IProfileSetup\.DefaultInputEncoding\(Encoding\) Method

Default input encoding of the console at the time the profile was created\.

```csharp
ConsolePlusLibrary.IProfileSetup DefaultInputEncoding(System.Text.Encoding value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.DefaultInputEncoding(System.Text.Encoding).value'></a>

`value` [System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

The encoding to set as the default input encoding\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.DefaultOutputEncoding(System.Text.Encoding)'></a>

## IProfileSetup\.DefaultOutputEncoding\(Encoding\) Method

Default output encoding of the console at the time the profile was created\.

```csharp
ConsolePlusLibrary.IProfileSetup DefaultOutputEncoding(System.Text.Encoding value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.DefaultOutputEncoding(System.Text.Encoding).value'></a>

`value` [System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')

The encoding to set as the default output encoding\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.Interactive(bool)'></a>

## IProfileSetup\.Interactive\(bool\) Method

Indicating whether or not the console supports interaction\.

```csharp
ConsolePlusLibrary.IProfileSetup Interactive(bool value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.Interactive(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A boolean value indicating whether the console supports interaction\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.SupportsAnsi(ConsolePlusLibrary.AutoDetect)'></a>

## IProfileSetup\.SupportsAnsi\(AutoDetect\) Method

Gets a value indicating whether ANSI escape sequences are supported for styling/output\.

```csharp
ConsolePlusLibrary.IProfileSetup SupportsAnsi(ConsolePlusLibrary.AutoDetect value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.SupportsAnsi(ConsolePlusLibrary.AutoDetect).value'></a>

`value` [AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect')

An [AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect') value indicating whether ANSI escape sequences are supported\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.SupportUnicode(ConsolePlusLibrary.AutoDetect)'></a>

## IProfileSetup\.SupportUnicode\(AutoDetect\) Method

Indicates whether Unicode output is fully supported\.

```csharp
ConsolePlusLibrary.IProfileSetup SupportUnicode(ConsolePlusLibrary.AutoDetect value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.SupportUnicode(ConsolePlusLibrary.AutoDetect).value'></a>

`value` [AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect')

An [AutoDetect](AutoDetect.md 'ConsolePlusLibrary\.AutoDetect') value indicating whether Unicode output is supported\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.

<a name='ConsolePlusLibrary.IProfileSetup.TimeMsResizeChange(int)'></a>

## IProfileSetup\.TimeMsResizeChange\(int\) Method

Time taken for the console to trigger a resize event after the console window has been resized\. 
This can be used to optimize performance by reducing the frequency of resize events, especially in scenarios where rapid resizing may occur\.
Default value is 300 milliseconds, Range valid 100\-1000 milliseconds\.

```csharp
ConsolePlusLibrary.IProfileSetup TimeMsResizeChange(int value);
```
#### Parameters

<a name='ConsolePlusLibrary.IProfileSetup.TimeMsResizeChange(int).value'></a>

`value` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The time in milliseconds to set for the resize event delay\.

#### Returns
[IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup')  
The current instance of [IProfileSetup](IProfileSetup.md 'ConsolePlusLibrary\.IProfileSetup') to allow for fluent configuration\.