using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static Text scoreText;
    public static float score = 0;
    public static float scoreMult = 1.0f;
    // Start is called before the first frame update
    private void Start() {
        ScoreController.InitializeScore();
    }
    static void InitializeScore(){
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        AllignScore();
    }
    public static void IncreaseScore(float amnt){
        score += amnt * scoreMult;
        AllignScore();
    }
    public static void AllignScore(){
        scoreText.text = score.ToString();
    }
}
