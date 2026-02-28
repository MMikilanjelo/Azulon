using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Drag_Grid_Item_Use_Case;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Place_GridItem_Use_Case;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Reduce_Adjacent_Plants_Turns_Use_Case;
using Core.Disposables;
using Core.Extensions;
using Core.Reactive.Collections.Interfaces;
using Core.Registries;
using Core.State_Machine.States;
using Features.Inventory;
using Features.Plant;
using Infrastructure.Drag_Position_Provider;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.Game_Factory;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using Infrastructure.Services.Grid_Service;
using Infrastructure.Update_Loop_Service;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UI.UI_Root.Mediator.Interfaces;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State
{
    public class GameplayState : ApplicationStateBase,
        IEnterState,
        IExitState
    {
        public IReadOnlyReactiveHashSet<InventoryItemModel> InventoryItems => _inventory.Items;

        private readonly IFactoryProvider _factoryProvider;
        private readonly ITimeService _timeService;
        private readonly IGameplayStateUIMediator _uiMediator;

        private IGameFactory _gameFactory;

        private readonly IGridModel _gridModel;

        private CompositeDisposable _subscriptions;

        private readonly IDragGridItemUseCase _dragGridItemUseCase;
        private readonly IPlacePlantUseCase _placePlantUseCase;
        private readonly IReduceAdjacentPlantsTurnsUseCase _reduceAdjacentPlantsTurnsUseCase;
        private readonly Registry<InventoryItemModel> _inventory = new();

        public GameplayState(
            IApplicationStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IGridService gridService,
            IDragPositionProvider dragPositionProvider,
            ITimeService timeService,
            IGameplayStateUIMediator uiMediator
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _timeService = timeService;
            _uiMediator = uiMediator;

            _gridModel = new GridModel(320, 320);

            _dragGridItemUseCase = new DragGridItemUseCase(dragPositionProvider);

            _placePlantUseCase = new PlacePlantUseCase(_gridModel, gridService);

            _reduceAdjacentPlantsTurnsUseCase = new ReduceAdjacentPlantsTurnsUseCase(_gridModel);
        }

        public async void Enter()
        {
            _subscriptions = new CompositeDisposable();

            _gameFactory = _factoryProvider.GetFactoryById<IGameFactory>(FactoryId.Game);

            _uiMediator.Initialize(this);

            _uiMediator.CreateGameplayScreen().Forget();

            // var gridItem = await _gameFactory.CreatePlant(null, Vector3.zero);
            // gridItem.DragEnded.Subscribe(OnItemDragEnded).AddTo(_subscriptions);
            // gridItem.DragStarted.Subscribe(OnItemGridStarted).AddTo(_subscriptions);
            //
            // var gridItem2 = await _gameFactory.CreatePlant(null, Vector3.zero * 4);
            // gridItem2.DragEnded.Subscribe(OnItemDragEnded).AddTo(_subscriptions);
            // gridItem2.DragStarted.Subscribe(OnItemGridStarted).AddTo(_subscriptions);
            //
            // _gridModel.RegisterItem(gridItem.Model);
            // _gridModel.RegisterItem(gridItem2.Model);
            // _timeService.UpdateTicked.Subscribe(OnUpdateTicked).AddTo(_subscriptions);
        }

        public void Exit()
        {
            _subscriptions.Dispose();
            _uiMediator.Dispose();
        }

        private void OnItemDragEnded(PlantModel item)
        {
            _dragGridItemUseCase.StopDrag();

            _placePlantUseCase.Execute(item);
        }

        private void OnItemGridStarted(PlantModel view) =>
            _dragGridItemUseCase.StartDrag(view);

        private void OnUpdateTicked(float deltaTime) =>
            _dragGridItemUseCase.UpdateItemPosition(deltaTime);
    }
}