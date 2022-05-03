using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] private static ScoreController sc;    //reference to player score
    public void Start(){
        sc = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
    }
    public static void Win(){
        //Print Score
        //Add score to leaderboard
        //Show Play Again/Quit buttons.
        SaveScore();
        Application.LoadLevel("GameOverScreen");
    }
    public static void Lose(){
        //Show sad message
        //dunno really
        SaveScore();
        Application.LoadLevel("GameOverScreen");
    }
    public static void SaveScore()
    {
        PlayerPrefs.SetFloat("score", sc.GetScore());
    }
}
