using UnityEngine;

[DefaultExecutionOrder(-100)]
public class AroundSun : MonoBehaviour
{
    public Transform sun;
    public Transform earth;

    public float orbitSpeed = 1f;

    void LateUpdate()
    {
        if (sun == null || earth == null) return;

        earth.RotateAround(
            sun.position,
            Vector3.up,
            orbitSpeed * Time.deltaTime
        );
    }
}