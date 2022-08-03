using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopScale : MonoBehaviour
{
    // Start is called before the first frame update

    public float ScaleValue;
    void Start()
    {

    }

    void CallScale(){
        StartCoroutine(Scale());
    }
    IEnumerator Scale(){
        yield return new WaitForSeconds(3);
        LeanTween.scale(gameObject, Vector3.one * ScaleValue, 1).setEasePunch();
        yield return new WaitForSeconds(3);   
    }
}
