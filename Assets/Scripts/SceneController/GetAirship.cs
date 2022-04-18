using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAirship : MonoBehaviour
{
    [SerializeField]
    public static GameObject airship;
    public static GameObject ReturnAirship(){
        airship = GameObject.FindGameObjectWithTag("Airship");
        return airship;
    }
}
