using System.Linq;
using Core.Registries;
using Features.Plant;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models
{
    public class GridModel : IGridModel
    {
        public IRegistry<PlantModel> Registry => _gridItemRegistry;
        public int Width { get; }
        public int Height { get; }
        public int MinX { get; }
        public int MaxX { get; }
        public int MinY { get; }
        public int MaxY { get; }

        private readonly Registry<PlantModel> _gridItemRegistry = new();

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

        public PlantModel GetItemAt(Vector2Int cell)
        {
            return _gridItemRegistry.Query(items => items.FirstOrDefault(item =>
                item.Definition.ShapeOffsets.Any(offset => item.GridPosition.Value + offset == cell)));
        }

        public bool CanPlaceItem(PlantModel item, Vector2Int targetOrigin)
        {
            foreach (var offset in item.Definition.ShapeOffsets)
            {
                var targetCell = targetOrigin + offset;

                if (!IsInBounds(targetCell))
                {
                    return false;
                }

                var occupant = GetItemAt(targetCell);

                if (occupant != null && occupant != item)
                {
                    return false;
                }
            }

            return true;
        }

        public void RegisterItem(PlantModel item) =>
            _gridItemRegistry.TryAdd(item);
    }
}