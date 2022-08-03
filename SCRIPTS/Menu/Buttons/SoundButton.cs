using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Image SoundButtonObject;

    public Sprite SoundOn;
    public Sprite SoundOff;
    void Start()
    {
        if (PlayerPrefs.GetInt("SoundOn") == 1){
            SoundButtonObject.sprite = SoundOn;
        }else if (PlayerPrefs.GetInt("SoundOn") == 0){
                    SoundButtonObject.sprite = SoundOff;
        }
    }

    public void SwitchSound(){
        if (PlayerPrefs.GetInt("SoundOn") == 1){
                PlayerPrefs.SetInt("SoundOn", 0);
                SoundButtonObject.sprite = SoundOff;
        }else if (PlayerPrefs.GetInt("SoundOn") == 0){
                PlayerPrefs.SetInt("SoundOn", 1);
                  SoundButtonObject.sprite = SoundOn;
        }
    }
}
