using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetModel : MonoBehaviour
{
    public GameObject newTarget;
    private bool newTargetInstantiated = false;

    void OnDestroy()
    {
        CameraFollow camera = GameObject.FindObjectOfType<CameraFollow>();
        if (camera != null && camera.Target == this.transform)
        {
            if (!newTargetInstantiated)
            {
                GameObject newTargetObject = Instantiate(newTarget);
                camera.SwitchTarget(newTargetObject.transform);
                newTargetInstantiated = true;
            }
        }
    }
}


