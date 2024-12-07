using Inventory.Core.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Core
{
    public class ElementDisplay : MonoBehaviour
    {
        [SerializeField] private Image itemImage;

        private void OnEnable()
        {
            Inventory.Instance.OnElementDisplay += DisplayElement;
            itemImage.enabled = false;
            itemImage.sprite = null;
        }

        private void OnDisable()
        {
            Inventory.Instance.OnElementDisplay -= DisplayElement;
        }
        
        private void DisplayElement(InventoryElement element)
        {
            itemImage.enabled = true;
            itemImage.sprite = element.ImageDisplay;
        }
    }
}