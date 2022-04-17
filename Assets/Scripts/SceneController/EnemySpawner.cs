using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyPrefab;
    public GameObject enemyPrefabSlow;
    public GameObject enemyPrefabFast;
    public float currentEnemyStrength = 1.0f;
    private float spawnMinimumDist = 50.0f;
    private float spawnMaximumDist = 75.0f;
    private float slowChance = 0.5f;
    private float fastChance = 1.0f;
    private float regChance = 9.0f;


    private float spawnCD = 0.0f;
    private float spawnMaxCD = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemyStrength = Time.realtimeSinceStartup;
        if(spawnCD > spawnMaxCD){
            SpawnEnemy();
            spawnCD = 0;
        }else{
            spawnCD += Time.deltaTime;
        }
    }
    public void SpawnEnemy(){
        //Debug.Log("Spawned Enemy");
        //Assign random position within spawn bounds.
        Vector3 spawnPosition = RandomSpawnVector();
        //Instantiate a gameobject at the new position, and keep reference

        float type = Random.Range(0, 10);

        if (type < slowChance) { 
            var newEnemy = Instantiate(enemyPrefabSlow, spawnPosition, Quaternion.identity);
            AdjustStats(newEnemy);
            enemies.Add(newEnemy);
        }
        else if (type < slowChance + fastChance) { 
            var newEnemy = Instantiate(enemyPrefabFast, spawnPosition, Quaternion.identity);
            AdjustStats(newEnemy);
            enemies.Add(newEnemy);
        }
        else { 
            var newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            AdjustStats(newEnemy);
            enemies.Add(newEnemy);
        }
        
        //GameObject enemy = Instantiate();
        
        //Apply currentEnemyStrength
        //newEnemy.GetComponent<EnemyHealth>().
 
    }
    public void AdjustStats(GameObject enemy){
        float gamePercentOver = Time.realtimeSinceStartup/ 240.0f;
        enemy.GetComponent<EnemyAttack>().IncreaseAttack(gamePercentOver);
        enemy.GetComponent<EnemyHealth>().IncreaseHealth(gamePercentOver);
    }
    public Vector3 RandomSpawnVector(){
        Vector3 pos = Quaternion.AngleAxis(Random.Range(0,359),Vector3.up) * transform.forward;
        pos *= (Random.Range(spawnMinimumDist,spawnMaximumDist));
        return pos;
    }
    public void SetSpawnRate(float spawnTimer){
        spawnMaxCD = spawnTimer;
    }
    public void ClearEnemies(){
        foreach(GameObject enemy in enemies){
            Destroy(enemy);
        }
    }
}
