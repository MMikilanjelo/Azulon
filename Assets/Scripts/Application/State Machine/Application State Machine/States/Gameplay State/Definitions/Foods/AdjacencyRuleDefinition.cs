using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Foods
{
    [CreateAssetMenu(menuName = "Food/AdjacencyRuleDefinition")]
    public class AdjacencyRuleDefinition : ScriptableObject
    {
        [field: SerializeField] public FoodId NeighbourId { get; private set; }
        [field: SerializeField, Min(0f)] public float Multiplier { get; private set; }
        [field: SerializeField] public string ComboLabel { get; private set; }
    }
}