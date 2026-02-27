using System;

namespace Core.Reactive.Interfaces
{
    public interface IReadOnlyReactiveEvent<out T>
    {
        IDisposable Subscribe(Action<T> action);
    }
}