using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Start the game
    public void GameStart()
    {
        Application.LoadLevel("Main");
    }

    //Return to main menu
    public void ToMainMenu()
    {
        Application.LoadLevel("IntroScreen");
    }

    //Quit Game
    public void GameEnd()
    {
        Application.Quit();
    }
}
