using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace PlayerMovement.Core
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float SPEED_MULTIPLIER;
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

                playerRB.AddForce(moveDirection * ((speed + additionalSpeed) * SPEED_MULTIPLIER * Time.deltaTime), ForceMode.Force);
                Stairs();
            }
            else
            {
                playerRB.velocity *= 0.995f;
            }
        }
        
        private void Stairs()
        {
            Vector3 stairRayOrigin = transform.position + Vector3.up * 0.1f;
            Vector3 stairRayDirection = moveDirection.normalized;

            if (Physics.Raycast(stairRayOrigin, stairRayDirection, out RaycastHit hit, 0.5f))
            {
                float stairAngle = Vector3.Angle(hit.normal, Vector3.up);
                Debug.Log($"{stairAngle}");
                
                if (stairAngle >= 90f)
                {
                    Vector3 stairClimbForce = Vector3.up * (playerRB.velocity.magnitude * 0.20f);
                    playerRB.AddForce(stairClimbForce, ForceMode.Impulse);
                }
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