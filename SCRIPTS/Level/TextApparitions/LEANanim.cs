using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LEANanim : MonoBehaviour
{

     public TextMeshProUGUI bruh;

     private Vector3 sidee;
    public Canvas renderCanvas;
     private int xValue;
     private int centerX;
     private bool appearedOnce;
     void Start(){
             StartCoroutine(Scale());

     }

     void FixedUpdate(){
             if (FindObjectOfType<GameManager>().gameHasEnded == true) {
                        gameObject.SetActive(false);
                 }
     }
     IEnumerator Scale(){
             yield return new WaitForSeconds(0.25f); 
         LeanTween.scale(gameObject, Vector3.one * 1.35f, 1f).setEasePunch();
     }
      public IEnumerator Create(int side){
        appearedOnce = true;
            if (side == 1 ){
                      sidee = new Vector3(1300,-125,0);
                       xValue = -1300;
                       centerX = 200;
            }else if (side == 2) {
                    sidee = new Vector3(-1300,-125,0);
                    xValue = 1300;
                    centerX = -200;
            }
        
        TextMeshProUGUI NewText = Instantiate(bruh, sidee,  Quaternion.identity) as TextMeshProUGUI;


    NewText.transform.SetParent(renderCanvas.transform, false);

            NewText.transform.LeanMoveLocal(new Vector3(centerX,-150,0), 0.25f)/* MOOVE  TO MID */
                        .setEaseOutQuad();

      
            yield return new WaitForSeconds(0.9f);
         NewText.transform.LeanMoveLocal(new Vector3(xValue,600,0), 0.3f) /* MOOVE AWAY */
            .setEaseOutQuad();
             yield return new WaitForSeconds(1);
 
 
    }

}
