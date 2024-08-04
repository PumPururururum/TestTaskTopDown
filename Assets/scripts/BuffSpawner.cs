using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public float weaponSpawnRate = 10f;
    public float buffSpawnRate = 27f;
    public GameObject weaponBonus;
    public GameObject buffBonus;
    private bool canSpawn = true;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        StartCoroutine(WeaponSpawner());
        StartCoroutine(BonusSpawner());
    }
    private void Update()
    {
        if (player = null)
            canSpawn = false;
    }

    private void SpawnWeapon()
    {
        
        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(weaponBonus, spawnPosition, Quaternion.identity);
    }


    private Vector3 GetSpawnPosition()
    {
        float randX = Random.Range(0f, 1f);
        float randY = Random.Range(0f, 1f);
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(randX, randY, 0));
        spawnPosition.z = 0;
        if (spawnPosition.x >= 20 || spawnPosition.x <= -20 || spawnPosition.y <= -15 || spawnPosition.y >= 15)
           spawnPosition = GetSpawnPosition();
        return spawnPosition;
    }

    private IEnumerator WeaponSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(weaponSpawnRate);
        while (canSpawn)
        {
            yield return wait;
            SpawnWeapon();
        } 
    }

    private void SpawnBuff()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(buffBonus, spawnPosition, Quaternion.identity);
    }

    private IEnumerator BonusSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(buffSpawnRate);
        while (canSpawn)
        {
            yield return wait;
            SpawnBuff();
        }
    }

   
}
