using Core.Reactive;
using Core.Reactive.Interfaces;
using UI.Abstractions;
using UI.Abstractions.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class BoardCellView : MonoBehaviour, IView, IPointerDownHandler
    {
        [SerializeField] private Image _assignedItemImage;
        public IReadOnlyReactiveEvent<BoardCellView> Clicked => _clicked;

        private readonly ReactiveEvent<BoardCellView> _clicked = new();

        public void ShowAssignedItemImage(Sprite icon)
        {
            _assignedItemImage.sprite = icon;
            _assignedItemImage.gameObject.SetActive(true);
        }

        public void HideAssignedItemImage() =>
            _assignedItemImage.gameObject.SetActive(false);

        public void OnPointerDown(PointerEventData eventData) =>
            _clicked.Invoke(this);

        public void Destroy() =>
            Destroy(gameObject);

        private void OnDestroy() =>
            _clicked.Dispose();
    }
}