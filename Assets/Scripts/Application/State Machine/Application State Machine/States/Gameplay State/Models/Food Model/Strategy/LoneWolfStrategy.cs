using System.Collections.Generic;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy
{
    /// <summary>
    /// Honey: scores double when placed alone — pure and undiluted
    /// </summary>
    public class LoneWolfStrategy : IFoodResolutionStrategy
    {
        private readonly int _baseValue;
        private readonly float _loneMultiplier;
        private readonly string _comboLabel;

        public LoneWolfStrategy(int baseValue, float loneMultiplier = 2f, string comboLabel = "PURE!")
        {
            _baseValue = baseValue;
            _loneMultiplier = loneMultiplier;
            _comboLabel = comboLabel;
        }

        public CellResolutionResult Resolve(FoodModel food, IReadOnlyList<FoodModel> neighbours)
        {
            var isAlone = neighbours.Count == 0;
            var multiplier = isAlone ? _loneMultiplier : 1f;
            var gold = Mathf.RoundToInt(_baseValue * multiplier);

            return new CellResolutionResult(
                food.GridPosition.Value,
                food.Definition.Icon,
                gold,
                isAlone,
                isAlone ? _comboLabel : ""
            );
        }
    }
}