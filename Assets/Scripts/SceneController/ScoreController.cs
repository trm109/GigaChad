using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScoreController : MonoBehaviour
{
    public static Text scoreText;
    public static float score = 0;
    public static float scoreMult = 1.0f;
    // Start is called before the first frame update
    static void InitializeScore(){
        scoreText = GameObject.FindObjectWithTag("Score").GetComponent<scoreText>();
    }
    public static void IncreaseScore(float amnt){
        score += amnt * scoreMult;
    }
}
