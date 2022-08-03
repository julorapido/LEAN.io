using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform plane;

    // Update is called once per frame
    void Start(){

    }
    void fixedUpdate()
    {
    
     plane.transform.Rotate(0.0f, 0.0f, 50f, Space.Self);
    }
}
