using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public interface ISceneLoadingService
    {
        Task LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive);
        Task UnloadSceneAsync(string sceneName);
    }
}