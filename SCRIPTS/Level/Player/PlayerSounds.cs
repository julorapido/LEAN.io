using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource SpeedBost;

    public void PlaySpeedSound(){
        SpeedBost.Play();
    }
}
