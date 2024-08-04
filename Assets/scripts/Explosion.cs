using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(explosionTime());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<Bullet>().damageEnemy(collision);
        
    }

    IEnumerator explosionTime()
    {
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        
        yield return wait;
        Destroy(transform.parent.gameObject);
    }
}
