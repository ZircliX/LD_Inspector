using CyberEnigma.Core.Inventory.Core;
using CyberEnigma.Core.Inventory.Core.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Detection
{
    public class ICollectable : MonoBehaviour
    {
        [SerializeField] private InputAction takeObjectAction;
        [SerializeField] private InventoryElement inventoryElement;
        [SerializeField] private GameObject instructions;
        private bool isInRange;
        
        private void Awake()
        {
            takeObjectAction.Enable();
            takeObjectAction.performed += OnCollect;
        }

        private void OnDestroy()
        {
            takeObjectAction.Disable();
            takeObjectAction.performed -= OnCollect;
        }

        private void OnCollect(InputAction.CallbackContext context)
        {
            if (!isInRange) return;
            
            Inventory.Instance.AddItem(inventoryElement);
            isInRange = false;
            instructions.SetActive(false);
            
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = true;
                instructions.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = false;
                instructions.SetActive(false);
            }
        }
    }
}