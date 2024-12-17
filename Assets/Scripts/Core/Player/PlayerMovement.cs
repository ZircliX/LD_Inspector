using UnityEngine;
using UnityEngine.InputSystem;

namespace CyberEnigma.Core.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float SPEED_MULTIPLIER = 1;
        public CharacterController CharacterController { get; private set; }
        
        [Header("Movement")]
        [SerializeField] private float speed = 8f;
        [SerializeField] private float sprintMultiplier = 2f;
        [SerializeField] private float acceleration = 16f;
        [SerializeField] private float deceleration = 32f;

        private bool isRunning;
        private bool isMoving;
        public bool isGrounded { get; private set; }
        private Vector2 targetVelocity;
        
        // ChannelKey crouchkey = ChannelKey.GetUniqueChannelKey(); (créer une clée unique pour les channels)
        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
        }
        
        private void FixedUpdate()
        {
            Vector3 forward = Vector3.ProjectOnPlane(GameCamera.Forward, transform.up).normalized;
            Vector3 right = Vector3.Cross(transform.up, forward).normalized;

            Vector3 velocity = forward * targetVelocity.y + right * targetVelocity.x;

            if (isRunning)
            {
                velocity *= sprintMultiplier;
            }
            
            isGrounded = CharacterController.SimpleMove(velocity * (SPEED_MULTIPLIER * speed * Time.deltaTime));
        }
        
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            //Debug.Log(input);

            isMoving = input.sqrMagnitude != 0;
            targetVelocity = input * speed;
            Debug.Log("OnMoveInput");

        }

        public void OnSprintInput(InputAction.CallbackContext context)
        {
            isRunning = context.phase == InputActionPhase.Performed;
            Debug.Log("OnSprint");
        }
    }
}