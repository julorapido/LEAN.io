using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COINSTERRAIN : MonoBehaviour
{

    void Start()
    {
        
          for (int i=0; i < gameObject.transform.childCount; i++){
            GameObject SETOFCOINS = gameObject.transform.GetChild(i).gameObject;
             for (int e=0; e < SETOFCOINS.transform.childCount; e++){
                 GameObject Coin = SETOFCOINS.transform.GetChild(e).gameObject;
                    Coin.GetComponent<MeshRenderer>().enabled = true;
                      for (int f=0; f < Coin.transform.childCount; f++){
                            GameObject CoinSide = Coin.transform.GetChild(f).gameObject;
                              CoinSide.GetComponent<MeshRenderer>().enabled = false;
                              CoinSide.GetComponent<Collider>().enabled = false;
                      }

             }
          } 

    }
}

