using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //Items:
    /*
    Heal Airship:
        Rarity: 22.5%
        +7.5%
    Heal Player:
        Rarity: 35%
        +25%
    Invincibility:
        Rarity 10%
        15 seconds.
    Score Multiplier:
        Rarity 22.5%
        150% increase in score for 30 seconds.
    Black Hole:
        Rarity 10%
        Clears enemies in x radius.

    */
    //Heal Airship Variables:
    private static float rarityHA = 22.5f;
    private static float HA_HealPercent = 0.075f;
    //Heal Player Variables:
    private static float rarityHP = 35f;
    private static float HP_HealPercent = 0.25f;
    //Invincibility Variables:
    private static float rarityIV = 10f;
    private static float IV_Duration = 15f;
    //Score Multiplier Varibles;
    private static float raritySM = 22.5f;
    private static float SM_Multiplier = 2.5f;
    //Black Hole Variables:
    private static float rarityBH = 10.0f;
    private static float radius = 15f;
    public void HealAirship(){
        GetAirship.ReturnAirship()
            .GetComponent<AirshipHealth>()
                .Damage(-1 * 
                        HA_HealPercent * AirshipHealth.maxHealth);
    }
    public void HealPlayer(){
        GetPlayer.ReturnPlayer()
            .GetComponent<PlayerHealth>()
                .Damage(-1 * 
                HP_HealPercent * PlayerHealth.maxHealth);
    }
    public void Invincibility(){
        PlayerHealth.TimedInvulnerable((int) IV_Duration * 1000);
    }
    public void ScoreMultiplier(){
        //permanent, change to temporary eventually.
        ScoreController.scoreMult *= 1.3f;
    }
    public void BlackHole(){

    }
}
