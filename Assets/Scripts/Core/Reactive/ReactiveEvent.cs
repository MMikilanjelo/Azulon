using System;
using System.Collections.Generic;
using Core.Disposables;
using Core.Reactive.Interfaces;

namespace Core.Reactive
{
    public sealed class ReactiveEvent<T> : IReactiveEvent<T>, IReadOnlyReactiveEvent<T>
    {
        private readonly List<Subscription<T>> _subscribers = new();
        private readonly List<Subscription<T>> _toAdd = new();
        private readonly List<Subscription<T>> _toRemove = new();
        private bool _isIterating;

        public IDisposable Subscribe(Action<T> action)
        {
            var subscriber = new Subscription<T>(action);

            if (_isIterating)
            {
                _toAdd.Add(subscriber);
            }
            else
            {
                _subscribers.Add(subscriber);
            }

            return new Disposable(() => Unsubscribe(subscriber));
        }

        public void Invoke(T value)
        {
            _isIterating = true;

            foreach (var sub in _subscribers)
            {
                if (!_toRemove.Contains(sub))
                {
                    sub.Invoke(value);
                }
            }

            _isIterating = false;

            FlushBuffers();
        }

        private void Unsubscribe(Subscription<T> subscription)
        {
            if (_isIterating)
            {
                _toRemove.Add(subscription);
            }
            else
            {
                _subscribers.Remove(subscription);
            }
        }

        private void FlushBuffers()
        {
            if (_toAdd.Count > 0)
            {
                _subscribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (var sub in _toRemove) _subscribers.Remove(sub);
                _toRemove.Clear();
            }
        }

        public void Dispose()
        {
            _subscribers.Clear();
            _toAdd.Clear();
            _toRemove.Clear();
        }
    }
}