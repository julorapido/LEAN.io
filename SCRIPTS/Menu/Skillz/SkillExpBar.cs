using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillExpBar : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject Menu;
      public string SkillString;
      private GameObject ExpTick;
    // Update is called once per frame
    void FixedUpdate()
    {

        if (PlayerPrefs.GetInt(SkillString) >= 1  ){
              for (int i=0; i < PlayerPrefs.GetInt(SkillString); i++){
                         ExpTick = Menu.transform.GetChild(i).gameObject;
                        ExpTick.transform.GetChild(0).gameObject.SetActive(true);
                }
        }
    }
}
