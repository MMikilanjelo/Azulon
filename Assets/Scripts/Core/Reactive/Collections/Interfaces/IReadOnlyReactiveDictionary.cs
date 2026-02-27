using System.Collections.Generic;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;

namespace Core.Reactive.Collections.Interfaces
{
    public interface IReadOnlyReactiveDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        IReadOnlyReactiveEvent<KeyValuePair<TKey, TValue>> Added { get; }
        IReadOnlyReactiveEvent<KeyValuePair<TKey, TValue>> Removed { get; }
        IReadOnlyReactiveEvent<KeyValuePair<TKey, TValue>> Changed { get; }
        IReadOnlyReactiveEvent<EmptyEvent> Cleared { get; }
    }
}