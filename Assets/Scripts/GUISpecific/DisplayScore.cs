using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public static Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("GOScore").GetComponent<Text>();
        scoreText.text = PlayerPrefs.GetFloat("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
