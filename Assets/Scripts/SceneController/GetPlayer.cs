using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
