using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.Models.Inventory_Models
{
    public class InventoryItemModel
    {
        public string ItemId { get; }
        public ItemCategory Category { get; }
        public Sprite Icon { get; }

        public InventoryItemModel(string itemId, ItemCategory category, Sprite icon)
        {
            ItemId = itemId;
            Category = category;
            Icon = icon;
        }
    }
}