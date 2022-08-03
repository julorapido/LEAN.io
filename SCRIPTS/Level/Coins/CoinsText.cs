    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinsText : MonoBehaviour
{

    public int ActualCoins;
    public TextMeshProUGUI bruh;
    public GameObject CoinImage;
    private bool isBumping = false;
    void Start(){
        ActualCoins = 0;
    }
   public  void ScoreUp(){
        ActualCoins =  ActualCoins + 1 + PlayerPrefs.GetInt("CoinSkill");
    }
     void FixedUpdate(){
       
         bruh.text = ActualCoins.ToString();

    }

   public  void Bump(){
        if (isBumping == false){
                StartCoroutine(PutDelay());
                    LeanTween.scale(gameObject, Vector3.one * 1.25f, 0.6f).setEasePunch();
                    LeanTween.scale(CoinImage, Vector3.one * 1.4f, 0.8f).setEasePunch();
                   
        }
    }

    IEnumerator PutDelay(){
            isBumping = true;
             yield return new WaitForSeconds(0.95f);
             isBumping = false;

    }


}
