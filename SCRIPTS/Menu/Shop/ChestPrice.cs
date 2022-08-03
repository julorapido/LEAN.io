using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChestPrice : MonoBehaviour
{
    public TextMeshProUGUI chestText;
        private string SlotAssign;
    public GameObject WholeChest;

    private int div = 0;

    public TextMeshProUGUI SkinText;
  public TextMeshProUGUI TrailText;
   public TextMeshProUGUI or;

    public bool AllSkinBought = true;
    public bool AllTrailsBought = true;
    
    // Start is called before the first frame update
    void Start()
    {
      AllTrailsBought = true;
      AllSkinBought = true;
        UpdateChestPrice();
    }
   private void FixedUpdate() {
             chestText.text = PlayerPrefs.GetInt("PlayerKey") + "/6";
    }
    // Update is called once per frame
    public void UpdateChestPrice()
    {
      AllTrailsBought = true;
      AllSkinBought = true;
      div = 0;
        for (int i=1; i <= 7; i++){
        
          SlotAssign = "SkinSlotState" + i;
              if (PlayerPrefs.GetInt(SlotAssign) == 0){
                div += 1;
                AllSkinBought = false;
              }
        }
      for (int i=1; i <= 4; i++){
        SlotAssign = "TrailSlotState" + i;
          if  (PlayerPrefs.GetInt(SlotAssign) == 0){
               div += 1;
               AllTrailsBought = false;
          }
      }

      if (AllSkinBought == true || AllTrailsBought == true){
        or.enabled = false; 
            if (AllSkinBought == true){
              SkinText.enabled = false;
              TrailText.transform.localPosition	= new Vector3(TrailText.transform.localPosition.x,0.2f,TrailText.transform.localPosition.z);
            }else if (AllTrailsBought == true){
                TrailText.enabled = false;
                 SkinText.transform.localPosition	= new Vector3(TrailText.transform.localPosition.x - 1,0.2f,TrailText.transform.localPosition.z);
            }
      }


    IEnumerator ScaleLoop(){
        while(true){
                    yield return new WaitForSeconds(1);
                LeanTween.scale(WholeChest, Vector3.one , 1);
                yield return new WaitForSeconds(1);
                LeanTween.scale(WholeChest,new Vector3(0.95f,0.95f,WholeChest.transform.localScale.z), 1);

        }
 
    }
      if (div <= 1){
        WholeChest.SetActive(false);
      }



       if (PlayerPrefs.GetInt("PlayerKey") >= 6){
        StartCoroutine(ScaleLoop());
      }
    }
}
