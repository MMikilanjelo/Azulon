using Features.Plant;
using Infrastructure.Drag_Position_Provider;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Drag_Grid_Item_Use_Case
{
    public class DragGridItemUseCase : IDragGridItemUseCase
    {
        private readonly IDragPositionProvider _positionProvider;

        private PlantModel _current;

        public DragGridItemUseCase(IDragPositionProvider positionProvider) =>
            _positionProvider = positionProvider;

        public void StartDrag(PlantModel view) =>
            _current = view;

        public void StopDrag() =>
            _current = null;

        public void UpdateItemPosition(float deltaTime)
        {
            if (_current is null)
            {
                return;
            }

            var world = _positionProvider.GetWorldPosition();

            var target = world - new Vector3(0.5f, 0.5f, 0f);

            var finalTarget = Vector3.Lerp(_current.WorldPosition.Value, target, 22f * deltaTime);

            _current.UpdateWorldPosition(finalTarget);
        }
    }
}