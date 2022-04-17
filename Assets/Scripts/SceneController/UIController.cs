using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    
    public void ShowWinScreen(){
        winScreen.SetActive(true);
        //lock controls
    }
    public void ShowLoseScreen(){
        loseScreen.SetActive(true);
        //lock controls
    }
}
