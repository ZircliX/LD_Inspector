using System;
using UnityEngine;

namespace Core.Detection
{
    [RequireComponent(typeof(BoxCollider))]
    public class RangeDetection : MonoBehaviour
    {
        public event Action<bool> OnTrigger;
        public bool IsInRange { get; private set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsInRange = true;
                OnTrigger?.Invoke(IsInRange);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsInRange = false;
                OnTrigger?.Invoke(IsInRange);
            }
        }
    }
}