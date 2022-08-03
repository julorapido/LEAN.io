using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCollect : MonoBehaviour
{
    // Start is called before the first frame update
    private Gain gainscrpt;
    public AudioSource CoinSound;
    private CoinsText a;


    private float YposRefreshed;

    void Start() {
        a = FindObjectOfType<CoinsText>();
        gainscrpt = FindObjectOfType<Gain>();
    }
    

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "PLAYERR"){
      
            FindObjectOfType<OutlineToggle>().QuickFunc();
            
                FindObjectOfType<CoinsText>().Bump();

                FindObjectOfType<CoinsText>().ScoreUp();
                  if (PlayerPrefs.GetInt("SoundOn") == 1){
                        CoinSound.Play();
                  }
                Invoke("disappear", 0f);
                StartCoroutine(gainscrpt.Create());
        }
    }


    void disappear(){
        this.gameObject.SetActive(false);
    }


}
