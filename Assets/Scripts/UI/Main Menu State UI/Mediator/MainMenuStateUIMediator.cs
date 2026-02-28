using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;
using Core.Extensions;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Main_Menu_State_UI.Mediator.Interfaces;
using UI.UI_Root.Mediator.Interfaces;

namespace UI.Main_Menu_State_UI.Mediator
{
    public class MainMenuStateUIMediator :
        IMainMenuStateUIMediator,
        IMainMenuScreenMediator
    {
        private MainMenuState _state;
        private IMainMenuStateUIFactory _factory;
        private readonly IFactoryProvider _factoryProvider;
        private readonly IScreenStackMediator _screenStackMediator;

        public MainMenuStateUIMediator(IFactoryProvider factoryProvider, IScreenStackMediator screenStackMediator)
        {
            _factoryProvider = factoryProvider;
            _screenStackMediator = screenStackMediator;
        }

        public void Initialize(MainMenuState state)
        {
            _state = state;
            _factory = _factoryProvider.GetFactoryById<IMainMenuStateUIFactory>(FactoryId.UI);
        }

        public void Dispose() =>
            _screenStackMediator.PopAll();

        public Task CreateMainMenuScreen() =>
            _screenStackMediator.Push(parent => _factory.CreateMainMenuScreen(parent, this));

        public void OnStartGameButtonClicked() =>
            _state.StartGame();
    }
}