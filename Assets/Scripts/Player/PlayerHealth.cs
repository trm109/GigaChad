using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Public Variables

    //Private variables
    [SerializeField]
    private float health = 10.0f;
    private float maxHealth;

    
    [SerializeField]
    private HealthBar healthBar;    //Reference to the health bar

    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.InitializeHealth(maxHealth);
    }
    void Update()
    {
        //continuously update health bar for the player
        healthBar.SetValue(health);
    }
    //Can heal too.
    public void Damage(float dmg){
        if(isInvincible){
            return;
        }
        health -= dmg;
        health = Mathf.Clamp(health,0,maxHealth);
        if (health == 0){
            Faint();
        }
    }
    private void Faint(){
        //do something, idk
    }
    public float GetHealth()
    {
        return health;
    }
    public void SetInvulnerable(){
        isInvincible = true;
    }
    public void IncreaseMaxHealth(float newMax)
    {
        maxHealth = newMax;
        //for the time being, health will also just be set to the max health upon increase
        health = maxHealth;
    }
}
