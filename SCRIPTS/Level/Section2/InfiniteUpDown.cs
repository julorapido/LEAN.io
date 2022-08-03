using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cube;
    public float waitTime;

    public int Xdecalage;
    public int zValue;
    public int yValue;
    void Start()
    {
        StartCoroutine(InfiniteLoop());
    }

    private IEnumerator InfiniteLoop()
    {
        while (true)
        {
             yield return new WaitForSeconds(waitTime);
             transform.LeanMoveLocal(new Vector3(Xdecalage,yValue,zValue), 2)
            .setEaseOutQuad();
            yield return new WaitForSeconds(waitTime);
            transform.LeanMoveLocal(new Vector3(-Xdecalage,yValue,zValue), 2)
                    .setEaseOutQuad();
            
            yield return new WaitForSeconds(waitTime);
        }
    }
}
