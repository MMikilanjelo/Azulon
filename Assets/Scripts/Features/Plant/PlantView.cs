using System.Collections.Generic;
using Core.Reactive;
using Core.Reactive.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.Plant
{
    public class PlantView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public IReadOnlyReactiveEvent<PlantModel> DragEnded => _dragEnded;
        public IReadOnlyReactiveEvent<PlantModel> DragStarted => _dragStarted;
        public PlantModel Model { get; private set; }

        private readonly ReactiveEvent<PlantModel> _dragEnded = new();

        private readonly ReactiveEvent<PlantModel> _dragStarted = new();

        private bool _isDragging;

        private Tween _snapTween;

        private List<GridBlockView> _blockViews;

        public void Construct(
            List<GridBlockView> blockViews,
            PlantModel item
        )
        {
            _blockViews = blockViews;

            Model = item;
            
            Model.WorldPosition.Subscribe(OnWorldPositionValueChanged);
        }

        private void OnWorldPositionValueChanged(Vector3 newPosition) =>
            transform.position = newPosition;

        public void OnPointerDown(PointerEventData eventData) =>
            BeginDrag();

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

            _dragStarted?.Invoke(Model);
        }

        private void EndDrag()
        {
            _isDragging = false;

            _dragEnded?.Invoke(Model);
        }
    }
}