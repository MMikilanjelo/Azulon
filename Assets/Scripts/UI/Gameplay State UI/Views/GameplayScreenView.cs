using UI.Abstractions;
using UI.Components;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;

namespace UI.Gameplay_State_UI.Views
{
    public class GameplayScreenView : ScreenViewBase
    {
        [SerializeField] private CustomButtonComponent _shopButton;
        [SerializeField] private CustomButtonComponent _inventoryButton;

        private IGameplayScreenMediator _mediator;

        public void Construct(IGameplayScreenMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnShown()
        {
            _shopButton.onClick.AddListener(_mediator.OnOpenShopButtonClicked);
            _inventoryButton.onClick.AddListener(_mediator.OnOpenInventoryButtonClicked);
        }

        protected override void OnDestroyed()
        {
            _shopButton.onClick.RemoveListener(_mediator.OnOpenShopButtonClicked);
            _inventoryButton.onClick.RemoveListener(_mediator.OnOpenInventoryButtonClicked);
        }

        protected override void OnHidden()
        {
            _shopButton.onClick.RemoveListener(_mediator.OnOpenShopButtonClicked);
            _inventoryButton.onClick.RemoveListener(_mediator.OnOpenInventoryButtonClicked);
        }
    }
}