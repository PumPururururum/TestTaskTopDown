using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public string enemyName;
    
    public int maxHealth;
    
    
    public float movementSpeed;
    
    public int scoreForKill;
    
    public float spawnChance;

}

