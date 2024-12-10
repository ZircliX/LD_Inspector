using System;
using System.Collections.Generic;
using CyberEnigma.Core.Inventory.Core.Data;
using LTX.Singletons;
using UnityEngine;

namespace CyberEnigma.Core.Inventory.Core
{
    public class Inventory : MonoSingleton<Inventory>
    {
        public Dictionary<ItemGroup, List<InventoryElement>> PlayerInventory { get; private set; }

        public event Action<InventoryElement> OnElementDisplay;
        public event Action<InventoryElement> OnElementAdded;
        public event Action<InventoryElement> OnElementRemoved;
        
        protected override void Awake()
        {
            base.Awake();
            
            PlayerInventory = new Dictionary<ItemGroup, List<InventoryElement>>
            {
                { ItemGroup.Key, new List<InventoryElement>() },
                { ItemGroup.Note, new List<InventoryElement>() },
                { ItemGroup.Image, new List<InventoryElement>() }
            };
        }

        public void AddItem(InventoryElement item)
        {
            // Debug.Log($"Added Item : {item.itemGroup}");
            
            PlayerInventory[item.itemGroup].Add(item);
            OnElementAdded?.Invoke(item);
        }

        public void RemoveItem(InventoryElement item)
        {
            //Debug.Log($"Removed Item : {item.itemGroup}");
            
            PlayerInventory[item.itemGroup].Remove(item);
            OnElementRemoved?.Invoke(item);
        }

        public void ShowElementInfos(InventoryElement element)
        {
            //Debug.Log($"Show Item : {element.itemGroup}");
            
            OnElementDisplay?.Invoke(element);
        }
    }
}