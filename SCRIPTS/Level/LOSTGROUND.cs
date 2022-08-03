using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSTGROUND : MonoBehaviour
{
     private bool LeanActive;
     void Start(){
          LeanActive = false;
     }
    void OnCollisionEnter (Collision collisioninfo){    
          if ((collisioninfo.collider.tag == "OBSTACLE")){
               Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),collisioninfo.collider);
          }
     }

     void FixedUpdate(){
    
        LeanActive = FindObjectOfType<LEANeffects>().FixedLeanBool;
     
           if (LeanActive == true){
                gameObject.tag = "LEANGROUND";
          }

          if (LeanActive == false){
               gameObject.tag = "LOSTGROUND";    
          }
     }
}
