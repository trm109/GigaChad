using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengeanceMode : MonoBehaviour
{
    [SerializeField]
    private float vTime = 240.0f;
    private GameObject player;
    private GameObject airship;
    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup >= vTime){
            StartVengeanceMode();
        }
    }
    public void StartVengeanceMode(){
        Debug.Log("Vengeance Mode Activated");
        airship.SetActive(false);
        player.GetComponent<PlayerHealth>().SetInvulnerable();
    }
}
