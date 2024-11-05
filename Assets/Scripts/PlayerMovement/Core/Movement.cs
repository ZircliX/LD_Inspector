using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace PlayerMovement.Core
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float zoomSpeed;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        internal float additionalSpeed;

        [SerializeField] private float jumpForce;

        private float verticalInput, horizontalInput;
        private Vector3 moveDirection;

        private bool isMoving, isRunning;
        internal CameraZoom cameraZoom;

        [SerializeField] private Transform orientation;
        private Rigidbody playerRB;

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            moveDirection = (verticalInput * orientation.forward + horizontalInput * orientation.right).normalized;

            if (isMoving)
            {
                float speed = (cameraZoom.IsZooming, isRunning) switch
                {
                    (true, _) => zoomSpeed,
                    (false, true) => runSpeed,
                    _ => walkSpeed
                };

                playerRB.AddForce(moveDirection * ((speed + additionalSpeed) * 10f), ForceMode.Force);
            }
            else
            {
                playerRB.velocity *= 0.995f;
            }
        }

        private static bool SwitchContextPhase(InputAction.CallbackContext context)
        {
            return context.phase switch
            {
                InputActionPhase.Started => true,
                InputActionPhase.Performed => context.interaction is not SlowTapInteraction,
                InputActionPhase.Canceled => false,
                _ => false,
            };
        }

        public void Run(InputAction.CallbackContext context)
        {
            isRunning = SwitchContextPhase(context);
        }

        public void MoveInput(InputAction.CallbackContext context)
        {
            Vector2 keyboardInput = context.ReadValue<Vector2>();
            verticalInput = keyboardInput.y;
            horizontalInput = keyboardInput.x;

            isMoving = SwitchContextPhase(context);
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}