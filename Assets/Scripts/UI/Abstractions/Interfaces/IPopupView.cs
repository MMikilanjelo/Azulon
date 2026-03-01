using System.Threading.Tasks;

namespace UI.Abstractions.Interfaces
{
    public interface IPopupView : IView
    {
        bool IsShown { get; }
        Task Show();
        Task Hide();
        void Destroy();
    }
}