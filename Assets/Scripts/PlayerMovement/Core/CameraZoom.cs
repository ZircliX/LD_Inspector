using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [HideInInspector]
    public bool isZooming { get; private set; }

    [SerializeField]
    private float zoomSpeed, noZoomSpeed;
    [SerializeField]
    private float maxZoom, defaultZoom;

    [SerializeField] private new Camera camera;

    private Coroutine zoomCoroutine;

    private void Update()
    {
        if (isZooming)
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
            zoomCoroutine = StartCoroutine(LerpZoom(defaultZoom, noZoomSpeed));
        }
    }

    private IEnumerator LerpZoom(float targetZoom, float speed)
    {
        while (Mathf.Abs(camera.fieldOfView - targetZoom) > 0.01f)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetZoom, speed * Time.deltaTime);
            yield return null;
        }
        camera.fieldOfView = targetZoom;
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        isZooming = context.performed;
    }
}