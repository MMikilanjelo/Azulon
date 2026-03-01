using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions
{
    [CreateAssetMenu(menuName = "Food/Definition")]
    public class FoodDefinition : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public FoodId FoodId { get; private set; }
        [field: SerializeField] public AdjacencyRuleDefinition[] Rules { get; private set; }
        [field: SerializeField, Min(0f)] public int BaseValue { get; private set; }
        [field: SerializeField] public FoodStrategyType Strategy { get; private set; } // enum
    }
}