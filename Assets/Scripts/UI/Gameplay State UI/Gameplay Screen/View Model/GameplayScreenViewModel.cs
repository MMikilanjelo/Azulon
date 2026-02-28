using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using UI.Abstractions;
using UI.Abstractions.Interfaces;

namespace UI.Gameplay_State_UI.Gameplay_Screen.View_Model
{
    public class GameplayScreenViewModel : ScreenViewModelBase, IGameplayScreenViewModel
    {
        private readonly IGameplayScreenModel _model;

        public GameplayScreenViewModel(IGameplayScreenModel model)
        {
            _model = model;
        }

        public void OnShowButtonClicked() =>
            _model.OpenShop();

        public void OnInventoryButtonClicked() =>
            _model.OpenInventory();
    }
}