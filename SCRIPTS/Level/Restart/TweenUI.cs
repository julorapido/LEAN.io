using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float Ypos;
    public float Xpos;
    public float TweenTime;
    public GameObject e;
    public bool hasTweened = false;
    void Start()
    {
        Tween();
    }


    IEnumerator waitScale(){
         yield return new WaitForSeconds(1f);
        LeanTween.scale(e, Vector3.one * 0.6f, 1).setEasePunch();

    }
    public void Tween() {
            hasTweened = true;
            transform.LeanMoveLocal(new Vector3(Xpos,Ypos,0), TweenTime)
            .setEaseOutQuad();

            StartCoroutine(waitScale());
    }

    
}
