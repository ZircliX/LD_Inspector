using CyberEnigma.Core.Inventory.Core.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberEnigma.Core.Inventory.Core
{
    public class InventoryItemUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image image;
        
        private InventoryElement element;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Inventory.Instance.ShowElementInfos(element);
        }

        public void SyncData(InventoryElement itemData)
        {
            element = itemData;
            image.sprite = itemData.itemImage;
        }
    }
}