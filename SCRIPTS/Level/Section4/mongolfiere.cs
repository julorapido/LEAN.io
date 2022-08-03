using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mongolfiere : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody ballooon;
        public Transform ballooontrnsfrm;

    public int Yforce;
    // Update is called once per frame
    void FixedUpdate()
    {
        ballooon.AddForce(Vector3.up * Time.deltaTime * Yforce);
    }

    void OnCollisionEnter (Collision collisioninfo){

            if (collisioninfo.collider.tag == "ROOF"){
                StartCoroutine(ReplaceBalloon());
            }else if (collisioninfo.collider.tag == "LOSTGROUND"){
                Physics.IgnoreCollision(collisioninfo.collider, GetComponent<Collider>());
            }

    }

    IEnumerator ReplaceBalloon(){
        yield return new WaitForSeconds(0.1f);
        ballooontrnsfrm.localPosition = new Vector3(-2.3f,-249.1f,236);
    }
}
