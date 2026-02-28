using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Global_State_Machine.States.Boot_State;
using Application.State_Machine.Global_State_Machine.States.Main_State;
using Core.State_Machine;
using Infrastructure.Factory_Provider;
using Infrastructure.Services;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Services.Scene_Loading_Service;
using UI.Screen_Mediator;
using Unity.VisualScripting;

namespace Application.State_Machine.Global_State_Machine
{
    public class GlobalStateMachine : StateMachineBase<IGlobalState>, IGlobalStateMachine
    {
        public GlobalStateMachine(
            ISceneLoadingService sceneLoadingService,
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator,
            IGridService gridService
        )
        {
            var bootState = new BootState(
                this,
                sceneLoadingService,
                factoryProvider,
                screenMediator
            );

            var mainState = new MainState(
                this,
                factoryProvider,
                screenMediator,
                gridService
            );

            RegisterState(bootState);
            RegisterState(mainState);
        }
    }
}