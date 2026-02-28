using Features.Plant;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Place_GridItem_Use_Case
{
    public interface IPlacePlantUseCase
    {
        bool Execute(PlantModel item);
    }
}