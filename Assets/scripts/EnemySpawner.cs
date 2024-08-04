using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float startSpawnRate = 2f;
    private float currentSpawnRate;
    private float minSpawnRate = 0.5f;
    private float spawnRateDif = 0.1f;
    private float spawnDifTime = 10f;

    public GameObject[] enemyPrefabs;
    private bool canSpawn = true;
    private GameObject enemyToSpawn;
    public Camera cam;
    private Vector3 spawnPosition;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        currentSpawnRate = startSpawnRate;
        StartCoroutine(Spawner());
        StartCoroutine(SpawnRateChange());
        Spawn();
    }
    private void Update()
    {
        if (player = null)
            canSpawn = false;
    }



    private void Spawn()
    {
        float random = Random.value;
        
        if (random <= 0.6f) 
             enemyToSpawn = enemyPrefabs[0];
        else
        if (random <= 0.9f)
                enemyToSpawn = enemyPrefabs[1];
        else
        if (random <= 1f)
                enemyToSpawn = enemyPrefabs[2];

        GetSpawnPosition();
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(currentSpawnRate);

        while (canSpawn)
        {
            yield return wait;
            Spawn();
        }
    }

    private IEnumerator SpawnRateChange()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnDifTime);
        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate =- spawnRateDif;
            yield return wait;
        }    
    }

    private void GetSpawnPosition()
    {
        float randX = Random.Range(-0.2f, 1.2f);
        float randY = Random.Range(-0.2f, 1.2f);
        if (-0.1f <= randX && randX < 1.1f)
        {
            if (randY < 0.5f)
                randY = -0.2f;
            else randY = 1.2f;
        }
        if (-0.1f <= randY && randY < 1.1f)
        {
            if (randX < 0.5f)
                randX = -0.2f;
            else randX = 1.2f;
        }
        spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(randX, randY, 0));

        if (spawnPosition.x >= 20 || spawnPosition.x <= -20 || spawnPosition.y <= -15 || spawnPosition.y >= 15)
            GetSpawnPosition();
    }

}
