namespace UI.Abstractions.Interfaces
{
    public interface IPopupView<in TViewModel> : IView<TViewModel> where TViewModel : IPopupViewModel
    {
    }
}