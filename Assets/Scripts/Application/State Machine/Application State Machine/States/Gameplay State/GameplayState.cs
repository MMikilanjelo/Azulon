using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Interfaces;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models;
using Core.Disposables;
using Core.Extensions;
using Core.Reactive.Events;
using Core.State_Machine.States;
using Features.Grid_Item;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.Game_Factory;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using Infrastructure.Services.Grid_Service;
using UI.Screen_Mediator;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State
{
    public class GameplayState : ApplicationStateBase, IEnterState, IExitState, IGameplayScreenUIModel
    {
        private readonly IFactoryProvider _factoryProvider;
        private readonly IScreenMediator _screenMediator;
        private readonly IGridService _gridService;

        private IGameFactory _gameFactory;
        private IGameplayStateUIFactory _uiFactory;

        private GridModel _gridModel;

        private CompositeDisposable _subscriptions;

        public GameplayState(
            IApplicationStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IScreenMediator screenMediator,
            IGridService gridService
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _screenMediator = screenMediator;
            _gridService = gridService;
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
        }

        public void Exit()
        {
            _subscriptions.Dispose();
        }

        public void OpenInventory()
        {
        }

        public void OpenShop()
        {
        }

        private void OnItemPlaced()
        {
        }

        private void OnItemDragEnded(GridItemView view)
        {
            var worldPos = view.transform.position;

            var gridPos = _gridService.WorldToGrid(worldPos);

            var finalPos = _gridService.GridToWorld(gridPos);

            view.SlideTo(finalPos);
        }
    }
}