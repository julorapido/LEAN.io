using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lastscore : MonoBehaviour
{
    private int e; 
    public TextMeshProUGUI bruh;

    void Start(){
        e =  PlayerPrefs.GetInt("PlayerLastScore", 0);
    }
    void FixedUpdate(){
        e = PlayerPrefs.GetInt("PlayerLastScore");
        bruh.text = e.ToString();
    }
}
