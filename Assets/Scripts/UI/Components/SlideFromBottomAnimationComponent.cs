using System.Threading.Tasks;
using Core.Extensions;
using DG.Tweening;
using UnityEngine;

namespace UI.Components
{
    [RequireComponent(typeof(CanvasGroup))]
    public class SlideFromBottomAnimationComponent : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _easeIn = Ease.OutBack;
        [SerializeField] private Ease _easeOut = Ease.InCubic;

        private Tween _moveTween;

        public void PlayIn()
        {
            _moveTween.KillIfActive();

            _target.anchoredPosition = new Vector2(0, -Screen.height);

            _moveTween = _target
                .DOAnchorPos(Vector2.zero, _duration)
                .SetEase(_easeIn)
                .SetUpdate(true);
        }

        public Task PlayOut()
        {
            _moveTween.KillIfActive();

            _moveTween = _target
                .DOAnchorPos(new Vector2(0, -Screen.height), _duration)
                .SetEase(_easeOut)
                .SetUpdate(true);

            return _moveTween.AsyncWaitForCompletion();
        }

        private void OnDestroy() =>
            _moveTween.KillIfActive();
    }
}