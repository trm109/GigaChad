using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Public Variables

    //Private variables
    [SerializeField]
    private float health = 10.0f;
    private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }
    //Can heal too.
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //do something, idk
    }
}
