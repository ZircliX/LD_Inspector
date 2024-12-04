using UnityEngine;

namespace Core.Detection
{
    public class RangeDetection : MonoBehaviour
    {
        public bool isInRange { get; private set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = false;
            }
        }
    }
}