using Application.State_Machine.Application_State_Machine.Models.Inventory_Models;
using JetBrains.Annotations;
using UnityEngine;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Shop
{
    [CreateAssetMenu(menuName = "Shop/Definition")]
    public class ShopItemDefinition : ScriptableObject
    {
        [field: SerializeField] public ItemCategory Category { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string ItemId { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField, Min(1)] public int Price { get; private set; } = 1;
    }
}