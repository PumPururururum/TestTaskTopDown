using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    private PlayerMovement player;
    private void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
            player.movementSpeed = player.movementSpeed * 0.6f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
            player.movementSpeed = player.movementSpeed / 0.6f;
    }
}
