using PuzzleSystem.Core;
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
            movementScript = GetComponent<Movement>();
            cameraZoomScript = GetComponent<CameraZoom>();
            mouseMovementScript = GetComponent<MouseMovement>();
        }
        
        private void OnZoom()
        {
            movementScript.isZooming = cameraZoomScript.isZooming;
        }

        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStarted += OnPuzzleStarted;
            PuzzleManager.Instance.OnPuzzleStopped += OnPuzzleStopped;
        }

        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStarted -= OnPuzzleStarted;
            PuzzleManager.Instance.OnPuzzleStopped -= OnPuzzleStopped;
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