using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrail : MonoBehaviour
{
   public TrailRenderer myTrailRenderer;

    public Material[] AllTrailSkins;

    Material PlayerMat;
    void FixedUpdate()
    {
         TrailRenderer myTrailRenderer = GetComponent<TrailRenderer>();
          myTrailRenderer.material = AllTrailSkins[PlayerPrefs.GetInt("TrailSkin")];


    }
}
