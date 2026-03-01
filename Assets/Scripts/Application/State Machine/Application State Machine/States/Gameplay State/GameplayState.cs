using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.Abstractions;
using Application.State_Machine.Application_State_Machine.Abstractions.Interfaces;
using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Grid_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Selection_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Deselect_Inventory_Item_Use_Case;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Place_Item_From_Inventory_Use_Case;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Resolve_Grid_Use_Case;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Select_Inventory_Item_Use_Case;
using Core.Disposables;
using Core.Extensions;
using Core.Reactive.Collections.Interfaces;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;
using Core.State_Machine.States;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.Game_Factory;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State
{
    public class GameplayState : ApplicationStateBase,
        IEnterState,
        IExitState
    {
        public IReadOnlyReactiveList<InventoryItemModel> InventoryItems => _inventoryModel.Items;
        public IReadOnlyReactiveList<ShopItemModel> ShopItems => _shopModel.Items;
        public IReadOnlyReactiveHashSet<FoodModel> GridItems => _gridModel.Items;
        public IReadOnlyReactiveProperty<int> PlayerGold => _playerModel.Gold;

        private readonly IFactoryProvider _factoryProvider;
        private readonly IGameplayStateUIMediator _uiMediator;

        private IGameFactory _gameFactory;

        private readonly IGridModel _gridModel;
        private readonly ISelectionModel _selectionModel;
        private readonly IInventoryModel _inventoryModel;

        private readonly IPlayerModel _playerModel;
        private readonly IShopModel _shopModel;

        private IPlaceItemFromInventoryUseCase _placeItemFromInventoryUseCase;
        private IDeselectInventoryItemUseCase _deselectInventoryItemUseCase;
        private IResolveGridUseCase _resolveGridUseCase;
        private ISelectInventoryItemUseCase _selectItemUseCase;

        private CompositeDisposable _subscriptions;

        public GameplayState(
            IApplicationStateMachine stateMachine,
            IFactoryProvider factoryProvider,
            IGameplayStateUIMediator uiMediator,
            IPlayerModel playerModel,
            IInventoryModel inventoryModel,
            IShopModel shopModel
        ) : base(stateMachine)
        {
            _factoryProvider = factoryProvider;
            _uiMediator = uiMediator;
            _playerModel = playerModel;
            _inventoryModel = inventoryModel;
            _shopModel = shopModel;

            _gridModel = new GridModel(3, 3);
            _selectionModel = new SelectionModel();
        }

        public void Enter()
        {
            _subscriptions = new CompositeDisposable();

            _gameFactory = _factoryProvider.GetFactoryById<IGameFactory>(FactoryId.Game);

            _placeItemFromInventoryUseCase ??= new PlaceItemFromInventoryUseCase(_gridModel, _gameFactory);
            _resolveGridUseCase ??= new ResolveGridUseCase(_gridModel, _playerModel);
            _selectItemUseCase ??= new SelectInventoryItemUseCase(_selectionModel);
            _deselectInventoryItemUseCase ??= new DeselectInventoryItemUseCase(_selectionModel);

            _uiMediator.InventoryItemClicked.Subscribe(OnInventoryItemSelected).AddTo(_subscriptions);
            _uiMediator.BoardCellClicked.Subscribe(cell => OnBoardCellClicked(cell).Forget()).AddTo(_subscriptions);
            _uiMediator.FinishTurnClicked.Subscribe(OnFinishTurnClicked).AddTo(_subscriptions);
            _uiMediator.ShopItemClicked.Subscribe(OnShopItemClicked).AddTo(_subscriptions);
            _uiMediator.Initialize(this);
            _uiMediator.CreateGameplayScreen().Forget();
            _uiMediator.FillBoard(_gridModel.GetAllPositions()).Forget();
        }


        public void Exit()
        {
            _subscriptions.Dispose();
            _uiMediator.Dispose();
        }

        private void OnFinishTurnClicked(EmptyEvent _) =>
            _resolveGridUseCase.Execute();

        private async Task OnBoardCellClicked(Vector2Int cell)
        {
            if (!_selectionModel.HasSelection)
            {
                return;
            }

            var selectedItem = _selectionModel.SelectedItem.Value;

            if (!await _placeItemFromInventoryUseCase.Execute(selectedItem, cell))
            {
                return;
            }

            _inventoryModel.Remove(selectedItem);

            _deselectInventoryItemUseCase.Execute();
        }

        private void OnShopItemClicked(ShopItemModel itemToPurchaseModel)
        {
            var isPurchaseSucceed = _playerModel.TryPurchase(itemToPurchaseModel.Price);

            if (!isPurchaseSucceed)
            {
                return;
            }

            var inventoryModel = new InventoryItemModel(
                itemToPurchaseModel.ItemId,
                itemToPurchaseModel.Category,
                itemToPurchaseModel.Icon
            );

            _inventoryModel.Add(inventoryModel);
        }

        private void OnInventoryItemSelected(InventoryItemModel item) =>
            _selectItemUseCase.Execute(item);
    }
}