using Core.Reactive;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;
using DG.Tweening;
using UnityEngine;

namespace Views
{
    public class GridItemView : MonoBehaviour
    {
        public IReadOnlyReactiveEvent<EmptyEvent> DragEnded => _dragEnded;

        public IReadOnlyReactiveEvent<EmptyEvent> DragStarted => _dragStarted;

        private readonly ReactiveEvent<EmptyEvent> _dragEnded = new();
        
        private readonly ReactiveEvent<EmptyEvent> _dragStarted = new();

        private Camera _mainCamera;
        private bool _isDragging;
        private Tween _snapTween;

        public GridItem Item { get; private set; }

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!_isDragging)
            {
                return;
            }

            var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            mousePos.z = 0f;

            var targetPos = mousePos - new Vector3(0.5f, 0.5f, 0f);

            transform.position = Vector3.Lerp(transform.position, targetPos, 22f * Time.deltaTime);
        }

        public void Setup(GridItem item)
        {
            Item = item;

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            var tileSize = 1f;

            var halfTile = new Vector3(tileSize / 2f, tileSize / 2f, 0f);

            foreach (Vector2Int offset in item.Definition.ShapeCoords)
            {
                var blockObj = new GameObject($"Block_{offset.x}_{offset.y}");

                blockObj.transform.SetParent(transform);

                blockObj.transform.localPosition = new Vector3(offset.x * tileSize, offset.y * tileSize, 0f) + halfTile;

                var col = blockObj.AddComponent<BoxCollider2D>();

                col.size = Vector2.one * tileSize;

                var sr = blockObj.AddComponent<SpriteRenderer>();

                sr.sprite = item.Definition.Icon;
            }
        }

        private void OnMouseDown()
        {
            BeginDrag();
        }

        private void OnMouseUp()
        {
            if (_isDragging)
            {
                EndDrag();
            }
        }

        private void BeginDrag()
        {
            _isDragging = true;

            _dragStarted?.Invoke(new EmptyEvent());
        }

        private void EndDrag()
        {
            _isDragging = false;

            _dragEnded?.Invoke(new EmptyEvent());
        }

        public void SlideTo(Vector2 finalPos)
        {
            transform.DOKill();

            transform.DOMove(finalPos, 0.2f).SetEase(Ease.OutCubic);
        }
    }
}