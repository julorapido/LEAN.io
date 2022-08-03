using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
  public AudioSource PlaySound;

  public void PlayGame(){
      if (PlayerPrefs.GetInt("SoundOn") == 1){
                 PlaySound.Play();
        }  
      StartCoroutine(waitAndPlay());
  
  }
  IEnumerator waitAndPlay(){
    yield return new WaitForSeconds(0.18f);
        SceneManager.LoadScene("Level01");
  }
}
