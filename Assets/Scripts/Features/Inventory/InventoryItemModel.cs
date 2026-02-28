using Core.Reactive;
using Core.Reactive.Interfaces;

namespace Features.Inventory
{
    public class InventoryItemModel
    {
        public string ItemId { get; }

        public IReadOnlyReactiveProperty<int> Quantity => _quantity;
        public ItemCategory Category { get; }

        private readonly ReactiveProperty<int> _quantity;

        public InventoryItemModel(string itemId, int quantity, ItemCategory category)
        {
            ItemId = itemId;
            Category = category;
            _quantity = new ReactiveProperty<int>(quantity);
        }
    }
}