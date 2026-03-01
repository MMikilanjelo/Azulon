using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Global_State_Machine.States.Boot_State;
using Application.State_Machine.Global_State_Machine.States.Main_State;
using Core.State_Machine;
using Infrastructure.Asset_Provider;
using Infrastructure.Drag_Position_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Services;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Services.Scene_Loading_Service;
using Infrastructure.Update_Loop_Service;
using UI.UI_Root.Mediator.Interfaces;
using Unity.VisualScripting;

namespace Application.State_Machine.Global_State_Machine
{
    public class GlobalStateMachine : StateMachineBase<IGlobalState>, IGlobalStateMachine
    {
        public GlobalStateMachine(
            ISceneLoadingService sceneLoadingService,
            IFactoryProvider factoryProvider,
            IScreenStackMediator screenStackMediator,
            IUIRootMediator uiRootMediator,
            IGridService gridService,
            IDragPositionProvider dragPositionProvider,
            ITimeService timeService,
            IPopupStackMediator popupStackMediator,
            IPlayerModel playerModel,
            IInventoryModel inventoryModel,
            IShopModel shopModel,
            IAssetProvider assetProvider
        )
        {
            var bootState = new BootState(
                this,
                sceneLoadingService,
                factoryProvider,
                uiRootMediator
            );

            var mainState = new MainState(
                this,
                factoryProvider,
                screenStackMediator,
                gridService,
                dragPositionProvider,
                timeService,
                uiRootMediator,
                popupStackMediator,
                playerModel,
                inventoryModel,
                shopModel,
                assetProvider
            );

            RegisterState(bootState);
            RegisterState(mainState);
        }
    }
}