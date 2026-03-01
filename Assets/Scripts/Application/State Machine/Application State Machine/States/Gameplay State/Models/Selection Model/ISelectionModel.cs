using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Core.Reactive.Interfaces;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Selection_Model
{
    public interface ISelectionModel
    {
        IReadOnlyReactiveProperty<InventoryItemModel> SelectedItem { get; }
        bool HasSelection { get; }
        void Select(InventoryItemModel item);
        void Deselect();
    }
}