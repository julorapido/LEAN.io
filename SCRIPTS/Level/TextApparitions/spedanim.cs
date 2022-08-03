using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class spedanim : MonoBehaviour
{
     public TextMeshProUGUI bruh;

     private Vector3 side;
    public Canvas renderCanvas;
     private int xValue;
     
     void Start(){
             StartCoroutine(Scale());
       
     }
     IEnumerator Scale(){
             yield return new WaitForSeconds(0.4f); 
         LeanTween.scale(gameObject, Vector3.one * 1.35f, 1.5f).setEasePunch();
     }
      public IEnumerator Create(){
                 int  siderandomized = Random.Range(1, 4);
            if (siderandomized == 1 || siderandomized == 3){
                      side = new Vector3(1300,320,0);
                       xValue = -1300;
            }else if (siderandomized == 2 || siderandomized == 4) {
                    side = new Vector3(-1300,320,0);
                    xValue = 1300;
            }
        
        TextMeshProUGUI NewText = Instantiate(bruh, side,  Quaternion.identity) as TextMeshProUGUI;


    NewText.transform.SetParent(renderCanvas.transform, false);

            NewText.transform.LeanMoveLocal(new Vector3(0,150,0), 0.4f)/* MOOVE  TO MID */
                        .setEaseOutQuad();


            yield return new WaitForSeconds(0.9f);
         NewText.transform.LeanMoveLocal(new Vector3(xValue,320,0), 0.45f) /* MOOVE AWAY */
            .setEaseOutQuad();
             yield return new WaitForSeconds(1);
    
 
    }
}
