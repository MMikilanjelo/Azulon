using UI.Abstractions.Interfaces;
using UI.Components;
using UI.Main_Menu_State_UI.Main_Menu_Screen.View_Model;
using UnityEngine;

namespace UI.Main_Menu_State_UI.Main_Menu_Screen.View
{
    public class MainMenuScreenView : MonoBehaviour, IScreenView<IMainMenuScreenViewModel>
    {
        [SerializeField] private CustomButtonComponent _startGameButton;

        private IMainMenuScreenViewModel _viewModel;

        public void Bind(IMainMenuScreenViewModel viewModel)
        {
            _viewModel = viewModel;

            _startGameButton.onClick.AddListener(OnStartClicked);

            _viewModel.VisibilityChanged.Subscribe(OnVisibilityChanged);
        }

        private void OnVisibilityChanged(bool isVisible) =>
            gameObject.SetActive(isVisible);

        private void OnStartClicked() =>
            _viewModel.OnPlayButtonClicked();
    }
}