using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Asset_Provider
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : Object;
        Task<T> LoadAsync<T>(string path) where T : Object;
    }
}