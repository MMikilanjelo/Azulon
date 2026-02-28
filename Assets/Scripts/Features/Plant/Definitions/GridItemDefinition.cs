using System.Collections.Generic;
using Features.Plant.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Features.Plant.Definitions
{
    [CreateAssetMenu(menuName = "GridItems/Definition")]
    public class GridItemDefinition : ScriptableObject
    {
        public IReadOnlyList<Vector2Int> ShapeOffsets => _shapeOffsets;

        [field: SerializeField] private List<Vector2Int> _shapeOffsets;
        [field: SerializeField] public Color Color { get; private set; }
        [field: SerializeField] public int TurnsToMature { get; private set; }
        [field: SerializeField] public PlantId PlantId { get; private set; }
        [field: SerializeField] public List<Color> GrowthStageColors { get; private set; }
    }
}