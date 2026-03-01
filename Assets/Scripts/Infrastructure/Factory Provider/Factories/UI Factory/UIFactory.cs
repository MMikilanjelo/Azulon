using System.Threading.Tasks;
using Infrastructure.Asset_Provider;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Abstractions;
using UI.Abstractions.Interfaces;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UI.Gameplay_State_UI.Views;
using UI.Main_Menu_State_UI.Mediator.Interfaces;
using UI.Main_Menu_State_UI.Views;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory
{
    public class UIFactory :
        IMainMenuStateUIFactory,
        IGameplayStateUIFactory,
        IInventoryUIFactory
    {
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<IScreenView> CreateMainMenuScreen(Transform parent, IMainMenuScreenMediator mediator)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.MainMenuScreenView);

            var view = Object.Instantiate(prefab, parent).GetComponent<MainMenuScreenView>();

            view.Construct(mediator);

            return view;
        }

        public async Task<IScreenView> CreateGameplayScreen(Transform parent, IGameplayScreenMediator mediator)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.GameplayScreenView);

            var view = Object.Instantiate(prefab, parent).GetComponent<GameplayScreenView>();

            view.Construct(mediator);

            return view;
        }

        public async Task<IPopupView> CreateShopPopup(Transform parent, IShopPopupMediator mediator)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.ShopPopupView);

            var view = Object.Instantiate(prefab, parent).GetComponent<ShopPopupView>();

            view.Construct(mediator);

            return view;
        }

        public async Task<IPopupView> CreateInventoryPopup(Transform parent, IInventoryPopupMediator mediator)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.InventoryPopupView);

            var view = Object.Instantiate(prefab, parent).GetComponent<InventoryPopupView>();

            view.Construct(mediator);

            return view;
        }

        public async Task<BoardView> CreateBoardView(Transform parent)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.BoardView);

            var view = Object.Instantiate(prefab, parent).GetComponent<BoardView>();

            return view;
        }

        public async Task<BoardCellView> CreateBoardCellView(Transform parent)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.BoardCellView);

            var view = Object.Instantiate(prefab, parent).GetComponent<BoardCellView>();

            return view;
        }

        public async Task<InventoryItemView> CreateInventoryItemView(Transform parent)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.InventoryItemView);

            var view = Object.Instantiate(prefab, parent).GetComponent<InventoryItemView>();

            return view;
        }

        public async Task<ShopItemView> CreateShopItemView(Transform parent)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.ShopItemView);

            var view = Object.Instantiate(prefab, parent).GetComponent<ShopItemView>();

            return view;
        }
    }
}