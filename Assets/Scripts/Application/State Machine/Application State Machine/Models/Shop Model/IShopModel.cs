using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Shop;
using Core.Reactive.Collections.Interfaces;

namespace Application.State_Machine.Application_State_Machine.Models.Shop_Model
{
    public interface IShopModel
    {
        IReadOnlyReactiveList<ShopItemModel> Items { get; }
        void Initialize(ShopCatalogDefinition catalog);
    }
}