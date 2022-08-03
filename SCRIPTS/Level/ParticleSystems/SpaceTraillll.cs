using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTraillll : MonoBehaviour
{
    // Start is called before the first frame update
     public Rigidbody Player;
    public ParticleSystem SpaceTrailz;

    private ParticleSystem.EmissionModule ps; 
    private Vector3 PlayerVelocity;

    // Update is called once per frame
    private void FixedUpdate()
    {
         SpaceTrailz = GetComponent<ParticleSystem>();
         ps = SpaceTrailz.emission;
        ps.rateOverTime = (Player.velocity.z * 5);
        if (FindObjectOfType<GameManager>().gameHasEnded == true ){
            SpaceTrailz.Stop();
        }   
    }
}
