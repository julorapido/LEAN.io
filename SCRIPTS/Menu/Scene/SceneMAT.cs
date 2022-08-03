using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMAT : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer Player;
    public Material[] AllPlayerSkins;

    Material PlayerMat;
    void FixedUpdate()
    {
         Player.material = AllPlayerSkins[PlayerPrefs.GetInt("PlayerSkin")];
    }
}
