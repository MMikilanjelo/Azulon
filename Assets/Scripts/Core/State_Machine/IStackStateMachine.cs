using Core.State_Machine.States;

namespace Core.State_Machine
{
    public interface IStackStateMachine<in T> where T : IState
    {
        void Pop();
        void Enter<TState, TPayload>(TPayload payload, StateTransitionBehaviour behaviour) where TState : class, T, IPayloadState<TPayload>;
        void RegisterState(T state);
        void Enter<TState>(StateTransitionBehaviour behaviour) where TState : class, T, IEnterState;
        void ExitStateMachine();
    }
}