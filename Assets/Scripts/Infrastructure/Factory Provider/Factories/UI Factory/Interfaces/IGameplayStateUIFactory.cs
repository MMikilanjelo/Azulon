using System.Threading.Tasks;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI.Abstractions;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces
{
    public interface IGameplayStateUIFactory : IFactory
    {
        Task<IScreenView> CreateGameplayScreen(Transform parent, IGameplayScreenMediator mediator);
        Task<IScreenView> CreateShopPopup(Transform parent, IShopPopupMediator mediator);
        Task<IScreenView> CreateInventoryPopup(Transform parent, IInventoryPopupMediator mediator);
    }
}