using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 0.1f;
    public GameObject completeLevelUi;
    public GameObject player;
    public ParticleSystem confetti;

    public ParticleSystem defeat;
    public AudioSource deafeatSound;

    void Awake() {
     Application.targetFrameRate = 60;
         QualitySettings.vSyncCount = 0;

      }

    public void GameOver(int n){
        if (gameHasEnded == false){
            CompleteLevel();
            OnTextClick();
            gameHasEnded = true ;
            PlayerPrefs.SetInt("PlayerLastScore", (FindObjectOfType<PlayerCollision>().CurrentScore));
            FindObjectOfType<NEWHIGHSCORE>().CheckHighScore();
            if (n == 0){
                StartCoroutine(WaitOffPlayer());
            }else if (n == 1){
                 StartCoroutine(InstantDefeat());
            }

        }
    }

    public void CompleteLevel(){
        completeLevelUi.SetActive(true);

        if ( (FindObjectOfType<PlayerCollision>().CurrentScore) > ( 4 * (PlayerPrefs.GetInt("BestScore", 0) / 5))){
                confetti.Play();
        }
    }

    
    public void ScreenTapped(){
         
           Invoke("Restart", restartDelay);
    }

     IEnumerator WaitOffPlayer(){
          yield return new WaitForSeconds(0.6f);
                FindObjectOfType<CameraShake>().ShakeCoroutine();
          defeat.Play();
            if (PlayerPrefs.GetInt("SoundOn") == 1){
                    deafeatSound.Play();
            }
          player.SetActive(false);
     }

    IEnumerator InstantDefeat(){
     
          yield return new WaitForSeconds(0.01f);
          defeat.Play();
          player.SetActive(false);
     }
    // the image you want to fade, assign in inspector
    public Image img;

    public TextMeshProUGUI txt;
    public TextMeshProUGUI scrtxt;

  public void OnTextClick()
    {
        StartCoroutine(FadeText(true));
        StartCoroutine(FadeHealth(true));
        StartCoroutine(FadeScore(true));
    }

    IEnumerator FadeHealth(bool fadeAway )
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

    }


        IEnumerator FadeText(bool fadeAway )
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {   
                // set color with i as alpha
                txt.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

    }

           IEnumerator FadeScore(bool fadeAway )
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {   
                // set color with i as alpha
                scrtxt.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

    }
}



 