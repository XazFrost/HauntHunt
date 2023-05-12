using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float maxOffset = 4f;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (target != null)
        {   
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(target.position);
            dir = new Vector3(dir.x, 0, dir.y);
            
            Vector3 targetPosition = Mathf.Clamp(dir.magnitude * 0.002f, -1, 1) * dir.normalized * maxOffset + transform.position;
            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
