namespace Core.State_Machine.States
{
    public interface ISuspendState : IState
    {
        void Suspend();
        void Resume();
    }
}