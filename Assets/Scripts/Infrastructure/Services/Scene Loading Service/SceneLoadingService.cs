using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.Scene_Loading_Service
{
    public class SceneLoadingService : ISceneLoadingService
    {
        private readonly HashSet<string> _loadedScenes = new() { SceneName.BootScene };

        public async Task LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                return;
            }

            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);

            if (asyncOperation == null)
            {
                Debug.LogError($"[SceneLoadingService] Failed to load scene '{sceneName}'. Is it added to the Build Settings?");

                return;
            }

            await asyncOperation;
            
            _loadedScenes.Add(sceneName);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        public async Task UnloadSceneAsync(string sceneName)
        {
            if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                return;
            }

            var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            if (asyncOperation == null)
            {
                Debug.LogWarning($"[SceneLoadingService] Failed to unload scene '{sceneName}'. It might not be loaded.");
                return;
            }

            if (_loadedScenes.Contains(sceneName))
            {
                _loadedScenes.Remove(sceneName);
            }

            await asyncOperation;
        }

        public void MoveGameObjectToScene(GameObject gameObject, string sceneName)
        {
            if (_loadedScenes.Contains(sceneName))
            {
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(sceneName));
            }
        }
    }
}