using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Enums;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.Game_Factory
{
    public interface IGameFactory : IFactory
    {
        Task<FoodModel> CreateFood(FoodId id, Vector2Int gridPosition);
    }
}