// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using ConsolePlusLibrary.Figlet;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsolePlusLibrary
{
    /// <summary>
    /// Extension methods for ConsolePlus, providing additional functionality to the IConsole interface.
    /// </summary>
    public static partial class ConsolePlusExtends
    {
        /// <summary>
        /// Registers a callback action to be invoked before the console exits, allowing for custom cleanup or final output. 
        /// The action receives the current console instance and a boolean indicating if Ctrl+C was pressed as parameters.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="action">The action to be invoked before the console exits.</param>
#pragma warning disable IDE0060 // Remove unused parameter
        public static void ActionBeforeExist(this IConsole console, Action<IConsole,Exception?,bool> action)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            ConsolePlus.ActionBeforeExitValue = action;
        }


        /// <summary>
        /// Writes a specified number of empty lines to the console, allowing for better readability and separation of output.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="steps">The number of empty lines to write.</param>
        public static void WriteLines(this IConsole console, int steps = 1)
        {
            ConsolePlus.Envlock.Run(() =>
            {
                if (steps < 1)
                {
                    return;
                }
                var segments = new List<Fragment>
                {
                    new("", null, FragmentKind.ClearRestofline),
                    new("", null, FragmentKind.LineBreak)
                };
                for (int i = 0; i < steps - 1; i++)
                {
                    segments.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                    segments.Add(new Fragment("", null, FragmentKind.LineBreak));
                }
                ((IConsolePlus)console).Writer.WriteOutput([.. segments]);
            });
        }

        /// <summary>
        /// Clears the current line in the console, optionally allowing you to specify a different row and style for the cleared line. This can be useful for updating output in place or removing unwanted text from the console.  
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="row">The row number of the line to clear. If null, the current line is cleared.</param>
        /// <param name="style">The style to apply to the cleared line. If null, the default style is used.</param>
        public static void ClearLine(this IConsole console, int? row = null, Style? style = null)
		{
            ConsolePlus.Envlock.Run(() =>
            {
                console.ClearLine(row, style);
                row ??= console.CursorTop;
                var currentstyle = console.CurrentStyle;
                var effectiveStyle = style ?? currentstyle;
                ((IConsolePlus)console).Writer.ApplyStyle(effectiveStyle);
                console.SetCursorPosition(0, row.Value);
                var segments = new List<Fragment>
                {
                    new("", null, FragmentKind.ClearRestofline),
                };
                ((IConsolePlus)console).Writer.WriteOutput([.. segments]);
                ((IConsolePlus)console).Writer.ApplyStyle(currentstyle);
            });
        }

        /// <summary>
        /// Redirects the console output to the error stream, allowing you to capture and handle error messages separately from standard output. This can be particularly useful for logging errors or displaying error messages in a different format or color. The method returns an IDisposable that, when disposed, will restore the original console output stream.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <returns>An IDisposable that restores the original console output stream when disposed.</returns>
        public static IDisposable OutputError(this IConsole console)
        {
            return ConsolePlus.Envlock.Run(() =>
            {
                return new RedirectToErrorOutput((IConsolePlus)console);
            });
        }

        /// <summary>
        /// Draws a dashed line in the console with the specified text, dash options, and style.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="text">The text to display within the dashed line. If null, only the dashes are displayed.</param>
        /// <param name="dashOptions">The options for the dashed line, such as border style.</param>
        /// <param name="style">The style to apply to the dashed line. If null, the default style is used.</param>
        /// <param name="extralines">The number of extra blank lines to append after the dashed line.</param>
        /// <param name="applycolorbackground">If true, applies the background color across the full line.</param>
        public static void Dash(this IConsole console, string? text, DashOptions dashOptions = DashOptions.SingleBorder, Style? style = null, int extralines = 0, bool applycolorbackground = false)
        {
            ConsolePlus.Envlock.Run(() =>
            {
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                var _style = style ?? console.CurrentStyle;
                var lines = text.SplitLines();
                var segments = new List<Fragment>();
                var maxlength = 0;
                foreach (var line in lines)
                {
                    var len = Markup.Length(line);
                    if (maxlength < len)
                    {
                        maxlength = len;
                    }
                }
                var borderUp = DashUtil.GetBorderUp(console, dashOptions);
                if (!string.IsNullOrWhiteSpace(borderUp))
                {
                    segments.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                    segments.Add(new Fragment(new string(borderUp[0], maxlength), _style.Overflow(Overflow.Crop)));
                    segments.Add(new Fragment("", null, FragmentKind.LineBreak));
                }

                foreach (var line in lines)
                {
                    segments.AddRange(Fragment.FromText(line, _style, true));
                    segments.Add(new Fragment("", null, FragmentKind.LineBreak));
                }

                var borderDown = DashUtil.GetBorderDown(console, dashOptions);
                if (!string.IsNullOrWhiteSpace(borderDown))
                {
                    segments.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                    segments.Add(new Fragment(new string(borderDown[0], maxlength), _style.Overflow(Overflow.Crop)));
                    segments.Add(new Fragment("", null, FragmentKind.LineBreak));
                }
                ((IConsolePlus)console).Writer.WriteOutput([.. segments]);
                if (style.HasValue && applycolorbackground)
                {
                    console.ForegroundColor = style.Value.Foreground;
                    console.BackgroundColor = style.Value.Background;
                }
                if (extralines > 0)
                {
                    segments.Clear();
                    for (int i = 0; i < extralines; i++)
                    {
                        segments.Add(new Fragment("", null, FragmentKind.ClearRestofline));
                        segments.Add(new Fragment("", null, FragmentKind.LineBreak));
                    }
                    ((IConsolePlus)console).Writer.WriteOutput([.. segments]);
                }
            });
        }

        /// <summary>
        /// Draws a banner in the console with the specified text, dash options, and style. A banner is a decorative element that can be used to highlight important information or create visual separation in the console output. The method allows you to customize the appearance of the banner using different dash options and styles.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="text">The text to display within the banner. If null, only the dashes are displayed.</param>
        /// <param name="style">The style to apply to the banner. If null, the default style is used.</param>
        /// <param name="dashOptions">The options for the banner, such as border style.</param>
        public static void Banner(this IConsole console, string? text, Style? style = null, DashOptions dashOptions = DashOptions.None)
        {
            ConsolePlus.Envlock.Run(() =>
            {
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                var banner = new BannerWidget((IConsolePlus)console, text, style ?? ((IConsolePlus)console).CurrentStyle);
                banner.Border(dashOptions);
                banner.Show();
            });
        }

        /// <summary>
        /// Draws a banner in the console with the specified text, font, dash options, and style. A banner is a decorative element that can be used to highlight important information or create visual separation in the console output. The method allows you to customize the appearance of the banner using different fonts, dash options, and styles. The font is specified by providing the path to a FIGlet font file, which defines how the characters in the banner will be rendered.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="text">The text to display within the banner. If null, only the dashes are displayed.</param>
        /// <param name="pathfontFiglet">The path to the FIGlet font file to use for rendering the banner text.</param>
        /// <param name="style">The style to apply to the banner. If null, the default style is used.</param>
        /// <param name="dashOptions">The options for the banner, such as border style.</param>
        public static void Banner(this IConsole console, string? text, string pathfontFiglet, Style? style = null, DashOptions dashOptions = DashOptions.None)
        {
            ConsolePlus.Envlock.Run(() =>
            {
                if (string.IsNullOrEmpty(pathfontFiglet))
                {
                    throw new ArgumentException("Path to Figlet font cannot be null or empty.", nameof(pathfontFiglet));
                }
                if (!File.Exists(pathfontFiglet))
                {
                    throw new ArgumentException("Path to Figlet font does not exist.", nameof(pathfontFiglet));
                }
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                var banner = new BannerWidget((IConsolePlus)console, text, style ?? ((IConsolePlus)console).CurrentStyle);
                banner.Border(dashOptions);
                banner.FromFont(pathfontFiglet);
                banner.Show();
            });
        }

        /// <summary>
        /// Draws a banner in the console with the specified text, font stream, dash options, and style. A banner is a decorative element that can be used to highlight important information or create visual separation in the console output. The method allows you to customize the appearance of the banner using different fonts, dash options, and styles. The font is specified by providing a stream containing a FIGlet font file, which defines how the characters in the banner will be rendered.
        /// </summary>
        /// <param name="console">The console instance to operate on.</param>
        /// <param name="text">The text to display within the banner. If null, only the dashes are displayed.</param>
        /// <param name="streamFontFiglet">The stream containing the FIGlet font file to use for rendering the banner text.</param>
        /// <param name="dashOptions">The options for the banner, such as border style.</param>
        /// <param name="style">The style to apply to the banner. If null, the default style is used.</param>
        public static void Banner(this IConsole console, string? text, Stream streamFontFiglet, Style? style = null, DashOptions dashOptions = DashOptions.None)
        {
            ConsolePlus.Envlock.Run(() =>
            {
                if (streamFontFiglet == null)
                {
                    throw new ArgumentException("Stream to Figlet font cannot be null.", nameof(streamFontFiglet));
                }
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                var banner = new BannerWidget((IConsolePlus)console, text, style ?? ((IConsolePlus)console).CurrentStyle);
                banner.Border(dashOptions);
                banner.FromFont(streamFontFiglet);
                banner.Show();
            });
        }

    }
}
