using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Selection_Model;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Select_Inventory_Item_Use_Case
{
    public class SelectInventoryItemUseCase : ISelectInventoryItemUseCase
    {
        private readonly ISelectionModel _selectionModel;

        public SelectInventoryItemUseCase(ISelectionModel selectionModel) =>
            _selectionModel = selectionModel;

        public void Execute(InventoryItemModel item) =>
            _selectionModel.Select(item);
    }
}