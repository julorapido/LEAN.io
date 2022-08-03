using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class SkillPrice : MonoBehaviour
{
    private int SkillLevel; 
    public TextMeshProUGUI bruh;
    public string SkillString;
    

    private Vector3 initialTextPos;
    private Transform TextParent;
     private GameObject ChildTextIteration;
    void Start(){
        SkillLevel =  PlayerPrefs.GetInt(SkillString);
        initialTextPos = bruh.transform.localPosition;
        TextParent =  bruh.transform.parent;
    }

     void FixedUpdate(){
            SkillLevel =  PlayerPrefs.GetInt(SkillString);
         if (SkillLevel < 1){
                  bruh.text = (100).ToString();

         }else if ((SkillLevel >= 1) && (SkillLevel < 5)) {
                     
                 bruh.text = (SkillLevel * 100 * 6).ToString();

         }else if (SkillLevel >= 5){
                bruh.text = "MAX.";
                bruh.transform.localPosition = new Vector3(initialTextPos.x + 23,initialTextPos.y,initialTextPos.z);

             for (int i=0; i < TextParent.childCount; i++){
                  ChildTextIteration =  TextParent.GetChild(i).gameObject;
                  if (ChildTextIteration.tag == "SklCoinImg"){
                      ChildTextIteration.SetActive(false);
                  }
             }

         }




    }
}

