using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool MenuClicked = false;
    public GameObject Menu;
    public GameObject SettingsBtn;
    public Button SettingsBUTTON;


    private int Ygap = 0;
    private List<GameObject> ButtonsList = new List<GameObject>();
    

   public void Unroll(){

  
            StartCoroutine(DisableBtn());
                if (MenuClicked == false){
                    MenuClicked = true; 
                    for (int i=0; i < Menu.transform.childCount; i++){
                    Ygap -= 95; 
                            Menu.transform.GetChild(i).gameObject.SetActive(true); 
                            Menu.transform.GetChild(i).gameObject.transform.LeanMoveLocal(new Vector3(0,Ygap,0), 0.3f)
                    .setEaseOutQuad();
                            LeanTween.rotateZ (SettingsBtn , -60  ,0.3f );
                    }

                } else if(MenuClicked == true){
                    Ygap = 0; 

                    LeanTween.rotateZ (SettingsBtn , 0  ,0.3f );
                    MenuClicked = false;
                    
                    for (int i=0; i < Menu.transform.childCount; i++){
                        
                        Menu.transform.GetChild(i).gameObject.transform.LeanMoveLocal(new Vector3(0,0,0), 0.3f)
                                .setEaseOutQuad();

                        ButtonsList.Insert(i,  Menu.transform.GetChild(i).gameObject);
                    }

                }

       
    }




    IEnumerator DisableBtn(){
         SettingsBUTTON.enabled = false;
        yield return new WaitForSeconds(0.7f);
         SettingsBUTTON.enabled = true;
    }
}
