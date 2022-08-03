using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TABLET : MonoBehaviour
{

    private float AspectRatio;
    private float h;
    private float w;
    
    public GameObject Center;
      public GameObject Shop;

      public List<GameObject> Skillz = new List<GameObject>();

    void Start()
    {
          Application.targetFrameRate = 60;
         QualitySettings.vSyncCount = 0;


        h =  Screen.height;
        w =  Screen.width;
        AspectRatio = h / w;

        if (AspectRatio < 1.6f){
            Debug.Log("TABLET");

            Center.transform.localScale = new Vector3(0.8f,0.8f,1f) ;
            Center.transform.localPosition = new Vector3(Center.transform.localPosition.x,Center.transform.localPosition.y - 65,Center.transform.localPosition.z) ;

            Shop.transform.localPosition = new Vector3(Shop.transform.localPosition.x,Shop.transform.localPosition.y + 50,Shop.transform.localPosition.z) ;
            Shop.transform.localScale = new Vector3(9,9,Center.transform.localScale.z) ;

            for (int i=0; i < Skillz.Count; i++){
                    GameObject SkillChild = Skillz[i];
                        SkillChild.transform.localPosition = new Vector3(SkillChild.transform.localPosition.x,SkillChild.transform.localPosition.y + 110,SkillChild.transform.localPosition.z) ;
                          SkillChild.transform.localScale = new Vector3(0.9f,0.9f,Center.transform.localScale.z) ;
                    }
        }else if (AspectRatio > 1.6f){
                Debug.Log("PHONE");
        }
    }

}
