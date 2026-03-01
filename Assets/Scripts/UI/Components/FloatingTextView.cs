using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class FloatingTextView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _duration = 0.8f;
        [SerializeField] private float _moveDistance = 80f;

        public async Task Play(string message, Color color)
        {
            _text.text = message;

            _text.color = color;

            _canvasGroup.alpha = 1f;

            transform.localScale = Vector3.one;

            var sequence = DOTween.Sequence();

            sequence
                .Join(transform.DOLocalMoveY(transform.localPosition.y + _moveDistance, _duration)
                    .SetEase(Ease.OutCubic));

            sequence
                .Join(_canvasGroup.DOFade(0f, _duration)
                    .SetEase(Ease.InQuint));

            sequence.Join(transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0f), 0.3f, 1));

            await sequence.AsyncWaitForCompletion();

            Destroy(gameObject);
        }
    }
}