using System;
using System.Threading.Tasks;

namespace ConsolePlusLibrary.Core
{
    internal interface ILock 
    {
        void Run(Action action);
        T Run<T>(Func<T> func);
        Task<T> RunAsync<T>(Func<Task<T>> func);
    }
}
