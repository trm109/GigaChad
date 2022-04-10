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
    private float maxHealth = 10.0f;
    [SerializeField]
    private Slider healthBar;
    private GameObject item;
    private GameObject itemInstance;


    // Start is called before the first frame update
    void Start()
    {
        IncreaseHealth(Time.realtimeSinceStartup / 240.0f);
    }
    //Can heal too.
    public void Damage(float dmg)
    {
        //Debug.Log("<<<Enemy Damaged");
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.value = health / maxHealth;
        if (health == 0)
        {
            Die();
        }
    }
    public void IncreaseHealth(float percent){
        maxHealth *= percent + 1f;
        health = maxHealth;
        healthBar.value = health / maxHealth;
    }
    public void Die()
    {
        //do something, idk
        //Debug.Log("Enemy Died");
        //Increment player kills
        
        item = EnemyDrop.Drop();

        if (item != null)
        {
            itemInstance = Instantiate(item, this.transform);
            itemInstance.SetActive(true);
        }

        GameObject pl = GetComponent<GetPlayer>().player;
        pl.GetComponent<PlayerUpgrades>().kills++;
        Destroy(gameObject);
    }
}
