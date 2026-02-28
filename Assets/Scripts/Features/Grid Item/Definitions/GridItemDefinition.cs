using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Features.Grid_Item.Definitions
{
    [CreateAssetMenu(menuName = "GridItems/Definition")]
    public class GridItemDefinition : ScriptableObject
    {
        public IReadOnlyList<Vector2Int> Shape => _shape;

        [field: SerializeField] private List<Vector2Int> _shape;

        [field: SerializeField] public Color Color { get; private set; }
    }
}