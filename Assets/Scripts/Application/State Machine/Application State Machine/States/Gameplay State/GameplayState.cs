using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Drag_Grid_Item_Use_Case;
using Core.Disposables;
using Core.Extensions;
using Core.State_Machine.States;
using Features.Grid_Item;
using Infrastructure.Drag_Position_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.Game_Factory;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Update_Loop_Service;
using UI.Screen_Mediator;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State
{
    public class GameplayState : ApplicationStateBase,
        IEnterState,
        IExitState,
        IGameplayScreenModel,
        IShopPopupModel
    {
        private readonly IFactoryProvider _factoryProvider;
        private readonly IScreenMediator _screenMediator;
        private readonly IGridService _gridService;
        private readonly ITimeService _timeService;

        private IGameFactory _gameFactory;
        private IGameplayStateUIFactory _uiFactory;

        private GridModel _gridModel;

        private CompositeDisposable _subscriptions;

        private readonly IDragGridItemUseCase _dragGridItemUseCase;

        public GameplayState(
            IApplicationStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator,
            IGridService gridService,
            IDragPositionProvider dragPositionProvider,
            ITimeService timeService
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _screenMediator = screenMediator;
            _gridService = gridService;
            _timeService = timeService;

            _dragGridItemUseCase = new DragGridItemUseCase(dragPositionProvider);
        }

        public async void Enter()
        {
            _subscriptions = new CompositeDisposable();
            _gridModel ??= new GridModel(320, 320);

            _uiFactory = _factoryProvider.GetFactoryById<IGameplayStateUIFactory>(FactoryId.UI);
            _gameFactory = _factoryProvider.GetFactoryById<IGameFactory>(FactoryId.Game);

            _screenMediator.Push(parent => _uiFactory.CreateGameplayScreen(parent, this)).Forget();

            var gridItem = await _gameFactory.CreateGridItem(null, Vector3.zero);

            _gridModel.AddItem(gridItem);

            _subscriptions.Add(gridItem.DragEnded.Subscribe(OnItemDragEnded));
            _subscriptions.Add(gridItem.DragStarted.Subscribe(OnItemGridStarted));

            _subscriptions.Add(_timeService.UpdateTicked.Subscribe(OnUpdateTicked));
        }

        public void Exit()
        {
            _subscriptions.Dispose();
        }

        public void OpenInventory()
        {
        }

        public async void OpenShop()
        {
            var viewModel = await _uiFactory.CreateShopPopup(_screenMediator.ScreenRoot, this);

            viewModel.Show();
        }

        private void OnItemDragEnded(GridItem item)
        {
            _dragGridItemUseCase.StopDrag();

            var gridPos = _gridService.WorldToGrid(item.WorldPosition.Value);

            var finalPos = _gridService.GridToWorld(gridPos);

            item.UpdateGridPosition(gridPos);
            
            item.UpdateWorldPosition(finalPos);
        }

        private void OnItemGridStarted(GridItem view) =>
            _dragGridItemUseCase.StartDrag(view);

        private void OnUpdateTicked(float deltaTime) =>
            _dragGridItemUseCase.UpdateItemPosition(deltaTime);
    }
}