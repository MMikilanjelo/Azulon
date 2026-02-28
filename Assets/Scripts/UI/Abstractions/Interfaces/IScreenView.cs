namespace UI.Abstractions.Interfaces
{
    public interface IScreenView<in TViewModel> : IView<TViewModel> where TViewModel : IScreenViewModel
    {
    }
}