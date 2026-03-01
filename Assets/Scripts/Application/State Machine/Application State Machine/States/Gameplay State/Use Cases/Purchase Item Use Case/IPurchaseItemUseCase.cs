using Application.State_Machine.Application_State_Machine.Models.Shop_Model;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Purchase_Item_Use_Case
{
    public interface IPurchaseItemUseCase
    {
        bool Execute(ShopItemModel itemToPurchaseModel);
    }
}