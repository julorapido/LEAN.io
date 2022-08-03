using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChange : MonoBehaviour
{

    public Material[] PlayerSkins;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       Player.GetComponent<Renderer>().material =   PlayerSkins[PlayerPrefs.GetInt("PlayerSkin",0)];
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
