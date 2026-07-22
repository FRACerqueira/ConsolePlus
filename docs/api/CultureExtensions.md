<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## CultureExtensions Class

Provides extension methods for working with culture names\.

```csharp
public static class CultureExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CultureExtensions
### Methods

<a name='ConsolePlusLibrary.CultureExtensions.ExistsCulture(thisstring)'></a>

## CultureExtensions\.ExistsCulture\(this string\) Method

Determines whether the specified culture name corresponds to a valid culture recognized by the \.NET
framework\.

```csharp
public static bool ExistsCulture(this string name);
```
#### Parameters

<a name='ConsolePlusLibrary.CultureExtensions.ExistsCulture(thisstring).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The culture name to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
true if the specified culture name is valid and recognized; otherwise, false\.

### Remarks
This method does not throw an exception for invalid or unrecognized culture names\.
            Use this method to safely check for culture existence before performing culture\-specific
            operations\.