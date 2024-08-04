using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FieldSpawner : MonoBehaviour
{
    public GameObject DeathField;
    public GameObject SlowField;
    public int deathFieldNumber;
    public int slowFieldNumber;
    void Start()
    {
        for (int i = 0; i < deathFieldNumber; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            Instantiate(DeathField, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < slowFieldNumber; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            Instantiate(SlowField, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        float randX = Random.Range(-20f, 20f);
        float randY = Random.Range(-15f, 15f);
        Vector3 spawnPosition = new Vector3 (randX, randY, 0f);
        return spawnPosition;
    }
}
