using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Serializes test classes that touch process-wide static state that isn't otherwise isolated
    // per-instance: BaseClassCI's environment-variable cache (ProfileExtensionsTests) and the real
    // ConsolePlusLibrary.ConsolePlus singleton, whose static ctor populates that same cache
    // (ConsolePlusExtendsTests). xUnit parallelizes different test classes by default; classes in
    // this collection run sequentially relative to each other instead.
    [CollectionDefinition(Name, DisableParallelization = true)]
    public class GlobalStateCollection
    {
        public const string Name = "ConsolePlus global state (BaseClassCI env-var cache / ConsolePlus singleton)";
    }
}
