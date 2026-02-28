using System.Collections.Generic;
using Core.Reactive;
using Core.Reactive.Events;
using Core.Reactive.Interfaces;
using DG.Tweening;
using Features.Grid_Item.Definitions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Features.Grid_Item
{
    public class GridItemView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public IReadOnlyReactiveEvent<GridItemView> DragEnded => _dragEnded;
        public IReadOnlyReactiveEvent<GridItemView> DragStarted => _dragStarted;
        public IReadOnlyCollection<Vector2Int> OccupiedOffsets => _definition.Shape;

        private readonly ReactiveEvent<GridItemView> _dragEnded = new();

        private readonly ReactiveEvent<GridItemView> _dragStarted = new();

        private Camera _mainCamera;

        private bool _isDragging;

        private Tween _snapTween;

        private List<GridBlockView> _blockViews;

        private GridItemDefinition _definition;

        private void Awake() =>
            _mainCamera = Camera.main;

        public void Construct(List<GridBlockView> blockViews, GridItemDefinition definition)
        {
            _blockViews = blockViews;
            
            _definition = definition;
        }

        private void Update()
        {
            if (!_isDragging)
            {
                return;
            }

            var screenPos = Pointer.current.position.ReadValue();

            var worldPos = _mainCamera.ScreenToWorldPoint(screenPos);

            worldPos.z = 0f;

            var targetPos = worldPos - new Vector3(0.5f, 0.5f, 0f);

            transform.position = Vector3.Lerp(transform.position, targetPos, 22f * Time.deltaTime);
        }

        public void OnPointerDown(PointerEventData eventData) =>
            BeginDrag();

        public void SlideTo(Vector2 finalPos)
        {
            transform.DOKill();

            transform.DOMove(finalPos, 0.2f).SetEase(Ease.OutCubic);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isDragging)
            {
                EndDrag();
            }
        }

        private void BeginDrag()
        {
            _isDragging = true;

            _dragStarted?.Invoke(this);
        }

        private void EndDrag()
        {
            _isDragging = false;

            _dragEnded?.Invoke(this);
        }
    }
}