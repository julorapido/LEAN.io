using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostMn : MonoBehaviour
{
    public Rigidbody Player;
    public int BoostValue;
    public int RandomX;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
                Player.AddForce( Random.Range(-RandomX, RandomX),0,BoostValue * Time.deltaTime, ForceMode.VelocityChange);
    }
}
