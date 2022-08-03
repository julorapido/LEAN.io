using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinZap : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem zap;

    private bool alreadyRunning = false;

    IEnumerator PutZapDelay(){
      alreadyRunning = true;
      yield return new WaitForSeconds(1.2f);
      alreadyRunning = false;
    }

      void OnTriggerEnter(Collider other)
    {
         if (FindObjectOfType<GameManager>().gameHasEnded == false ){
          if (other.tag == "PLAYERR"){
              if(alreadyRunning == false){
                zap.Play();
                StartCoroutine(PutZapDelay());
              }
          }
        
         }
    }
}
