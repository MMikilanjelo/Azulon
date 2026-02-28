using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.Scene_Loading_Service
{
    public interface ISceneLoadingService
    {
        Task LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive);
        Task UnloadSceneAsync(string sceneName);
        void MoveGameObjectToScene(GameObject gameObject, string sceneName);
    }
}