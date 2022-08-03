using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gain : MonoBehaviour
{

    public TextMeshProUGUI text;
    public TextMeshProUGUI NewText;
    public Canvas renderCanvas;
    // Start is called before the first frame update
    void Start()
    {
            text.text = "+" + (PlayerPrefs.GetInt("CoinSkill") + 1);
                LeanTween.scale(gameObject, Vector3.one * 1.35f, 1.6f).setEasePunch();
                   StartCoroutine(FadeText(true));
    }


       IEnumerator FadeText(bool fadeAway )
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= -0.1f; i -= (Time.deltaTime * 2f))
            {   
                // set color with i as alpha
                text.color = new Color(1, 1, 1, i);
                yield return null;
            }

        }

    }

    
    public IEnumerator Create(){
        TextMeshProUGUI NewText = Instantiate(text, new Vector3(205,-400,0),  Quaternion.identity) as TextMeshProUGUI; 

        NewText.transform.LeanMoveLocal(new Vector3(205,-200,0), 1f)
            .setEaseOutQuad();
        NewText.transform.SetParent(renderCanvas.transform, false);
        yield return new WaitForSeconds(1.25f);
        
    }


}
