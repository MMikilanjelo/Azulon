using System.Collections.Generic;
using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.Models.Shop_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;
using UnityEngine;

namespace UI.Gameplay_State_UI.Mediator.Interfaces
{
    public interface IGameplayStateUIMediator
    {
        IReadOnlyReactiveEvent<EmptyEvent> FinishTurnClicked { get; }
        IReadOnlyReactiveEvent<Vector2Int> BoardCellClicked { get; }
        IReadOnlyReactiveEvent<InventoryItemModel> InventoryItemClicked { get; }
        IReadOnlyReactiveEvent<ShopItemModel> ShopItemClicked { get; }

        void Initialize(GameplayState gameplayState);
        Task CreateGameplayScreen();
        Task FillBoard(IReadOnlyList<Vector2Int> positions);
        void Dispose();
    }
}