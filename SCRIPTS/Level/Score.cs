using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI  scoreText;

    private PlayerCollision bruh;
    private int ScoreValue;

    void Start() {

       bruh = FindObjectOfType<PlayerCollision>();
       ScoreValue = bruh.CurrentScore;
    }
    void FixedUpdate()
        {
            ScoreValue = bruh.CurrentScore;
            scoreText.text = ScoreValue.ToString();    
        }


  
}
