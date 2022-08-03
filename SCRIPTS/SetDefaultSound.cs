using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          if (PlayerPrefs.GetInt("Launched") == 0){
            PlayerPrefs.SetInt("SoundOn", 1);
            PlayerPrefs.SetInt("Launched", 1);
          }
    }

}
