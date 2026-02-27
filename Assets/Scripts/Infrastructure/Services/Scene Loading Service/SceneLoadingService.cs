using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.Scene_Loading_Service
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public async Task LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);

            if (asyncOperation == null)
            {
                Debug.LogError($"[SceneLoadingService] Failed to load scene '{sceneName}'. Is it added to the Build Settings?");
                
                return;
            }

            await asyncOperation;
        }

        public async Task UnloadSceneAsync(string sceneName)
        {
            var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            if (asyncOperation == null)
            {
                Debug.LogWarning($"[SceneLoadingService] Failed to unload scene '{sceneName}'. It might not be loaded.");
                return;
            }

            await asyncOperation;
        }
    }
}