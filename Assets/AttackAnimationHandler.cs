using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationHandler : MonoBehaviour
{   
    public GameObject fist;
    public GameObject sword;
    public GameObject axe;
    public GameObject morningstar;
    public GameObject swingObj;
    public GameObject jabObj;
    public float swingStartAngle;
    public float animSpeed;
    public float animCurrentTime;
    public float animMaxTime = 0.2f;
    private bool swinging = false;
    private bool jabbing = false;
    public int currentWeapon = 0;
    //1 = 0 deg, 0 = 180 deg, -1 = 360 deg.
    private void Update() {
        if(swinging){
            if(animCurrentTime >= animMaxTime){
                animCurrentTime = 0.0f;
                swinging = false;
                ResetSwing();
            }else{
                animCurrentTime += Time.deltaTime;
            }
            swingObj.transform.localEulerAngles = new Vector3(0,Mathf.Lerp(swingStartAngle,-swingStartAngle,animCurrentTime/animMaxTime),0);
        }
    }
    public void ResetSwing(){
        swingObj.transform.localEulerAngles = new Vector3(0,swingStartAngle,0);
        if(currentWeapon == 1){
            sword.SetActive(false);
        }
        if(currentWeapon == 2){
            axe.SetActive(false);
        }
        if(currentWeapon == 3){
            morningstar.SetActive(false);
        }
    }
    //rotation.y goes from 1 to -1
    public void Swing(){
        if(GetComponent<PlayerWeapons>().currentWeapon.type == Weapon.WeaponType.Sword){
            currentWeapon = 1;
            sword.SetActive(true);
        }else{
            if(GetComponent<PlayerWeapons>().currentWeapon.type == Weapon.WeaponType.Axe){
                currentWeapon = 2;
                axe.SetActive(true);
            }else{
                if(GetComponent<PlayerWeapons>().currentWeapon.type == Weapon.WeaponType.Morningstar){
                    currentWeapon = 3;
                    morningstar.SetActive(true);
                }else{
                    currentWeapon = 0;
                }
            }
        }

        swinging = true;

    }
    public void Jab(){
        jabObj.GetComponent<ParticleSystem>().time = 0;
    }
    public void SetSwingAngle(float dotAngle){
        dotAngle *= -1f;
        //-1 = 0 deg, 0 = 180 deg, 1 = 360 deg.
        dotAngle += 1f;
        //0 = 0 deg, 1 = 180 deg, 2 = 360 deg.
        dotAngle /= 2f;
        //0 = 0 deg, .5 = 180 deg, 1 = 360 deg.
        swingStartAngle = 360f / 2 * dotAngle;
        ResetSwing();
    }
}
