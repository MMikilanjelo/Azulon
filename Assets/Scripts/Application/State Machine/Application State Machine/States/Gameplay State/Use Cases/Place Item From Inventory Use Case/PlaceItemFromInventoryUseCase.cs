using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Enums;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Grid_Model;
using Infrastructure.Factory_Provider.Factories.Game_Factory;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Place_Item_From_Inventory_Use_Case
{
    public class PlaceItemFromInventoryUseCase : IPlaceItemFromInventoryUseCase
    {
        private readonly IGridModel _gridModel;
        private readonly IGameFactory _gameFactory;

        public PlaceItemFromInventoryUseCase(IGridModel gridModel, IGameFactory gameFactory)
        {
            _gridModel = gridModel;
            _gameFactory = gameFactory;
        }

        public async Task<bool> Execute(InventoryItemModel selectedItem, Vector2Int pos)
        {
            if (!_gridModel.IsCellEmpty(pos) || !_gridModel.IsInBounds(pos))
            {
                return false;
            }

            // var foodId = Enum.Parse<FoodId>(selectedItem.ItemId);

            var plant = await _gameFactory.CreateFood(FoodId.Honey, pos);

            plant.SetGridPosition(pos);

            _gridModel.RegisterItem(plant);

            return true;
        }
    }
}