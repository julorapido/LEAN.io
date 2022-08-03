using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillUnlock : MonoBehaviour
{
    // Start is called before the first frame update
     private int SkillLevel;
    public string SkillString;
     private int UserCoins;

        public AudioSource UnlockSound;
        public Button MainButton;

        public GameObject WholeSkill;
    void Start()
    {

    /* Debug.Log( SkillString.ToString() + PlayerPrefs.GetInt(SkillString)); */
       SkillLevel =  PlayerPrefs.GetInt(SkillString, 0); 
        UserCoins =  PlayerPrefs.GetInt("PlayerCoins");
    }

    void FixedUpdate(){
        UserCoins =  PlayerPrefs.GetInt("PlayerCoins");
         SkillLevel =  PlayerPrefs.GetInt(SkillString); 
        if (SkillLevel < 1){
                if (UserCoins < 100){
                    MainButton.enabled = false;
                }else if (UserCoins >= 100) {
                    MainButton.enabled = true;
                }
        }else if (SkillLevel >= 1) {
                  if (UserCoins < (SkillLevel * 100 * 6)){
                        MainButton.enabled = false;
                  }else if (UserCoins >= 100)  {
                    MainButton.enabled = true;
                }
        }else if (SkillLevel >= 5){
            MainButton.enabled = false;
        }
       
    }
    // Update is called once per frame
    public void Unlock()
    {

           
            if (SkillLevel < 1){

                    if (UserCoins >= (100)){
                            LeanTween.scale(WholeSkill, Vector3.one * 1.1f, 0.75f)
            .setEasePunch();
                            PlayerPrefs.SetInt("PlayerCoins", UserCoins - (100));
                            PlayerPrefs.SetInt(SkillString, 1); 
                                        if (PlayerPrefs.GetInt("SoundOn") == 1){
                                    UnlockSound.Play();
                            }
                            SkillLevel =  PlayerPrefs.GetInt(SkillString); 
                            UserCoins =  PlayerPrefs.GetInt("PlayerCoins");
                    }
            }else if (SkillLevel >= 1) {
                        UserCoins =  PlayerPrefs.GetInt("PlayerCoins");
                        if (UserCoins >= (SkillLevel * 100 * 6)){
                                       LeanTween.scale(WholeSkill, Vector3.one * 1.1f, 0.75f)
            .setEasePunch();
                                    SkillLevel =  PlayerPrefs.GetInt(SkillString); 
                                    PlayerPrefs.SetInt(SkillString, SkillLevel + 1); 
                                    PlayerPrefs.SetInt("PlayerCoins", UserCoins - (SkillLevel * 100 * 6));
                                    if (PlayerPrefs.GetInt("SoundOn") == 1){
                                            UnlockSound.Play();
                                    }
                                    UserCoins =  PlayerPrefs.GetInt("PlayerCoins");
                            

                               
                        }
                 
            }
                    
        }

}
