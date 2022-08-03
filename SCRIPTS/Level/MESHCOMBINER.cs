using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MESHCOMBINER : MonoBehaviour
{
    public Material nightMAT;
    public Material dayMAT;
    private void Start(){
        CombineMeshes();
     
    }

    

    public void CombineMeshes(){

            Quaternion oldRot =  transform.rotation;
    Vector3 oldPos = transform.position;
    
    transform.position = Vector3.zero;
    transform.rotation = Quaternion.identity;

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Mesh FinalMesh = new Mesh();
        CombineInstance[] combiners = new CombineInstance[filters.Length];
        for (int a = 0; a < filters.Length; a ++){
            if (filters[a].transform == transform)
                continue;
            combiners[a].subMeshIndex = 0;
            combiners[a].mesh = filters[a].sharedMesh;
            combiners[a].transform = filters[a].transform.localToWorldMatrix;
          
        }
        FinalMesh.CombineMeshes(combiners);
        gameObject.GetComponent<MeshFilter>().sharedMesh = FinalMesh;
        GetComponent<MeshFilter>().sharedMesh = FinalMesh;
    
                if (PlayerPrefs.GetInt("NightMode") == 0){
                    gameObject.GetComponent<Renderer>().material = dayMAT;
                }
                if (PlayerPrefs.GetInt("NightMode") == 1){
                    gameObject.GetComponent<Renderer>().material = nightMAT; 
                }
   


        gameObject.GetComponent<MeshCollider>().sharedMesh = FinalMesh;
        GetComponent<MeshCollider>().sharedMesh = FinalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;
    }
}
