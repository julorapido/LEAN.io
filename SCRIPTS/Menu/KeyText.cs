using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyText : MonoBehaviour
{
    private int e; 
    public TextMeshProUGUI bruh;

    void Start(){
        e =  PlayerPrefs.GetInt("PlayerKey", 0);
    }
    void FixedUpdate(){
        e = PlayerPrefs.GetInt("PlayerKey");
    }
     void Update(){
         bruh.text = e.ToString();

    }
}
