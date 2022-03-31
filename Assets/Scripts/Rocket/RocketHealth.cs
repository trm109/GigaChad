using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 200;
    private int maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RocketDamage(int n)
    {
        health -= n;
    }
}
