using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(GetPlayer))]
[RequireComponent(typeof(GetAirship))]
[RequireComponent(typeof(EnemySpawner))]
public class TimeEvents : MonoBehaviour
{
    [SerializeField]
    private const float defendTimeDuration = 240.0f; // update to 4 minutes for actual gameplay.
    private static float vengeanceModeDuration = 60.0f; //Variable, changes.
    public static bool isVengeanceMode = false;
    [SerializeField] private GameObject vm;   //Holds a reference to the splash screen that displays when vengance mode begins.
    public WinLose wl;
    public static float totalTime = 0.0f;
    [SerializeField] private Timer timerUI;
    // Start is called before the first frame update
    void Start()
    {
        wl = GetComponent<WinLose>();
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerUI.UpdateText(totalTime);
        if(!isVengeanceMode){
            if(totalTime >= defendTimeDuration){
                //Switch to Vengeance Mode.
                StartVengeanceMode();
                //Change text to red.
                timerUI.ChangeColor(Color.red);
            }else{
                timerUI.UpdateText(totalTime);
            }
        }else{
            if(totalTime >= (defendTimeDuration + vengeanceModeDuration)){
                //Game Over.
                WinLose.Win();
            }else{
                // should count down.
                // (defendTime + vModeDuration) - totalTime
                timerUI.UpdateText((defendTimeDuration + vengeanceModeDuration) - totalTime);
            }
        }
        if(totalTime >= (defendTimeDuration + vengeanceModeDuration)){
            WinLose.Win();
        }
        //update time.
        UpdateTimer();
    }
    public void UpdateTimer(){
        totalTime += Time.deltaTime;
    }
    //set bool.
    //clear enemies (with vfx)
    //Make player invulnerable. (or vastly increase regeneration?)
    //Remove airship.
    //Increase enemy spawns.
    //Alter UI.
    public void SetVengeanceTime(float t){
        vengeanceModeDuration = t;
    }
    public void StartVengeanceMode(){
        isVengeanceMode = true;
        ClearEnemies();
        ClearAirship();
        SetInvulnerable();
        ChangeEnemySpawns();
        AlterUI();
        ShowVMSplash();
    }
    public void ClearEnemies(){
        EnemySpawner en = GetComponent<EnemySpawner>();
        en.ClearEnemies();
    }
    public void ClearAirship(){
        GameObject airship = GetAirship.ReturnAirship();
        airship.GetComponent<AirshipHealth>().Disable();
    }
    public void SetInvulnerable(){
        GameObject player = GetPlayer.ReturnPlayer();
        PlayerHealth.SetInvulnerable();
    }
    public void ChangeEnemySpawns(){
        EnemySpawner en = GetComponent<EnemySpawner>();
        en.SetSpawnRate(0.5f);
        GetTarget.isVengeanceMode = true;
    }
    public void AlterUI(){
        
    }
    public void ShowVMSplash()
    {
        vm.SetActive(true);
    }
}