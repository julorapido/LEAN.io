using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENUgift : MonoBehaviour
{

    public bool is_Gift_Shop;
    // Update is called once per frame
        public bool is_Key_Gift;
    public void GetGift()
    {
        if (FindObjectOfType<UnityAdds>().IsCoinLoopingGift == false){
                if((is_Key_Gift == true) ){
                      if (FindObjectOfType<ChestButton>().ChestOppenned == false){
                                 FindObjectOfType<UnityAdds>().PlayRewardedAdd("gift_keyy");
                                  gameObject.SetActive(false);
                      }
                 
                }


                if (is_Gift_Shop == true){
                       if (FindObjectOfType<ChestButton>().ChestOppenned == false){
                  FindObjectOfType<UnityAdds>().PlayRewardedAdd("gift_shop");
                     gameObject.SetActive(false);
                }
                }
                
                
                if ((is_Gift_Shop == false) && (is_Key_Gift == false) ){
                      if (FindObjectOfType<ChestButton>().ChestOppenned == false){
                                 FindObjectOfType<UnityAdds>().PlayRewardedAdd("gift_menu");
                      }
                 
                } 
                
      
        }

      
    }


}
