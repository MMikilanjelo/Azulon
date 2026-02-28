using Application.State_Machine.Global_State_Machine.Abstractions;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Global_State_Machine.States.Main_State;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using Infrastructure.Services.Scene_Loading_Service;
using UI.UI_Root.Mediator.Interfaces;

namespace Application.State_Machine.Global_State_Machine.States.Boot_State
{
    public class BootState : GlobalStateBase, IEnterState
    {
        private readonly ISceneLoadingService _sceneLoadingService;
        private readonly IFactoryProvider _factoryProvider;
        private readonly IUIRootMediator _uiRootMediator;

        public BootState(
            IGlobalStateMachine stateMachine,
            ISceneLoadingService sceneLoadingService,
            IFactoryProvider factoryProvider,
            IUIRootMediator uiRootMediator
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _sceneLoadingService = sceneLoadingService;
            _uiRootMediator = uiRootMediator;
        }

        public async void Enter()
        {
            _factoryProvider.Initialize();

            await _uiRootMediator.Initialize();

            await _sceneLoadingService.LoadSceneAsync(SceneName.MainScene);

            _sceneLoadingService.MoveGameObjectToScene(_uiRootMediator.UIRoot.gameObject, SceneName.MainScene);

            await _sceneLoadingService.UnloadSceneAsync(SceneName.BootScene);

            StateMachine.Enter<MainState>();
        }
    }
}