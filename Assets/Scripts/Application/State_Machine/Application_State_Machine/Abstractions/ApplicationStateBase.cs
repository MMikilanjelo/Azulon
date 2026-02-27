using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;

namespace Application.State_Machine.Application_State_Machine.Abstractions
{
    public abstract class ApplicationStateBase
    {
        protected readonly IApplicationStateMachine StateMachine;

        protected ApplicationStateBase(IApplicationStateMachine stateMachine) =>
            StateMachine = stateMachine;
    }
}