using Application.State_Machine.Application_State_Machine;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;
using Application.State_Machine.Global_State_Machine.Abstractions;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using Infrastructure.Services.Grid_Service;
using TMPro.EditorUtilities;
using UI.Screen_Mediator;

namespace Application.State_Machine.Global_State_Machine.States.Main_State
{
    public class MainState : GlobalStateBase, IEnterState
    {
        private readonly IApplicationStateMachine _applicationStateMachine;

        public MainState(
            IGlobalStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator,
            IGridService gridService
        ) : base(stateMachine)
        {
            _applicationStateMachine = new ApplicationStateMachine(
                factoryProvider,
                screenMediator,
                gridService
            );
        }

        public void Enter()
        {
            _applicationStateMachine.Enter<MainMenuState>();
        }
    }
}