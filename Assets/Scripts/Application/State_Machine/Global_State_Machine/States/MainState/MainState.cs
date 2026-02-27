using Application.State_Machine.Global_State_Machine.Abstractions;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;

namespace Application.State_Machine.Global_State_Machine.States.MainState
{
    public class MainState : GlobalStateBase
    {
        public MainState(IGlobalStateMachine stateMachine) : base(stateMachine)
        {
        }
    }
}