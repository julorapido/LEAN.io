using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweenplaybtn : MonoBehaviour
{
    // Start is called before the first frame update
    public float TweenTime;
    void Update()
    {
        
     StartCoroutine(AnimationCoroutine());
         
    }

    IEnumerator AnimationCoroutine()
    {
        
        Tween();
        yield return new WaitForSeconds(1);
        TweenBack();
    }
    public void Tween() {

        transform.localScale = Vector3.one;
        
        LeanTween.scale(gameObject, Vector3.one * 1.2f, TweenTime)
            .setEasePunch();
    }

      public void TweenBack() {

        transform.localScale = Vector3.one;
        
        LeanTween.scale(gameObject, Vector3.one * 1.2f, TweenTime)
            .setEasePunch();
    }
}
