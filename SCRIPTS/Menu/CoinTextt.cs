using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextt : MonoBehaviour
{
    private int e; 
    public TextMeshProUGUI bruh;

    void Start(){
        e =  PlayerPrefs.GetInt("PlayerCoins", 0);
    }
    void FixedUpdate(){
        e = PlayerPrefs.GetInt("PlayerCoins");
    }
     void Update(){
         bruh.text = e.ToString();

    }
}
