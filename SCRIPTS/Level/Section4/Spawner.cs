using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sphere;

    public int Loop;
    public Transform NewParent;
    public GameObject lostground;
    private int i = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
  
        if (i < Loop){
             i += 1;
           GameObject child =  Instantiate(sphere, transform.position, Quaternion.identity);  
           child.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Physics.IgnoreCollision(child.GetComponent<Collider>(), lostground.GetComponent<Collider>());
            child.transform.SetParent(NewParent);

        }

    }
}
