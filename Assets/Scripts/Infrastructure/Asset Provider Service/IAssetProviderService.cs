using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Asset_Provider_Service
{
    public interface IAssetProviderService
    {
        T Load<T>(string path) where T : Object;
        Task<T> LoadAsync<T>(string path) where T : Object;
    }
}