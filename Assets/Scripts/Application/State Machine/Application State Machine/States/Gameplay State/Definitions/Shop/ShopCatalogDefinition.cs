using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Definitions.Shop
{
    [CreateAssetMenu(menuName = "Shop/CatalogDefinition")]
    public class ShopCatalogDefinition : ScriptableObject
    {
        public IReadOnlyList<ShopItemDefinition> Items => _items.ToList().AsReadOnly();

        [field: SerializeField] private List<ShopItemDefinition> _items;
    }
}