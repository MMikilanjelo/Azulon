using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Selection_Model;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Deselect_Inventory_Item_Use_Case
{
    public class DeselectInventoryItemUseCase : IDeselectInventoryItemUseCase
    {
        private readonly ISelectionModel _selectionModel;

        public DeselectInventoryItemUseCase(ISelectionModel selectionModel) =>
            _selectionModel = selectionModel;

        public void Execute() =>
            _selectionModel.Deselect();
    }
}