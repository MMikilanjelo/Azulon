using System.Threading.Tasks;
using UI.Abstractions.Interfaces;
using UnityEngine;

namespace UI.Abstractions
{
    public abstract class PopupViewBase : MonoBehaviour, IPopupView
    {
        public bool IsShown => gameObject.activeSelf;
        protected RectTransform RectTransform => _rectTransform ??= GetComponent<RectTransform>();

        private RectTransform _rectTransform;

        public async Task Show()
        {
            await PlayInAnimation();

            OnShown();

            gameObject.SetActive(true);
        }

        public async Task Hide()
        {
            await PlayOutAnimation();

            OnHidden();

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