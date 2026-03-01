using System.Collections.Generic;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy
{
    public interface IFoodResolutionStrategy
    {
        CellResolutionResult Resolve(FoodModel foodModel, IReadOnlyList<FoodModel> neighbours);
    }
}