using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class x2yourcoins : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ui;
    public Button Btn;

    public float DownToXValue;
    public float AnimationTime;
    private Vector3 StartScale;
    private bool started = false;
    public bool IsKeyBtn;
    void Start()
    {
        StartScale = Ui.transform.localScale;
    }

    IEnumerator ScaleLoop(){
        started = true;
        while (true){
            yield return new WaitForSeconds(AnimationTime);
         LeanTween.scale(gameObject, StartScale, AnimationTime);
         yield return new WaitForSeconds(AnimationTime);
          LeanTween.scale(gameObject, StartScale * DownToXValue, AnimationTime);
        }

    }

    void FixedUpdate(){
        if (IsKeyBtn == true){
            if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == true ){
                Btn.interactable = true;
                  if (started == false){
                     StartCoroutine(ScaleLoop());
                  }
            }
        }else if (IsKeyBtn == false){
            if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == false) {
                            Btn.interactable = false;
                        }else if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == true ){
                            if (FindObjectOfType<CoinsText>().ActualCoins > 0){
                                    Btn.interactable = true;
                            if (started == false){
                                StartCoroutine(ScaleLoop());
                            }
                            }
                    
                        }
        }
      
    }
}
