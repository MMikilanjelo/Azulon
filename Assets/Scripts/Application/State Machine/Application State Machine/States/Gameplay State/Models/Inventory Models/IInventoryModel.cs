using Core.Reactive.Collections.Interfaces;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Inventory_Models
{
    public interface IInventoryModel
    {
        IReadOnlyReactiveList<InventoryItemModel> Items { get; }
        void Remove(InventoryItemModel selectedItem);
    }
}