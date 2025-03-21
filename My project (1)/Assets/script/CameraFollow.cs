using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek pemain
    public Vector3 offset; // Offset kamera dari pemain

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}