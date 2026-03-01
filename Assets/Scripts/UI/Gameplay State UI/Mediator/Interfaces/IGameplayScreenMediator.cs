using System.Threading.Tasks;
using Core.Reactive.Interfaces;

namespace UI.Gameplay_State_UI.Mediator.Interfaces
{
    public interface IGameplayScreenMediator
    {
        IReadOnlyReactiveEvent<int> PlayerGoldChanged { get; }
        void OnOpenShopButtonClicked();
        void OnOpenInventoryButtonClicked();
        void OnFinishTurnButtonClicked();
    }
}