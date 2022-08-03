 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : MonoBehaviour
{
    // Start is called before the first frame update
    public bool onLean = false;
    public AudioSource LeanSound;
    public float LEANTIME;

    void Start(){
        onLean = false;
        LEANTIME = 4 + (PlayerPrefs.GetInt("LeanSkill") / 2);
    }
    void OnTriggerEnter(Collider other){
         if (other.gameObject.tag == "PLAYERR"){
        
            if (onLean == false){

                   if (PlayerPrefs.GetInt("SoundOn") == 1){
                        LeanSound.Play();
                  }
                   StopCoroutine(LeanMode(LEANTIME));
                  StopCoroutine(FindObjectOfType<LEANeffects>().VisualLeanEffects());

                  StartCoroutine(LeanMode(LEANTIME));
                  StartCoroutine(FindObjectOfType<LEANeffects>().VisualLeanEffects());
                gameObject.GetComponent<MeshRenderer>().enabled = false;
         
            }
           
        }
    }

    IEnumerator LeanMode(float Delayy){
        onLean = true;
        yield return new WaitForSeconds(Delayy);
        onLean = false;
    }


}
