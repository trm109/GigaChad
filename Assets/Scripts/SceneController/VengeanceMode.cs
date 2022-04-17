using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengeanceMode : MonoBehaviour
{
    [SerializeField]
    private float vTime = 60.0f;
    private GameObject player;
    private GameObject airship;
    private GameObject pointer;
    private bool isVengeance = false;
    // Update is called once per frame
    void Update()
    {
        airship = GetComponent<GetAirship>().airship;
        pointer = GetComponent<GetPointer>().pointer;
        player = GetComponent<GetPlayer>().player;
        if(!isVengeance){
            if(Time.realtimeSinceStartup >= vTime){
                StartVengeanceMode();
            }
        }
    }
    public void StartVengeanceMode(){
        isVengeance = true;
        Debug.Log("Vengeance Mode Activated");
        KillAllEnemies();
        airship.SetActive(false);
        pointer.SetActive(false);
        GetTarget.isVengeanceMode = true;
        player.GetComponent<PlayerHealth>().SetInvulnerable();
    }
    private void KillAllEnemies(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies){
            e.GetComponent<EnemyHealth>().Die();
        }
    }
    private void IncreaseEnemySpawnrate(){
        //Do something
    }
}
