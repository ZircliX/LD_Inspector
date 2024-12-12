using UnityEngine;

namespace CyberEnigma.Core.Inventory.Core.Data
{
    [CreateAssetMenu(fileName = "NewInventoryElement", menuName = "ScriptableObjects/InventoryElement")]
    public class InventoryElement : ScriptableObject
    {
        public ItemGroup itemGroup;
        public Sprite itemImage;
        public GameObject itemPrefab;
    }
}