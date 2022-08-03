using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailPos : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void FixedUpdate()
    {
         transform.position = player.position + offset;
    }
}
