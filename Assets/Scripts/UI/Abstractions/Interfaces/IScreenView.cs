namespace UI.Abstractions.Interfaces
{
    public interface IScreenView<in TViewModel> where TViewModel : IScreenViewModel
    {
        void Bind(TViewModel viewModel);
    }
}