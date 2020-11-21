using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour
{

    public Transform Target = null;
    public bool FollowTarget = true;
    public float CameraHeight = 70;


    void LateUpdate()
    {
        if (Target)
        {
            if (FollowTarget)
            {
                this.transform.position = new Vector3(Target.position.x, CameraHeight, Target.position.z);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x, CameraHeight, this.transform.position.z);
            }
        }
    }
}
