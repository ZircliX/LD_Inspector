using System;
using System.Collections.Generic;
using Inventory.Core.Data;
using LTX.Singletons;

namespace Inventory.Core
{
    public class Inventory : MonoSingleton<Inventory>
    {
        public Dictionary<ItemGroup, List<InventoryElement>> PlayerInventory { get; private set; }
        public InventoryElement[] elements;

        public event Action<InventoryElement> OnElementDisplay;
        
        protected override void Awake()
        {
            base.Awake();
            
            PlayerInventory = new Dictionary<ItemGroup, List<InventoryElement>>
            {
                { ItemGroup.Key, new List<InventoryElement>() },
                { ItemGroup.Note, new List<InventoryElement>() },
                { ItemGroup.Image, new List<InventoryElement>() }
            };

            for (int i = 0; i < 5; i++)
            {
                PlayerInventory[ItemGroup.Key].Add(elements[0]);
            }
            for (int i = 0; i < 2; i++)
            {
                PlayerInventory[ItemGroup.Note].Add(elements[1]);
            }
            for (int i = 0; i < 2; i++)
            {
                PlayerInventory[ItemGroup.Image].Add(elements[2]);
            }
        }

        private void AddItem(InventoryElement itemToAdd)
        {
            PlayerInventory[itemToAdd.ItemGroup].Add(itemToAdd);
        }

        private void RemoveItem(InventoryElement itemToRemove)
        {
            PlayerInventory[itemToRemove.ItemGroup].Remove(itemToRemove);
        }

        public void ShowElementInfos(InventoryElement element)
        {
            OnElementDisplay?.Invoke(element);
        }
    }
}