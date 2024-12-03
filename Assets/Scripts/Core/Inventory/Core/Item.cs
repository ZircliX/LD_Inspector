using Inventory.Core.Data;
using UnityEngine;

namespace Inventory.Core
{
    public class Item : MonoBehaviour
    {
        [field : SerializeField] public InventoryElement InventoryElement { get; private set; }

        public void SetInventoryElement(InventoryElement item)
        {
            InventoryElement = item;
        }
    }
}