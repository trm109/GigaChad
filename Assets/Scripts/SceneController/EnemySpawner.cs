using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyPrefab;
    public float currentEnemyStrength = 1.0f;
    private float spawnMinimumDist = 50.0f;
    private float spawnMaximumDist = 75.0f;


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
        var newEnemy = Instantiate(enemyPrefab,spawnPosition, Quaternion.identity);
        //GameObject enemy = Instantiate();
        AdjustStats(newEnemy);
        //Apply currentEnemyStrength
        //newEnemy.GetComponent<EnemyHealth>().
        enemies.Add(newEnemy);
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
