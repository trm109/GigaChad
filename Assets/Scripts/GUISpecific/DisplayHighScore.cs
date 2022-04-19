using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public static Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("GOHiScore").GetComponent<Text>();
        float currentScore = PlayerPrefs.GetFloat("score");
        float hiScore = PlayerPrefs.GetFloat("hiScore");
        
        if (currentScore > hiScore)
        {
            PlayerPrefs.SetFloat("hiScore", currentScore);
            scoreText.text = PlayerPrefs.GetFloat("hiScore").ToString();
        }
        else
            scoreText.text = PlayerPrefs.GetFloat("hiScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
