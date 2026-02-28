using TMPro;
using UI.Abstractions.Interfaces;
using UI.Components;
using UI.Gameplay_State_UI.Gameplay_Screen.View_Model;
using UnityEngine;

namespace UI.Gameplay_State_UI.Gameplay_Screen.View
{
    public class GameplayScreenView : MonoBehaviour, IScreenView<IGameplayScreenViewModel>
    {
        [SerializeField] private CustomButtonComponent _shopButton;
        [SerializeField] private CustomButtonComponent _inventoryButton;

        private IGameplayScreenViewModel _viewModel;

        public void Bind(IGameplayScreenViewModel viewModel)
        {
            _viewModel = viewModel;

            _shopButton.onClick.AddListener(OnShopButtonClicked);
            _inventoryButton.onClick.AddListener(OnInventoryButtonClicked);

            _viewModel.IsVisible.Subscribe(OnVisibilityChanged);
        }

        private void OnVisibilityChanged(bool isVisible) =>
            gameObject.SetActive(isVisible);

        private void OnShopButtonClicked() =>
            _viewModel.OnShowButtonClicked();

        private void OnInventoryButtonClicked() =>
            _viewModel.OnInventoryButtonClicked();
    }
}