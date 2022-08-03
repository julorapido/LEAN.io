using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startanim : MonoBehaviour
{
     public TextMeshProUGUI bruh;
    void Start(){
    
        StartCoroutine(anim());
        StartCoroutine(scaleanim());
        StartCoroutine(FadeIn(true));
    }


      IEnumerator FadeIn(bool fadeAway )
    {
        // fade from opaque to transparent
         if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0; i >= 1; i += Time.deltaTime / 10)
            {   
                // set color with i as alpha
                bruh.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

    }

        IEnumerator scaleanim(){
               yield return new WaitForSeconds(0.5f);
                LeanTween.scale(gameObject, Vector3.one * 1.4f, 1.5f).setEasePunch();
        }

     IEnumerator anim(){
            bruh.transform.LeanMoveLocal(new Vector3(0,250,0), 0.7f)
            .setEaseOutQuad();
             yield return new WaitForSeconds(1.4f);
        bruh.transform.LeanMoveLocal(new Vector3(-1300,330,0), 0.35f)
            .setEaseOutQuad();
     }
}
