using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    //Current Weapon
    [SerializeField]
    private Weapon currentWeapon = new Weapon();
    [SerializeField]
    private List<Weapon> nearbyWeapons = new List<Weapon>();
    public WeaponIconManager wim;
    //List of weapons nearby.
    //
    // Start is called before the first frame update
    void Start()
    {
        Weapon temp = new Weapon();
        temp.damage = 6.0f;
        temp.range = 5.0f;
        temp.aoeAngle = 0.5f;
        temp.attackSpeed = .25f;
        currentWeapon = temp;
        UpdatePlayerStats();
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(nearbyWeapons.Count > 0){
                currentWeapon = nearbyWeapons[0].Pickup();
                nearbyWeapons[0].DestroyThis();
                UpdatePlayerStats();
                UpdateIcon();
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Weapon>()){
            nearbyWeapons.Add(other.GetComponent<Weapon>());
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<Weapon>()){
            nearbyWeapons.Remove(other.GetComponent<Weapon>());
        }
    }
    //Update player stats.
    private void UpdatePlayerStats(){
        PlayerAttack.ChangeWeapon(currentWeapon.damage,
                                    currentWeapon.range,
                                    currentWeapon.aoeAngle,
                                    currentWeapon.attackSpeed);
        Debug.Log("Changing player stats!");
    }
    private void UpdateIcon(){
        //Implement this.
        wim.UpdateIcon(currentWeapon.icon);
    }
    //
}
