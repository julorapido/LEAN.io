using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
  
  public float duratione;
  public float magnitudee;

  private float updatedZvalue;

  public void  ShakeCoroutine(){
      StartCoroutine(Shake());
  }
    public IEnumerator Shake(){

      Vector3 OriginalPos = transform.localPosition;

      float elapsed = 0.0f;
      
      while (elapsed < duratione) {
          float x = Random.Range(-1f, 1f) * magnitudee;
          float y = Random.Range(-1f, 1f) * magnitudee;

          transform.localPosition = new Vector3(OriginalPos.x + x,OriginalPos.y + y, OriginalPos.z);

          elapsed += Time.deltaTime;

          yield  return null;
      }

      transform.localPosition = OriginalPos;
  }
}
