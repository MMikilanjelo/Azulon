using Features.Grid_Item;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Drag_Grid_Item_Use_Case
{
    public interface IDragGridItemUseCase
    {
        void StartDrag(GridItem view);
        void StopDrag();
        void UpdateItemPosition(float deltaTime);
    }
}