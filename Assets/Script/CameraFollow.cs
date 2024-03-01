using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private void LateUpdate()
    {
        if (target == null)
        {
            target = FindObjectOfType<Player>()?.gameObject?.transform;
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;
            // move camera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }
}
