using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI bruh;
    public int ActualHealth;
    void Start()
    {
        ActualHealth = PlayerPrefs.GetInt("HealthSkill") + 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         bruh.text = ActualHealth.ToString();
    }
}
