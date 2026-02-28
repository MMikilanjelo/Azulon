using Core.Reactive;
using Core.Reactive.Interfaces;
using Features.Plant.Definitions;
using UnityEngine;

namespace Features.Plant
{
    public class PlantModel
    {
        public IReadOnlyReactiveProperty<Vector2Int> GridPosition => _gridPosition;
        public IReadOnlyReactiveProperty<Vector3> WorldPosition => _worldPosition;
        public IReactiveProperty<int> TurnsLeftToMature => _turnsLeftToMature;
        public GridItemDefinition Definition { get; }

        private readonly ReactiveProperty<Vector2Int> _gridPosition;
        private readonly ReactiveProperty<Vector3> _worldPosition;
        private readonly ReactiveProperty<int> _turnsLeftToMature;

        public PlantModel(GridItemDefinition definition, Vector2Int gridPosition, Vector3 worldPosition)
        {
            Definition = definition;

            _turnsLeftToMature = new ReactiveProperty<int>(definition.TurnsToMature);

            _worldPosition = new ReactiveProperty<Vector3>(worldPosition);

            _gridPosition = new ReactiveProperty<Vector2Int>(gridPosition);
        }

        public void SnapToGrid(Vector2Int gridPos, Vector3 worldPos)
        {
            UpdateGridPosition(gridPos);

            UpdateWorldPosition(worldPos);
        }

        public void ReduceTurnsToMature(int amount)
        {
            amount = Mathf.Clamp(amount, 0, _turnsLeftToMature.Value);

            _turnsLeftToMature.Value -= amount;
        }

        public Color GetVisualForTurn()
        {
            var stagesGrown = Definition.TurnsToMature- TurnsLeftToMature.Value;

            var safeIndex = Mathf.Clamp(stagesGrown, 0, Definition.GrowthStageColors.Count - 1);

            return Definition.GrowthStageColors[safeIndex];
        }

        public void UpdateGridPosition(Vector2Int gridPosition) =>
            _gridPosition.Value = gridPosition;

        public void UpdateWorldPosition(Vector3 position) =>
            _worldPosition.Value = position;
    }
}