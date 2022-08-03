using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLinesSripts : MonoBehaviour
{
    public Transform Camera;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.position + offset;
    }
}
