using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RSbuttons : MonoBehaviour
{
     public AudioSource ReplaySound;


    public void LoadHome(){
          if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == true) {
               FindObjectOfType<UnityAdds>().PlayInterstitialAd();
                SceneManager.LoadScene("Menu");
          }
    }

    public void LoadAgain(){

      if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == true) {
      StartCoroutine(REPLAY());
                if (PlayerPrefs.GetInt("SoundOn") == 1){
                 ReplaySound.Play();
        }  
          }
     
  }


  IEnumerator REPLAY(){
    yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Level01");
  }
}
