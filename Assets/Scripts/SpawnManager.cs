
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject PowerupPrefab;

    private float spawnRange = 10.0f;

    //private Rigidbody enemyRb;
    //private float enemyMass = 100;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        //enemyRb = GetComponent<Rigidbody>();
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp() 
    {
        Instantiate(PowerupPrefab, GenerateRandomSpawnPosition(), PowerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int EnemiesToSpawn)
    {
        for (int i = 0; i < EnemiesToSpawn; i++)
        {
            enemyPrefab.transform.localScale = transform.localScale + new Vector3(2, 2, 2);
            //enemyRb.mass = enemyMass;
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomSpawnPosition() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomSpawnPos = new Vector3(spawnPosX, -2, spawnPosZ);

        return randomSpawnPos;
    }
}
