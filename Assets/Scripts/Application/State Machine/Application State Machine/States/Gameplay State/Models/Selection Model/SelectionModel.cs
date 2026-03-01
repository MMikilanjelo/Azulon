using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Core.Reactive;
using Core.Reactive.Interfaces;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Selection_Model
{
    public class SelectionModel : ISelectionModel
    {
        public IReadOnlyReactiveProperty<InventoryItemModel> SelectedItem => _selectedItem;

        private readonly ReactiveProperty<InventoryItemModel> _selectedItem = new();

        public bool HasSelection => SelectedItem.Value != null;

        public void Select(InventoryItemModel item) =>
            _selectedItem.Value = item;

        public void Deselect() =>
            _selectedItem.Value = null;
    }
}