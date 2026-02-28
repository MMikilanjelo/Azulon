using Features.Plant;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Drag_Grid_Item_Use_Case
{
    public interface IDragGridItemUseCase
    {
        void StartDrag(PlantModel view);
        void StopDrag();
        void UpdateItemPosition(float deltaTime);
    }
}