using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsRestart1 : MonoBehaviour
{   
     private CoinsText gameCoinz;

    public TextMeshProUGUI bruh;

    private int CoinstoAdd;
    private int playercoinz;

    public AudioSource CoinLoop;
    public bool CoinRefreshed = false;
    private bool CoinsCoroutine = false;
    void Start()
    {
        gameCoinz = FindObjectOfType<CoinsText>();
        playercoinz = PlayerPrefs.GetInt("PlayerCoins", 0);
    }

    public void StartCoinRoutine(){
        StartCoroutine(RefreshCoin());
    }
    // Update is called once per frame
    void Update()
    {
        
          CoinstoAdd = gameCoinz.ActualCoins;
        bruh.text = PlayerPrefs.GetInt("PlayerCoins", 0).ToString();

         if (FindObjectOfType<GameManager>().gameHasEnded == true ){
             if (CoinsCoroutine == false) {
                 CoinsCoroutine = true;
                Invoke("StartCoinRoutine", 1.8f);
             }
         }
    }

    IEnumerator RefreshCoin(){
         
         float delay = 0.09f;
         if (CoinstoAdd > 30){
            delay = 0.03f;
         }
         LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.3f * CoinstoAdd).setEasePunch();
            for (int i = 1; i < CoinstoAdd + 1; i++){
                  yield return new WaitForSeconds(delay);
                      if (PlayerPrefs.GetInt("SoundOn") == 1){
                        CoinLoop.Play();
                  }
                  PlayerPrefs.SetInt("PlayerCoins", playercoinz + 1);
                  playercoinz = PlayerPrefs.GetInt("PlayerCoins", 0);
               
        }
        CoinRefreshed = true;
    }
}
