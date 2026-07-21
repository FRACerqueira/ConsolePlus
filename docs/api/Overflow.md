<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## Overflow Enum

Specifies how text overflow should be handled\.

```csharp
public enum Overflow
```
### Fields

<a name='ConsolePlusLibrary.Overflow.None'></a>

`None` 0

No overflow handling\. Excess characters are placed on the next line\.

<a name='ConsolePlusLibrary.Overflow.Crop'></a>

`Crop` 1

Truncates the text at the end of the line\.

<a name='ConsolePlusLibrary.Overflow.Ellipsis'></a>

`Ellipsis` 2

Truncates the text at the end of the line and appends an ellipsis character\.