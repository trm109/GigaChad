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

    //Vengeance Upgrade tiers.
    public float[] vengeanceTimeTiers = new float[]{45.0f,60.0f,75.0f,90.0f};
    public float[] vengeancePowerTiers = new float[]{1.2f,1.4f ,1.8f ,2.5f};
    //RNG Upgrade tiers.
    public float[] rngDropTiers = new float[]{1.03f,1.05f,1.1f ,1.2f};
    public float[] rngMidTiers =  new float[]{1.1f,1.15f ,1.25f,1.75f};
    public float[] rngHighTiers = new float[]{1.0f,1.075f,1.15f,1.25f};

    //Health upgrade tiers.
    public float[] healthTiers = new float[]{1.08f,1.2f,1.36f,1.56f};
    //Power upgrade tiers.
    public float[] powerDamageTiers = new float[]{1.1f, 1.2f,1.4f,1.6f};
    public float[] powerSpeedTiers =  new float[]{0.9f,0.85f,0.8f,0.6f};
    public int skillVengeance = 0;
    public int skillRNG = 0;
    public int skillHealth = 0;
    public int skillPower = 0;

    public int kills = 0;

    private const int SKILLCAP = 4;

    // Start is called before the first frame update
    void Start()
    {
    
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
                            UpgradeVengeance(skillVengeance);
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
                            public void UpgradeRNG(skillRNG);
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
                            UpgradeHealth(skillHealth);
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
                            UpgradePower(skillPower);
                            skillPower++;
                            
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
    public void UpgradeVengeance(int tier){
        //GetComponent<PlayerAttack>().
        PlayerAttack.vengeancePowerMult = vengeancePowerTiers[tier];
        PlayerAttack.vengeanceSpeedMult = 1.0f;
        PlayerAttack.CalculateDamage();
    }
    public void UpgradeRNG(int tier){

    }
    public void UpgradeHealth(int tier){
        PlayerHealth.healthMult = healthTiers[tier];
        PlayerHealth.CalculateHealth();
    }
    public void UpgradePower(int tier){
        PlayerAttack.powerMult = powerDamageTiers[tier];
        PlayerAttack.speedMult = powerSpeedTiers[tier];
        PlayerAttack.CalculateDamage();
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
