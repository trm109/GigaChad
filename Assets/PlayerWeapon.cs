using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public List<GameObject> weaponsInRange;       //list of weapons in range
    public GameObject weapon;                     //weapon to be picked up
    [SerializeField] GameObject currentWeapon;    //Represents player's current weapon
    [SerializeField] GameObject emptyHands;
    private bool inRange;                       //bool for if player is in range of weapon


    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = emptyHands; //set starting weapon to empty hands
    }

    // Update is called once per frame
    void Update()
    {
        if ( weaponsInRange.Count > 0 && inRange && Input.GetKeyDown(KeyCode.E))
        {
            currentWeapon = weaponsInRange[0];          //Sets current weapon to first weapon in list of weapons in range
        }
    }


    private void  OnTriggerEnter(Collider other) {
        if (other.tag == "Weapon") { 
            inRange = true;                             //Sets inrange to true when entering collider
            weaponsInRange.Add(other.gameObject);       //Adds weapon to lists of weapons in range
        }
     }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Weapon") { 
            inRange = false;                            //Sets inrange to false when exiting collider
            weaponsInRange.Remove(other.gameObject);    //Removes weapon from list of weapons in range
        }
    }
    
}

