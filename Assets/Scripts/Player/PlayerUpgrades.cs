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

    private int kills = 0;

    private const int SKILLCAP = 4;

    public static int score = 0;
    private static int[] curUpgradeCosts = new int[4];
    private void Start() {
        UpdateUpgradeCosts();
    }
    // Start is called before the first frame update
    private void UpdateUpgradeCosts(){
        // 0 = Vengeance.
        // 1 = RNG
        // 2 = Health
        // 3 = Power
        curUpgradeCosts[0] = upgradeCost[skillVengeance];
        curUpgradeCosts[1] = upgradeCost[skillRNG];
        curUpgradeCosts[2] = upgradeCost[skillHealth];
        curUpgradeCosts[3] = upgradeCost[skillPower];
        CheckUpgradeAbility();
    }
    private void CheckUpgradeAbility(){
        Debug.Log("Costs: " + curUpgradeCosts[0] + ", " +  curUpgradeCosts[1] + ", " +  curUpgradeCosts[2] + ", " +  curUpgradeCosts[3] + ".");
        NotificationKey.key_1.SetActive((curUpgradeCosts[0] <= kills));
        NotificationKey.key_2.SetActive((curUpgradeCosts[1] <= kills));
        NotificationKey.key_3.SetActive((curUpgradeCosts[2] <= kills));
        NotificationKey.key_4.SetActive((curUpgradeCosts[3] <= kills));
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
                            UpgradeVengeance(skillVengeance);
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
                            UpgradeRNG(skillRNG);
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
                            UpgradeHealth(skillHealth);
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
                            
                            Debug.Log("Upgraded Power to level " + skillPower);
                            UpgradePower(skillPower);
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
    public void IncrementKills(int amnt = 1){
        kills += amnt;
        CheckUpgradeAbility();
        //Check for upgradability.
    }


    public void UpgradeVengeance(int tier){
        //GetComponent<PlayerAttack>().
        PlayerAttack.vengeancePowerMult = vengeancePowerTiers[tier];
        PlayerAttack.vengeanceSpeedMult = 1.0f;
        PlayerAttack.CalculateDamage();
        UpdateUpgradeCosts();
    }
    public void UpgradeRNG(int tier){
        //default 8 percent.
        EnemyDrop.dropchance = rngMidTiers[tier];
        UpdateUpgradeCosts();
    }
    public void UpgradeHealth(int tier){
        PlayerHealth.healthMult = healthTiers[tier];
        PlayerHealth.CalculateHealth();
        UpdateUpgradeCosts();
    }
    public void UpgradePower(int tier){
        PlayerAttack.powerMult = powerDamageTiers[tier];
        PlayerAttack.speedMult = powerSpeedTiers[tier];
        PlayerAttack.CalculateDamage();
        UpdateUpgradeCosts();
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
