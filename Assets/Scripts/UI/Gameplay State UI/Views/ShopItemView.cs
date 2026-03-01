using Core.Reactive;
using Core.Reactive.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class ShopItemView : MonoBehaviour
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Button _purchaseButton;
        public IReadOnlyReactiveEvent<ShopItemView> PurchaseButtonClicked => _purchaseButtonClicked;

        private readonly ReactiveEvent<ShopItemView> _purchaseButtonClicked = new();

        public void Construct() =>
            _purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);

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

        public void Destroy() =>
            Destroy(gameObject);

        private void OnDestroy() =>
            _purchaseButtonClicked.Dispose();

        private void OnPurchaseButtonClicked() =>
            _purchaseButtonClicked.Invoke(this);
    }
}