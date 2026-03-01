using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.Models.Shop_Model
{
    public class ShopItemModel
    {
        public string ItemId { get; }
        public ItemCategory Category { get; }
        public string Description { get; }
        public string Title { get; }
        public int Price { get; }
        public Sprite Icon { get; }

        public ShopItemModel(
            string itemItemId,
            ItemCategory itemCategory,
            Sprite itemIcon,
            string itemDescription,
            string itemTitle,
            int itemPrice
        )
        {
            ItemId = itemItemId;
            Category = itemCategory;
            Icon = itemIcon;
            Description = itemDescription;
            Price = itemPrice;
            Title = itemTitle;
        }
    }
}