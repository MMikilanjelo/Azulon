using Core.Reactive;
using Core.Reactive.Interfaces;

namespace Application.State_Machine.Application_State_Machine.Models.Player_Model
{
    public class PlayerModel : IPlayerModel
    {
        public IReadOnlyReactiveProperty<int> Gold => _gold;

        private readonly ReactiveProperty<int> _gold = new();

        public bool HasSufficientFunds(int amount) =>
            _gold.Value >= amount;

        public void EarnGold(int amount)
        {
            if (amount < 0)
            {
                return;
            }

            _gold.Value += amount;
        }

        public void SpendGold(int amount)
        {
            if (amount < 0)
            {
                return;
            }

            if (!HasSufficientFunds(amount))
            {
                return;
            }

            _gold.Value -= amount;
        }

        public bool TryPurchase(int cost)
        {
            if (cost < 0 || !HasSufficientFunds(cost))
            {
                return false;
            }

            SpendGold(cost);

            return true;
        }
    }
}