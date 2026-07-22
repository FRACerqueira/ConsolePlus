<img src="https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png" width="120" alt="ConsolePlus" />

#### [ConsolePlus\.net](ConsolePlus.md 'ConsolePlus')
### [ConsolePlusLibrary](ConsolePlusLibrary.md 'ConsolePlusLibrary')

## ConsolePlusExtends Class

Extension methods for ConsolePlus, providing additional functionality to the IConsole interface\.

```csharp
public static class ConsolePlusExtends
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ConsolePlusExtends
### Methods

<a name='ConsolePlusLibrary.ConsolePlusExtends.ActionBeforeExist(thisConsolePlusLibrary.IConsole,System.Action_ConsolePlusLibrary.IConsole,System.Exception,bool_)'></a>

## ConsolePlusExtends\.ActionBeforeExist\(this IConsole, Action\<IConsole,Exception,bool\>\) Method

Registers a callback action to be invoked before the console exits, allowing for custom cleanup or final output\. 
The action receives the current console instance and a boolean indicating if Ctrl\+C was pressed as parameters\.

```csharp
public static void ActionBeforeExist(this ConsolePlusLibrary.IConsole console, System.Action<ConsolePlusLibrary.IConsole,System.Exception?,bool> action);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.ActionBeforeExist(thisConsolePlusLibrary.IConsole,System.Action_ConsolePlusLibrary.IConsole,System.Exception,bool_).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ActionBeforeExist(thisConsolePlusLibrary.IConsole,System.Action_ConsolePlusLibrary.IConsole,System.Exception,bool_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')

The action to be invoked before the console exits\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions)'></a>

## ConsolePlusExtends\.Banner\(this IConsole, string, string, Nullable\<Style\>, DashOptions\) Method

Draws a banner in the console with the specified text, font, dash options, and style\. A banner is a decorative element that can be used to highlight important information or create visual separation in the console output\. The method allows you to customize the appearance of the banner using different fonts, dash options, and styles\. The font is specified by providing the path to a FIGlet font file, which defines how the characters in the banner will be rendered\.

```csharp
public static void Banner(this ConsolePlusLibrary.IConsole console, string? text, string pathfontFiglet, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.None);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display within the banner\. If null, only the dashes are displayed\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).pathfontFiglet'></a>

`pathfontFiglet` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to the FIGlet font file to use for rendering the banner text\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the banner\. If null, the default style is used\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The options for the banner, such as border style\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions)'></a>

## ConsolePlusExtends\.Banner\(this IConsole, string, Stream, Nullable\<Style\>, DashOptions\) Method

Draws a banner in the console with the specified text, font stream, dash options, and style\. A banner is a decorative element that can be used to highlight important information or create visual separation in the console output\. The method allows you to customize the appearance of the banner using different fonts, dash options, and styles\. The font is specified by providing a stream containing a FIGlet font file, which defines how the characters in the banner will be rendered\.

```csharp
public static void Banner(this ConsolePlusLibrary.IConsole console, string? text, System.IO.Stream streamFontFiglet, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.None);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display within the banner\. If null, only the dashes are displayed\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).streamFontFiglet'></a>

`streamFontFiglet` [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream')

The stream containing the FIGlet font file to use for rendering the banner text\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the banner\. If null, the default style is used\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.IO.Stream,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The options for the banner, such as border style\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions)'></a>

## ConsolePlusExtends\.Banner\(this IConsole, string, Nullable\<Style\>, DashOptions\) Method

Draws a banner in the console with the specified text, dash options, and style\. A banner is a decorative element that can be used to highlight important information or create visual separation in the console output\. The method allows you to customize the appearance of the banner using different dash options and styles\.

```csharp
public static void Banner(this ConsolePlusLibrary.IConsole console, string? text, System.Nullable<ConsolePlusLibrary.Style> style=null, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.None);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display within the banner\. If null, only the dashes are displayed\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the banner\. If null, the default style is used\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Banner(thisConsolePlusLibrary.IConsole,string,System.Nullable_ConsolePlusLibrary.Style_,ConsolePlusLibrary.DashOptions).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The options for the banner, such as border style\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ClearLine(thisConsolePlusLibrary.IConsole,System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## ConsolePlusExtends\.ClearLine\(this IConsole, Nullable\<int\>, Nullable\<Style\>\) Method

Clears the current line in the console, optionally allowing you to specify a different row and style for the cleared line\. This can be useful for updating output in place or removing unwanted text from the console\.

```csharp
public static void ClearLine(this ConsolePlusLibrary.IConsole console, System.Nullable<int> row=null, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.ClearLine(thisConsolePlusLibrary.IConsole,System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ClearLine(thisConsolePlusLibrary.IConsole,System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_).row'></a>

`row` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The row number of the line to clear\. If null, the current line is cleared\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ClearLine(thisConsolePlusLibrary.IConsole,System.Nullable_int_,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the cleared line\. If null, the default style is used\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool)'></a>

## ConsolePlusExtends\.Dash\(this IConsole, string, DashOptions, Nullable\<Style\>, int, bool\) Method

Draws a dashed line in the console with the specified text, dash options, and style\.

```csharp
public static void Dash(this ConsolePlusLibrary.IConsole console, string? text, ConsolePlusLibrary.DashOptions dashOptions=ConsolePlusLibrary.DashOptions.SingleBorder, System.Nullable<ConsolePlusLibrary.Style> style=null, int extralines=0, bool applycolorbackground=false);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to display within the dashed line\. If null, only the dashes are displayed\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool).dashOptions'></a>

`dashOptions` [DashOptions](DashOptions.md 'ConsolePlusLibrary\.DashOptions')

The options for the dashed line, such as border style\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the dashed line\. If null, the default style is used\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool).extralines'></a>

`extralines` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of extra blank lines to append after the dashed line\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.Dash(thisConsolePlusLibrary.IConsole,string,ConsolePlusLibrary.DashOptions,System.Nullable_ConsolePlusLibrary.Style_,int,bool).applycolorbackground'></a>

`applycolorbackground` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, applies the background color across the full line\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.OutputError(thisConsolePlusLibrary.IConsole)'></a>

## ConsolePlusExtends\.OutputError\(this IConsole\) Method

Redirects the console output to the error stream, allowing you to capture and handle error messages separately from standard output\. This can be particularly useful for logging errors or displaying error messages in a different format or color\. The method returns an IDisposable that, when disposed, will restore the original console output stream\.

```csharp
public static System.IDisposable OutputError(this ConsolePlusLibrary.IConsole console);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.OutputError(thisConsolePlusLibrary.IConsole).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

#### Returns
[System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')  
An IDisposable that restores the original console output stream when disposed\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## ConsolePlusExtends\.ReadInlineEmacs\(this IConsole, Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>\) Method

Reads input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns input entered by the user as a string after the Enter key is pressed\.

```csharp
public static string ReadInlineEmacs(this ConsolePlusLibrary.IConsole console, System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The line of input entered by the user as a string\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken)'></a>

## ConsolePlusExtends\.ReadInlineEmacsAsync\(this IConsole, Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>, CancellationToken\) Method

Reads input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns the input entered by the user as a string after the Enter key is pressed\.

```csharp
public static System.Threading.Tasks.Task<string?> ReadInlineEmacsAsync(this ConsolePlusLibrary.IConsole console, System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The line of input entered by the user as a string\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_)'></a>

## ConsolePlusExtends\.ReadLineEmacs\(this IConsole, Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>\) Method

Reads a line of input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns the line of input entered by the user as a string after the Enter key is pressed\.

```csharp
public static string ReadLineEmacs(this ConsolePlusLibrary.IConsole console, System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The line of input entered by the user as a string\.

### Remarks
the new line is not included in the result, but it is included in the console output\. 
If you want to read a line of input without including the new line in the console output, you can use the [ReadInlineEmacs\(this IConsole, Func&lt;char,bool&gt;, CaseOptions, int, Nullable&lt;Style&gt;\)](ConsolePlusExtends.md#ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacs(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_) 'ConsolePlusLibrary\.ConsolePlusExtends\.ReadInlineEmacs\(this ConsolePlusLibrary\.IConsole, System\.Func\<char,bool\>, ConsolePlusLibrary\.CaseOptions, int, System\.Nullable\<ConsolePlusLibrary\.Style\>\)') method instead\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken)'></a>

## ConsolePlusExtends\.ReadLineEmacsAsync\(this IConsole, Func\<char,bool\>, CaseOptions, int, Nullable\<Style\>, CancellationToken\) Method

Reads a line of input from the console using Emacs\-style key bindings, allowing for more efficient and familiar text editing capabilities\. 
This method provides an enhanced input experience for users who are accustomed to Emacs key bindings, 
enabling them to navigate and edit their input more effectively\. 
The method returns the line of input entered by the user as a string after the Enter key is pressed\.

```csharp
public static System.Threading.Tasks.Task<string?> ReadLineEmacsAsync(this ConsolePlusLibrary.IConsole console, System.Func<char,bool>? acceptInput=null, ConsolePlusLibrary.CaseOptions caseOptions=ConsolePlusLibrary.CaseOptions.Any, int maxlength=int.MaxValue, System.Nullable<ConsolePlusLibrary.Style> style=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).acceptInput'></a>

`acceptInput` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to determine whether a character is accepted as input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).caseOptions'></a>

`caseOptions` [CaseOptions](CaseOptions.md 'ConsolePlusLibrary\.CaseOptions')

Specifies the case options for the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).maxlength'></a>

`maxlength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Specifies the maximum length of the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).style'></a>

`style` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Style](Style.md 'ConsolePlusLibrary\.Style')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The style to apply to the input\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.ReadLineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The line of input entered by the user as a string\.

### Remarks
the new line is not included in the result, but it is included in the console output\. 
If you want to read a line of input without including the new line in the console output, you can use the [ReadInlineEmacsAsync\(this IConsole, Func&lt;char,bool&gt;, CaseOptions, int, Nullable&lt;Style&gt;, CancellationToken\)](ConsolePlusExtends.md#ConsolePlusLibrary.ConsolePlusExtends.ReadInlineEmacsAsync(thisConsolePlusLibrary.IConsole,System.Func_char,bool_,ConsolePlusLibrary.CaseOptions,int,System.Nullable_ConsolePlusLibrary.Style_,System.Threading.CancellationToken) 'ConsolePlusLibrary\.ConsolePlusExtends\.ReadInlineEmacsAsync\(this ConsolePlusLibrary\.IConsole, System\.Func\<char,bool\>, ConsolePlusLibrary\.CaseOptions, int, System\.Nullable\<ConsolePlusLibrary\.Style\>, System\.Threading\.CancellationToken\)') method instead\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.WriteLines(thisConsolePlusLibrary.IConsole,int)'></a>

## ConsolePlusExtends\.WriteLines\(this IConsole, int\) Method

Writes a specified number of empty lines to the console, allowing for better readability and separation of output\.

```csharp
public static void WriteLines(this ConsolePlusLibrary.IConsole console, int steps=1);
```
#### Parameters

<a name='ConsolePlusLibrary.ConsolePlusExtends.WriteLines(thisConsolePlusLibrary.IConsole,int).console'></a>

`console` [IConsole](IConsole.md 'ConsolePlusLibrary\.IConsole')

The console instance to operate on\.

<a name='ConsolePlusLibrary.ConsolePlusExtends.WriteLines(thisConsolePlusLibrary.IConsole,int).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of empty lines to write\.