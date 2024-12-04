using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Detection
{
    public class ReadInput : MonoBehaviour
    {
        [SerializeField] private InputAction takeObjectAction;
        public event Action<InputAction.CallbackContext> OnInput; 
        
        private void Awake()
        {
            takeObjectAction.performed += ctx => OnInput?.Invoke(ctx);
        }

        private void OnEnable()
        {
            takeObjectAction.Enable();
        }

        private void OnDisable()
        {
            takeObjectAction.Disable();
        }
    }
}