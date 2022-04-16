using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    [SerializeField]
    public static GameObject player;
    public void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log("GETPLAYER");
    }
    public static GameObject ReturnPlayer(){
        player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
}
