using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody cubee;
    public float Xdecalage;
    public int sens;
    // Start is called before the first frame update
    void Start()
    {
       if (sens == 0 ){
        StartCoroutine(InfiniteLoop0());
       }else if (sens == 1){
        StartCoroutine(InfiniteLoop1());
       }
    }


        private IEnumerator InfiniteLoop0()
    {
        while (true)
        {
       
             transform.LeanMoveLocal(new Vector3(Xdecalage,22.19f,-64.24f), 1f)
            .setEaseOutQuad();
            yield return new WaitForSeconds(1f);
            transform.LeanMoveLocal(new Vector3(Xdecalage,13.6f,-64.24f), 1f)
                    .setEaseOutQuad();

             yield return new WaitForSeconds(1f);
        }
    }

        private IEnumerator InfiniteLoop1()
    {
        while (true)
        {
          
             transform.LeanMoveLocal(new Vector3(Xdecalage,13.6f ,-64.24f), 1f)
            .setEaseOutQuad();
             yield return new WaitForSeconds(1f);
            transform.LeanMoveLocal(new Vector3(Xdecalage,22.19f,-64.24f), 1f)
                    .setEaseOutQuad();
            yield return new WaitForSeconds(1f);
        }
    }
}
