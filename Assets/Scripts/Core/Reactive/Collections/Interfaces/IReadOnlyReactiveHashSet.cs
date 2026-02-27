using System.Collections.Generic;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;

namespace Core.Reactive.Collections.Interfaces
{
    public interface IReadOnlyReactiveHashSet<out T> : IReadOnlyCollection<T>
    {
        IReadOnlyReactiveEvent<T> Added { get; }
        IReadOnlyReactiveEvent<T> Removed { get; }
        IReadOnlyReactiveEvent<EmptyEvent> Cleared { get; }
    }
}