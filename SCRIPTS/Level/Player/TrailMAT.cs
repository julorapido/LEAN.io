using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMAT : MonoBehaviour
{
    // Start is called before the first frame update
    public TrailRenderer myTrailRenderer;

    public Material[] AllTrailSkins;

    Material PlayerMat;
    void Start()
    {
         TrailRenderer myTrailRenderer = GetComponent<TrailRenderer>();
          myTrailRenderer.material = AllTrailSkins[PlayerPrefs.GetInt("TrailSkin")];

        Debug.Log("TrailSkin" + PlayerPrefs.GetInt("TrailSkin"));

    }
}
