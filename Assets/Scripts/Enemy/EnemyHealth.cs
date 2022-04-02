using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    //Public Variables

    //Private variables
    [SerializeField]
    private float health = 10.0f;
    private float maxHealth;
    [SerializeField]
    private Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;

        healthBar.value = health / maxHealth;
    }
    //Can heal too.
    public void Damage(float dmg)
    {
        Debug.Log("<<<Enemy Damaged");
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.value = health / maxHealth;
        if (health == 0)
        {
            Die();
        }
        
    }
    private void Die()
    {
        //do something, idk
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }
}
