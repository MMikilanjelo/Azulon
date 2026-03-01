using UnityEngine;

namespace UI.Gameplay_State_UI.Mediator.Interfaces
{
    public interface IShopPopupMediator
    {
        void OnShopPopUpDimmerClicked();
        void OnShopOpened(Transform parent);
    }
}