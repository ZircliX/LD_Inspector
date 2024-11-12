using Inventory.Core.Data;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Inventory.Core
{
    public class ElementDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI typeText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Image itemImage;

        private void OnEnable()
        {
            Inventory.Instance.OnElementDisplay += DisplayElement;
        }

        private void OnDisable()
        {
            Inventory.Instance.OnElementDisplay -= DisplayElement;
        }

        private void Start()
        {
            ClearDisplay();
        }

        private void DisplayElement(InventoryElement element)
        {
            nameText.text = element.Name;
            typeText.text = element.ItemGroup.ToString();
            descriptionText.text = element.Description;
            
            itemImage.enabled = true;
            itemImage.sprite = element.ImageDisplay;
        }

        private void ClearDisplay()
        {
            nameText.text = "";
            typeText.text = "";
            descriptionText.text = "";
            
            itemImage.enabled = false;
        }
    }
}