using System.Threading.Tasks;
using UnityEngine;

namespace Core.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Safely executes an async task from a synchronous method.
        /// Logs any exceptions to the Unity console.
        /// </summary>
        public static void Forget(this Task task)
        {
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Debug.LogError($"[Task Error]: {t.Exception?.Flatten().InnerException}");
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}