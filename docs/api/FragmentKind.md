<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## FragmentKind Enum

Identifies the semantic category of a [Fragment](Fragment.md 'ConsolePlusLibrary\.Fragment') during rendering\.

```csharp
public enum FragmentKind
```
### Fields

<a name='ConsolePlusLibrary.FragmentKind.ContentText'></a>

`ContentText` 0

Regular text content that is written to the output as\-is\.

<a name='ConsolePlusLibrary.FragmentKind.LineBreak'></a>

`LineBreak` 1

A line break that advances rendering to the next line\.

<a name='ConsolePlusLibrary.FragmentKind.ClearRestofline'></a>

`ClearRestofline` 2

A directive to clear the remainder of the current line from the cursor position\.