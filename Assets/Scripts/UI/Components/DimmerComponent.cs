using Core.Extensions;
using Core.Reactive;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Components
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DimmerComponent : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _maxAlpha = 0.5f;

        public IReadOnlyReactiveEvent<EmptyEvent> Clicked => _clicked;

        private readonly ReactiveEvent<EmptyEvent> _clicked = new();
        private Tween _fadeTween;

        public void Show(float duration)
        {
            _fadeTween?.Kill();

            _canvasGroup.blocksRaycasts = true;
            _fadeTween = _canvasGroup.DOFade(_maxAlpha, duration);
        }

        public void Hide(float duration)
        {
            _fadeTween?.Kill();

            _canvasGroup.blocksRaycasts = false;
            _fadeTween = _canvasGroup.DOFade(0f, duration);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _fadeTween.KillIfActive();

            _clicked.Invoke(new EmptyEvent());
        }

        private void OnDestroy() =>
            _fadeTween.KillIfActive();
    }
}