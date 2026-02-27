using System.Threading.Tasks;
using Infrastructure.Factory_Provider.Factories.Interfaces;
using UI;
using UI.Screen_Mediator;

namespace Infrastructure.Factory_Provider.Factories.UI_Root_Factory
{
    public interface IUIRootFactory : IFactory
    {
        Task<UIRootView> CreateUIRoot();
    }
}