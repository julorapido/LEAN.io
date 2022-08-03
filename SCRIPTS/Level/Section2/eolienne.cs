using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eolienne : MonoBehaviour
{
    private float rotateSpeed = 0.3f;

    // Update is called once per frame
    void FixedUpdate()
    {
                transform.Rotate(0,0,rotateSpeed, Space.Self);

    }
}
