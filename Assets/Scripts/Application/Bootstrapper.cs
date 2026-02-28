using Application.State_Machine.Global_State_Machine;
using Application.State_Machine.Global_State_Machine.States.Boot_State;
using Infrastructure.Asset_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Services;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Services.Scene_Loading_Service;
using UI.Screen_Mediator;
using UnityEngine;

namespace Application
{
    public class Bootstrapper : MonoBehaviour
    {
        public void Start()
        {
            DontDestroyOnLoad(gameObject);

            var assetProvider = new AssetProvider();

            var gridService = new GridService();

            var sceneLoadingService = new SceneLoadingService();

            var factoryProvider = new FactoryProvider(assetProvider);

            var screenMediator = new ScreenMediator(factoryProvider);

            var stateMachine = new GlobalStateMachine(
                sceneLoadingService,
                factoryProvider,
                screenMediator,
                gridService
            );

            stateMachine.Enter<BootState>();
        }
    }
}