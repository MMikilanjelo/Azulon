using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Drag_Position_Provider
{
    public class DragPositionProvider : IDragPositionProvider
    {
        public Vector3 GetWorldPosition()
        {
            var camera = Camera.main;

            if (camera == null)
            {
                return Vector3.zero;
            }

            var screenPos = Pointer.current.position.ReadValue();
            
            var world = camera.ScreenToWorldPoint(screenPos);

            world.z = 0f;

            return world;
        }
    }
}