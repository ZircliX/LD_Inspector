using UnityEngine;

namespace Inventory.Core.Data
{
    [CreateAssetMenu(fileName = "NewInventoryElement", menuName = "ScriptableObjects/InventoryElement")]
    public class InventoryElement : ScriptableObject
    {
        public string Name;
        public ItemGroup ItemGroup;
        public string Description;
        
        public Sprite ImageDisplay;
    }
}