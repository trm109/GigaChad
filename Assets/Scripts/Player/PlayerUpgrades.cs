using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public enum UpgradeSkill{
        Vengeance,
        RNG,
        Health,
        Power
    }
    public int[] upgradeCost = new int[]{10,50,100,200};
    public int skillVengeance;
    public int skillRNG;
    public int skillHealth;
    public int skillPower;

    public int kills;

    private const int SKILLCAP = 4;

    // Start is called before the first frame update
    void Start()
    {
        skillVengeance = 0;
        skillRNG = 0;
        skillHealth = 0;
        skillPower = 0;

        kills = 0;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("1 pressed");
            Upgrade(UpgradeSkill.Vengeance);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Upgrade(UpgradeSkill.RNG);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Upgrade(UpgradeSkill.Health);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Upgrade(UpgradeSkill.Power);
        }
    }
    public void Upgrade(UpgradeSkill upgradeSkill)
    {
        switch (upgradeSkill){
                case UpgradeSkill.Vengeance:
                    if(skillVengeance >= SKILLCAP){
                        Debug.Log("Skill is already maxed");
                    }else{
                        if(kills >= upgradeCost[skillVengeance]){
                            kills -= upgradeCost[skillVengeance];
                            skillVengeance++;
                            Debug.Log("Upgraded Vengeance to level " + skillVengeance);
                        }else{
                            Debug.Log("Not enough kills" + kills + " " + upgradeCost[skillVengeance+1]);
                        }
                    }
                    break;
                case UpgradeSkill.RNG:
                    if(skillRNG >= SKILLCAP){
                        Debug.Log("Skill is already maxed");
                    }else{
                        if(kills >= upgradeCost[skillRNG]){
                            kills -= upgradeCost[skillRNG];
                            skillRNG++;
                            Debug.Log("Upgraded RNG to level " + skillRNG);
                        }
                    }
                    break;
                case UpgradeSkill.Health:
                    if(skillHealth >= SKILLCAP){
                        Debug.Log("Skill is already maxed");
                    }else{
                        if(kills >= upgradeCost[skillHealth]){
                            kills -= upgradeCost[skillHealth];
                            skillHealth++;
                            Debug.Log("Upgraded Health to level " + skillHealth);
                        }
                    }
                    break;
                case UpgradeSkill.Power:
                    if(skillPower >= SKILLCAP){
                        Debug.Log("Skill is already maxed");
                    }else{
                        if(kills >= upgradeCost[skillPower]){
                            kills -= upgradeCost[skillPower];
                            skillPower++;
                            GetComponent<PlayerAttack>().IncreasePower(skillPower);
                            Debug.Log("Upgraded Power to level " + skillPower);
                        }
                    }
                    break;
                default:
                    Debug.Log("Invalid upgrade name: " + upgradeSkill);
                    break;
            }
    }

    public int GetKills()
    {
        return kills;
    }

    public int GetCurrentLevel(UpgradeSkill upgradeSkill)
    {
        switch (upgradeSkill)
        {
            case UpgradeSkill.Vengeance:
                return skillVengeance;
            case UpgradeSkill.RNG:
                return skillRNG;
            case UpgradeSkill.Health:
                return skillHealth;
            case UpgradeSkill.Power:
                return skillPower;
            default:
                Debug.Log("Invalid upgrade name: " + upgradeSkill);
                return -1;
        }
    }
}
