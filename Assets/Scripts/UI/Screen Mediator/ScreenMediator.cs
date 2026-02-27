using System.Threading.Tasks;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Root_Factory;
using UnityEngine;

namespace UI.Screen_Mediator
{
    public class ScreenMediator : IScreenMediator
    {
        public Transform ScreenRoot => _uiRootView.transform;

        private readonly IFactoryProvider _factoryProvider;

        private UIRootView _uiRootView;
        
        public ScreenMediator(IFactoryProvider factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }

        public async Task Initialize()
        {
            var factory = _factoryProvider.GetFactoryById<IUIRootFactory>(FactoryId.UIRoot);
            
            _uiRootView = await factory.CreateUIRoot();
        }
    }
}