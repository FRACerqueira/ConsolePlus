<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## ConsoleKeyInfoExtensions Class

Provides extension methods for [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate specific key combinations,
including standard keys and Emacs\-style shortcuts\.

```csharp
public static class ConsoleKeyInfoExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ConsoleKeyInfoExtensions
### Methods

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsBackwardWord(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsBackwardWord\(this ConsoleKeyInfo\) Method

Determines whether the Alt\+B \(backward word\) Emacs shortcut was pressed\.

```csharp
public static bool IsBackwardWord(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsBackwardWord(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+B was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsCapitalizeOverCursor(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsCapitalizeOverCursor\(this ConsoleKeyInfo\) Method

Determines whether the Alt\+C \(capitalize over cursor\) Emacs shortcut was pressed\.

```csharp
public static bool IsCapitalizeOverCursor(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsCapitalizeOverCursor(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+C was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearAfterCursor(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsClearAfterCursor\(this ConsoleKeyInfo\) Method

Determines whether the Control\+K \(clear after cursor\) Emacs shortcut was pressed\.

```csharp
public static bool IsClearAfterCursor(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearAfterCursor(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+K was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearBeforeCursor(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsClearBeforeCursor\(this ConsoleKeyInfo\) Method

Determines whether the Control\+U \(clear before cursor\) Emacs shortcut was pressed\.

```csharp
public static bool IsClearBeforeCursor(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearBeforeCursor(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+U was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearContent(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsClearContent\(this ConsoleKeyInfo\) Method

Determines whether the Control\+L \(clear content\) Emacs shortcut was pressed\.

```csharp
public static bool IsClearContent(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearContent(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+L was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearWordAfterCursor(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsClearWordAfterCursor\(this ConsoleKeyInfo\) Method

Determines whether the Control\+D \(clear word after cursor\) Emacs shortcut was pressed\.

```csharp
public static bool IsClearWordAfterCursor(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearWordAfterCursor(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+D was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearWordBeforeCursor(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsClearWordBeforeCursor\(this ConsoleKeyInfo\) Method

Determines whether the Control\+W \(clear word before cursor\) Emacs shortcut was pressed\.

```csharp
public static bool IsClearWordBeforeCursor(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsClearWordBeforeCursor(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+W was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsForwardWord(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsForwardWord\(this ConsoleKeyInfo\) Method

Determines whether the Alt\+F \(forward word\) Emacs shortcut was pressed\.

```csharp
public static bool IsForwardWord(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsForwardWord(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+F was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsLowersCurrentWord(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsLowersCurrentWord\(this ConsoleKeyInfo\) Method

Determines whether the Alt\+L \(lower\-case word\) Emacs shortcut was pressed\.

```csharp
public static bool IsLowersCurrentWord(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsLowersCurrentWord(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+L was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressAltSpaceKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressAltSpaceKey\(this ConsoleKeyInfo\) Method

Determines whether Alt\+Spacebar was pressed\.

```csharp
public static bool IsPressAltSpaceKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressAltSpaceKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+Spacebar was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressAltTabKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressAltTabKey\(this ConsoleKeyInfo\) Method

Determines whether the Alt\+Tab key was pressed\.

```csharp
public static bool IsPressAltTabKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressAltTabKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+Tab was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressBackspaceKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressBackspaceKey\(this ConsoleKeyInfo, bool\) Method

Determines whether Backspace or \(optionally\) Control\+H \(Emacs delete previous character\) was pressed\.

```csharp
public static bool IsPressBackspaceKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressBackspaceKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressBackspaceKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+H\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Backspace \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCollapseKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCollapseKey\(this ConsoleKeyInfo\) Method

Determines whether the key represents a "collapse" action for tree controls\.

```csharp
public static bool IsPressCollapseKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCollapseKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` for Numpad Minus or '\-' character; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlAltSpaceKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlAltSpaceKey\(this ConsoleKeyInfo\) Method

Determines whether Control\+Alt\+Spacebar was pressed\.

```csharp
public static bool IsPressCtrlAltSpaceKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlAltSpaceKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+Alt\+Spacebar was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlAltTabKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlAltTabKey\(this ConsoleKeyInfo\) Method

Determines whether the Ctrl\+Alt\+Tab key was pressed\.

```csharp
public static bool IsPressCtrlAltTabKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlAltTabKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Ctrl\+Alt\+Tab was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlDeleteKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlDeleteKey\(this ConsoleKeyInfo\) Method

Determines whether Control\+Delete \(clear word after cursor\) was pressed\.

```csharp
public static bool IsPressCtrlDeleteKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlDeleteKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+Delete was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlEndKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlEndKey\(this ConsoleKeyInfo\) Method

Determines whether Control\+End was pressed\.

```csharp
public static bool IsPressCtrlEndKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlEndKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+End was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlHomeKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlHomeKey\(this ConsoleKeyInfo\) Method

Determines whether Control\+Home was pressed\.

```csharp
public static bool IsPressCtrlHomeKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlHomeKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+Home was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlSpaceKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlSpaceKey\(this ConsoleKeyInfo\) Method

Determines whether Control\+Spacebar was pressed\.

```csharp
public static bool IsPressCtrlSpaceKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlSpaceKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+Spacebar was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlTabKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressCtrlTabKey\(this ConsoleKeyInfo\) Method

Determines whether the Ctrl\+Tab key was pressed\.

```csharp
public static bool IsPressCtrlTabKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressCtrlTabKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Ctrl\+Tab was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressDeleteKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressDeleteKey\(this ConsoleKeyInfo, bool\) Method

Determines whether Delete or \(optionally\) Control\+D \(Emacs delete forward\) was pressed\.

```csharp
public static bool IsPressDeleteKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressDeleteKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressDeleteKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+D\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Delete \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressDownArrowKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressDownArrowKey\(this ConsoleKeyInfo, bool\) Method

Determines whether DownArrow or \(optionally\) Control\+N \(Emacs next line/history\) was pressed\.

```csharp
public static bool IsPressDownArrowKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressDownArrowKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressDownArrowKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+N\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if DownArrow \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEndKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressEndKey\(this ConsoleKeyInfo, bool\) Method

Determines whether End or \(optionally\) Control\+E \(Emacs end\-of\-line\) was pressed\.

```csharp
public static bool IsPressEndKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEndKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEndKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+E\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if End \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEnterKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressEnterKey\(this ConsoleKeyInfo, bool\) Method

Determines whether the pressed key represents an Enter action\.

```csharp
public static bool IsPressEnterKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEnterKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEnterKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+J as Enter \(Emacs style\)\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Enter \(or accepted Emacs equivalent\) was pressed; otherwise, `false`\.

### Remarks
On non\-Windows platforms both CR \(13\) and LF \(10\) may be emitted\. This method normalizes those cases\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEscKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressEscKey\(this ConsoleKeyInfo\) Method

Determines whether Escape \(without modifiers\) was pressed\.

```csharp
public static bool IsPressEscKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressEscKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Escape was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressExpandKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressExpandKey\(this ConsoleKeyInfo\) Method

Determines whether the key represents an "expand" action for tree controls\.

```csharp
public static bool IsPressExpandKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressExpandKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` for Numpad Plus or '\+' character; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressFilterActivationKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressFilterActivationKey\(this ConsoleKeyInfo\) Method

Determines whether the cross\-terminal filter activation key was pressed\.

```csharp
public static bool IsPressFilterActivationKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressFilterActivationKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` for Ctrl\+Alt\+Spacebar \(primary\) or Ctrl\+Spacebar \(fallback for terminals
            that do not report Ctrl\+Alt\+Spacebar consistently\); otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressHomeKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressHomeKey\(this ConsoleKeyInfo, bool\) Method

Determines whether Home or \(optionally\) Control\+A \(Emacs beginning\-of\-line\) was pressed\.

```csharp
public static bool IsPressHomeKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressHomeKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressHomeKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+A\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Home \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressLeftArrowKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressLeftArrowKey\(this ConsoleKeyInfo, bool\) Method

Determines whether LeftArrow or \(optionally\) Control\+B \(Emacs move backward\) was pressed\.

```csharp
public static bool IsPressLeftArrowKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressLeftArrowKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressLeftArrowKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+B\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if LeftArrow \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressPageDownKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressPageDownKey\(this ConsoleKeyInfo, bool\) Method

Determines whether PageDown or \(optionally\) Alt\+N \(Emacs next extended navigation\) was pressed\.

```csharp
public static bool IsPressPageDownKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressPageDownKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressPageDownKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Alt\+N\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if PageDown \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressPageUpKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressPageUpKey\(this ConsoleKeyInfo, bool\) Method

Determines whether PageUp or \(optionally\) Alt\+P \(Emacs previous extended navigation\) was pressed\.

```csharp
public static bool IsPressPageUpKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressPageUpKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressPageUpKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Alt\+P\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if PageUp \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressRightArrowKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressRightArrowKey\(this ConsoleKeyInfo, bool\) Method

Determines whether RightArrow or \(optionally\) Control\+F \(Emacs move forward\) was pressed\.

```csharp
public static bool IsPressRightArrowKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressRightArrowKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressRightArrowKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+F\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if RightArrow \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressShiftTabKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressShiftTabKey\(this ConsoleKeyInfo\) Method

Determines whether Shift\+Tab was pressed\.

```csharp
public static bool IsPressShiftTabKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressShiftTabKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Shift\+Tab was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpaceKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressSpaceKey\(this ConsoleKeyInfo\) Method

Determines whether Spacebar \(without modifiers\) was pressed\.

```csharp
public static bool IsPressSpaceKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpaceKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Spacebar was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpecialKey(thisSystem.ConsoleKeyInfo,System.ConsoleKey,System.ConsoleModifiers)'></a>

## ConsoleKeyInfoExtensions\.IsPressSpecialKey\(this ConsoleKeyInfo, ConsoleKey, ConsoleModifiers\) Method

Determines whether the pressed key matches the specified [key](ConsoleKeyInfoExtensions.md#ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpecialKey(thisSystem.ConsoleKeyInfo,System.ConsoleKey,System.ConsoleModifiers).key 'ConsolePlusLibrary\.ConsoleKeyInfoExtensions\.IsPressSpecialKey\(this System\.ConsoleKeyInfo, System\.ConsoleKey, System\.ConsoleModifiers\)\.key') and [modifier](ConsoleKeyInfoExtensions.md#ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpecialKey(thisSystem.ConsoleKeyInfo,System.ConsoleKey,System.ConsoleModifiers).modifier 'ConsolePlusLibrary\.ConsoleKeyInfoExtensions\.IsPressSpecialKey\(this System\.ConsoleKeyInfo, System\.ConsoleKey, System\.ConsoleModifiers\)\.modifier')\.

```csharp
public static bool IsPressSpecialKey(this System.ConsoleKeyInfo keyinfo, System.ConsoleKey key, System.ConsoleModifiers modifier);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpecialKey(thisSystem.ConsoleKeyInfo,System.ConsoleKey,System.ConsoleModifiers).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpecialKey(thisSystem.ConsoleKeyInfo,System.ConsoleKey,System.ConsoleModifiers).key'></a>

`key` [System\.ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey 'System\.ConsoleKey')

The expected [System\.ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey 'System\.ConsoleKey')\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressSpecialKey(thisSystem.ConsoleKeyInfo,System.ConsoleKey,System.ConsoleModifiers).modifier'></a>

`modifier` [System\.ConsoleModifiers](https://learn.microsoft.com/en-us/dotnet/api/system.consolemodifiers 'System\.ConsoleModifiers')

The expected [System\.ConsoleModifiers](https://learn.microsoft.com/en-us/dotnet/api/system.consolemodifiers 'System\.ConsoleModifiers')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if both key and modifier match; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressTabKey(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsPressTabKey\(this ConsoleKeyInfo\) Method

Determines whether the Tab key \(without modifiers\) was pressed\.

```csharp
public static bool IsPressTabKey(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressTabKey(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Tab was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressUpArrowKey(thisSystem.ConsoleKeyInfo,bool)'></a>

## ConsoleKeyInfoExtensions\.IsPressUpArrowKey\(this ConsoleKeyInfo, bool\) Method

Determines whether UpArrow or \(optionally\) Control\+P \(Emacs previous line/history\) was pressed\.

```csharp
public static bool IsPressUpArrowKey(this System.ConsoleKeyInfo keyinfo, bool emacskeys=true);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressUpArrowKey(thisSystem.ConsoleKeyInfo,bool).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsPressUpArrowKey(thisSystem.ConsoleKeyInfo,bool).emacskeys'></a>

`emacskeys` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If `true`, also accepts Control\+P\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if UpArrow \(or Emacs equivalent\) was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsTransposePrevious(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsTransposePrevious\(this ConsoleKeyInfo\) Method

Determines whether the Control\+T \(transpose previous characters\) Emacs shortcut was pressed\.

```csharp
public static bool IsTransposePrevious(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsTransposePrevious(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Control\+T was pressed; otherwise, `false`\.

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsUppersCurrentWord(thisSystem.ConsoleKeyInfo)'></a>

## ConsoleKeyInfoExtensions\.IsUppersCurrentWord\(this ConsoleKeyInfo\) Method

Determines whether the Alt\+U \(upper\-case word\) Emacs shortcut was pressed\.

```csharp
public static bool IsUppersCurrentWord(this System.ConsoleKeyInfo keyinfo);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsoleKeyInfoExtensions.IsUppersCurrentWord(thisSystem.ConsoleKeyInfo).keyinfo'></a>

`keyinfo` [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo')

The [System\.ConsoleKeyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.consolekeyinfo 'System\.ConsoleKeyInfo') to evaluate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if Alt\+U was pressed; otherwise, `false`\.