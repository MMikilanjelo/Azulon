using Application.State_Machine.Global_State_Machine;
using Application.State_Machine.Global_State_Machine.States.Boot_State;
using Infrastructure.Asset_Provider;
using Infrastructure.Drag_Position_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Services;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Services.Scene_Loading_Service;
using Infrastructure.Update_Loop_Service;
using UI.Screen_Mediator;
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

            var stateMachine = new GlobalStateMachine(
                sceneLoadingService,
                factoryProvider,
                screenMediator,
                gridService,
                dragPositionProvider,
                timeService
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