using Core.Reactive.Interfaces;

namespace Application.State_Machine.Application_State_Machine.Models.Player_Model
{
    public interface IPlayerModel
    {
        IReadOnlyReactiveProperty<int> Gold { get; }
        void EarnGold(int gold);
        bool HasSufficientFunds(int amount);
        void SpendGold(int amount);
        bool TryPurchase(int cost);
    }
}