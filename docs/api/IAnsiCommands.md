<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## IAnsiCommands Interface

Provides methods for emitting ANSI escape codes to control the console output\.

```csharp
public interface IAnsiCommands
```
### Methods

<a name='ConsolePlusLibrary.IAnsiCommands.ClearScrollback()'></a>

## IAnsiCommands\.ClearScrollback\(\) Method

Clears the scrollback buffer by emitting `CSI 3J`\.

```csharp
void ClearScrollback();
```

<a name='ConsolePlusLibrary.IAnsiCommands.CursorBackward(int)'></a>

## IAnsiCommands\.CursorBackward\(int\) Method

This control function moves the cursor to the left by a specified number of columns
by emitting `CSI n D`\.
The cursor stops at the left border of the page\.

```csharp
void CursorBackward(int steps);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorBackward(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of steps to move the cursor backward\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUB](https://vt100.net/docs/vt100-ug/chapter3.html#CUB 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUB')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorBackwardTabulation(int)'></a>

## IAnsiCommands\.CursorBackwardTabulation\(int\) Method

Move the active position n tabs backward
by emitting `CSI n Z`\.

```csharp
void CursorBackwardTabulation(int tabs=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorBackwardTabulation(int).tabs'></a>

`tabs` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of tabs to move backwards

### Remarks
See [https://vt100\.net/docs/vt510\-rm/CBT\.html](https://vt100.net/docs/vt510-rm/CBT.html 'https://vt100\.net/docs/vt510\-rm/CBT\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorDown(int)'></a>

## IAnsiCommands\.CursorDown\(int\) Method

This control function moves the cursor down a specified number of lines in the same column
by emitting `CSI n B`\.
The cursor stops at the bottom margin\.
If the cursor is already below the bottom margin, then the cursor stops at the bottom line\.

```csharp
void CursorDown(int steps);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorDown(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of steps to move the cursor down\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUD](https://vt100.net/docs/vt100-ug/chapter3.html#CUD 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUD')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorForward(int)'></a>

## IAnsiCommands\.CursorForward\(int\) Method

This control function moves the cursor to the right by a specified number of columns
by emitting `CSI n C`\.
The cursor stops at the right border of the page\.

```csharp
void CursorForward(int steps);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorForward(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of steps to move the cursor right\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUF](https://vt100.net/docs/vt100-ug/chapter3.html#CUF 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUF')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorHome()'></a>

## IAnsiCommands\.CursorHome\(\) Method

Moves the cursor to position 1,1 \(top left corner\) by emitting `CSI H`\.

```csharp
void CursorHome();
```

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUP](https://vt100.net/docs/vt100-ug/chapter3.html#CUP 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUP')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorHorizontalAbsolute(int)'></a>

## IAnsiCommands\.CursorHorizontalAbsolute\(int\) Method

Moves the active position to the n\-th character of the active line
by emitting `CSI n G`

```csharp
void CursorHorizontalAbsolute(int position);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorHorizontalAbsolute(int).position'></a>

`position` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The horizontal position\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/CHA\.html](https://vt100.net/docs/vt510-rm/CHA.html 'https://vt100\.net/docs/vt510\-rm/CHA\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorHorizontalTabulation(int)'></a>

## IAnsiCommands\.CursorHorizontalTabulation\(int\) Method

Move the active position n tabs forward
by emitting `CSI n I`\.

```csharp
void CursorHorizontalTabulation(int tabs=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorHorizontalTabulation(int).tabs'></a>

`tabs` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of tabs to move forward

### Remarks
See [https://vt100\.net/docs/vt510\-rm/CHT\.html](https://vt100.net/docs/vt510-rm/CHT.html 'https://vt100\.net/docs/vt510\-rm/CHT\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorLeft(int)'></a>

## IAnsiCommands\.CursorLeft\(int\) Method

This control function moves the cursor to the left by a specified number of columns
by emitting `CSI n D`\.
The cursor stops at the left border of the page\.

```csharp
void CursorLeft(int steps);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorLeft(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of steps to move the cursor left\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUB](https://vt100.net/docs/vt100-ug/chapter3.html#CUB 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUB')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorNextLine(int)'></a>

## IAnsiCommands\.CursorNextLine\(int\) Method

Move the cursor to the next line
by emitting `CSI n E`\.

```csharp
void CursorNextLine(int lines=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorNextLine(int).lines'></a>

`lines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of lines to move

### Remarks
See [https://vt100\.net/docs/vt510\-rm/CNL\.html](https://vt100.net/docs/vt510-rm/CNL.html 'https://vt100\.net/docs/vt510\-rm/CNL\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorPosition(int,int)'></a>

## IAnsiCommands\.CursorPosition\(int, int\) Method

This control function moves the cursor to the specified line and column \(1\-indexed\)
by emitting `CSI row;column H`\.

```csharp
void CursorPosition(int row, int column);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorPosition(int,int).row'></a>

`row` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The row\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorPosition(int,int).column'></a>

`column` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The column\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUP](https://vt100.net/docs/vt100-ug/chapter3.html#CUP 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUP')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorPreviousLine(int)'></a>

## IAnsiCommands\.CursorPreviousLine\(int\) Method

Move the cursor to the preceding line
by emitting `CSI n F`\.

```csharp
void CursorPreviousLine(int lines=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorPreviousLine(int).lines'></a>

`lines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of lines to move

### Remarks
See [https://vt100\.net/docs/vt510\-rm/CPL\.html](https://vt100.net/docs/vt510-rm/CPL.html 'https://vt100\.net/docs/vt510\-rm/CPL\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorRight(int)'></a>

## IAnsiCommands\.CursorRight\(int\) Method

This control function moves the cursor to the right by a specified number of columns
by emitting `CSI n C`\.
The cursor stops at the right border of the page\.

```csharp
void CursorRight(int steps);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorRight(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of steps to move the cursor right\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUF](https://vt100.net/docs/vt100-ug/chapter3.html#CUF 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUF')\.

<a name='ConsolePlusLibrary.IAnsiCommands.CursorUp(int)'></a>

## IAnsiCommands\.CursorUp\(int\) Method

Moves the cursor up a specified number of lines in the same column by emitting `CSI n A`\.
The cursor stops at the top margin\.
If the cursor is already above the top margin, then the cursor stops at the top line\.

```csharp
void CursorUp(int steps);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.CursorUp(int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of steps to move the cursor up\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUU](https://vt100.net/docs/vt100-ug/chapter3.html#CUU 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#CUU')\.

<a name='ConsolePlusLibrary.IAnsiCommands.DeleteCharacter(int)'></a>

## IAnsiCommands\.DeleteCharacter\(int\) Method

This control function deletes one or more characters from the cursor position to the right
by emitting `CSI n P`\.

```csharp
void DeleteCharacter(int characters=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.DeleteCharacter(int).characters'></a>

`characters` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to delete\. If [characters](IAnsiCommands.md#ConsolePlusLibrary.IAnsiCommands.DeleteCharacter(int).characters 'ConsolePlusLibrary\.IAnsiCommands\.DeleteCharacter\(int\)\.characters') is greater than the number of characters between the cursor and the right margin, then DCH only deletes the remaining characters\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/DCH\.html](https://vt100.net/docs/vt510-rm/DCH.html 'https://vt100\.net/docs/vt510\-rm/DCH\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.DeleteLine(int)'></a>

## IAnsiCommands\.DeleteLine\(int\) Method

This control function deletes one or more lines in the scrolling region
by emitting `CSI n M`, starting with the line that has the cursor\.
As lines are deleted, lines below the cursor and in the scrolling region move up\.
The terminal adds blank lines with no visual character attributes at the bottom of the scrolling region\.
If `lines` is greater than the number of lines remaining on the page, DL deletes only the remaining lines\.
DL has no effect outside the scrolling margins\.

```csharp
void DeleteLine(int lines=0);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.DeleteLine(int).lines'></a>

`lines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of lines to delete\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/DL\.html](https://vt100.net/docs/vt510-rm/DL.html 'https://vt100\.net/docs/vt510\-rm/DL\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.EnterAltScreen()'></a>

## IAnsiCommands\.EnterAltScreen\(\) Method

Enters the alternative screen buffer by emitting `CSI ? 1049 h`\.

```csharp
void EnterAltScreen();
```

<a name='ConsolePlusLibrary.IAnsiCommands.EraseCharacter(int)'></a>

## IAnsiCommands\.EraseCharacter\(int\) Method

Erases one or more characters from the cursor position to the right by emitting `CSI n X` \(ECH\)\.
ECH clears character attributes from erased character positions\.
ECH works inside or outside the scrolling margins\.

```csharp
void EraseCharacter(int characters=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.EraseCharacter(int).characters'></a>

`characters` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to erase\. A value of 0 or 1 erases one character\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/ECH\.html](https://vt100.net/docs/vt510-rm/ECH.html 'https://vt100\.net/docs/vt510\-rm/ECH\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.EraseInDisplay(int)'></a>

## IAnsiCommands\.EraseInDisplay\(int\) Method

This control function erases characters from part or all of the display\.
When you erase complete lines, they become single\-height, single\-width lines,
with all visual character attributes cleared\.
ED works inside or outside the scrolling margins\.

```csharp
void EraseInDisplay(int mode=0);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.EraseInDisplay(int).mode'></a>

`mode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The amount of the display to erase\.

<a name='ConsolePlusLibrary.IAnsiCommands.EraseInLine(int)'></a>

## IAnsiCommands\.EraseInLine\(int\) Method

This control function erases characters on the line that has the cursor\.
EL clears all character attributes from erased character positions\.
EL works inside or outside the scrolling margins\.

```csharp
void EraseInLine(int mode=0);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.EraseInLine(int).mode'></a>

`mode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The section of the line to erase\.

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#EL](https://vt100.net/docs/vt100-ug/chapter3.html#EL 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#EL')\.

<a name='ConsolePlusLibrary.IAnsiCommands.ExitAltScreen()'></a>

## IAnsiCommands\.ExitAltScreen\(\) Method

Exits the alternative screen buffer by emitting `CSI ? 1049 l`\.

```csharp
void ExitAltScreen();
```

<a name='ConsolePlusLibrary.IAnsiCommands.HideCursor()'></a>

## IAnsiCommands\.HideCursor\(\) Method

Hides the cursor by emitting `CSI ? 25 l`\.

```csharp
void HideCursor();
```

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#RM](https://vt100.net/docs/vt100-ug/chapter3.html#RM 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#RM')\.

<a name='ConsolePlusLibrary.IAnsiCommands.Index()'></a>

## IAnsiCommands\.Index\(\) Method

Moves the cursor down one line in the same column by emitting `ESC D`\.
If the cursor is at the bottom margin, then the screen performs a scroll\-up\.

```csharp
void Index();
```

### Remarks
See [https://vt100\.net/docs/vt510\-rm/IND\.html](https://vt100.net/docs/vt510-rm/IND.html 'https://vt100\.net/docs/vt510\-rm/IND\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.InsertCharacter(int)'></a>

## IAnsiCommands\.InsertCharacter\(int\) Method

inserts one or more space \(SP\) characters starting at the cursor position
by emitting `CSI n @` \(ICH\)\.
The ICH sequence inserts blank characters with the normal character attribute\.
The cursor remains at the beginning of the blank characters\.
Text between the cursor and right margin moves to the right\.
Characters scrolled past the right margin are lost\. ICH has no effect outside the scrolling margins\.

```csharp
void InsertCharacter(int characters=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.InsertCharacter(int).characters'></a>

`characters` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to insert\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/ICH\.html](https://vt100.net/docs/vt510-rm/ICH.html 'https://vt100\.net/docs/vt510\-rm/ICH\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.InsertLine(int)'></a>

## IAnsiCommands\.InsertLine\(int\) Method

Inserts one or more blank lines, starting at the cursor by emitting `CSI n L` \(IL\)\.
As lines are inserted, lines below the cursor and in the scrolling region move down\.
Lines scrolled off the page are lost\. IL has no effect outside the page margins\.

```csharp
void InsertLine(int lines=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.InsertLine(int).lines'></a>

`lines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of lines to insert\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/IL\.html](https://vt100.net/docs/vt510-rm/IL.html 'https://vt100\.net/docs/vt510\-rm/IL\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.RestoreCursor(bool)'></a>

## IAnsiCommands\.RestoreCursor\(bool\) Method

Moves cursor to the position saved by save cursor command in SCO console mode
by emitting `CSI u` \(SCORC\) if staying on page, otherwise `ESC 8` \(DECRC\)\.

```csharp
void RestoreCursor(bool stayOnPage=true);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.RestoreCursor(bool).stayOnPage'></a>

`stayOnPage` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to keep the cursor on the current page\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/SCORC\.html](https://vt100.net/docs/vt510-rm/SCORC.html 'https://vt100\.net/docs/vt510\-rm/SCORC\.html') and
[https://vt100\.net/docs/vt510\-rm/DECRC\.html](https://vt100.net/docs/vt510-rm/DECRC.html 'https://vt100\.net/docs/vt510\-rm/DECRC\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.ReverseIndex()'></a>

## IAnsiCommands\.ReverseIndex\(\) Method

Moves the cursor up one line in the same column by emitting `ESC M`\.
If the cursor is at the top margin, then the screen performs a scroll\-down\.

```csharp
void ReverseIndex();
```

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#RI](https://vt100.net/docs/vt100-ug/chapter3.html#RI 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#RI')\.

<a name='ConsolePlusLibrary.IAnsiCommands.SaveCursor(bool)'></a>

## IAnsiCommands\.SaveCursor\(bool\) Method

Saves current cursor position for SCO console mode by emitting `CSI s` \(SCOSC\)
if staying on page, otherwise `ESC 7` \(DECSC\)\.

```csharp
void SaveCursor(bool stayOnPage=true);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.SaveCursor(bool).stayOnPage'></a>

`stayOnPage` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether to keep the cursor on the current page\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/SCOSC\.html](https://vt100.net/docs/vt510-rm/SCOSC.html 'https://vt100\.net/docs/vt510\-rm/SCOSC\.html') and
[https://vt100\.net/docs/vt510\-rm/DECSC\.html](https://vt100.net/docs/vt510-rm/DECSC.html 'https://vt100\.net/docs/vt510\-rm/DECSC\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.ScrollDown(int)'></a>

## IAnsiCommands\.ScrollDown\(int\) Method

Moves the user window down a specified number of lines in page memory
by emitting `CSI n S`\.

```csharp
void ScrollDown(int lines=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.ScrollDown(int).lines'></a>

`lines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of lines to move the user window down in page memory\.
`lines` new lines appear at the bottom of the display\.
`lines` old lines disappear at the top of the display\.
You cannot pan past the bottom margin of the current page\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/SU\.html](https://vt100.net/docs/vt510-rm/SU.html 'https://vt100\.net/docs/vt510\-rm/SU\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.ScrollUp(int)'></a>

## IAnsiCommands\.ScrollUp\(int\) Method

Moves the user window up a specified number of lines in page memory
by emitting `CSI n T`\.

```csharp
void ScrollUp(int lines=1);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.ScrollUp(int).lines'></a>

`lines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of lines to move the user window up in page memory\.
`lines` new lines appear at the top of the display\.
`lines` old lines disappear at the bottom of the display\.
You cannot pan past the top margin of the current page\.

### Remarks
See [https://vt100\.net/docs/vt510\-rm/SD\.html](https://vt100.net/docs/vt510-rm/SD.html 'https://vt100\.net/docs/vt510\-rm/SD\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.SetCursorStyle(int)'></a>

## IAnsiCommands\.SetCursorStyle\(int\) Method

Select the style of the cursor on the screen by emitting `CSI n SP q`

```csharp
void SetCursorStyle(int style=0);
```
#### Parameters

<a name='ConsolePlusLibrary.IAnsiCommands.SetCursorStyle(int).style'></a>

`style` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The style of the cursor

### Remarks
See [https://vt100\.net/docs/vt510\-rm/DECSCUSR\.html](https://vt100.net/docs/vt510-rm/DECSCUSR.html 'https://vt100\.net/docs/vt510\-rm/DECSCUSR\.html')\.

<a name='ConsolePlusLibrary.IAnsiCommands.ShowCursor()'></a>

## IAnsiCommands\.ShowCursor\(\) Method

Shows the cursor by emitting `CSI ? 25 h`\.

```csharp
void ShowCursor();
```

### Remarks
See [https://vt100\.net/docs/vt100\-ug/chapter3\.html\#SM](https://vt100.net/docs/vt100-ug/chapter3.html#SM 'https://vt100\.net/docs/vt100\-ug/chapter3\.html\#SM')\.