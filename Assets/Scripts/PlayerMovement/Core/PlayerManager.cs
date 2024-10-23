using UnityEngine;

namespace PlayerMovement.Core.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private Movement movementScript;
        [SerializeField] private CameraZoom cameraZoomScript;
        [SerializeField] private MouseMovement mouseMovementScript;

        private void OnZoom()
        {
            movementScript.isZooming = cameraZoomScript.isZooming;
            
            
        }
    }
}