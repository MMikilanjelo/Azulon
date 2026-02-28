using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State.Interfaces;
using Infrastructure.Asset_Provider;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Gameplay_State_UI.Gameplay_Screen.View_Model;
using UI.Gameplay_State_UI.Gameplay_Screen.View;
using UI.Gameplay_State_UI.Shop_Popup_View.View_Model;
using UI.Gameplay_State_UI.Shop_Popup_View.View;
using UI.Main_Menu_State_UI.Main_Menu_Screen.View_Model;
using UI.Main_Menu_State_UI.Main_Menu_Screen.View;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.UI_Factory
{
    public class UIFactory : IMainMenuStateUIFactory, IGameplayStateUIFactory
    {
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<IMainMenuScreenViewModel> CreateMainMenuScreen(Transform parent, IMainMenuScreenModel model)
        {
            var viewModel = new MainMenuScreenViewModel(model);

            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.MainMenuScreenView);

            var view = Object.Instantiate(prefab, parent).GetComponent<MainMenuScreenView>();

            view.Bind(viewModel);

            return viewModel;
        }

        public async Task<IGameplayScreenViewModel> CreateGameplayScreen(Transform parent, IGameplayScreenModel model)
        {
            var viewModel = new GameplayScreenViewModel(model);

            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.GameplayScreenView);

            var view = Object.Instantiate(prefab, parent).GetComponent<GameplayScreenView>();

            view.Bind(viewModel);

            return viewModel;
        }

        public async Task<IShopPopupViewModel> CreateShopPopup(Transform parent, IShopPopupModel model)
        {
            var viewModel = new ShopPopupViewModel(model);

            var prefab = await _assetProvider.LoadAsync<GameObject>(AssetAddress.ShopPopupView);

            var view = Object.Instantiate(prefab, parent).GetComponent<ShopPopupView>();

            view.Bind(viewModel);
            
            return viewModel;
        }
    }
}