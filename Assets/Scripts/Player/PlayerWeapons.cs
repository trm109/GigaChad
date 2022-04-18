using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    //Current Weapon
    [SerializeField]
    public Weapon currentWeapon = new Weapon();
    [SerializeField]
    private List<Weapon> nearbyWeapons = new List<Weapon>();
    public WeaponIconManager wim;
    //List of weapons nearby.
    //
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerStats();
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(nearbyWeapons.Count > 0){
                currentWeapon = nearbyWeapons[0].Pickup();
                audioPicker();
                var temp = nearbyWeapons[0];
                nearbyWeapons.Remove(temp);
                temp.DestroyThis();
                UpdatePlayerStats();
                UpdateIcon();
            }
        }
    }

    private void audioPicker() {
        if (currentWeapon.type == Weapon.WeaponType.Fist) {
            GetComponent<AttackAudio>().setCounter(1);
        }
        else if (currentWeapon.type == Weapon.WeaponType.Brass_Knuckles) {
            GetComponent<AttackAudio>().setCounter(2);
        }
        else if (currentWeapon.type == Weapon.WeaponType.Sword) {
            GetComponent<AttackAudio>().setCounter(3);
        }
        else if (currentWeapon.type == Weapon.WeaponType.Morningstar) {
            GetComponent<AttackAudio>().setCounter(4);
        }
        else if (currentWeapon.type == Weapon.WeaponType.Axe) {
            GetComponent<AttackAudio>().setCounter(5);
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






