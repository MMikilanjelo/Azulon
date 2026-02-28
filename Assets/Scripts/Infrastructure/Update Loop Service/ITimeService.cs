using Core.Reactive.Interfaces;

namespace Infrastructure.Update_Loop_Service
{
    public interface ITimeService
    {
        IReadOnlyReactiveEvent<float> UpdateTicked { get; }
    }
}