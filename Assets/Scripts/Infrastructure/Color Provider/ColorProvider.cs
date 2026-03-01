using System.Drawing;
using Color = UnityEngine.Color;

namespace Infrastructure.Color_Provider
{
    public class ColorProvider : IColorProvider
    {
        public Color PurchaseSucceed => Color.green;
        public Color PurchaseFailed => Color.darkRed;
        public Color IncomeHighlight => Color.yellow;
    }
}