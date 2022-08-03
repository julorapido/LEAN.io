using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightModeLvl : MonoBehaviour
{
    public Material skyboxJOUR;
    public Material skyboxNUIT;

    
    private Color DayColorFog = new Color32(0, 156, 255, 255);
    private Color NightColorFog = new Color32(0, 0, 93, 255);


    private Color NightLight = new Color32(41, 43, 191, 255);
    void Start()
    {
         if (PlayerPrefs.GetInt("NightMode") == 0){
              RenderSettings.skybox = skyboxJOUR;
                  RenderSettings.fogColor = DayColorFog;
        }else if (PlayerPrefs.GetInt("NightMode") == 1){
                 RenderSettings.skybox = skyboxNUIT;
                 RenderSettings.ambientLight = NightLight * 3.8f ;
                  RenderSettings.fogColor = NightColorFog;
        }
    }

}
