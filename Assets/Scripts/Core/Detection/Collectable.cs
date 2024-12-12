using CyberEnigma.Core.Inventory.Core;
using CyberEnigma.Core.Inventory.Core.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Detection
{
    [RequireComponent(typeof(EnableGameObject))]
    [RequireComponent(typeof(RangeDetection))]
    [RequireComponent(typeof(ReadInput))]
    public class Collectable : MonoBehaviour
    {
        [field : SerializeField] public InventoryElement inventoryElement { get; private set; }
        private RangeDetection rangeScript;
        private ReadInput inputScript;

        private void Awake()
        {
            rangeScript = GetComponent<RangeDetection>();
            inputScript = GetComponent<ReadInput>();

            inputScript.OnInput += OnCollect;
        }

        private void OnDestroy()
        {
            inputScript.OnInput -= OnCollect;
        }

        private void OnCollect(InputAction.CallbackContext context)
        {
            if (!rangeScript.IsInRange) return;
            
            Inventory.Instance.AddItem(inventoryElement);
            
            Destroy(gameObject);
        }
    }
}