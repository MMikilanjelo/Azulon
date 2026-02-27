using System;
using System.Collections.Generic;
using Core.Reactive.Collections;
using Core.Reactive.Collections.Interfaces;

namespace Core.Taggable
{
    public abstract class Taggable<T> where T : ITag
    {
        public IReadOnlyReactiveDictionary<Type, T> Tags => _tags;

        private readonly ReactiveDictionary<Type, T> _tags = new();

        public bool Is<TTag>(out TTag tag) where TTag : class, T, ITag
        {
            _tags.TryGetValue(typeof(TTag), out var value);

            tag = value as TTag;

            return tag != null;
        }

        public void Remove<TTag>() where TTag : T =>
            _tags.Remove(typeof(TTag));

        public bool Has<TTag>() where TTag : T =>
            _tags.ContainsKey(typeof(TTag));

        public void Add(T tag)
        {
            if (tag == null)
            {
                return;
            }

            var tagType = tag.GetType();

            _tags.TryAdd(tagType, tag);
        }

        protected void Add(ICollection<T> tags)
        {
            foreach (var tag in tags)
            {
                tags.Add(tag);
            }
        }
    }
}