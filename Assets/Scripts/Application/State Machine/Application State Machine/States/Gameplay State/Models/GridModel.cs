using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Registries;
using Features.Grid_Item;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models
{
    public class GridModel
    {
        public IRegistry<GridItemView> Registry => _gridItemRegistry;
        public int Width { get; }
        public int Height { get; }

        private readonly Registry<GridItemView> _gridItemRegistry = new();

        public GridModel(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // public bool IsCellOccupied(Vector2Int gridOrigin, Vector2Int coords)
        // {
        //     return Registry.Query(items => items.Any(item =>
        //         item.OccupiedOffsets.Any(offset => gridOrigin + offset == coords)));
        // }
        //
        // public GridItemView GetItemAt(Vector2Int gridOrigin, Vector2Int coords)
        // {
        //     return Registry.Query(items => items.FirstOrDefault(item =>
        //         item.OccupiedOffsets.Any(offset => gridOrigin + offset == coords)));
        // }

        public bool IsInBounds(Vector2Int coords) =>
            coords.x >= 0 && coords.x < Width && coords.y >= 0 && coords.y < Height;

        public void AddItem(GridItemView gridItem) =>
            _gridItemRegistry.TryAdd(gridItem);
    }
}