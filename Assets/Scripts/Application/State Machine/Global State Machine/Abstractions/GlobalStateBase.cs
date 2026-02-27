using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Core.State_Machine;

namespace Application.State_Machine.Global_State_Machine.Abstractions
{
    public abstract class GlobalStateBase : IGlobalState
    {
        protected readonly IGlobalStateMachine  StateMachine;

        protected GlobalStateBase(IGlobalStateMachine stateMachine) =>
            StateMachine = stateMachine;
    }
}