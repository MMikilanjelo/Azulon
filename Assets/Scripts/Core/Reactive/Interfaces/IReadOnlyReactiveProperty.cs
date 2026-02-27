using System;

namespace Core.Reactive.Interfaces
{
    public interface IReadOnlyReactiveProperty<out T>
    {
        T Value { get; }
        IDisposable Subscribe(Action<T> action);
    }
}