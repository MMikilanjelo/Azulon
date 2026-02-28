using Features.Plant;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models
{
    public interface IGridModel
    {
        bool CanPlaceItem(PlantModel item, Vector2Int gridPos);
        void RegisterItem(PlantModel plantModel);
        PlantModel GetItemAt(Vector2Int neighborCell);
    }
}