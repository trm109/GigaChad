using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{
    public bool playertarget = false;
    public GameObject targetObj;

    public static bool isVengeanceMode = false;
    public void Awake(){
        Target();
    }
    public void Target()
    {
        float n = Random.Range(0, 10);
        if ((n < 5) || isVengeanceMode) { 
            playertarget = true; 
            targetObj = GameObject.FindGameObjectWithTag("Player");
        }else{
            targetObj = GameObject.FindGameObjectWithTag("Airship");
        }
        
    }
}
