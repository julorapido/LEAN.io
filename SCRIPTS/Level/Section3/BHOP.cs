using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHOP : MonoBehaviour
{
    public int Ypos;
    public int Xpos;
    public int Zpos;

    public Rigidbody Player;
    void OnCollisionEnter (Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "PLAYERR"){
            Player.AddForce(Xpos * Time.deltaTime,Ypos * Time.deltaTime,Zpos * Time.deltaTime, ForceMode.VelocityChange);
         LeanTween.scale(gameObject, Vector3.one * 0.98f, 1).setEasePunch();
        }
                
            
               
    }
}
