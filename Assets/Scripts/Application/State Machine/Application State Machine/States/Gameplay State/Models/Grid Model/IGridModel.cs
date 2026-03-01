using System.Collections;
using System.Collections.Generic;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Core.Reactive.Collections.Interfaces;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Grid_Model
{
    public interface IGridModel
    {
        IReadOnlyReactiveHashSet<FoodModel> Items { get; }
        bool CanPlaceItem(FoodModel item, Vector2Int gridPos);
        void RegisterItem(FoodModel foodModel);
        FoodModel GetItemAt(Vector2Int neighborCell);
        IReadOnlyList<Vector2Int> GetAllPositions();
        bool IsCellEmpty(Vector2Int pos);
        bool IsInBounds(Vector2Int pos);
        void ClearAll();
    }
}