using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKILLSz : MonoBehaviour
{
    public GameObject Skill;
    // Start is called before the first frame update
    private float SkillXPOS;
    private float SkillYPOS;
    public float TweenTime;

    public int StartXPos;
    void Start()
    {
        SkillXPOS = Skill.transform.localPosition.x;
               SkillYPOS = Skill.transform.localPosition.y;

        Skill.transform.position = new Vector3(StartXPos,Skill.transform.position.y,Skill.transform.position.z);
        StartCoroutine(SlideIn());
    }   
    IEnumerator SlideIn(){
        yield return new WaitForSeconds(TweenTime);
        Skill.transform.LeanMoveLocal(new Vector3(SkillXPOS,SkillYPOS,0), 0.5f)
            .setEaseOutQuad();
        
    }
  
}
