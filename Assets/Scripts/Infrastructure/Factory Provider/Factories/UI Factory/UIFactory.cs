using System.Threading.Tasks;
using Infrastructure.Asset_Provider;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Abstractions;
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

        public async Task<IScreenView> CreateShopPopup(Transform parent, IShopPopupMediator mediator)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.ShopPopupView);

            var view = Object.Instantiate(prefab, parent).GetComponent<ShopPopupView>();

            view.Construct(mediator);

            return view;
        }

        public async Task<IScreenView> CreateInventoryPopup(Transform parent, IInventoryPopupMediator mediator)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.InventoryPopupView);

            var view = Object.Instantiate(prefab, parent).GetComponent<InventoryPopupView>();

            view.Construct(mediator);

            return view;
        }

        // public async Task<InventoryItemView> CreateInventoryItemView(Transform parent, IInventoryItemViewModel viewModel)
        // {
        //     var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.InventoryItemView);
        //
        //     var view = Object.Instantiate(prefab, parent).GetComponent<InventoryItemView>();
        //
        //     view.Bind(viewModel);
        //
        //     return view;
        // }
    }
}