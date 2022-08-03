using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStar : MonoBehaviour
{
        public int rotateSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
             transform.Rotate(0,0,rotateSpeed, Space.Self);
    }
}
