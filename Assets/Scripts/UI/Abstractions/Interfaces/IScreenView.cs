using System.Threading.Tasks;

namespace UI.Abstractions.Interfaces
{
    public interface IScreenView : IView
    {
        Task Show();
        Task Hide();
        void Destroy();
    }
}