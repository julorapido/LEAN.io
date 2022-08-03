using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAPPARITION : MonoBehaviour
{
    public Transform coinobject;
    public float TweenTime;

    private bool coinspawned = false;
    private float Ypos;
    // Update is called once per frame
    private int luck;
    void Start(){
            Ypos = coinobject.localPosition.y;
             luck = Random.Range(1, 4);
    }
    void Update()
    {
        if (FindObjectOfType<TweenUI>().hasTweened == true){
            if (coinspawned == false) {
                
                coinspawned = true;
                if (luck == 1 || luck == 3){    
                      Invoke("Tween", 1);
                }
        
            }
     
        }
    }

        public void Tween() {
            transform.LeanMoveLocal(new Vector3(129,Ypos,0), TweenTime)
            .setEaseOutQuad();
    }
}
