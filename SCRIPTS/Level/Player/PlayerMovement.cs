using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerbody;
    public Transform playertransform;
    private float strafemove;
    public float fowardForce = 6000f;


    public float playervelocz;
    public float playerZZpos;
    private int PlayerSpeedLevel;


    private Vector3 TouchPosition;
    private Vector3 Direction;
    private int SectionPassed = 0;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        strafemove = 445 + 30 * (PlayerPrefs.GetInt("StrafeSkill"));
        playerbody.useGravity = true;
        PlayerSpeedLevel = PlayerPrefs.GetInt("SpeedSkill") / 3;
    }

    private void Update(){

        if (Input.touchCount > 0){
            
                Touch touch = Input.GetTouch(0);
                if (touch.deltaPosition.x > 0){
                            playerbody.AddForce( 2 * (Vector3.right * strafemove));
                        
                }else if (touch.deltaPosition.x < 0){
                        playerbody.AddForce( -2 * ( Vector3.right  * strafemove));
                    
                }

        }
         if (Input.GetKey("q"))
        {
            playerbody.AddForce( -2 * (Vector3.right * strafemove));
        }

             if (Input.GetKey("d"))
        {
            playerbody.AddForce( 2 * (Vector3.right * strafemove));
        }
    }

    int b = 1;
    int ecart = 100;
    void FixedUpdate()
    {
           
                playerZZpos = playertransform.position.z;
                playervelocz = playerbody.velocity.z;
                playerbody.useGravity = true;
            if (GameObject.FindGameObjectsWithTag("NewSection").Length > 0){
        
                /*--------------------------------------------------------------------------------------------------------------------------------*/
            

                   
                     /* AFTER THE SECTION*/  /* AFTER THE SECTION*/  /* AFTER THE SECTION*/  /* AFTER THE SECTION*/
                    if (playertransform.position.z > (GameObject.FindGameObjectsWithTag("NewSection")[SectionPassed].transform.position.z + 480)){
                                GameObject.FindGameObjectsWithTag("NewSection")[SectionPassed].SetActive(false);
                                SectionPassed += 1; 
                             
                    }

             
                        /* BELOW THE SECTION*/  /* BELOW THE SECTION*/  /* BELOW THE SECTION*/  /* BELOW THE SECTION*/
                          if (GameObject.FindGameObjectsWithTag("NewSection").Length >= 2){
                            /*Debug.Log(GameObject.FindGameObjectsWithTag("NewSection")[b]);*/
                                if (playertransform.position.z > (GameObject.FindGameObjectsWithTag("NewSection")[b].transform.position.z - ecart)){
                                            Debug.Log("ee");
                                                GameObject Path =  GameObject.FindGameObjectsWithTag("NewSection")[b].transform.GetChild(0).gameObject;
                                                Path.SetActive(true);
                                                ecart += 85;
                                                 
                                        }
                                        
                                if (playertransform.position.z > (GameObject.FindGameObjectsWithTag("NewSection")[b].transform.position.z + 50)){
                                            b++;
                                        }
                          } 
           
                 
                
    
               
                 
                 
                
                

                    /*--------------------------------------------------------------------------------------------------------------------------------*/
       
                
        
        
            }
            
   
            if(playervelocz >= 0 && playervelocz < 10) {
                  playerbody.AddForce(0, 0, ( 1.375f *(5 + PlayerSpeedLevel / 2.5f) * fowardForce * Time.deltaTime));
            }
            else if (playervelocz >= 10 && playervelocz < 25){
                    playerbody.AddForce(0, 0, (1.175f * (5 + PlayerSpeedLevel / 2.5f) * fowardForce * Time.deltaTime));
            }else if (playervelocz >= 25 && playervelocz < 40) {

                    playerbody.AddForce(0, 0, ((5 + PlayerSpeedLevel / 2.5f) * fowardForce * Time.deltaTime) / ( playerbody.velocity.z / 9 - (PlayerSpeedLevel / 9)) );


            }else if (playervelocz >= 40 && playervelocz < 55){
                     playerbody.AddForce(0, 0, ((5 + PlayerSpeedLevel / 2.5f) * fowardForce * Time.deltaTime) / ( playerbody.velocity.z / 7 - (PlayerSpeedLevel / 12)) );

            }else if (playervelocz >= 55){
                     playerbody.AddForce(0, 0, ((5 + PlayerSpeedLevel / 2.5f) * fowardForce * Time.deltaTime) / ( playerbody.velocity.z / 3 ) );

            }
             

    }
}
