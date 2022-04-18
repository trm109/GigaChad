using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerAttack : MonoBehaviour
{
    private bool isdown;       //bool for keeping track of whether player is down
    public void setDown(bool n) { isdown = n; }
    //public bool getDown() { return isdown; }


    //Current weapon
    [SerializeField]
    private static float damage;
    private static float defaultDamage = 6.0f;
    public static float powerMult = 1.0f;
    public static float vengeancePowerMult = 1.0f;
    public static float speedMult = 1.0f;
    public static float vengeanceSpeedMult = 1.0f;
    public static float range;
    private bool isPunchLeft = false;
    //1 = 0 deg, 0 = 180 deg, -1 = 360 deg.
    //.5f = 45deg (total of 90 degree area)
    public static float angle = .5f; 
    public Animator anim;

    private static float cooldown = 0.0f;
    private static float defaultMaxCooldown = .25f;
    private static float maxCooldown;
    AttackAnimationHandler attackAnimHandler;
    // Start is called before the first frame update
    void Start()
    {
        isdown = false;
        anim = GetComponent<Animator>();
        damage = defaultDamage;
        maxCooldown = defaultMaxCooldown;
        attackAnimHandler = GetComponent<AttackAnimationHandler>();
        attackAnimHandler.SetSwingAngle(angle);
    }

    // Update is called once per frame
    void Update()
    {
        OnLeftClick();
        OnRightClick();
        if(cooldown > 0){
            cooldown -= Time.deltaTime;
        }
        /*Debug.Log("Player Transform::::: " + transform.forward +
                    "\nPlayer Transform Normalized:::" + transform.forward.normalized);*/
    }
    public static void CalculateDamage(){
        if(!TimeEvents.isVengeanceMode){
            damage = defaultDamage * powerMult;
            maxCooldown = defaultMaxCooldown * speedMult;
        }else{
            damage = defaultDamage * powerMult * vengeancePowerMult;
            maxCooldown = defaultMaxCooldown * speedMult * vengeanceSpeedMult;
        }
    }
    private void OnLeftClick(){
        if(cooldown <= 0 && !isdown){
            if(Input.GetMouseButton(0)){
                anim.SetTrigger("ResetPunch");
                Attack();
                anim.ResetTrigger("isLeftPunch");
                anim.SetBool("isLeftPunch", isPunchLeft);
                anim.SetTrigger("Punch"); 
                isPunchLeft = !isPunchLeft;
                cooldown = maxCooldown;
                anim.ResetTrigger("ResetPunch");
                attackAnimHandler.Swing();
                GetComponent<AttackAudio>().play();
            }
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
            if(IsHit(toEnemy, new Vector2(transform.forward.x,transform.forward.z))){
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
    //
    //
    //
    public bool IsHit(Vector2 a, Vector2 b){
        //Debug.Log("Vector A::" + a);
        //Debug.Log("Vector B::" + b);
        //Debug.Log("Is Hit, " + Vector2.Dot(a.normalized,b) + "\n"+
        //            " toEnemy = " + a.normalized +
        //            ", transform.position = " + b);
        //and in the proper angle
        if(Vector2.Dot(a.normalized,b.normalized) < angle){
            //Debug.Log("Enemy not in angle: " + Vector2.Dot(a.normalized,b.normalized) + " < " + angle);
            return false;
        }
        //if it doesn't trigger the false checks, return true.
        return true;
    }
    public static void ChangeWeapon(float newDamage, float newRange, float newAOE, float newAttackSpeed){
        defaultDamage = newDamage;
        range = newRange;
        angle = newAOE;
        maxCooldown = newAttackSpeed;
        CalculateDamage();
    }
}
