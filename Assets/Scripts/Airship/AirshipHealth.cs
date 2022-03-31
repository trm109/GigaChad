using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipHealth : MonoBehaviour
{
    private int health = 200;
    private int maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;
    }

   
    public void AirshipDamage(int n)
    {
        health = -n;
    }

}
