using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public Rigidbody Player;
    public int BoostValue;
    private bool SpeedActivated;
    private float PlayerZSpeed;
    // Start is called before the first frame update
    private void FixedUpdate(){
        PlayerZSpeed = Player.velocity.z;
        
    }
    void OnTriggerEnter(Collider other)
    {   
        if (SpeedActivated == false){
            if (other.GetComponent<Collider>().tag == "PLAYERR"){
                SpeedActivated = true;
                StartCoroutine(ReactivateAfter());
                if (PlayerZSpeed < 10){
                    Player.AddForce(0,-(100 * Time.deltaTime),BoostValue * 2.15f * Time.deltaTime, ForceMode.VelocityChange);
                }else if (PlayerZSpeed >= 10){
                    Player.AddForce(0,-(100 * Time.deltaTime),BoostValue * Time.deltaTime, ForceMode.VelocityChange);
                }else if (PlayerZSpeed >= 40){
                    Player.AddForce(0,-(100 * Time.deltaTime),BoostValue * -1.85f* Time.deltaTime, ForceMode.VelocityChange);
                }else if (PlayerZSpeed >= 55){
                    Player.AddForce(0,-(100 * Time.deltaTime),BoostValue * -3f* Time.deltaTime, ForceMode.VelocityChange);
                }else if (PlayerZSpeed >= 70){
                    Player.AddForce(0,-(100 * Time.deltaTime),BoostValue * -4f* Time.deltaTime, ForceMode.VelocityChange);
                }
        
                StartCoroutine(FindObjectOfType<spedanim>().Create());
                 StartCoroutine(FindObjectOfType<chromatic>().SpeedChromatic());
                 if (PlayerPrefs.GetInt("SoundOn") == 1){
                    FindObjectOfType<PlayerSounds>().PlaySpeedSound();
                 }
            
            }
       }
    }

    IEnumerator ReactivateAfter(){
        yield return new WaitForSeconds(1.5f);
        SpeedActivated = false;
    }
}
