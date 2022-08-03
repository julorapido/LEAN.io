using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEYGIFTT : MonoBehaviour
{
    public void GETDAKEY(){

      if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == true) {
            FindObjectOfType<UnityAdds>().PlayRewardedAdd("gift_key");
          }
 
     
  }
}
