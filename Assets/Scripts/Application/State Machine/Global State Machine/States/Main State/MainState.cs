using Application.State_Machine.Application_State_Machine;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Shop;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;
using Application.State_Machine.Global_State_Machine.Abstractions;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Core.State_Machine.States;
using Infrastructure.Asset_Provider;
using Infrastructure.Drag_Position_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Update_Loop_Service;
using TMPro.EditorUtilities;
using UI.UI_Root.Mediator.Interfaces;

namespace Application.State_Machine.Global_State_Machine.States.Main_State
{
    public class MainState : GlobalStateBase, IEnterState
    {
        private readonly IApplicationStateMachine _applicationStateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IShopModel _shopModel;
        private readonly IPlayerModel _playerModel;

        public MainState(
            IGlobalStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IScreenStackMediator screenStackMediator,
            IGridService gridService,
            IDragPositionProvider dragPositionProvider,
            ITimeService timeService,
            IUIRootMediator uiRootMediator,
            IPopupStackMediator popupStackMediator,
            IPlayerModel playerModel,
            IInventoryModel inventoryModel,
            IShopModel shopModel,
            IAssetProvider assetProvider
        ) : base(stateMachine)
        {
            _assetProvider = assetProvider;

            _shopModel = shopModel;

            _playerModel = playerModel;

            _applicationStateMachine = new ApplicationStateMachine(
                factoryProvider,
                screenStackMediator,
                gridService,
                dragPositionProvider,
                timeService,
                uiRootMediator,
                popupStackMediator,
                playerModel,
                inventoryModel,
                shopModel
            );
        }

        public async void Enter()
        {
            var shopCatalog = await _assetProvider.LoadAsync<ShopCatalogDefinition>(AssetAddress.ShopCatalogDefinition);

            _shopModel.Initialize(shopCatalog);

            _playerModel.EarnGold(100);

            _applicationStateMachine.Enter<MainMenuState>();
        }
    }
}