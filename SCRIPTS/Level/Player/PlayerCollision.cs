using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerCollision : MonoBehaviour
{
    public Rigidbody r;
    public Transform playr_transfrm;
    public float Speed;

     public GameObject ALLH;
     public TextMeshProUGUI bruh;

    public PlayerMovement movement;

    public int PlayerScore;
    public int BoostValue;

    public int BestScore;
    public int CurrentScore;

    public AudioSource ScoreSound;
    public AudioSource ScoreAirSound;

    public AudioSource TouchGround;
    public AudioSource DefeatSound;
    public AudioSource OBSTACLESOUND;
    public AudioSource LeanGroundSound;

    private Collider DetectedCollider;
     private Collider DetectedColliderEnter;
    public bool NewHighScore = false;
    private bool BallScaling = false;
  public ParticleSystem coinring;

   public Outline1 HealthOutilner;
   public GameObject Healthtxt;
      public GameObject Healthimg;

    private bool HasLeftGround = false;
    private float playerz;
    private int AirCap;
    private float initialPOS;

    private int AirPoint;
    void Start(){
         HealthOutilner = GetComponent<Outline1>();
        CurrentScore = 0;
        r = GetComponent<Rigidbody>();
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        
    }
        IEnumerator QuickOutline(){
         HealthOutilner.enabled = true;
             yield return new WaitForSeconds(0.2f);
            HealthOutilner.enabled = false;
    }
    
        void OnCollisionEnter (Collision collisioninfo){
        //Debug.Log(collisioninfo.collider.name);
        if
            ( (collisioninfo.collider.tag == "LOSTGROUND") || (collisioninfo.collider.tag == "OBSTACLE") )
            
            {
             
              
                if (collisioninfo.collider.tag == "OBSTACLE"){
                       if ( FindObjectOfType<HealthText>().ActualHealth >= 1){
                                                              if (PlayerPrefs.GetInt("SoundOn") == 1){
                                                                    OBSTACLESOUND.Play();
                                                                }
                                            StartCoroutine(QuickOutline());
                                                          FindObjectOfType<HealthText>().ActualHealth = FindObjectOfType<HealthText>().ActualHealth - 1;
                       }
          

                      if ( FindObjectOfType<HealthText>().ActualHealth == 0){
                          FindObjectOfType<GameManager>().GameOver(0);
                            movement.enabled = false;
                      }
        
                         LeanTween.scale(Healthtxt, Vector3.one * 1.2f, 1f).setEasePunch();
                       LeanTween.scale(Healthimg, Vector3.one * 1.2f, 1f).setEasePunch();

                }else if (collisioninfo.collider.tag == "LOSTGROUND"){
                        FindObjectOfType<GameManager>().GameOver(0);
                }
           
            }else if ((collisioninfo.collider.tag == "TERRAIN")) {
                if (FindObjectOfType<GameManager>().gameHasEnded == false){
                        if (PlayerPrefs.GetInt("SoundOn") == 1){
                                                                        DefeatSound.Play();
                                                                }
                }
                 movement.enabled = false;
                FindObjectOfType<GameManager>().GameOver(1);
    
                  

            }else if ((collisioninfo.collider.tag == "SOL")){
                if (collisioninfo.collider != DetectedColliderEnter){

                        HasLeftGround = false;
                        AirCap = 50;
                          StopCoroutine(waitOn()); 
                        initialPOS = gameObject.transform.position.z;
                        DetectedColliderEnter  = collisioninfo.collider;
                       if (PlayerPrefs.GetInt("SoundOn") == 1){
                                        TouchGround.Play();
                                }
                }
            }else if ((collisioninfo.collider.tag == "SPEEDBOST")){
                     HasLeftGround = false;
                       StopCoroutine(waitOn()); 



            }else if ((collisioninfo.collider.tag == "LEANGROUND")){
                if (r.velocity.z <= 30){
                        r.AddForce(0,5000 * Time.deltaTime,300 * Time.deltaTime, ForceMode.VelocityChange);
                }else if (r.velocity.z > 30 ){
                        r.AddForce(0,4350 * Time.deltaTime,300 * Time.deltaTime, ForceMode.VelocityChange);
                }else if (r.velocity.z >= 46){
                        r.AddForce(0,3650 * Time.deltaTime,300 * Time.deltaTime, ForceMode.VelocityChange);
                }
                          StopCoroutine(waitOn());                                 
                         StartCoroutine(waitOn());
                             CurrentScore += 1;
                        initialPOS = gameObject.transform.position.z;
                        if (BallScaling == false) {
                                        if (PlayerPrefs.GetInt("SoundOn") == 1){
                                                ScoreSound.Play();
                                        }
                                        StartCoroutine(PutDelay());
                                        LeanTween.scale(gameObject, Vector3.one * 1.15f, 1.15f).setEasePunch();
                                                 LeanTween.scale(ALLH, Vector3.one * 1.35f, 1.15f)
                        .setEasePunch();
                                }
                   if (PlayerPrefs.GetInt("SoundOn") == 1){
                        LeanGroundSound.Play();
                  }
                  if (playr_transfrm.position.x > 1){
                     StartCoroutine(FindObjectOfType<LEANanim>().Create(1));
                  }else if (playr_transfrm.position.x < 0){
                         StartCoroutine(FindObjectOfType<LEANanim>().Create(2));
            }

            }
    }

    void OnCollisionExit (Collision colliisioninfoexit){
            
            if (FindObjectOfType<GameManager>().gameHasEnded == false ){
                    if ((colliisioninfoexit.collider.tag == "SOL")  || (colliisioninfoexit.collider.tag == "SPEEDBOOST") ) {
                        
                        if (colliisioninfoexit.collider != DetectedCollider){
                                 StopCoroutine(waitOn());                                 
                                StartCoroutine(waitOn());
         
                                coinring.Play();
                                CurrentScore += 1;

                                DetectedCollider = colliisioninfoexit.collider;
                                if (BallScaling == false) {
                                        if (PlayerPrefs.GetInt("SoundOn") == 1){
                                                ScoreSound.Play();
                                        }
                                        StartCoroutine(PutDelay());
                                        LeanTween.scale(gameObject, Vector3.one * 1.15f, 1.15f).setEasePunch();
                                                 LeanTween.scale(ALLH, Vector3.one * 1.35f, 1.15f)
                        .setEasePunch();
                                }
                       


                    }

                } 
            }
    }



    IEnumerator waitOn(){
        yield return new WaitForSeconds (1f);
        HasLeftGround = true;
 
    }
    IEnumerator PutDelay(){
            BallScaling = true;
             yield return new WaitForSeconds(1.18f);
             BallScaling = false;

    }

    void FixedUpdate() {

             playerz = gameObject.transform.position.z;
             if (HasLeftGround == true){
                
                  if (playerz > initialPOS + AirCap){
                        CurrentScore += 1;
                        AirCap += 50;
                        if (PlayerPrefs.GetInt("SoundOn") == 1){
                            ScoreAirSound.Play();
                        }
                        if (BallScaling == false) {
                             StartCoroutine(PutDelay());
                            LeanTween.scale(ALLH, Vector3.one * 1.35f, 1.15f)
                           .setEasePunch(); 
                        }
                  }
             }
          

        if (CurrentScore > BestScore) {
            NewHighScore = true;
            PlayerPrefs.SetInt("BestScore", CurrentScore);
        }
    }

} 
