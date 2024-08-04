using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    private PlayerMovement player;
    private void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
            player.Death();
    }
}
