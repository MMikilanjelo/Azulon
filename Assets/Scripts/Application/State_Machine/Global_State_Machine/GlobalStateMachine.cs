using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Core.State_Machine;
using Unity.VisualScripting;

namespace Application.State_Machine.Global_State_Machine
{
    public class GlobalStateMachine : StateMachineBase<IGlobalState>, IGlobalStateMachine
    {
        public GlobalStateMachine()
        {
        }
    }
}