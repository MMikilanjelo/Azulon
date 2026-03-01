using System.Collections.Generic;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy;
using Core.Reactive;
using Core.Reactive.Interfaces;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model
{
    public class FoodModel
    {
        public IReadOnlyReactiveProperty<Vector2Int> GridPosition => _gridPosition;
        public FoodDefinition Definition { get; }

        private readonly ReactiveProperty<Vector2Int> _gridPosition;
        private readonly IFoodResolutionStrategy _strategy;

        public FoodModel(
            FoodDefinition definition,
            IFoodResolutionStrategy strategy,
            Vector2Int gridPosition
        )
        {
            Definition = definition;

            _strategy = strategy;

            _gridPosition = new ReactiveProperty<Vector2Int>(gridPosition);
        }

        public void SetGridPosition(Vector2Int gridPosition) =>
            _gridPosition.Value = gridPosition;

        public CellResolutionResult Resolve(IReadOnlyList<FoodModel> neighbours) =>
            _strategy.Resolve(this, neighbours);
    }
}