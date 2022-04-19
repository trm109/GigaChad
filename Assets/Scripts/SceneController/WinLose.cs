using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] private ScoreController sc;    //reference to player score

    public void Win(){
        //Print Score
        //Add score to leaderboard
        //Show Play Again/Quit buttons.
        SaveScore();
        Application.LoadLevel("GameOverScreen");
    }
    public void Lose(){
        //Show sad message
        //dunno really
        SaveScore();
        Application.LoadLevel("GameOverScreen");
    }
    public void SaveScore()
    {
        PlayerPrefs.SetFloat("score", sc.GetScore());
    }
}
