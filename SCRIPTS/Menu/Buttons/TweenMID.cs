using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMID : MonoBehaviour
{
    // Start is called before the first frame update
    public float Ypos;
    public float TweenTime;
    void Start()
    {
        Tween();
    }

    void Update()
    {
        
    }
    public void Tween() {
     
            transform.LeanMoveLocal(new Vector3(0,Ypos,0), TweenTime)
            .setEaseOutQuad();
    }
}
