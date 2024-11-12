using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public bool IsZooming { get; private set; }

    [SerializeField]
    private float zoomSpeed, unzoomSpeed;
    [SerializeField]
    private float maxZoom, defaultZoom;

    [SerializeField] private new Camera camera;

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
        while (Mathf.Abs(camera.fieldOfView - targetZoom) > 0.01f)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetZoom, speed * Time.deltaTime);
            yield return null;
        }
        camera.fieldOfView = targetZoom;
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        IsZooming = context.performed;
    }
}