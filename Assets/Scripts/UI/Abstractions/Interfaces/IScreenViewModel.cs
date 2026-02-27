using Core.Reactive.Interfaces;

namespace UI.Abstractions.Interfaces
{
    public interface IScreenViewModel
    {
        IReadOnlyReactiveProperty<bool> VisibilityChanged { get; }
        void Show();
        void Hide();
    }
}