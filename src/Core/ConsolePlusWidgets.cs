// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.IO;

namespace ConsolePlusLibrary.Core
{
    /// <summary>
    /// Default <see cref="IWidgets"/> implementation backing <see cref="ConsolePlus.Widgets"/>.
    /// </summary>
    /// <param name="console">The console instance the produced widgets render to.</param>
    internal sealed class ConsolePlusWidgets(IConsole console) : IWidgets
    {
        /// <inheritdoc/>
        public IBanner Banner(string text, Style? style = null) => new BannerBuilder(console, text, style);

        /// <inheritdoc/>
        public IStringDash Dash(string text, Style? style = null) => new StringDashBuilder(console, text, style);
    }

    /// <summary>
    /// Default <see cref="IBanner"/> implementation, deferring the actual render to
    /// <see cref="Show"/> so <see cref="FromFont(string)"/>/<see cref="FromFont(Stream)"/> and
    /// <see cref="Border"/> can be chained beforehand.
    /// </summary>
    internal sealed class BannerBuilder(IConsole console, string text, Style? style) : IBanner
    {
        private string? _fontPath;
        private Stream? _fontStream;
        private DashOptions _dashOptions = DashOptions.None;

        /// <inheritdoc/>
        public IBanner FromFont(string filepathFont)
        {
            _fontPath = filepathFont;
            _fontStream = null;
            return this;
        }

        /// <inheritdoc/>
        public IBanner FromFont(Stream streamFont)
        {
            _fontStream = streamFont;
            _fontPath = null;
            return this;
        }

        /// <inheritdoc/>
        public IBanner Border(DashOptions dashOptions)
        {
            _dashOptions = dashOptions;
            return this;
        }

        /// <inheritdoc/>
        public void Show()
        {
            if (_fontStream is not null)
            {
                console.Banner(text, _fontStream, style, _dashOptions);
            }
            else if (_fontPath is not null)
            {
                console.Banner(text, _fontPath, style, _dashOptions);
            }
            else
            {
                console.Banner(text, style, _dashOptions);
            }
        }
    }

    /// <summary>
    /// Default <see cref="IStringDash"/> implementation, deferring the actual render to
    /// <see cref="Show"/> so <see cref="Border"/>/<see cref="Extralines"/> can be chained beforehand.
    /// </summary>
    internal sealed class StringDashBuilder(IConsole console, string text, Style? style) : IStringDash
    {
        private DashOptions _dashOptions = DashOptions.SingleBorder;
        private int _extralines;

        /// <inheritdoc/>
        public IStringDash Border(DashOptions dashOptions)
        {
            _dashOptions = dashOptions;
            return this;
        }

        /// <inheritdoc/>
        public IStringDash Extralines(int value)
        {
            _extralines = value;
            return this;
        }

        /// <inheritdoc/>
        public void Show() => console.Dash(text, _dashOptions, style, _extralines);
    }
}
