using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplParticle : MonoBehaviour
{
  public Transform car;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = car.position;
    }
}
