using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Inventory.Core.Data;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Inventory.Core
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private Image baseImagePrefab;
        [SerializeField] private Transform contentParent;
        
        [Space]
        private PointerEventData _pointerEventData;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private EventSystem _eventSystem;

        private void Start()
        {
            RefreshDisplay();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastToUI();
            }
        }
        
        private void CreateItemImage(InventoryElement item)
        {
            Image newImage = Instantiate(baseImagePrefab, contentParent);

            newImage.gameObject.GetComponent<Item>().SetInventoryElement(item);
            newImage.name = item.name;
            newImage.sprite = item.ImageDisplay;
        }

        private void RefreshDisplay()
        {
            for (int i = 0; i < Inventory.Instance.PlayerInventory.Keys.Count; i++)
            {
                ItemGroup group = Inventory.Instance.PlayerInventory.Keys.ElementAt(i);
                
                for (int j = 0; j < Inventory.Instance.PlayerInventory[group].Count; j++)
                {
                    InventoryElement element = Inventory.Instance.PlayerInventory[group][j];
                    
                    CreateItemImage(element);
                }
            }
        }
        
        private void RaycastToUI()
        {
            _pointerEventData = new PointerEventData(_eventSystem)
            {
                position = Pointer.current.position.ReadValue()
            };

            List<RaycastResult> results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(_pointerEventData, results);
            
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.TryGetComponent(out Item itemComponent))
                {
                    Inventory.Instance.ShowElementInfos(itemComponent.InventoryElement);
                }
            }
        }
    }
}