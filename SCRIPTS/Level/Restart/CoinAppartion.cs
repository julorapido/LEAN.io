using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAppartion : MonoBehaviour
{
    public Transform coinobject;
    public float TweenTime;

    private bool coinspawned = false;
    private float Ypos;
    // Update is called once per frame

    void Start(){
            Ypos = coinobject.localPosition.y;
        
    }
    void Update()
    {
        if (FindObjectOfType<TweenUI>().hasTweened == true){
            if (coinspawned == false) {
                
                coinspawned = true;
                Invoke("Tween", 1);
            }
     
        }
    }

        public void Tween() {
            transform.LeanMoveLocal(new Vector3(0,Ypos,0), TweenTime)
            .setEaseOutQuad();
    }
}
