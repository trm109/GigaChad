using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    
    public enum WeaponType{
        Fist,
        Sword,
        Axe,
        Morningstar,
        Brass_Knuckles
    }
    [SerializeField]
    public WeaponType type = WeaponType.Fist;
    [SerializeField]

    public float damage = 6.0f;
    [SerializeField]

    public float range = 5.0f;
    [SerializeField]

    public float aoeAngle = 0.5f;
    [SerializeField]

    public float attackSpeed = 0.25f;
    public Sprite icon;
    public Weapon Pickup(){
        return this;
    }
    public void DestroyThis(){
        Destroy(this.gameObject);
    }
}
