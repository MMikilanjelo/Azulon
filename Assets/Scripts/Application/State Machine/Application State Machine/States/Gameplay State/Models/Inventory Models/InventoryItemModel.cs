using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Enums;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Inventory_Models
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