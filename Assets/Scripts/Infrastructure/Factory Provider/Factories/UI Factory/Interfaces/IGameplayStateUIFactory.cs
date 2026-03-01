using System.Threading.Tasks;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI.Abstractions;
using UI.Abstractions.Interfaces;
using UI.Components;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UI.Gameplay_State_UI.Views;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces
{
    public interface IGameplayStateUIFactory : IFactory
    {
        Task<IScreenView> CreateGameplayScreen(Transform parent, IGameplayScreenMediator mediator);
        Task<IPopupView> CreateShopPopup(Transform parent, IShopPopupMediator mediator);
        Task<IPopupView> CreateInventoryPopup(Transform parent, IInventoryPopupMediator mediator);
        Task<BoardView> CreateBoardView(Transform parent);
        Task<BoardCellView> CreateBoardCellView(Transform parent);
        Task<InventoryItemView> CreateInventoryItemView(Transform parent);
        Task<ShopItemView> CreateShopItemView(Transform parent);
        Task<FloatingTextView> CreateFloatingTextView(Transform parent);
    }
}