using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Inventory_Models;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Place_GridItem_Use_Case
{
    public interface IPlacePlantUseCase
    {
        Task<bool> Execute(InventoryItemModel selectedItem, Vector2Int pos);
    }
}