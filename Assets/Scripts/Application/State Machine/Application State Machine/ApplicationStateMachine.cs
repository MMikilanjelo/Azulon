using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;
using Core.State_Machine;
using Infrastructure.Factory_Provider;
using UI.Screen_Mediator;
using UnityEditor.SceneManagement;

namespace Application.State_Machine.Application_State_Machine
{
    public class ApplicationStateMachine : StateMachineBase<IApplicationState>, IApplicationStateMachine
    {
        public ApplicationStateMachine(
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator
        )
        {
            var mainState = new MainMenuState(this, factoryProvider, screenMediator);
            
            var gameplayState= new GameplayState(this, factoryProvider, screenMediator);

            RegisterState(mainState);
            
            RegisterState(gameplayState);
        }
    }
}
