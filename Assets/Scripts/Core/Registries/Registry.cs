using System.Collections.Generic;
using Core.Reactive.Collections;
using Core.Reactive.Collections.Interfaces;

namespace Core.Registries
{
    public class Registry<T> : IRegistry<T> where T : class
    {
        public IReadOnlyReactiveHashSet<T> Items => _items;

        public delegate TResult Selector<out TResult>(IEnumerable<T> items);

        private readonly ReactiveHashSet<T> _items = new();

        public bool TryAdd(T item) =>
            item != null && _items.Add(item);

        public bool Remove(T item) =>
            _items.Remove(item);

        public TResult Query<TResult>(Selector<TResult> selector) =>
            selector.Invoke(_items);
    }
}