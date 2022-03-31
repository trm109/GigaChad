using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("GETPLAYER");
    }
}
