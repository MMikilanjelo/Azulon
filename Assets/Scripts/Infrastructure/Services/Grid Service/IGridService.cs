using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.Grid_Service
{
    public interface IGridService
    {
        Vector2 GridToWorld(Vector2Int gridPos);
        Vector2Int WorldToGrid(Vector3 worldPos);
        ICollection<Vector2Int> GetShapeCoords(Vector2Int origin, List<Vector2Int> offsets);
    }
}