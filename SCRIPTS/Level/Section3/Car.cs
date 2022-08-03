    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody car;
    public Transform cartransform;
    public int Xforce;

    private bool hastouched = false;
    public ParticleSystem carcrash;
    // Start is called before the first frame update


    void Start()
    {
        car = GetComponent<Rigidbody>();
        car.velocity= new Vector3(0, -200, 0);
        cartransform.localPosition = new Vector3(-61.9f,105,-9.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        car.AddForce((7.5f * Xforce * Time.deltaTime), 0, 0);
    }

    void OnCollisionEnter (Collision collisioninfo){
        //Debug.Log(collisioninfo.collider.name);
        if
            ( (collisioninfo.collider.tag == "carbmpr") )
            
            {
    
              car.AddForce(0, (100 * Xforce * Time.deltaTime), 0);
            }

            else if ((collisioninfo.collider.tag == "carwall") ||(collisioninfo.collider.tag == "TERRAIN") ) {
                carcrash.Play();

                if (hastouched == false) {
                    StartCoroutine(RespawnCar());
                    hastouched = true;
                }
              
            }
      }


      IEnumerator RespawnCar(){
          yield return new WaitForSeconds(1.75f);
          cartransform.localPosition = new Vector3(-61.9f,105,-9.3f);
            car.rotation = Quaternion.Euler(110.581f, -58.354f, 211.822f);
             car.velocity= new Vector3(0, -200, 0);
             hastouched = false;
     }
}
