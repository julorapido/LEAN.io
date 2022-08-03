using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caca : MonoBehaviour
{
    public GameObject floor;
    public int bruh;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitOff());
    }

        IEnumerator WaitOff(){
            yield return new WaitForSeconds(bruh);

            floor.SetActive(false);
        } 
}
