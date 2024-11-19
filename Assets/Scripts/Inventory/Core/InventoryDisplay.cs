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

        private void OnEnable()
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

        private void ResetDisplay()
        {
            foreach (Transform child in contentParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void RefreshDisplay()
        {
            ResetDisplay();
            
            foreach (var group in Inventory.Instance.PlayerInventory.Keys)
            {
                foreach (var element in Inventory.Instance.PlayerInventory[group])
                {
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