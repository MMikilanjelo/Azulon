using System.Threading.Tasks;

namespace UI.Gameplay_State_UI.Mediator.Interfaces
{
    public interface IGameplayScreenMediator
    {
        void OnOpenShopButtonClicked();
        void OnOpenInventoryButtonClicked();
        void OnFinishTurnButtonClicked();
    }
}