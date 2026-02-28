using UnityEngine;

namespace Features.Plant
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GridBlockView : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _sprite;

        public void SetColor(Color color) =>
            _sprite.color = color;
    }
}