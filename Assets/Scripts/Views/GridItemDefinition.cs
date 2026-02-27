using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    [CreateAssetMenu(menuName = "GridItems/Definition")]
    public class GridItemDefinition : ScriptableObject
    {
        public IReadOnlyList<Vector2Int> ShapeCoords => _shapeCoords;
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public List<Vector2Int> _shapeCoords { get; private set; }
    }
}