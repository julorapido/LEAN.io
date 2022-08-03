 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Button SlotBtn;
    public Image LockImage;
    public int SkinPrice;
    public GameObject AllSlots;
    public GameObject PriceText; 
    public GameObject OwnSlot;
    public GameObject CheckBox;

    public AudioSource UnlockSound;
    public AudioSource SelectSound;

    public bool isTrails;
    private string SlotAssign;
    private int SlotNmbr;
    
    void Start()
    {

      for (int i=0; i < AllSlots.transform.childCount; i++){
            GameObject SlotChild = AllSlots.transform.GetChild(i).gameObject;
            if (SlotChild == OwnSlot){
                SlotNmbr = i;
            }
      }

      if (isTrails == true){
               SlotAssign = "TrailSlotState" + SlotNmbr;

      }else if (isTrails == false){
              SlotAssign = "SkinSlotState" + SlotNmbr;
      }

        if (SlotNmbr == 0){ /* UNLOCK SKIN 0 */
            PlayerPrefs.SetInt(SlotAssign,1);
        }

        if (isTrails == true){ /* WHEN DEFAULT SKIN 0 */
            if (PlayerPrefs.GetInt("TrailSkin") == 0){
                PlayerPrefs.SetInt("TrailSlotState0" ,2);
            }
        }else if (isTrails == false){
             if (PlayerPrefs.GetInt("PlayerSkin") == 0){
                PlayerPrefs.SetInt("SkinSlotState0",2);
            }
        }

         if ( (PlayerPrefs.GetInt(SlotAssign)) == 0){
                PriceText.SetActive(true);
                LockImage.enabled = true;
                if (PlayerPrefs.GetInt("PlayerCoins") >= SkinPrice){
                    StartCoroutine(ScaleLoop());
                }

        } 

        if ( (PlayerPrefs.GetInt(SlotAssign)) >= 1){
                PriceText.SetActive(false);
                LockImage.enabled = false;
                StopCoroutine("ScaleLoop");
        } 
        if ( (PlayerPrefs.GetInt(SlotAssign)) == 2){
                OwnSlot.transform.GetChild(0).gameObject.SetActive(true);
                CheckBox.SetActive(true);
        }
    }

    private bool Scaling = false;
    private void FixedUpdate() {
         if ( (PlayerPrefs.GetInt(SlotAssign)) == 0){
            if (PlayerPrefs.GetInt("PlayerCoins") >= SkinPrice){
                if (Scaling == false){
                    StartCoroutine(ScaleLoop());
                }
            }
         }
    
    }
    IEnumerator ScaleLoop(){
                Scaling = true;
                    yield return new WaitForSeconds(1);
                LeanTween.scale(OwnSlot, Vector3.one * 1, 1);
                yield return new WaitForSeconds(1);
                LeanTween.scale(OwnSlot,new Vector3(0.97f,0.97f,OwnSlot.transform.localScale.z), 1);
                Scaling = false;
    }

    // Update is called once per frame
    public void Unlock()
    {

            if ( (PlayerPrefs.GetInt(SlotAssign)) == 0){
                if (PlayerPrefs.GetInt("PlayerCoins") >= SkinPrice){
                        LockImage.enabled = false;
                        PlayerPrefs.SetInt("PlayerCoins", (PlayerPrefs.GetInt("PlayerCoins") - SkinPrice));
                        PlayerPrefs.SetInt(SlotAssign,1);
                    PriceText.SetActive(false);
                        if (PlayerPrefs.GetInt("SoundOn") == 1){
                                        UnlockSound.Play();
                                }
                   FindObjectOfType<ChestPrice>().UpdateChestPrice();
                }else if (PlayerPrefs.GetInt("PlayerCoins") < SkinPrice){
                    SlotBtn.enabled = false;
                }
            }
        
    }

    public void SelectSkin(){
       
       if ( (PlayerPrefs.GetInt(SlotAssign)) >= 1){
                for (int i=0; i < AllSlots.transform.childCount; i++){
                    
                    GameObject SlotChilds = AllSlots.transform.GetChild(i).gameObject;
                        GameObject Selected =  SlotChilds.transform.GetChild(0).gameObject;
                          GameObject CheckBox =  SlotChilds.transform.GetChild(5).gameObject;
                            if (Selected.activeSelf == true){
                                Selected.SetActive(false);
                                CheckBox.SetActive(false);
                                if (isTrails == true){
                                    PlayerPrefs.SetInt("TrailSlotState" + i,1);
                                }else if (isTrails == false){
                                    PlayerPrefs.SetInt("SkinSlotState" + i,1);
                                }
                            
                            }
                }
            OwnSlot.transform.GetChild(0).gameObject.SetActive(true);
            CheckBox.SetActive(true);
            StartCoroutine(DisableBtn());
            LeanTween.scale(OwnSlot, Vector3.one * 1.075f, 0.5f).setEasePunch();
            PlayerPrefs.SetInt(SlotAssign,2);
                if (PlayerPrefs.GetInt("SoundOn") == 1){
                                    SelectSound.Play();
                            }
            if (isTrails == false){
                PlayerPrefs.SetInt("PlayerSkin", SlotNmbr);
                Debug.Log("SKIN SELECTED =" + PlayerPrefs.GetInt("PlayerSkin"));
            }
             if (isTrails == true){
                PlayerPrefs.SetInt("TrailSkin", SlotNmbr);
                Debug.Log("TRAIL SELECTED =" + PlayerPrefs.GetInt("TrailSkin"));
            }
           
        }
    }

    IEnumerator DisableBtn(){
          SlotBtn.enabled = false;
         yield return new WaitForSeconds(0.6f);
          SlotBtn.enabled = true;
    }


}
