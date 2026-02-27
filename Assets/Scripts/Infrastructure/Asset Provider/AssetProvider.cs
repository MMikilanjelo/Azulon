using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Asset_Provider
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string path) where T : Object
        {
            var asset = Resources.Load<T>(path);

            if (asset == null)
            {
                Debug.LogError($"[AssetProviderService] Failed to load asset of type {typeof(T)} at path: Resources/{path}");
            }

            return asset;
        }

        public async Task<T> LoadAsync<T>(string path) where T : Object
        {
            var request = Resources.LoadAsync<T>(path);

            if (request == null)
            {
                Debug.LogError($"[AssetProviderService] Failed to start async load for path: Resources/{path}");
                return null; 
            }

            await request;

            return request.asset as T; 
        }
    }
}