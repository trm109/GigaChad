using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject target;
    public float damage;
    // Start is called before the first frame update
    void LateStart()
    {
        if(GetComponent<GetTarget>().playertarget){
            target = GetComponent<GetPlayer>().player;
        }else{
            target = GetComponent<GetAirship>().airship;
        }
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
