using Menu;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Detection
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(EnableGameObject))]
    [RequireComponent(typeof(RangeDetection))]
    [RequireComponent(typeof(ReadInput))]
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private GameObject codePanel;
        private RangeDetection rangeScript;
        private ReadInput inputScript;
        
        private void Awake()
        {
            rangeScript = GetComponent<RangeDetection>();
            inputScript = GetComponent<ReadInput>();
            
            inputScript.OnInput += OnInput;
        }

        private void OnDestroy()
        {
            inputScript.OnInput -= OnInput;
        }
        
        private void OnInput(InputAction.CallbackContext context)
        {
            if (!rangeScript.isInRange) return;

            if (MenuManager.Instance.menuState == MenuManager.MenuState.RequireInput)
            {
                MenuManager.Instance.SwitchMenuState(MenuManager.MenuState.None);
            }
            else
            {
                MenuManager.Instance.SwitchMenuState(MenuManager.MenuState.RequireInput);
            }
        }
    }
}