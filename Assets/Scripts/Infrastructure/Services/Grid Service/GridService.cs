using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Services.Grid_Service
{
    public class GridService : IGridService
    {
        private readonly float _cellSize = 1f;

        public Vector2 GridToWorld(Vector2Int gridPos) =>
            new(gridPos.x * _cellSize, gridPos.y * _cellSize);

        public Vector2Int WorldToGrid(Vector3 worldPos)
        {
            return new Vector2Int(
                Mathf.RoundToInt(worldPos.x / _cellSize),
                Mathf.RoundToInt(worldPos.y / _cellSize)
            );
        }

        public ICollection<Vector2Int> GetShapeCoords(Vector2Int origin, List<Vector2Int> offsets) =>
            offsets.Select(offset => origin + offset).ToList();
    }
}