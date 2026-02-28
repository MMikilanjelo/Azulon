using UnityEngine;

namespace Infrastructure.Drag_Position_Provider
{
    public interface IDragPositionProvider
    {
        Vector3 GetWorldPosition();
    }
}