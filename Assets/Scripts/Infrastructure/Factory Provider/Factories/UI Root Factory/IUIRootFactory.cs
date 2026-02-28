using System.Threading.Tasks;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI;
using UI.UI_Root.View;

namespace Infrastructure.Factory_Provider.Factories.UI_Root_Factory
{
    public interface IUIRootFactory : IFactory
    {
        Task<UIRootView> CreateUIRoot();
    }
}