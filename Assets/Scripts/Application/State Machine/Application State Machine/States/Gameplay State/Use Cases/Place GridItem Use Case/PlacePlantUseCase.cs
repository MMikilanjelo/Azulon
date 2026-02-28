using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models;
using Features.Plant;
using Infrastructure.Services.Grid_Service;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Place_GridItem_Use_Case
{
    public class PlacePlantUseCase : IPlacePlantUseCase
    {
        private readonly IGridModel _gridModel;
        
        private readonly IGridService _gridService;

        public PlacePlantUseCase(IGridModel gridModel, IGridService gridService)
        {
            _gridModel = gridModel;

            _gridService = gridService;
        }

        public bool Execute(PlantModel item)
        {
            var gridPos = _gridService.WorldToGrid(item.WorldPosition.Value);

            if (!_gridModel.CanPlaceItem(item, gridPos))
            {
                var previousWorldPosition = _gridService.GridToWorld(item.GridPosition.Value);

                item.UpdateWorldPosition(previousWorldPosition);

                return false;
            }

            var worldPosition = _gridService.GridToWorld(gridPos);

            item.SnapToGrid(gridPos, worldPosition);

            return true;
        }
    }
}