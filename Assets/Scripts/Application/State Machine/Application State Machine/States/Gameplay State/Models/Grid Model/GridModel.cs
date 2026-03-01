using System.Collections.Generic;
using System.Linq;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Core.Reactive.Collections.Interfaces;
using Core.Registries;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Grid_Model
{
    public class GridModel : IGridModel
    {
        public IReadOnlyReactiveHashSet<FoodModel> Items => _gridItemRegistry.Items;
        public int Width { get; }
        public int Height { get; }
        public int MinX { get; }
        public int MaxX { get; }
        public int MinY { get; }
        public int MaxY { get; }

        private readonly Registry<FoodModel> _gridItemRegistry = new();

        public GridModel(int width, int height)
        {
            Width = width;
            Height = height;

            MinX = -Mathf.FloorToInt(width / 2f);

            MaxX = MinX + width - 1;

            MinY = -Mathf.FloorToInt(height / 2f);

            MaxY = MinY + height - 1;
        }

        public bool IsInBounds(Vector2Int coords) =>
            coords.x >= MinX && coords.x <= MaxX &&
            coords.y >= MinY && coords.y <= MaxY;

        public void ClearAll() =>
            _gridItemRegistry.Clear();

        public FoodModel GetItemAt(Vector2Int cell) =>
            _gridItemRegistry.Query(items => items.FirstOrDefault(item => item.GridPosition.Value == cell));

        public IReadOnlyList<Vector2Int> GetAllPositions()
        {
            var positions = new List<Vector2Int>();

            for (var x = MinX; x <= MaxX; x++)
            {
                for (var y = MinY; y <= MaxY; y++)
                {
                    positions.Add(new Vector2Int(x, y));
                }
            }

            return positions;
        }

        public bool IsCellEmpty(Vector2Int pos) =>
            GetItemAt(pos) == null;

        public bool CanPlaceItem(FoodModel item, Vector2Int targetOrigin)
        {
            if (!IsInBounds(targetOrigin))
            {
                return false;
            }

            var occupant = GetItemAt(targetOrigin);

            if (occupant != null && occupant != item)
            {
                return false;
            }

            return true;
        }

        public void RegisterItem(FoodModel item) =>
            _gridItemRegistry.TryAdd(item);
    }
}