using System;
using Core.Disposables;

namespace Core.Extensions
{
    public static class DisposableExtensions
    {
        public static T AddTo<T>(this T disposable, CompositeDisposable compositeDisposable) where T : IDisposable
        {
            if (compositeDisposable == null)
            {
                throw new ArgumentNullException(nameof(compositeDisposable));
            }

            compositeDisposable.Add(disposable);

            return disposable; 
        }
    }
}