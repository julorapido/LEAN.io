using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyCubz : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cubee;

    public float tweentime;
    void Start()
    {
         StartCoroutine(InfiniteLoop1());
    }

       private IEnumerator InfiniteLoop1()
    {
        while (true)
        {
          
             transform.LeanMoveLocal(new Vector3(- cubee.localPosition.x, cubee.localPosition.y,cubee.localPosition.z), tweentime)
            .setEaseOutQuad();
             yield return new WaitForSeconds(tweentime);
            transform.LeanMoveLocal(new Vector3(cubee.localPosition.x, cubee.localPosition.y,cubee.localPosition.z), tweentime)
                    .setEaseOutQuad();
            yield return new WaitForSeconds(tweentime);
        }
    }
}
