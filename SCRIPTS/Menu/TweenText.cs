using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenText : MonoBehaviour
{
    // Start is called before the first frame update
    public float TweenTime;
    void Start()
    {
        Tween();
    }

    void Update()
    {
        
    }
    public void Tween() {
        LeanTween.cancel(gameObject);

        transform.localScale = Vector3.one;
        
        LeanTween.scale(gameObject, Vector3.one * 1.5f, TweenTime)
            .setEasePunch();
    }
}
