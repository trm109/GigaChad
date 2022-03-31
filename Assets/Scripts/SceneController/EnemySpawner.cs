using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float currentEnemyStrength = 1.0f;
    public float spawnMinimumDist;
    public float spawnMaximumDist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemyStrength = Time.realtimeSinceStartup;

    }
    public void SpawnEnemy(){
        //Assign random position within spawn bounds.
        Vector3 spawnPosition = new Vector3(RandomFloatInRange(),0,RandomFloatInRange());
        //Instantiate a gameobject at the new position, and keep reference
        //GameObject enemy = Instantiate();
        //Apply currentEnemyStrength
    }
    public float RandomFloatInRange(){
        float returnVal = 0;
        //Ensure max is larger.
        if(spawnMaximumDist < spawnMinimumDist){
            var temp = spawnMaximumDist;
            spawnMaximumDist = spawnMinimumDist;
            spawnMinimumDist = temp;
        }
        int randomSign = Random.value < .5? 1 : -1;
        returnVal = Random.Range(spawnMinimumDist,spawnMaximumDist);
        return returnVal * randomSign;
    }
}
