using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoins : MonoBehaviour
{   
    private GameObject Section;
    private float rotateSpeed;

    // Start is called before the first frame update
    private void Start(){
        rotateSpeed = Random.Range(3.1f, 3.4f);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        transform.Rotate(0,rotateSpeed,0, Space.World);

  
    }
}
