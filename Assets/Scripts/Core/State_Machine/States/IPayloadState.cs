namespace Core.State_Machine.States
{
    public interface IPayloadState<in T> : IState
    {
        public void Enter(T payload);
    }
}