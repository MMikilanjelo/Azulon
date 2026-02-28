using System;
using Core.Reactive;
using Core.Reactive.Interfaces;
using Features.Grid_Item.Definitions;
using UnityEngine;

namespace Features.Grid_Item
{
    public class GridItem
    {
        public IReadOnlyReactiveProperty<Vector2Int> GridPosition => _gridPosition;
        public IReadOnlyReactiveProperty<Vector3> WorldPosition => _worldPosition;
        public GridItemDefinition Definition { get; }

        private readonly ReactiveProperty<Vector2Int> _gridPosition = new();

        private readonly ReactiveProperty<Vector3> _worldPosition = new();

        public GridItem(GridItemDefinition definition) =>
            Definition = definition;

        public void UpdateGridPosition(Vector2Int gridPosition) =>
            _gridPosition.Value = gridPosition;

        public void UpdateWorldPosition(Vector3 position) =>
            _worldPosition.Value = position;
    }
}