using System.Threading.Tasks;
using Features.Grid_Item;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UnityEngine;

namespace Infrastructure.Factory_Provider.Factories.Game_Factory
{
    public interface IGameFactory : IFactory
    {
        Task<GridItemView> CreateGridItem(Transform parent, Vector3 position);
    }
}