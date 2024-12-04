using UnityEngine;

namespace Core.Detection
{
    public class EnableGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject instructions;

        private void OnDisable()
        {
            if (!instructions) return;
            
            instructions.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isActiveAndEnabled)
            {
                instructions.SetActive(true);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && isActiveAndEnabled)
            {
                instructions.SetActive(false);
            }
        }
    }
}