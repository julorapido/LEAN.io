using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WHOLEui;
    public GameObject ShopUi;

    public Button MenuButton;
    public GameObject ButtonObject;
    private float YShopPos;
    private void Start(){
        YShopPos = ShopUi.transform.localPosition.y;
    }

    public void Shop(){
        YShopPos = ShopUi.transform.localPosition.y;
        if (FindObjectOfType<SettingsMenu>().MenuClicked == true){
            Debug.Log("TRUE");
            FindObjectOfType<SettingsMenu>().Unroll();
        }
        if ( MenuButton.enabled == true){
        LeanTween.scale(ButtonObject, Vector3.one * 0.95f, 0.75f)
            .setEasePunch();
        }
         
        MenuButton.enabled = false;

        WHOLEui.transform.LeanMoveLocal(new Vector3(-2000,0,0), 0.3f)
                        .setEaseOutQuad();

        ShopUi.transform.LeanMoveLocal(new Vector3(0,YShopPos,0), 0.45f)
                        .setEaseOutQuad();
    }

        public void LeaveShop(){
    MenuButton.enabled = true;
        WHOLEui.transform.LeanMoveLocal(new Vector3(0,0,0), 0.45f)
                        .setEaseOutQuad();

        ShopUi.transform.LeanMoveLocal(new Vector3(1200,YShopPos,0), 0.3f)
                        .setEaseOutQuad();
    }
}
