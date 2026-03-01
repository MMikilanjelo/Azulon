using System.Collections.Generic;
using System.Linq;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Foods;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy
{
    /// <summary>
    ///  Beef: good near Noodle (+50%), bad near Honey (-20%)
    ///  Calamari: good near Fish (+75%)
    /// </summary>
    public class AdjacencyMultiplierStrategy : IFoodResolutionStrategy
    {
        private readonly int _baseValue;

        private readonly AdjacencyRuleDefinition[] _rules;

        public AdjacencyMultiplierStrategy(int baseValue, AdjacencyRuleDefinition[] rules)
        {
            _baseValue = baseValue;
            _rules = rules;
        }

        public CellResolutionResult Resolve(FoodModel food, IReadOnlyList<FoodModel> neighbours)
        {
            var multiplier = 1f;

            var comboLabel = string.Empty;

            foreach (var rule in _rules)
            {
                if (neighbours.All(n => n.Definition.FoodId != rule.NeighbourId))
                {
                    continue;
                }

                multiplier += rule.Multiplier - 1f;

                if (rule.Multiplier > 1f)
                {
                    comboLabel = rule.ComboLabel;
                }
            }

            var gold = Mathf.RoundToInt(_baseValue * multiplier);

            return new CellResolutionResult(
                food.GridPosition.Value,
                food.Definition.Icon,
                gold,
                multiplier > 1f,
                comboLabel
            );
        }
    }
}