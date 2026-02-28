using Features.Plant;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Reduce_Adjacent_Plants_Turns_Use_Case
{
    public interface IReduceAdjacentPlantsTurnsUseCase
    {
        void Execute(PlantModel origin, int reductionAmount = 1);
    }
}