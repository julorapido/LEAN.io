using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SpeedScript : MonoBehaviour
{
    public Rigidbody player;
    public GameObject Particles;
    
    void Start() {
        Particles.gameObject.SetActive(false);
    }

    void Update () {

    if (FindObjectOfType<GameManager>().gameHasEnded == false ){
            if (player.velocity.z >= 47){
                Particles.gameObject.SetActive(true);
            }else {
                Particles.gameObject.SetActive(false);
            }
        }else {
            Particles.gameObject.SetActive(false);
        }
    }
}
