using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public float damage = 1f;
    public float attackRange = 5f;
    [SerializeField]
    private float cooldown;
    private const float maxCooldown = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<GetTarget>().playertarget){
            target = GetComponent<GetPlayer>().player;
            //Debug.Log("Assigned target to Player");
        }else{
            target = GetComponent<GetAirship>().airship;
            //Debug.Log("Assigned target to Airship");
        }
    }

    // Start is called before the first frame update
    public void Attack()
    {
        //Debug.Log("Enemy Attacking");
        if(GetComponent<GetTarget>().playertarget){
            target.GetComponent<PlayerHealth>().Damage(damage);
        }else{
            target.GetComponent<AirshipHealth>().Damage(damage);
        }
    }
    public void IncreaseAttack(float percent){
        damage *= 1f + percent;
    }
    // Update is called once per frame
    void Update()
    {
        //Cooldown
        if(cooldown <= 0){
            if(Vector3.Distance(transform.position,target.transform.position) <= attackRange){
                Attack();
                cooldown = maxCooldown;
            }
        }else{
            cooldown -= Time.deltaTime;
        }
    }
}
