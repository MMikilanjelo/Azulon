using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Application.State_Machine.Application_State_Machine.States.Main_Menu_State;
using Core.State_Machine;
using Infrastructure.Color_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Update_Loop_Service;
using UI.Gameplay_State_UI.Mediator;
using UI.Main_Menu_State_UI.Mediator;
using UI.UI_Root.Mediator.Interfaces;
using UnityEditor.SceneManagement;

namespace Application.State_Machine.Application_State_Machine
{
    public class ApplicationStateMachine : StateMachineBase<IApplicationState>, IApplicationStateMachine
    {
        public ApplicationStateMachine(
            IFactoryProvider factoryProvider,
            IScreenStackMediator screenStackMediator,
            IGridService gridService,
            ITimeService timeService,
            IUIRootMediator uiRootMediator,
            IPopupStackMediator popupStackMediator,
            IPlayerModel playerModel,
            IInventoryModel inventoryModel,
            IShopModel shopModel,
            IColorProvider colorProvider
        )
        {
            var mainStateMediator = new MainMenuStateUIMediator(factoryProvider, screenStackMediator);

            var mainState = new MainMenuState(
                this,
                mainStateMediator
            );

            var gameplayStateMediator = new GameplayStateUIMediator(
                factoryProvider,
                screenStackMediator,
                uiRootMediator,
                popupStackMediator,
                colorProvider
            );

            var gameplayState = new GameplayState(
                this,
                factoryProvider,
                gameplayStateMediator,
                playerModel,
                inventoryModel,
                shopModel
            );

            RegisterState(mainState);

            RegisterState(gameplayState);
        }
    }
}