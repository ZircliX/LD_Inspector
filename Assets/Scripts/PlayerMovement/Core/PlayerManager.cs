using LTX.ChanneledProperties;
using PuzzleSystem.Core;
using TheLastWitness.Core;
using UnityEngine;

namespace PlayerMovement.Core
{
    public class PlayerManager : MonoBehaviour
    {
        private Movement movementScript;
        private CameraZoom cameraZoomScript;
        private MouseMovement mouseMovementScript;

        private void Awake()
        {
            //Get Components
            movementScript = GetComponent<Movement>();
            cameraZoomScript = GetComponent<CameraZoom>();
            mouseMovementScript = GetComponent<MouseMovement>();

            //References Assignations
            movementScript.cameraZoom = cameraZoomScript;
        }

        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStarted += OnPuzzleStarted;
            PuzzleManager.Instance.OnPuzzleStopped += OnPuzzleStopped;
            
            GameController.CursorVisibility.AddPriority(this, PriorityTags.Small, false);
            GameController.CursorLockMode.AddPriority(this, PriorityTags.Small, CursorLockMode.Locked);
        }

        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStarted -= OnPuzzleStarted;
            PuzzleManager.Instance.OnPuzzleStopped -= OnPuzzleStopped;

            GameController.CursorVisibility.RemovePriority(this);
            GameController.CursorLockMode.RemovePriority(this);
        }
        
        private void OnPuzzleStarted(Puzzle puzzle)
        {
            movementScript.additionalSpeed = 5f;
        }
        
        private void OnPuzzleStopped(Puzzle puzzle)
        {
            movementScript.additionalSpeed = 0f;
        }
    }
}