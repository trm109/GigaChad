using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipHealth : MonoBehaviour
{
    private UIController gameController;
    private float health;
    private float maxhealth = 200f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        gameController = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIController>();
    }

   
    public void Damage(float n)
    {
        health -= n;
        health = Mathf.Clamp(health,0,maxhealth);
        if(health == 0f){
            Die();
        }
    }
    private void Die(){
        //Lose condition
        gameController.ShowLoseScreen();
        //Lock Player Movement
        //Prevent Enemies movement.
        //
        //Prevent UI Interaction (upgrades)

    }
}
