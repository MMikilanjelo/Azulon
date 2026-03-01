using System.Threading.Tasks;
using UI.Abstractions.Interfaces;
using UnityEngine;

namespace UI.Abstractions
{
    public abstract class ScreenViewBase : MonoBehaviour, IScreenView
    {
        protected RectTransform RectTransform => _rectTransform ??= GetComponent<RectTransform>();

        private RectTransform _rectTransform;

        public async Task Show()
        {
            gameObject.SetActive(true);
            OnShown();
            await PlayInAnimation();
        }

        public async Task Hide()
        {
            OnHidden();
            await PlayOutAnimation();
            gameObject.SetActive(false);
        }

        public virtual void Destroy()
        {
            OnDestroyed();
            Destroy(gameObject);
        }

        protected abstract void OnHidden();
        protected abstract void OnShown();
        protected abstract void OnDestroyed();
        protected virtual Task PlayInAnimation() => Task.CompletedTask;
        protected virtual Task PlayOutAnimation() => Task.CompletedTask;
    }
}