// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsolePlusLibrary.Core
{

    /// <summary>
    /// Defines a console profile describing capabilities, dimensions, colors and display behavior
    /// </summary>
    internal sealed class ProfileConsole : IProfileReadOnly
    {
        /// <summary>
        /// Gets the original culture of the console at the time the profile was created.
        /// </summary>
        public string OriginalCulture { get; set; } = CultureInfo.CurrentCulture.Name;

        /// <summary>
        /// Gets the default input encoding of the console at the time the profile was created.
        /// </summary>
        [JsonIgnore]
        public Encoding DefaultInputEncoding { get; set; } = Encoding.Default;

        /// <summary>
        /// Gets the default output encoding of the console at the time the profile was created.
        /// </summary>  
        [JsonIgnore]
        public Encoding DefaultOutputEncoding { get; set; } = Encoding.Default;

        /// <summary>
        /// Gets or sets the default input encoding name for JSON serialization/deserialization.
        /// </summary>
        [JsonPropertyName("DefaultInputEncoding")]
        public string DefaultInputEncodingName
        {
            get => DefaultInputEncoding?.WebName?? Encoding.Default.WebName;
            set => DefaultInputEncoding = value != null ? Encoding.GetEncoding(value) : Encoding.Default;
        }

        /// <summary>
        /// Gets or sets the default output encoding name for JSON serialization/deserialization.
        /// </summary>
        [JsonPropertyName("DefaultOutputEncoding")]
        public string DefaultOutputEncodingName
        {
            get => DefaultOutputEncoding?.WebName?? Encoding.Default.WebName;
            set => DefaultOutputEncoding = value != null ? Encoding.GetEncoding(value) : Encoding.Default;
        }

        /// <summary>
        /// Gets the default background <see cref="Color"/> used when no explicit color is specified.
        /// </summary>
        public Color DefaultBackgroundColor { get; set; } = Color.Black;

        /// <summary>
        /// Gets the default foreground <see cref="Color"/> used when no explicit color is specified.
        /// </summary>
        public Color DefaultForegroundColor { get ; set ; } = Color.White;

        /// <summary>
        /// Gets the original input encoding of the console at the time the profile was created.
        /// </summary>
        [JsonIgnore]
        public Encoding OriginalInputEncoding { get; set; } = Encoding.Default;

        /// <summary>
        /// Gets the original output encoding of the console at the time the profile was created.
        /// </summary>
        [JsonIgnore]
        public Encoding OriginalOutputEncoding { get; set; } = Encoding.Default;

        /// <summary>
        /// Gets the profile name (e.g. an identifier for the terminal type or configuration).
        /// </summary>
        public string ProfileName { get ; set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether the output device is a terminal (TTY).
        /// </summary>
        public bool IsTerminal { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether the console is interactive.
        /// </summary>
        public bool Interactive { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether Unicode output is fully supported.
        /// </summary>
        public AutoDetect SupportUnicode { get; set; } = AutoDetect.Detect;

        /// <summary>
        /// Gets a value indicating whether ANSI escape sequences are supported for styling/output.
        /// </summary>
        public AutoDetect SupportsAnsi { get; set; } = AutoDetect.Detect;

        /// <summary>
        /// Gets or sets the color system used by the console.
        /// </summary>  
        public ColorSystem ColorDepth { get; set; } = ColorSystem.FourBit;

        /// <summary>
        /// Gets a value indicating whether ANSI escape sequences are detected as supported in the current environment.
        /// </summary>
        [JsonIgnore]
        public bool DetectedAnsiSupport { get; set; }

        /// <summary>
        /// Gets a value indicating whether Unicode output is detected as supported in the current environment.
        /// </summary>
        [JsonIgnore]
        public bool DetectedUnicodeSupport { get; set; }

        /// <summary>
        /// Gets a value indicating whether the color depth was changed from the original detected value.
        /// </summary>
        [JsonIgnore]
        public bool ChangedColorDepth { get; set; }

        /// <summary>
        /// Gets a value indicating whether ANSI support was changed from the original detected value.
        /// </summary>
        [JsonIgnore]
        public bool ChangedSupportsAnsi { get; set; }

        /// <summary>
        /// Gets a value indicating whether Unicode support was changed from the original detected value.
        /// </summary>
        [JsonIgnore]
        public bool ChangedSupportUnicode { get; set; }
    }
}
