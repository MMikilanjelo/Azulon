using Core.Reactive.Interfaces;

namespace UI.Abstractions.Interfaces
{
    public interface IViewModel
    {
        IReadOnlyReactiveProperty<bool> IsVisible { get; }
        void Show();
        void Hide();
    }
}