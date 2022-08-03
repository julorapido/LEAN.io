using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    public GameObject[] section;
    public int Zpos ;
    public float Ypos = 31880.4f;
    public bool creatingSection = false;
    public int secNumber;
    private int xValue = -3;
    private bool calledOnce = false;
    public float CreatingTime;
    private int SectionRandomized;  
    private bool gameEnded = false;

    public Transform playerpos;

    private float zposplyr;
    private GameObject[] SectionList;

    void FixedUpdate()
    {
        if (creatingSection == false) {
            creatingSection = true;
           if (FindObjectOfType<GameManager>().gameHasEnded == false) {
                StartCoroutine(GenerateSection());
           }
       
        }

          if (FindObjectOfType<GameManager>().gameHasEnded == true) {
              gameEnded = true;
           }


    }

    IEnumerator GenerateSection() {
        if (calledOnce == false) {
            xValue = 0;
            Zpos = 452;
               yield return new WaitForSeconds(CreatingTime);
        }else if (calledOnce == true){
             yield return new WaitForSeconds(CreatingTime * 1.4f);
        }
     
        calledOnce = true;
        SectionRandomized = Random.Range(0, secNumber);
        section[SectionRandomized].SetActive(true);
        GameObject NewSec = Instantiate(section[SectionRandomized], new Vector3(xValue,Ypos, Zpos), Quaternion.identity);
        NewSec.gameObject.tag = "NewSection";

        section[SectionRandomized].SetActive(false);
         xValue -= 3;
        Zpos += 460;

        Ypos -= 130;
 
        creatingSection = false;
     
         yield return new WaitForSeconds(55f);

        if (gameEnded == false){
                    Destroy (NewSec);
        }

    }


}
