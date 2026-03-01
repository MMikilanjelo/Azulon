using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy
{
    public class CellResolutionResult
    {
        public Vector2Int Position { get; }
        public Sprite Icon { get; }
        public int Gold { get; }
        public bool WasBonus { get; }
        public string ComboLabel { get; }

        public CellResolutionResult(Vector2Int position, Sprite icon, int gold, bool wasBonus, string comboLabel = "")
        {
            Position = position;
            Icon = icon;
            Gold = gold;
            WasBonus = wasBonus;
            ComboLabel = comboLabel;
        }
    }
}