using Core.Reactive.Collections;
using Core.Reactive.Collections.Interfaces;

namespace Application.State_Machine.Application_State_Machine.Models.Inventory_Models
{
    public class InventoryModel : IInventoryModel
    {
        public IReadOnlyReactiveList<InventoryItemModel> Items => _inventory;

        private readonly ReactiveList<InventoryItemModel> _inventory = new();

        public void Add(InventoryItemModel selectedItem) =>
            _inventory.Add(selectedItem);

        public void Remove(InventoryItemModel selectedItem) =>
            _inventory.Remove(selectedItem);
    }
}