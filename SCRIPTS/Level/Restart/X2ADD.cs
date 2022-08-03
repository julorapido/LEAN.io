using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2ADD : MonoBehaviour
{
    // Start is called before the first frame update
            public GameObject X2BUTTONTURNOFF;
    public void X2DACOINS(){

      if (FindObjectOfType<CoinsRestart1>().CoinRefreshed == true) {
            FindObjectOfType<UnityAdds>().PlayRewardedAdd("X2");
          }
 
     
  }
}
