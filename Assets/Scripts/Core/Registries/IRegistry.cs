using Core.Reactive.Collections.Interfaces;

namespace Core.Registries
{
    public interface IRegistry<T> where T : class
    {
        IReadOnlyReactiveHashSet<T> Items { get; }
        bool TryAdd(T item);
        bool Remove(T item);
        TResult Query<TResult>(Registry<T>.Selector<TResult> selector);
        void Clear();
    }
}