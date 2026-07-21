// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsolePlusLibrary.Core
{
    internal static class Constants
    {
        public const string AsciiEllipsis = "_";
        public const string UnicodeEllipsis = "…";
        public const int DefaultTerminalWidth = 80;
        public const int DefaultTerminalHeight = 24;
        public const int DefaultCursorTop = 0;
        public const int DefaultCursorLeft = 0;
        public const string ProfileName = "ConsoleProfile.json";
        public static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            Converters = 
            { 
                new JsonStringEnumConverter(),
                new CultureInfoJsonConverter(),
                new ColorJsonConverter()
            }
        };
    }

}
