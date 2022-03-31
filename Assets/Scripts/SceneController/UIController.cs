using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    
    public void showWinScreen(){
        winScreen.SetActive(true);
        //lock controls
    }
    public void showLoseScreen(){
        loseScreen.SetActive(true);
        //lock controls
    }
}
