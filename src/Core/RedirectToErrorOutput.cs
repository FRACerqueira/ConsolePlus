// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

namespace ConsolePlusLibrary.Core
{
    internal sealed class RedirectToErrorOutput : IDisposable
    {
        private bool _disposed;
        private readonly IConsolePlus _consoleExtend;
        public RedirectToErrorOutput(IConsolePlus console)
        {
            _consoleExtend = console;
            _consoleExtend.WriteToErrorOutput = true;
        }

        #region IDisposable

        public void Dispose()
        {
            if (!_disposed)
            {
                _consoleExtend.WriteToErrorOutput = false;
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
