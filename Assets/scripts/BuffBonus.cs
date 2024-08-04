using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBonus : MonoBehaviour
{
    private PlayerMovement player;
    private int currentBuff;
    private SpriteRenderer sprite;
    private Collider2D collider2d;
    private bool pickedUp;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
        sprite = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();

        currentBuff = Random.Range(0, 2);
        StartCoroutine(LifeTime());
    }
    private void invulnerableBuff()
    {
        player.invulnerable = true;
    }

    private void speedBuff()
    {
        player.movementSpeed = player.movementSpeed * 1.5f;
    }

    private IEnumerator BuffDuration()
    {
        WaitForSeconds wait = new WaitForSeconds(10);

        yield return wait;
        DisableBuffs();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (currentBuff == 0)
                invulnerableBuff();

            if (currentBuff == 1)
                speedBuff();

            StartCoroutine(BuffDuration());
            sprite.enabled = false;
            collider2d.enabled = false;
            pickedUp = true;
        }
    }
    private IEnumerator LifeTime()
    {
        WaitForSeconds wait = new WaitForSeconds(5);

        yield return wait;
        if (pickedUp)
        {
            sprite.enabled = false;
            collider2d.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void DisableBuffs()
    {
        player.invulnerable = false;
        player.movementSpeed = player.movementSpeed / 1.5f;
    }
}
