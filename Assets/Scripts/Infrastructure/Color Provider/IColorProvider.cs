
using UnityEngine;

namespace Infrastructure.Color_Provider
{
    public interface IColorProvider
    {
        Color PurchaseSucceed { get; }
        Color PurchaseFailed { get; }
        Color IncomeHighlight { get; }
    }
}