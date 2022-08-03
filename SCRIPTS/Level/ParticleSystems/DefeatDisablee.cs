using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatDisablee : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ParticleTransform;

        void OnCollisionEnter (Collision collisioninfo){
                if (collisioninfo.collider.tag == "LOSTGROUND"){
                        Physics.IgnoreCollision(ParticleTransform.GetComponent<Collider>(), collisioninfo.collider);
                }
            }

}
