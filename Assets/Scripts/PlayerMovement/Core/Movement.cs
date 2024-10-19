using System;
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
        
        private float verticalInput, horizontalInput;
        private Vector3 moveDirection;
        private bool isMoving;
        private bool isRunning;

        [SerializeField] private Transform orientation;
        private Rigidbody playerRB;
        private CameraZoom cameraZoom;

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
            cameraZoom = GetComponent<CameraZoom>();
        }

        private void FixedUpdate()
        {
            moveDirection = (verticalInput * orientation.forward + horizontalInput * orientation.right).normalized;

            if (isMoving)
            {
                float speed = cameraZoom.isZooming ? zoomSpeed : (isRunning ? runSpeed : walkSpeed);
                
                playerRB.AddForce(moveDirection * (speed * 10f), ForceMode.Force);
            }
            else
            {
                playerRB.velocity *= 0.995f;
            }
        }

        
        void SwitchContextPhase(InputAction.CallbackContext context, Action<bool> myBool)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    myBool(true);
                    break;

                case InputActionPhase.Performed:
                    myBool(context.interaction is not SlowTapInteraction);
                    break;

                case InputActionPhase.Canceled:
                    myBool(false);
                    break;
            }
        }

        public void Run(InputAction.CallbackContext context)
        {
            SwitchContextPhase(context, endValue => isRunning = endValue);
        }
        
        public void MoveInput(InputAction.CallbackContext context)
        {
            var keyboardInput = context.ReadValue<Vector2>();
            verticalInput = keyboardInput.y;
            horizontalInput = keyboardInput.x;
            
            SwitchContextPhase(context, endValue => isMoving = endValue);
        }
    }
}