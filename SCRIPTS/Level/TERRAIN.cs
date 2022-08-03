using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TERRAIN : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
          for (int i=0; i < gameObject.transform.childCount; i++){
            GameObject DecorChildd = gameObject.transform.GetChild(i).gameObject;
             for (int e=0; e < DecorChildd.transform.childCount; e++){
                 GameObject Element = DecorChildd.transform.GetChild(e).gameObject;
                 Element.tag = "TERRAIN";
                    Element.GetComponent<MeshRenderer>().enabled = false;
                                        Element.GetComponent<Collider>().enabled = false;

             }
          } 

    }

    



}
