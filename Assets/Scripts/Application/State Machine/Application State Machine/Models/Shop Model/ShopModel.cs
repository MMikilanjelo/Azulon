using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Shop;
using Core.Reactive.Collections;
using Core.Reactive.Collections.Interfaces;
using Unity.VisualScripting;

namespace Application.State_Machine.Application_State_Machine.Models.Shop_Model
{
    public class ShopModel : IShopModel
    {
        public IReadOnlyReactiveList<ShopItemModel> Items => _items;

        private readonly ReactiveList<ShopItemModel> _items = new();

        public void Initialize(ShopCatalogDefinition catalog)
        {
            foreach (var item in catalog.Items)
            {
                _items.Add(new ShopItemModel(
                    item.ItemId,
                    item.Category,
                    item.Icon,
                    item.Description,
                    item.Title,
                    item.Price
                ));
            }
        }
    }
}