using System.Collections.Generic;
using CyberEnigma.Core.Inventory.Core.Data;
using UnityEngine;
using UnityEngine.UI;

namespace CyberEnigma.Core.Inventory.Core
{
    public class InventoryManagerUI : MonoBehaviour
    {
        [SerializeField] private InventoryItemUI itemPrefab;
        [SerializeField] private Image image;
        [SerializeField] private Transform content;

        private Dictionary<InventoryElement, InventoryItemUI> itemsUI;

        private void Awake()
        {
            itemsUI = new Dictionary<InventoryElement, InventoryItemUI>();
        }
        
        private void OnEnable()
        {
            Inventory.Instance.OnElementDisplay += DisplayElement;
            Inventory.Instance.OnElementAdded += AddElement;
            Inventory.Instance.OnElementRemoved += RemoveElement;
        }

        private void OnDisable()
        {
            Inventory.Instance.OnElementDisplay -= DisplayElement;
            Inventory.Instance.OnElementAdded -= AddElement;
            Inventory.Instance.OnElementRemoved -= RemoveElement;
        }

        private void AddElement(InventoryElement element)
        {
            Debug.Log($"Instantiate element : {element.itemGroup}");
            
            InventoryItemUI newItem = Instantiate(itemPrefab, content);
            newItem.SyncData(element);

            itemsUI[element] = newItem;
        }

        private void RemoveElement(InventoryElement element)
        {
            if (itemsUI.Remove(element))
            {
                Debug.Log($"Delete element : {element.itemGroup}");
                return;
            }
            Debug.Log("Element does not exist");
        }

        private void DisplayElement(InventoryElement element)
        {
            Debug.Log($"Display element : {element.itemGroup}");
            
            image.sprite = element.itemImage;
        }
    }
}