using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        float time = (Time.realtimeSinceStartup) / 60;
        if (time < 2) { damage = 1; }
        else if (time < 3) { damage = 2; }
        else { damage = 3; }
    }

    // Start is called before the first frame update
    public static void Attack()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
