using System.Threading.Tasks;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State;
using Core.Extensions;
using Infrastructure.Factory_Provider;
using Infrastructure.Factory_Provider.Factories;
using Infrastructure.Factory_Provider.Factories.UI_Factory.Interfaces;
using UI.Gameplay_State_UI.Mediator.Interfaces;
using UI.Gameplay_State_UI.Views;
using UI.UI_Root.Mediator.Interfaces;

namespace UI.Gameplay_State_UI.Mediator
{
    public class GameplayStateUIMediator :
        IGameplayStateUIMediator,
        IGameplayScreenMediator,
        IShopPopupMediator,
        IInventoryPopupMediator
    {
        private GameplayState _state;
        private IGameplayStateUIFactory _factory;

        private readonly IFactoryProvider _factoryProvider;
        private readonly IScreenStackMediator _screenStackMediator;

        private ShopPopupView _shopPopupView;

        public GameplayStateUIMediator(IFactoryProvider factoryProvider, IScreenStackMediator screenStackMediator)
        {
            _factoryProvider = factoryProvider;
            _screenStackMediator = screenStackMediator;
        }

        public void Initialize(GameplayState gameplayState)
        {
            _state = gameplayState;
            _factory = _factoryProvider.GetFactoryById<IGameplayStateUIFactory>(FactoryId.UI);
        }

        public Task CreateGameplayScreen() =>
            _screenStackMediator.Push(parent => _factory.CreateGameplayScreen(parent, this));

        public void OnOpenShopButtonClicked() =>
            _screenStackMediator.Push(parent => _factory.CreateShopPopup(parent, this)).Forget();

        public void OnOpenInventoryButtonClicked() =>
            _screenStackMediator.Push(parent => _factory.CreateInventoryPopup(parent, this)).Forget();

        public void OnShopPopUpDimmerClicked() =>
            _screenStackMediator.Pop().Forget();

        public void Dispose() =>
            _screenStackMediator.PopAll();
    }
}