using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
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

    public void Upgrade(string skill)
    {
        if(kills >= 10)
        {
            kills -= 10;
            switch (skill)
            {
                case "Vengeance":
                    if(skillVengeance < SKILLCAP)
                    {
                        skillVengeance++;
                        Debug.Log("Upgraded " + skill + " to level " + skillVengeance);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + skill + " skill!");
                    }
                    break;
                case "RNG":
                    if (skillRNG < SKILLCAP)
                    {
                        skillRNG++;
                        Debug.Log("Upgraded " + skill + " to level " + skillRNG);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + skill + " skill!");
                    }
                    break;
                case "Health":
                    if (skillHealth < SKILLCAP)
                    {
                        skillHealth++;
                        Debug.Log("Upgraded " + skill + " to level " + skillHealth);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + skill + " skill!");
                    }
                    break;
                case "Power":
                    if (skillPower < SKILLCAP)
                    {
                        skillPower++;
                        Debug.Log("Upgraded " + skill + " to level " + skillPower);
                    }
                    else
                    {
                        Debug.Log("You've maxxed out the " + skill + " skill!");
                    }
                    break;
                default:
                    Debug.Log("Invalid upgrade name: " + skill);
                    break;
            }
        }
        else
        {
            Debug.Log("You don't have enough kills to upgrade " + skill + " yet!");
        }
    }

    public int GetKills()
    {
        return kills;
    }

    public int GetCurrentLevel(string skill)
    {
        switch (skill)
        {
            case "Vengeance":
                return skillVengeance;
                break;
            case "RNG":
                return skillRNG;
                break;
            case "Health":
                return skillHealth;
                break;
            case "Power":
                return skillPower;
                break;
            default:
                Debug.Log("Invalid upgrade name: " + skill);
                return -1;
                break;
        }
    }
}
