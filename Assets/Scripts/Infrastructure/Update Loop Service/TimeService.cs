using Core.Reactive;
using Core.Reactive.Interfaces;
using UnityEngine;

namespace Infrastructure.Update_Loop_Service
{
    public class TimeService : MonoBehaviour, ITimeService
    {
        public float DeltaTime => Time.deltaTime;
        public IReadOnlyReactiveEvent<float> UpdateTicked => _updateTicked;

        private readonly ReactiveEvent<float> _updateTicked = new();

        private void Start() =>
            DontDestroyOnLoad(gameObject);

        private void Update() =>
            _updateTicked.Invoke(Time.deltaTime);
    }
}