using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAirship : MonoBehaviour
{
    [SerializeField]
    public GameObject airship;
    public void Awake(){
        airship = GameObject.FindGameObjectWithTag("Airship");
        Debug.Log("GETAIRSHIP");
    }
}
