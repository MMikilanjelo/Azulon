using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Core.Disposables;
using Core.Extensions;
using Core.Reactive;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using TMPro;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UI.Gameplay_State_UI.Views;
using UI.UI_Root.Mediator.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace UI.Gameplay_State_UI.Mediator
{
    public class GameplayStateUIMediator :
        IGameplayStateUIMediator,
        IGameplayScreenMediator,
        IShopPopupMediator,
        IInventoryPopupMediator
    {
        public IReadOnlyReactiveEvent<Vector2Int> BoardCellClicked => _boardCellClicked;
        public IReadOnlyReactiveEvent<EmptyEvent> FinishTurnClicked => _finishTurnClicked;
        public IReadOnlyReactiveEvent<InventoryItemModel> InventoryItemClicked => _inventoryItemClicked;

        private GameplayState _state;
        private IGameplayStateUIFactory _factory;

        private readonly IFactoryProvider _factoryProvider;
        private readonly IScreenStackMediator _screenStackMediator;
        private readonly IUIRootMediator _uiRootMediator;
        private readonly IPopupStackMediator _popupStackMediator;

        private BoardView _boardView;

        private readonly Dictionary<BoardCellView, Vector2Int> _boardViews = new();
        private readonly Dictionary<InventoryItemView, InventoryItemModel> _inventoryViews = new();

        private readonly ReactiveEvent<Vector2Int> _boardCellClicked = new();
        private readonly ReactiveEvent<InventoryItemModel> _inventoryItemClicked = new();
        private readonly ReactiveEvent<EmptyEvent> _finishTurnClicked = new();

        private CompositeDisposable _subscriptions = new();

        public GameplayStateUIMediator(
            IFactoryProvider factoryProvider,
            IScreenStackMediator screenStackMediator,
            IUIRootMediator uiRootMediator,
            IPopupStackMediator popupStackMediator
        )
        {
            _factoryProvider = factoryProvider;
            _screenStackMediator = screenStackMediator;
            _uiRootMediator = uiRootMediator;
            _popupStackMediator = popupStackMediator;
        }

        public void Initialize(GameplayState gameplayState)
        {
            _subscriptions = new CompositeDisposable();

            _state = gameplayState;

            _factory = _factoryProvider.GetFactoryById<IGameplayStateUIFactory>(FactoryId.UI);

            _state.InventoryItems.Removed.Subscribe(OnInventoryItemRemoved).AddTo(_subscriptions);
            _state.GridItems.Added.Subscribe(OnGridItemAdded).AddTo(_subscriptions);
            _state.GridItems.Removed.Subscribe(OnGridItemRemoved).AddTo(_subscriptions);
        }


        public void Dispose()
        {
            _subscriptions.Dispose();
            _screenStackMediator.PopAll();
            _popupStackMediator.PopAll();
        }

        public Task CreateGameplayScreen() =>
            _screenStackMediator.Push(parent => _factory.CreateGameplayScreen(parent, this));

        public async Task FillBoard(IReadOnlyList<Vector2Int> positions)
        {
            _boardView ??= await _factory.CreateBoardView(_uiRootMediator.UIRoot.GameplayUIContainer);

            foreach (var pos in positions)
            {
                var cell = await _factory.CreateBoardCellView(_boardView.GridLayoutGroup.transform);

                cell.Clicked.Subscribe(OnCellClicked);

                cell.HideAssignedItemImage();

                _boardViews[cell] = pos;
            }
        }

        public async Task FillInventory(Transform parent, IReadOnlyList<InventoryItemModel> items)
        {
            foreach (var item in items)
            {
                var view = await _factory.CreateInventoryItemView(parent);

                view.SetAssignedItemIcon(item.Icon);

                view.Clicked.Subscribe(OnInventoryItemClicked);

                _inventoryViews[view] = item;
            }
        }

        public void OnOpenShopButtonClicked() =>
            _popupStackMediator.Push(parent => _factory.CreateShopPopup(parent, this)).Forget();

        public void OnOpenInventoryButtonClicked() =>
            _popupStackMediator.Push(parent => _factory.CreateInventoryPopup(parent, this)).Forget();

        public void OnFinishTurnButtonClicked() =>
            _finishTurnClicked.Invoke(EmptyEvent.Default);

        public void OnShopPopUpDimmerClicked() =>
            _popupStackMediator.Pop().Forget();

        public void OnInventoryOpened(Transform inventoryItemsParent)
        {
            var items = _state.InventoryItems;

            FillInventory(inventoryItemsParent, items).Forget();
        }

        public void OnCloseInventoryButtonClicked()
        {
            _inventoryViews.Clear();

            _popupStackMediator.Pop().Forget();
        }

        private void OnCellClicked(BoardCellView view) =>
            _boardCellClicked.Invoke(_boardViews[view]);

        private void OnInventoryItemClicked(InventoryItemView view) =>
            _inventoryItemClicked.Invoke(_inventoryViews[view]);


        private void OnInventoryItemRemoved(InventoryItemModel model)
        {
            var kvp = _inventoryViews.FirstOrDefault(v => v.Value == model);

            if (kvp.Value is null)
            {
                return;
            }

            _inventoryViews.Remove(kvp.Key);

            kvp.Key.Destroy();
        }

        private void OnGridItemAdded(FoodModel model)
        {
            var kvp = _boardViews.FirstOrDefault(v => v.Value == (model.GridPosition.Value));

            kvp.Key?.ShowAssignedItemImage(model.Definition.Icon);
        }

        private void OnGridItemRemoved(FoodModel model)
        {
            var kvp = _boardViews.FirstOrDefault(v => v.Value == model.GridPosition.Value);

            if (kvp.Key is null)
            {
                return;
            }

            _boardViews.Remove(kvp.Key);

            kvp.Key.Destroy();
        }
    }
}