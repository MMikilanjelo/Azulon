using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Select_Inventory_Item_Use_Case
{
    public interface ISelectInventoryItemUseCase
    {
        void Execute(InventoryItemModel item);
    }
}