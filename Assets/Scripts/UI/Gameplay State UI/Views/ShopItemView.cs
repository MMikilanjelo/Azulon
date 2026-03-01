using Core.Reactive;
using Core.Reactive.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class ShopItemView : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _priceText;

        public IReadOnlyReactiveEvent<ShopItemView> Clicked => _clicked;

        private readonly ReactiveEvent<ShopItemView> _clicked = new();

        public void Setup(
            Sprite icon,
            string title,
            string description,
            int price
        )
        {
            _itemIcon.sprite = icon;
            _titleText.text = title;
            _descriptionText.text = description;
            _priceText.text = price.ToString();
        }

        public void OnPointerDown(PointerEventData eventData) =>
            _clicked.Invoke(this);

        public void Destroy() =>
            Destroy(gameObject);

        private void OnDestroy() =>
            _clicked.Dispose();
    }
}