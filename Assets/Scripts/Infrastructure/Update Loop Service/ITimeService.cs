using Core.Reactive.Interfaces;

namespace Infrastructure.Update_Loop_Service
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        IReadOnlyReactiveEvent<float> UpdateTicked { get; }
    }
}