using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;
using Core.State_Machine;
using Infrastructure.Factory_Provider;
using Infrastructure.Services.Grid_Service;
using UI.Screen_Mediator;
using UnityEditor.SceneManagement;

namespace Application.State_Machine.Application_State_Machine
{
    public class ApplicationStateMachine : StateMachineBase<IApplicationState>, IApplicationStateMachine
    {
        public ApplicationStateMachine(
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator,
            IGridService gridService
        )
        {
            var mainState = new MainMenuState(this, factoryProvider, screenMediator);

            var gameplayState = new GameplayState(this, factoryProvider, screenMediator, gridService);

            RegisterState(mainState);
            
            RegisterState(gameplayState);
        }
    }
}
