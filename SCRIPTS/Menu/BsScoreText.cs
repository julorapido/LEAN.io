using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BsScoreText : MonoBehaviour
{
    private int e; 
    public TextMeshProUGUI bruh;
    public int Value;
    public string TET;
    void Start(){
        e =  PlayerPrefs.GetInt("BestScore", 0);
    }

     void Update(){
         bruh.text =  TET + e.ToString();

    }
}
