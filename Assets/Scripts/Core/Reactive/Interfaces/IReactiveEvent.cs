using System;

namespace Core.Reactive.Interfaces
{
    public interface IReactiveEvent<in T> : IDisposable
    {
        void Invoke(T value);
    }
}