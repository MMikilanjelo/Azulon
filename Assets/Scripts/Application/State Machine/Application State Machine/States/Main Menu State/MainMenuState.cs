using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Core.Extensions;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using UI.Main_Menu_State_UI.Mediator.Interfaces;

namespace Application.State_Machine.Application_State_Machine.States.Main_Menu_State
{
    public class MainMenuState : ApplicationStateBase, IEnterState, IExitState
    {
        private readonly IFactoryProvider _factoryProvider;

        private readonly IMainMenuStateUIMediator _uiMediator;

        public MainMenuState(
            IApplicationStateMachine stateMachine,
            IMainMenuStateUIMediator uiMediator
        ) : base(stateMachine)
        {
            _uiMediator = uiMediator;
        }

        public void Enter()
        {
            _uiMediator.Initialize(this);
            _uiMediator.CreateMainMenuScreen().Forget();
        }

        public void StartGame() =>
            StateMachine.Enter<GameplayState>();

        public void Exit() =>
            _uiMediator.Dispose();
    }
}