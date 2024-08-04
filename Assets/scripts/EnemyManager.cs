using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyType;

    public GameObject player;
    private float distance;
    public int currentHealth;

    public UILogic UIscript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        UIscript = GameObject.FindGameObjectWithTag("logic").GetComponent<UILogic>();
        currentHealth = enemyType.maxHealth;
         
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
        if (player != null) 
        { 

            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();  
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyType.movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }

    private void Death()
    {
        UIscript.AddScore(enemyType.scoreForKill);
        Destroy(gameObject);
    }

    
}
