using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovement.Core
{
    public class MouseMovement : MonoBehaviour
    {
        [SerializeField] private float sensitivity;
        [SerializeField] private Transform cameraTrans;
        [SerializeField] private Transform orientation;
        
        private float mouseX, mouseY;
        private float rotationX, rotationY;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        private void Update()
        {
            rotationY += mouseX * Time.deltaTime * sensitivity;
            rotationX -= mouseY * Time.deltaTime * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            cameraTrans.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
            orientation.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }

        public void MouseInputX(InputAction.CallbackContext context)
        {
            var mouseInput = context.ReadValue<float>();
            mouseX = mouseInput;
        }
        public void MouseInputY(InputAction.CallbackContext context)
        {
            var mouseInput = context.ReadValue<float>();
            mouseY = mouseInput;
        }
    }
}