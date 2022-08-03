using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightMode : MonoBehaviour
{
    
    public Material skyboxJOUR;
    public Material skyboxNUIT;
    public Image BtnImg;
     public Button NightBtn;

    public GameObject ButtonObject;

    private Color DayColorFog = new Color32(0, 156, 255, 255);
 private Color NightColorFog = new Color32(0, 0, 93, 255);
      public Sprite on;
       public Sprite off;
       public AudioSource NightSound;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("NightMode") == 0){
              RenderSettings.skybox = skyboxJOUR;
                  RenderSettings.fogColor = DayColorFog;
                BtnImg.sprite = off;
        }else if (PlayerPrefs.GetInt("NightMode") == 1){
                 RenderSettings.skybox = skyboxNUIT;
                 BtnImg.sprite = on;
                   RenderSettings.fogColor = NightColorFog;
        }
      
    }

    public void SwitchLightMode(){

        if (PlayerPrefs.GetInt("NightMode") == 0){ /* MODE NUIT*/
            BtnImg.sprite = on;
             PlayerPrefs.SetInt("NightMode", 1);
              RenderSettings.skybox = skyboxNUIT;
                RenderSettings.fogColor = NightColorFog;

        }else if (PlayerPrefs.GetInt("NightMode") == 1){ /* MODE JOUR*/
            BtnImg.sprite = off;
              PlayerPrefs.SetInt("NightMode", 0);
              RenderSettings.skybox = skyboxJOUR;
               RenderSettings.fogColor = DayColorFog;
        }
        LeanTween.scale(ButtonObject, Vector3.one * 1.1f, 0.75f)
            .setEasePunch();
        StartCoroutine(DisableBtn());
          if (PlayerPrefs.GetInt("SoundOn") == 1){
                 NightSound.Play();
        }  
    }

    IEnumerator DisableBtn(){
        NightBtn.interactable = false;
        yield return new WaitForSeconds(0.75f);
        NightBtn.interactable = true;
    }
}
