using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class LEANeffects : MonoBehaviour
{
    public float TickRate;
    // Start is called before the first frame update
    private PostProcessVolume _gamePostProcessVolume;
    private ColorGrading _color_grading = null;
    private LensDistortion _lensDistortion = null;
    private float DistortionValue;
        private bool HasReached1 = false;
        
    
    public GameObject LeanBar;
        public GameObject WholeBar;
    private float DistValue;
    
    public bool FixedLeanBool;

    private RectTransform rec;
    private float LEANDELAY;
    void Start()
    {
              LEANDELAY = 4 + (PlayerPrefs.GetInt("LeanSkill") / 2);
      FixedLeanBool = false;

         _gamePostProcessVolume = GetComponent<PostProcessVolume>();
          _gamePostProcessVolume.profile.TryGetSettings(out _color_grading);
            _gamePostProcessVolume.profile.TryGetSettings(out _lensDistortion);
               _color_grading.enabled.value = false;
                    _lensDistortion.enabled.value = false;
                         WholeBar.SetActive(false);
                rec =  LeanBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public IEnumerator VisualLeanEffects()
    {
          StartCoroutine(Activate());
           yield return null;
    }

    private IEnumerator Activate(){
      FixedLeanBool = true;
                WholeBar.SetActive(true);
              StartCoroutine(LoadingBar());
            StartCoroutine(VisualDistortion());
                  _color_grading.enabled.value = true;
                _lensDistortion.enabled.value = true;

          yield return new WaitForSeconds(LEANDELAY);
                 Desactivate();
    }

    private void Desactivate(){
            StopCoroutine(VisualDistortion());
                 _color_grading.enabled.value = false; 
            _lensDistortion.enabled.value = false;
            WholeBar.SetActive(false);
            FixedLeanBool = false;
    }

   private void FixedUpdate() {
        DistValue = _lensDistortion.intensity.value;

        if (FindObjectOfType<GameManager>().gameHasEnded == true) {

            _color_grading.enabled.value = false; 
            _lensDistortion.enabled.value = false;
             WholeBar.SetActive(false);
        }
        
    }
    private IEnumerator VisualDistortion(){
       while(DistValue <= 45){
                    /* 0 TO 0.5*/   /* 0 TO 0.5*/   /* 0 TO 0.5*/   /* 0 TO 0.5*/
                float PreviousDistortionValue=  _lensDistortion.intensity.value;
                 yield return new WaitForSeconds(TickRate);
                _lensDistortion.intensity.value = (PreviousDistortionValue + 0.9f);
                 if(_lensDistortion.intensity.value == 44){
                            HasReached1 = true;
                    }
       }
                  /* 0.5 TO 0*/   /* 0.5 TO 0*/   /* 0.5 TO 0*/   /* 0.5 TO 0*/   /* 0.5 TO 0*/
                if(HasReached1 == true){
                      if(_lensDistortion.intensity.value > 0){
                                float PreviousDistortionValue2 = _lensDistortion.intensity.value;
                                yield return new WaitForSeconds(TickRate);
                                _lensDistortion.intensity.value = (PreviousDistortionValue2 - 0.09f);
                        }
                }
        }

    public IEnumerator LoadingBar(){
      WholeBar.transform.localScale = Vector3.one;
     rec.localScale = new Vector3(0, 1, 1);
      WholeBar.SetActive(true);
      LeanTween.scaleX(LeanBar,1,FindObjectOfType<Soda>().LEANTIME);
      StartCoroutine(ScaleLoop());
      yield return new WaitForSeconds(FindObjectOfType<Soda>().LEANTIME);
      WholeBar.SetActive(false);
    }

      IEnumerator ScaleLoop(){
        while (true){
            yield return new WaitForSeconds(0.5f);
         LeanTween.scale(WholeBar,  Vector3.one * 1.15f, 0.5f);
         yield return new WaitForSeconds(0.5f);
          LeanTween.scale(WholeBar, Vector3.one, 0.5f);
        }

    }
}
