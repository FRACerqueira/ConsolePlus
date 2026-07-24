// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Resources;
using System.Runtime.CompilerServices;

// Specifies the neutral culture for the assembly's resources
[assembly: NeutralResourcesLanguage("en-US")]

// Grants the headless VirtualTerminal test driver access to internal types (ConsoleWriter, ProfileConsole, IConsolePlus)
[assembly: InternalsVisibleTo("ConsolePlus.Tests")]
[assembly: InternalsVisibleTo("PromptPlus.Tests")]


