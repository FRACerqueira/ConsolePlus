// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************


using System;
using System.Collections.Frozen;
using System.Collections.Generic;
#if NET10_0_OR_GREATER
using System.Threading;
#endif

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    internal abstract class BaseClassCI()
    {
        private static FrozenDictionary<string, string>? _environmentVariables;
#if NET10_0_OR_GREATER
        private static readonly Lock _envLock = new();
#else
        private static readonly object _envLock = new();
#endif
        public static bool Found(Func<string, bool>? predicate, params string[] keys)
        {
            foreach (var key in keys)
            {
                if (GetEnvironmentVariables().TryGetValue(key, out var value))
                {
                    if (predicate == null || predicate(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves environment variables as a dictionary of key-value pairs, filtering for string keys and values.
        /// </summary>
        /// <returns>A dictionary containing the environment variables.</returns>
        private static FrozenDictionary<string, string> GetEnvironmentVariables()
        {
            lock (_envLock)
            {
                if (_environmentVariables != null)
                {
                    return _environmentVariables;
                }
                var envVars = Environment.GetEnvironmentVariables();
                var result = new Dictionary<string, string>();

                foreach (var key in envVars.Keys)
                {
                    if (key is string keyStr && envVars[key] is string valueStr)
                    {
                        result[keyStr] = valueStr;
                    }
                }
                _environmentVariables = result.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
                return _environmentVariables;
            }
        }
    }
}
