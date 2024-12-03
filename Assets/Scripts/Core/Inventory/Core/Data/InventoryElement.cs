using UnityEngine;

namespace Inventory.Core.Data
{
    [CreateAssetMenu(fileName = "NewInventoryElement", menuName = "ScriptableObjects/InventoryElement")]
    public class InventoryElement : ScriptableObject
    {
        public ItemGroup ItemGroup;
        public Sprite ImageDisplay;
    }
}