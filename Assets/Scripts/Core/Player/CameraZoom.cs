using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CyberEnigma.Core.Player
{
    public class CameraZoom : MonoBehaviour
    {
        public bool IsZooming { get; private set; }

        [SerializeField]
        private float zoomSpeed, unzoomSpeed;
        [SerializeField]
        private float maxZoom, defaultZoom;

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private Coroutine zoomCoroutine;

        private void Update()
        {
            if (IsZooming)
            {
                if (zoomCoroutine != null)
                {
                    StopCoroutine(zoomCoroutine);
                }
                zoomCoroutine = StartCoroutine(LerpZoom(maxZoom, zoomSpeed));
            }
            else
            {
                if (zoomCoroutine != null)
                {
                    StopCoroutine(zoomCoroutine);
                }
                zoomCoroutine = StartCoroutine(LerpZoom(defaultZoom, unzoomSpeed));
            }
        }

        private IEnumerator LerpZoom(float targetZoom, float speed)
        {
            while (Mathf.Abs(virtualCamera.m_Lens.FieldOfView - targetZoom) > 0.01f)
            {
                virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, targetZoom, speed * Time.deltaTime);
                yield return null;
            }
            virtualCamera.m_Lens.FieldOfView = targetZoom;
        }

        public void Zoom(InputAction.CallbackContext context)
        {
            IsZooming = context.performed;
        }
    }
}