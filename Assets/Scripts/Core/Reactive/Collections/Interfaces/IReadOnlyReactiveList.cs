using System.Collections.Generic;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;

namespace Core.Reactive.Collections.Interfaces
{
    public interface IReadOnlyReactiveList<T> : IReadOnlyList<T>
    {
        IReadOnlyReactiveEvent<T> Added { get; }
        IReadOnlyReactiveEvent<T> Removed { get; }
        IReadOnlyReactiveEvent<ValueChangedEvent<T>> Replaced { get; }
        IReadOnlyReactiveEvent<EmptyEvent> Cleared { get; }
    }
}