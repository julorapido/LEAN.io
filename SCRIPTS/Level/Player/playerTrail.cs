using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrail : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playertransform;
    public float OffsetZ;
     public TrailRenderer trail;

    void FixedUpdate()
    {
        trail.transform.localPosition = new Vector3(playertransform.position.x, playertransform.position.y, playertransform.position.z + OffsetZ);
    }
}
