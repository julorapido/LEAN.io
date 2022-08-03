using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForward : MonoBehaviour
{
    public GameObject Car;
    public Rigidbody CarRigid;
    public float CarSpeed;
    private Vector3 CarStartPos;
    // Start is called before the first frame update
    void Start()
    {
        CarStartPos = Car.transform.localPosition;
    }

    // Update is called once per frame
    private bool isrunning = false;
    void FixedUpdate()
    {
         if (FindObjectOfType<GameManager>().gameHasEnded == false ){
                  CarRigid.AddForce(CarSpeed * Time.deltaTime,0,0);
         }

         if (FindObjectOfType<GameManager>().gameHasEnded == true ){
                    CarRigid.constraints =  RigidbodyConstraints.None;
                   CarRigid.AddForce(0,20 * Time.deltaTime,0);
                if (isrunning == false){
                       StartCoroutine(Despawn());
                }
                
         }
  
    }

    IEnumerator Despawn(){
        isrunning = true;
        int time = Random.Range(1,2);
        yield return new WaitForSeconds(time);
        Destroy(Car);
    }

    void OnCollisionEnter (Collision collisioninfo){
        if (collisioninfo.collider.tag == "MURAUTOROUTE"){
                Car.transform.localPosition = CarStartPos;
               
        }
    }
}
