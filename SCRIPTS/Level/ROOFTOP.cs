using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROOFTOP : MonoBehaviour
{
    
    public Rigidbody PlayerRigid;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
          if (other.tag == "PLAYERR"){
             PlayerRigid.AddForce(0,-750 * Time.deltaTime,50 * Time.deltaTime, ForceMode.VelocityChange);
             Debug.Log("RALENTISSEMENT");
          }
    }
}
