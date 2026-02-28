using System.Threading.Tasks;

namespace UI.Abstractions
{
    public interface IScreenView
    {
        Task Show();
        Task Hide();
        void Destroy();
    }
}