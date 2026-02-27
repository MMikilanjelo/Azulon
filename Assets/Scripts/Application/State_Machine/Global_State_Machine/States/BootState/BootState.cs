using Application.State_Machine.Global_State_Machine.Abstractions;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Core.State_Machine.States;

namespace Application.State_Machine.Global_State_Machine.States.BootState
{
    public class BootState : GlobalStateBase , IEnterState
    {
        public BootState(IGlobalStateMachine stateMachine) : base(stateMachine)
        {
        }

        public void Enter()
        {
        }
    }
}