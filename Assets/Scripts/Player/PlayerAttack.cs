using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerAttack : MonoBehaviour
{
    //Current weapon
    public float damage;

    public float range;
    
    //1 = 0 deg, 0 = 90 deg, -1 = 180 deg.
    //.5f = 45deg (total of 90 degree area)
    public float angle = .5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnLeftClick();
        OnRightClick();
        /*Debug.Log("Player Transform::::: " + transform.forward +
                    "\nPlayer Transform Normalized:::" + transform.forward.normalized);*/
    }
    private void OnLeftClick(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Left Click");
            //Some Attack
            Attack();
        }
    }
    private void OnRightClick(){
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Right Click");
            //Some Secondary Attack
        }
    }
    private void Attack(){
        List<EnemyHealth> list = GetEnemies();
        foreach(EnemyHealth l in list){
            Vector2 toEnemy = new Vector2(l.gameObject.transform.position.x - transform.position.x,
                                        l.gameObject.transform.position.z - transform.position.z);
            if(IsHit(toEnemy, transform.forward)){
                l.Damage(damage);
            }
        }
        //Check for hit
        //if(IsHit())
        //Apply damage.
    }
    public List<EnemyHealth> GetEnemies(){
        List<EnemyHealth> list = new List<EnemyHealth>();
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        foreach(Collider hit in hits){
            if(hit.GetComponent<EnemyHealth>()){
                list.Add(hit.GetComponent<EnemyHealth>());
            }
        }
        return list;
    }
    public bool IsHit(Vector2 a, Vector2 b){
        Debug.Log("Is Hit, " + Vector2.Dot(a.normalized,b) + "\n"+
                    " toEnemy = " + a.normalized +
                    ", transform.position = " + b);
        //and in the proper angle
        if(Vector2.Dot(a.normalized,b.normalized) < angle){
            Debug.Log("Enemy not in angle: " + Vector2.Dot(a.normalized,b.normalized));
            return false;
        }
        //if it doesn't trigger the false checks, return true.
        return true;
    }
}
