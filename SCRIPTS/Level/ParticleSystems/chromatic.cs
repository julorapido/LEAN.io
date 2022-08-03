using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class chromatic : MonoBehaviour
{

    public float TickRate;
    private PostProcessVolume _gamePostProcessVolume;
    private ChromaticAberration _chromatic;

    private float ChromaticValue;
    public bool HasReached1 = false;
    void Start()
    {
        _gamePostProcessVolume = GetComponent<PostProcessVolume>();
        _gamePostProcessVolume.profile.TryGetSettings(out _chromatic);
    }

     private void FixedUpdate() {
        ChromaticValue = _chromatic.intensity.value;
    }

    public IEnumerator SpeedChromatic(){

                while(ChromaticValue <= 1){

                         float PreviousChromaticValue = _chromatic.intensity.value;
                       yield return new WaitForSeconds(TickRate);
                       _chromatic.intensity.value = (PreviousChromaticValue + 0.01f);
                        if(_chromatic.intensity.value > 1){
                            HasReached1 = true;
                        }
                }
                if(HasReached1 == true){
                      while(_chromatic.intensity.value > 0){
                                float PreviousChromaticValue = _chromatic.intensity.value;
                                yield return new WaitForSeconds(TickRate);
                                _chromatic.intensity.value = (PreviousChromaticValue - 0.01f);
                        }
                }
 }

}
