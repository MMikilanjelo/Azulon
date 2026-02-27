using Application.State_Machine.Application_State_Machine.States.Main_Menu_State.Interfaces;
using UI.Abstractions;

namespace UI.Main_Menu_State_UI.Main_Menu_Screen.View_Model
{
    public class MainMenuScreenViewModel : ScreenViewModelBase, IMainMenuScreenViewModel
    {
        private readonly IMainMenuScreenModel _model;

        public MainMenuScreenViewModel(IMainMenuScreenModel model)
        {
            _model = model;
        }

        public void OnPlayButtonClicked() =>
            _model.StartGame();
    }
}