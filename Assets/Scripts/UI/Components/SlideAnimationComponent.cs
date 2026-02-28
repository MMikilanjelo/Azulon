using System.Threading.Tasks;
using Core.Extensions;
using DG.Tweening;
using UnityEngine;

namespace UI.Components
{
    [RequireComponent(typeof(CanvasGroup))]
    public class SlideAnimationComponent : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _easeIn = Ease.OutBack;
        [SerializeField] private Ease _easeOut = Ease.InCubic;

        private Tween _moveTween;

        public Task PlayIn(Vector2 from, Vector2 to)
        {
            _moveTween.KillIfActive();

            _target.anchoredPosition = from;

            _moveTween = _target
                .DOAnchorPos(to, _duration)
                .SetEase(_easeIn)
                .SetUpdate(true);

            return _moveTween.AsyncWaitForCompletion();
        }

        public Task PlayOut(Vector2 to)
        {
            _moveTween.KillIfActive();

            _moveTween = _target
                .DOAnchorPos(to, _duration)
                .SetEase(_easeOut)
                .SetUpdate(true);

            return _moveTween.AsyncWaitForCompletion();
        }

        private void OnDestroy() =>
            _moveTween.KillIfActive();
    }
}