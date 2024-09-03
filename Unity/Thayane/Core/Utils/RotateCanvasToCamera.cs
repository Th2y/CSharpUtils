using UnityEngine;

public class RotateCanvasToCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}
