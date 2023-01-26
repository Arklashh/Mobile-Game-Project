using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target;
    public float SmoothSpeed = 0.125f;
    public Vector3 Offset;

    void FixedUpdate()
    {

        if (Target != null)
        {
            Vector3 desiredPosition = Target.position + Offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    public void SwitchTarget(Transform newTarget)
    {
        Target = newTarget;
    }
}
