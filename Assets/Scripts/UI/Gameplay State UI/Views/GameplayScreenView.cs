using TMPro;
using UI.Abstractions;
using UI.Components;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class GameplayScreenView : ScreenViewBase
    {
        [SerializeField] private CustomButtonComponent _shopButton;
        [SerializeField] private CustomButtonComponent _inventoryButton;
        [SerializeField] private CustomButtonComponent _finishTurnButton;
        [SerializeField] private TextMeshProUGUI _goldText;

        private IGameplayScreenMediator _mediator;

        public void Construct(IGameplayScreenMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnShown()
        {
            _shopButton.onClick.AddListener(_mediator.OnOpenShopButtonClicked);
            _inventoryButton.onClick.AddListener(_mediator.OnOpenInventoryButtonClicked);
            _finishTurnButton.onClick.AddListener(_mediator.OnFinishTurnButtonClicked);
        }

        protected override void OnDestroyed()
        {
            _shopButton.onClick.RemoveListener(_mediator.OnOpenShopButtonClicked);
            _inventoryButton.onClick.RemoveListener(_mediator.OnOpenInventoryButtonClicked);
            _finishTurnButton.onClick.RemoveListener(_mediator.OnFinishTurnButtonClicked);
        }

        protected override void OnHidden()
        {
            _shopButton.onClick.RemoveListener(_mediator.OnOpenShopButtonClicked);
            _inventoryButton.onClick.RemoveListener(_mediator.OnOpenInventoryButtonClicked);
            _finishTurnButton.onClick.RemoveListener(_mediator.OnFinishTurnButtonClicked);
        }
    }
}