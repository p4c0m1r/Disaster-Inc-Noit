using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(100)]
public class PlanetOrbitCamera : MonoBehaviour
{
    public Transform target;

    [Header("Orbit")]
    public float distance = 20f;
    public float sensitivity = 0.2f;

    [Header("Zoom")]
    public float zoomSpeed = 5f;
    public float minDistance = 5f;
    public float maxDistance = 50f;

    public float minPitch = -40f;
    public float maxPitch = 40f;

    float yaw;
    float pitch;

    void Start()
    {
        if (target == null) return;

        Vector3 dir = (transform.position - target.position).normalized;
        pitch = Mathf.Asin(dir.y) * Mathf.Rad2Deg;
        yaw = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
    }

    void LateUpdate()
    {
        
        if (target == null || Mouse.current == null) return;
        
        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 delta = Mouse.current.delta.ReadValue();
            yaw   += delta.x * sensitivity;
            pitch -= delta.y * sensitivity;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (Mathf.Abs(scroll) > 0.01f)
        {
            distance -= scroll * zoomSpeed * Time.deltaTime;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            if (distance > 20) return;
        }
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rot * new Vector3(0f, 0f, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}