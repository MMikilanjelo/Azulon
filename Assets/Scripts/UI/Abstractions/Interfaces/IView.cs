namespace UI.Abstractions.Interfaces
{
    public interface IView<in TViewModel> where TViewModel : IViewModel
    {
        void Bind(TViewModel viewModel);
    }
}