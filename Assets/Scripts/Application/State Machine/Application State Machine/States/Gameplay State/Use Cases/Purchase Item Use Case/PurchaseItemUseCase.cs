using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Core.Reactive.Events;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Purchase_Item_Use_Case
{
    public class PurchaseItemUseCase : IPurchaseItemUseCase
    {
        private readonly IPlayerModel _playerModel;

        private readonly IInventoryModel _inventoryModel;

        public PurchaseItemUseCase(IPlayerModel playerModel, IInventoryModel inventoryModel)
        {
            _playerModel = playerModel;
            _inventoryModel = inventoryModel;
        }

        public bool Execute(ShopItemModel itemToPurchaseModel)
        {
            var isPurchaseSucceed = _playerModel.TryPurchase(itemToPurchaseModel.Price);

            if (!isPurchaseSucceed)
            {
                return false;
            }

            var inventoryModel = new InventoryItemModel(
                itemToPurchaseModel.ItemId,
                itemToPurchaseModel.Category,
                itemToPurchaseModel.Icon
            );

            _inventoryModel.Add(inventoryModel);

            return true;
        }
    }
}