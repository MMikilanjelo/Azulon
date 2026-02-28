using System.Threading.Tasks;
using Features.Plant;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.Game_Factory
{
    public interface IGameFactory : IFactory
    {
        Task<PlantView> CreatePlant(Transform parent, Vector3 position);
    }
}