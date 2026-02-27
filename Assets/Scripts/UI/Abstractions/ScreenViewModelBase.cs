using Core.Reactive;
using Core.Reactive.Interfaces;
using UI.Abstractions.Interfaces;

namespace UI.Abstractions
{
    public abstract class ScreenViewModelBase : IScreenViewModel
    {
        public IReadOnlyReactiveProperty<bool> VisibilityChanged => _visibilityChanged;

        private readonly ReactiveProperty<bool> _visibilityChanged = new();

        public void Show() =>
            _visibilityChanged.Value = true;

        public void Hide() =>
            _visibilityChanged.Value = false;
    }
}