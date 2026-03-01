using System;
using Core.Reactive;
using Core.Reactive.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class InventoryItemView : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Image _assignedItemIcon;
        public IReadOnlyReactiveEvent<InventoryItemView> Clicked => _clicked;

        private readonly ReactiveEvent<InventoryItemView> _clicked = new();

        public void SetAssignedItemIcon(Sprite icon) =>
            _assignedItemIcon.sprite = icon;

        public void OnPointerDown(PointerEventData eventData) =>
            _clicked.Invoke(this);

        public void Destroy() =>
            Destroy(gameObject);

        private void OnDestroy() =>
            _clicked.Dispose();
    }
}