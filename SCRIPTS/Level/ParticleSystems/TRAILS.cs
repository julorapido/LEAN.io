using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRAILS : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void FixedUpdate()
    {
          if (FindObjectOfType<GameManager>().gameHasEnded == false ){
            transform.position = player.position + offset;
        }
    }
}
