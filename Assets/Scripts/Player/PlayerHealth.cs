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
    private bool isdown;            //boolean for if player is down or not
    private float timer;            //timer to keep track of how long player has been down
    private int nDown;              //counter to keep track of how many times player has gone down
    private float currentSpeed;
    public GameObject model;
    
    [SerializeField]
    private HealthBar healthBar;    //Reference to the health bar

    private static bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {

        nDown = 0;
        timer = 3f;
        isdown = false;
        currentSpeed = GetComponent<PlayerMovement>().getSpeed();
        maxHealth = health;
        healthBar.InitializeHealth(maxHealth);
        
    }

    void Update()
    {

        if (health == 0 && isdown == false) {
            isdown = true;
            GetComponent<PlayerAttack>().setDown(true);
            nDown += 1;
            currentSpeed = GetComponent<PlayerMovement>().getSpeed();
            GetComponent<PlayerMovement>().setSpeed(0);
            model.transform.Rotate(90.0f, 0f, 0f);

        }

        if (isdown) {
            timer -= Time.deltaTime;
        }

        if (timer < 0) {
            isdown = false;
            GetComponent<PlayerAttack>().setDown(false);
            health = maxHealth;
            GetComponent<PlayerMovement>().setSpeed(currentSpeed);
            if (nDown < 2) { timer = 5f; }
            else { timer = 10f; }
            model.transform.Rotate(-90.0f, 0f, 0f);
        }
        
        healthBar.SetValue(health);         //continuously update health bar for the player
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
    public static void CalculateHealth()
    {
        maxHealth = defaultMaxHealth * healthMult;
        //for the time being, health will also just be set to the max health upon increase
        health = maxHealth;
    }
}
