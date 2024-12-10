using UnityEngine;

namespace Core.Detection
{
    [RequireComponent(typeof(RangeDetection))]
    public class EnableGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject instructions;
        private RangeDetection rd;

        private void Awake()
        {
            rd = GetComponent<RangeDetection>();
        }

        private void OnEnable()
        {
            rd.OnTrigger += ChangeActive;
        }

        private void OnDisable()
        {
            if (!instructions) return;
            
            rd.OnTrigger -= ChangeActive;
            instructions.SetActive(false);
        }

        private void ChangeActive(bool state)
        {
            if (isActiveAndEnabled)
            {
                instructions.SetActive(state);
            }
        }
    }
}