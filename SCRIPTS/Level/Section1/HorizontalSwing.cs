using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSwing : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cubee;
    public 
    void Start()
    {
         StartCoroutine(InfiniteLoop1());
    }

       private IEnumerator InfiniteLoop1()
    {
        while (true)
        {
          
             transform.LeanMoveLocal(new Vector3(6, cubee.localPosition.y,cubee.localPosition.z), 1f)
            .setEaseOutQuad();
             yield return new WaitForSeconds(1f);
            transform.LeanMoveLocal(new Vector3(-6, cubee.localPosition.y,cubee.localPosition.z), 1f)
                    .setEaseOutQuad();
            yield return new WaitForSeconds(1f);
        }
    }
}
