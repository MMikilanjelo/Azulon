using Application.State_Machine.Global_State_Machine.Abstractions;
using Application.State_Machine.Global_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Global_State_Machine.States.Main_State;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using Infrastructure.Services.Scene_Loading_Service;
using UI.Screen_Mediator;

namespace Application.State_Machine.Global_State_Machine.States.Boot_State
{
    public class BootState : GlobalStateBase, IEnterState
    {
        private readonly ISceneLoadingService _sceneLoadingService;
        private readonly IFactoryProvider _factoryProvider;
        private readonly IScreenMediator _screenMediator;

        public BootState(
            IGlobalStateMachine stateMachine,
            ISceneLoadingService sceneLoadingService,
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _sceneLoadingService = sceneLoadingService;
            _screenMediator = screenMediator;
        }

        public async void Enter()
        {
            _factoryProvider.Initialize();

            await _screenMediator.Initialize();

            await _sceneLoadingService.LoadSceneAsync(SceneName.MainScene);

            _sceneLoadingService.MoveGameObjectToScene(_screenMediator.ScreenRoot.gameObject, SceneName.MainScene);

            await _sceneLoadingService.UnloadSceneAsync(SceneName.BootScene);

            StateMachine.Enter<MainState>();
        }
    }
}