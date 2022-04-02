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

    public void Upgrade(UpgradeSkill upgradeSkill)
    {
        if(kills >= 10)
        {
            kills -= 10;
            switch (upgradeSkill)
            {
                case UpgradeSkill.Vengeance:
                    if(skillVengeance < SKILLCAP)
                    {
                        skillVengeance++;
                        Debug.Log("Upgraded " + upgradeSkill + " to level " + skillVengeance);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + upgradeSkill + " skill!");
                    }
                    break;
                case UpgradeSkill.RNG:
                    if (skillRNG < SKILLCAP)
                    {
                        skillRNG++;
                        Debug.Log("Upgraded " + upgradeSkill + " to level " + skillRNG);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + upgradeSkill + " skill!");
                    }
                    break;
                case UpgradeSkill.Health:
                    if (skillHealth < SKILLCAP)
                    {
                        skillHealth++;
                        Debug.Log("Upgraded " + upgradeSkill + " to level " + skillHealth);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + upgradeSkill + " skill!");
                    }
                    break;
                case UpgradeSkill.Power:
                    if (skillPower < SKILLCAP)
                    {
                        skillPower++;
                        Debug.Log("Upgraded " + upgradeSkill + " to level " + skillPower);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + upgradeSkill + " skill!");
                    }
                    break;
                default:
                    Debug.Log("Invalid upgrade name: " + upgradeSkill);
                    break;
            }
        }
        else
        {
            Debug.Log("You don't have enough kills to upgrade " + upgradeSkill + " yet!");
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
