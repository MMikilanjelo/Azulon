using Core.State_Machine.States;

namespace Core.State_Machine
{
    public interface IPayloadStateMachine<in T> : IStateMachine<T> where T : IState
    {
        void Enter<TState, TPayload>(TPayload payload) where TState : class, T, IPayloadState<TPayload>;
    }
}