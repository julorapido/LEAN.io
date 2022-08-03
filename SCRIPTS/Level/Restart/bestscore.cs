using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class bestscore : MonoBehaviour
{

    public TextMeshProUGUI Scoree;
    public TextMeshProUGUI BestScoree;

    private PlayerCollision bruh;
    // Start is called before the first frame update
    void Start()
    {
        bruh = FindObjectOfType<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Scoree != null){
       Scoree.text = "SCORE : " +  bruh.CurrentScore.ToString(); 
        }else if (BestScoree != null){
        BestScoree.text = "BEST SCORE : " + PlayerPrefs.GetInt("BestScore", 0); 
        }

    }
}
