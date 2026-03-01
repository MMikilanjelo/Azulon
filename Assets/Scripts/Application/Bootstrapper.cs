using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Application.State_Machine.Global_State_Machine;
using Application.State_Machine.Global_State_Machine.States.Boot_State;
using Infrastructure.Asset_Provider;
using Infrastructure.Color_Provider;
using Infrastructure.Drag_Position_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Services;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Services.Scene_Loading_Service;
using Infrastructure.Update_Loop_Service;
using UI.UI_Root.Mediator;
using UnityEngine;

namespace Application
{
    public class Bootstrapper : MonoBehaviour
    {
        private const string TimeServicePath = "Services/TimeService";

        public void Start()
        {
            DontDestroyOnLoad(gameObject);

            var assetProvider = new AssetProvider();

            var gridService = new GridService();

            var sceneLoadingService = new SceneLoadingService();

            var timeService = CreateTimeService(assetProvider);

            var dragPositionProvider = new DragPositionProvider();

            var factoryProvider = new FactoryProvider(assetProvider);

            var screenMediator = new ScreenMediator(factoryProvider);

            var popupMediator = new PopupStackMediator(screenMediator);

            var playerModel = new PlayerModel();

            var inventoryModel = new InventoryModel();

            var shopModel = new ShopModel();

            var colorProvider = new ColorProvider();

            var stateMachine = new GlobalStateMachine(
                sceneLoadingService,
                factoryProvider,
                screenMediator,
                screenMediator,
                gridService,
                dragPositionProvider,
                timeService,
                popupMediator,
                playerModel,
                inventoryModel,
                shopModel,
                assetProvider,
                colorProvider
            );

            stateMachine.Enter<BootState>();
        }

        private static ITimeService CreateTimeService(IAssetProvider assetProvider)
        {
            var prefab = assetProvider.Load<GameObject>(TimeServicePath);

            return Instantiate(prefab).GetComponent<ITimeService>();
        }
    }
}