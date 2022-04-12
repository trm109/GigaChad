using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public static float dropchance = 0.8f;     //chance of drop
    public static float weaponchance = 3f;     //chance of drop being weapon given drop

    // weapon probabilities
    private static float brassknucklesC = 3.5f;
    private static float swordC = 1.5f;
    private static float morningstarC = 1.5f;
    private static float axeC = 3.5f;

    // weapon fields
    public static GameObject brassknuckles;
    public static GameObject sword;
    public static GameObject morningstar;
    public static GameObject axe;

    // item probabilities
    private static float survivorresC = 2.25f;
    private static float healthC = 3.5f;
    private static float invincC = 1.0f;
    private static float multiplyC = 2.25f;
    private static float blackholeC = 1.0f;

    //item fields
    public static GameObject survivorres;
    public static GameObject health;
    public static GameObject invinc;
    public static GameObject multiply;
    public static GameObject blackhole;


    public static GameObject Drop()
    {
        float willdrop = Random.Range(0, 10);   //for whether there will be a drop
        float droptype = Random.Range(0, 10);   //for whether drop will be an item or weapon
        float drop = Random.Range(0, 10);       //for what the actual drop will be once the type is decided


        if (willdrop < dropchance)
        {
            //if (droptype < weaponchance)        //drop will be a weapon
            //{
                if (drop < brassknucklesC) { return brassknuckles; }
                else if (drop < brassknucklesC + swordC) { return sword; }
                else if (drop < brassknucklesC + swordC + morningstarC) { return morningstar; }
                else { return axe; }

            //}
            /*else                                //drop will be an item
            {
                if (drop < survivorresC) { return survivorres; }
                else if (drop < survivorresC + healthC) { return health; }
                else if (drop < survivorresC + healthC + invincC) { return invinc; }
                else if (drop < survivorresC + healthC + invincC + multiplyC) { return multiply; }
                else { return blackhole; }
            }*/
        }
        else { return null; }



    }


}
