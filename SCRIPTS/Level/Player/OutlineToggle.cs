using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutlineToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public Outline outlinecontroller;
    void Start(){
        outlinecontroller = GetComponent<Outline>();
    }
    
        public void QuickFunc(){
            StartCoroutine(QuickOutline());
        }

    IEnumerator QuickOutline(){
         outlinecontroller.enabled = true;
             yield return new WaitForSeconds(0.2f);
            outlinecontroller.enabled = false;
    }
}
