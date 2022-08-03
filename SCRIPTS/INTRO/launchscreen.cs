using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class launchscreen : MonoBehaviour
{
  public CanvasGroup Texts;
  public GameObject textss;
    private void Start(){
        Application.targetFrameRate = 60;
         QualitySettings.vSyncCount = 0;
        StartCoroutine(LoadLevel());
        Texts.alpha = 0;
        StartCoroutine(Combine());
        StartCoroutine(WaitandScale());

    }

    IEnumerator AlphaOut(){
        for (float i = 1; i >= 0; i -= Time.deltaTime)
            {   
                 Texts.alpha = i;
                yield return null;
            }

    }

    IEnumerator AlphaIn(){
        for (float i = 0; i <= 1; i += Time.deltaTime)
            {   
                 Texts.alpha = i;
                yield return null;
            }

    }

      IEnumerator Combine(){
 StartCoroutine(AlphaIn());
  yield return new WaitForSeconds(2.5f);
 StartCoroutine(AlphaOut());
    }
    IEnumerator LoadLevel(){

        yield return new WaitForSeconds(3.81f);
            SceneManager.LoadScene("Menu");
    }

    IEnumerator WaitandScale(){
         yield return new WaitForSeconds(2f);
        LeanTween.scale(textss, Vector3.one * 1.1f, 0.8f).setEasePunch();
    }

}
