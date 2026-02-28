using System.Collections.Generic;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models;
using Features.Plant;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Reduce_Adjacent_Plants_Turns_Use_Case
{
    public class ReduceAdjacentPlantsTurnsUseCase : IReduceAdjacentPlantsTurnsUseCase
    {
        private readonly IGridModel _gridModel;

        private static readonly Vector2Int[] NeighborDirections =
        {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        public ReduceAdjacentPlantsTurnsUseCase(IGridModel gridModel)
        {
            _gridModel = gridModel;
        }

        public void Execute(PlantModel origin, int reductionAmount = 1)
        {
            var uniqueNeighbors = new HashSet<PlantModel>();

            foreach (var offset in origin.Definition.ShapeOffsets)
            {
                var cell = origin.GridPosition.Value + offset;

                foreach (var dir in NeighborDirections)
                {
                    var neighborCell = cell + dir;
                    
                    var occupant = _gridModel.GetItemAt(neighborCell);

                    if (occupant != null && occupant != origin)
                    {
                        uniqueNeighbors.Add(occupant);
                    }
                }
            }

            foreach (var neighbor in uniqueNeighbors)
            {
                neighbor.ReduceTurnsToMature(reductionAmount);
            }
        }
    }
}