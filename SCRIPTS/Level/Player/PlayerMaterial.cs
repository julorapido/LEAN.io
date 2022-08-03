using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer Player;
    public Material[] AllPlayerSkins;

    Material PlayerMat;
    void Start()
    {
         Player.material = AllPlayerSkins[PlayerPrefs.GetInt("PlayerSkin")];
        Debug.Log("PLayskin" + PlayerPrefs.GetInt("PlayerSkin"));


    }
}
