using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using Core.Extensions;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Screen_Mediator;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State
{
    public class GameplayState : ApplicationStateBase, IEnterState, IGameplayScreenUIModel
    {
        private readonly IFactoryProvider _factoryProvider;

        private IGameplayStateUIFactory _factory;

        private readonly IScreenMediator _screenMediator;

        public GameplayState(
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
            _factory = _factoryProvider.GetFactoryById<IGameplayStateUIFactory>(FactoryId.UI);

            _factory.CreateGameplayScreen(_screenMediator.ScreenRoot, this).Forget();
        }
    }
}