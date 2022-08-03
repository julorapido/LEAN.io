using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody r;

    public TrailRenderer playrtrail;
    public GameObject plyr;
    public ParticleSystem expl;

    IEnumerator Replace(){

         yield return new WaitForSeconds(0.35f);
         r.velocity = Vector3.zero;
            LeanTween.scale(plyr, Vector3.one * 1.7f, 0.02f);
         r.transform.position = new Vector3(0,-20.20f,56.21f);
    
    }
 private void OnCollisionEnter(Collision collisioninfo) {
        if (collisioninfo.collider.tag == "TRIGERRR" || collisioninfo.collider.tag == "TERRAIN" || collisioninfo.collider.tag == "OBSTACLE") {
            playrtrail.emitting = false;
            expl.Play();
            LeanTween.scale(plyr, Vector3.one * 0.1f, 0.001f);

            StartCoroutine(Replace());
            StartCoroutine(WaitTrail());
        }
    } 

    IEnumerator WaitTrail(){
          yield return new WaitForSeconds(0.42f);
            playrtrail.emitting = true;
    }

}


