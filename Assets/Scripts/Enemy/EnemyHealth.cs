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
    [SerializeField]
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
        ScoreController.IncreaseScore(5.0f);
        DropItem();    
        GameObject pl = GetPlayer.ReturnPlayer();
        pl.GetComponent<PlayerUpgrades>().IncrementKills();
        Destroy(gameObject);
    }
    //Implement RNG upgrades.
    //
    public void DropItem(){
        //Check if it drops any weapon at all.
        //Default, 1/10 chance.
        GameObject droppedWeapon = EnemyDrop.Drop();
        if(droppedWeapon != null){
            Instantiate(droppedWeapon,transform.position, Quaternion.identity);
        }
    }
    
}
