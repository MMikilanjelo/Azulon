using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State.Interfaces;
using Core.Extensions;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Screen_Mediator;

namespace Application.State_Machine.Application_State_Machine.States.Main_Menu_State
{
    public class MainMenuState : ApplicationStateBase, IEnterState, IMainMenuScreenModel
    {
        private readonly IFactoryProvider _factoryProvider;

        private IMainMenuStateUIFactory _factory;

        private readonly IScreenMediator _screenMediator;

        public MainMenuState(
            IApplicationStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _screenMediator = screenMediator;
        }

        public void Enter()
        {
            _factory = _factoryProvider.GetFactoryById<IMainMenuStateUIFactory>(FactoryId.UI);

            _factory.CreateMainMenuScreen(_screenMediator.ScreenRoot, this).Forget();
        }

        public void StartGame()
        {
            StateMachine.Enter<GameplayState>();
        }
    }
}