using System.Collections.Generic;
using Application.State_Machine.Application_State_Machine.Models.Player_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Grid_Model;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Resolve_Grid_Use_Case
{
    public class ResolveGridUseCase : IResolveGridUseCase
    {
        private readonly IGridModel _gridModel;
        private readonly IPlayerModel _playerModel;

        private static readonly Vector2Int[] Directions =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        public ResolveGridUseCase(IGridModel gridModel, IPlayerModel playerModel)
        {
            _gridModel = gridModel;
            _playerModel = playerModel;
        }

        public GridResolutionResult Execute()
        {
            var foods = _gridModel.Items;

            var cellResults = new List<CellResolutionResult>();

            foreach (var food in foods)
            {
                var neighbours = GetNeighbours(food.GridPosition.Value);

                var result = food.Resolve(neighbours);

                cellResults.Add(result);
            }

            var resolution = new GridResolutionResult(cellResults);

            _playerModel.EarnGold(resolution.TotalGold);

            _gridModel.ClearAll();

            return resolution;
        }

        private IReadOnlyList<FoodModel> GetNeighbours(Vector2Int pos)
        {
            var result = new List<FoodModel>();

            foreach (var dir in Directions)
            {
                var neighbour = _gridModel.GetItemAt(pos + dir);

                if (neighbour != null)
                {
                    result.Add(neighbour);
                }
            }

            return result;
        }
    }
}