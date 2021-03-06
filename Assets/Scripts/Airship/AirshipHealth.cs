using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipHealth : MonoBehaviour
{
    [SerializeField]
    private static float health;
    public static float maxHealth = 200f;

    [SerializeField]
    private HealthBar healthBar;    //Reference to the health bar

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.InitializeHealth(maxHealth);
    }

    void Update()
    {
        //continuously update health bar for the player
        healthBar.SetValue(health);
    }

    public void Damage(float n)
    {
        health -= n;
        health = Mathf.Clamp(health,0,maxHealth);
        if(health == 0f){
            Die();
        }
    }
    private void Die(){
        WinLose.Lose();
    }
    public void Disable(){
        //
        gameObject.SetActive(false);
    }
}
