using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWHIGHSCORE : MonoBehaviour
{
    public Transform highscoreobj;
    public GameObject highscoreobjjj;
    private float Ypos;
     private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        Ypos = highscoreobj.localPosition.y;
    }

    // Update is called once per frame
    public void CheckHighScore()
    {
         if (FindObjectOfType<PlayerCollision>().NewHighScore == true){
                if (spawned == false) {
                    highscoreobjjj.SetActive(true);
                    spawned = true;
                    Invoke("TweenMid", 0.7f);
                    StartCoroutine(Bouncing());
                }
         }else if (FindObjectOfType<PlayerCollision>().NewHighScore == false){
                highscoreobjjj.SetActive(false);
         }
    }

        public void TweenMid() {
            transform.LeanMoveLocal(new Vector3(6,Ypos,0), 0.8f)
            .setEaseOutQuad();
    }

    IEnumerator Bouncing(){
          yield return new WaitForSeconds(0.6f);
        while (true)
        {
           
            LeanTween.scale(gameObject, Vector3.one * 1.75f, 1.7f).setEasePunch();
               yield return new WaitForSeconds(1.71f);
        }
        
    }
}
