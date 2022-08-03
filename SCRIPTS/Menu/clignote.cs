using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clignote : MonoBehaviour
{
    // Start is called before the first frame update

    public float DownToXValue;
    public float AnimationTime;
    void Start()
    {
        StartCoroutine(ScaleLoop());
    }

    IEnumerator ScaleLoop(){
        while (true){
            yield return new WaitForSeconds(AnimationTime);
         LeanTween.scale(gameObject, Vector3.one * 1, AnimationTime);
         yield return new WaitForSeconds(AnimationTime);
          LeanTween.scale(gameObject, Vector3.one * DownToXValue, AnimationTime);
        }

    }
}
