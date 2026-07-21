// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
#if NET9_0_OR_GREATER
using System.Threading;
#endif
using System.Threading.Tasks;

namespace ConsolePlusLibrary.Core
{
    internal sealed class LockEnvironment : ILock
    {
#if NET9_0_OR_GREATER
        internal static readonly Lock _lock = new();
#else
        internal static readonly object _lock = new();
#endif
        public void Run(Action action)
        {
            if (Helper.MainToken.IsCancellationRequested)
            {
                action();
                return;
            }
#if NET9_0_OR_GREATER
            _lock.Enter();
            try
            {
                action();
            }
            finally
            {
                _lock.Exit();
            }
#else
            lock (_lock)
            {
                action();
            }
#endif
        }

        public T Run<T>(Func<T> func)
        {
#if NET9_0_OR_GREATER
            if (Helper.MainToken.IsCancellationRequested)
            {
                return func();
            }
            _lock.Enter();
            try
            {
                return func();
            }
            finally
            {
                _lock.Exit();
            }
#else
            lock (_lock)
            {
                return func();
            }
#endif
        }

        public Task<T> RunAsync<T>(Func<Task<T>> func)
        {
#if NET9_0_OR_GREATER
            if (Helper.MainToken.IsCancellationRequested)
            {
                return func();
            }
            _lock.Enter();
            try
            {
                return func();
            }
            finally
            {
                _lock.Exit();
            }
#else
            lock (_lock)
            {
                return func();
            }
#endif
        }
    }
}
