using Core.Reactive;
using Core.Reactive.Interfaces;
using UI.Abstractions.Interfaces;

namespace UI.Abstractions
{
    public abstract class PopupViewModelBase : IPopupViewModel
    {
        public IReadOnlyReactiveProperty<bool> IsVisible => _isVisible;

        readonly ReactiveProperty<bool> _isVisible = new();

        public void Show() =>
            _isVisible.Value = true;

        public void Hide() =>
            _isVisible.Value = false;
    }
}