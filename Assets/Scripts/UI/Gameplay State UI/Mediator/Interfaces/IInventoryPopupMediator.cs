using UnityEngine;

namespace UI.Gameplay_State_UI.Mediator.Interfaces
{
    public interface IInventoryPopupMediator
    {
        void OnInventoryOpened(Transform inventoryItemsParent);
        void OnCloseInventoryButtonClicked();
    }
}