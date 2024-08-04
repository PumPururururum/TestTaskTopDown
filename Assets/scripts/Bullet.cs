using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject weaponObject;
    public Weapon weapon;
    public float bulletSpeed = 20f;
    private Vector2 velocity;
    public float deathTime = 0.35f;
    public GameObject exploisionCollider;
     void Start()
    {
        weaponObject = GameObject.FindGameObjectWithTag("weapon");
        weapon = weaponObject.GetComponent<Weapon>();
        if(weapon.currentWeapon.weaponName == "Shotgun")
        {
            Destroy(gameObject, deathTime);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

       if (weapon.currentWeapon.weaponName != "Launcher")
       {
            damageEnemy(collision);

           if (collision.tag != "bullet" && collision.tag != "field" && collision.tag != "cameraBounds")
                Destroy(gameObject);

       }
    }

    public void damageEnemy(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            EnemyManager enemy = collision.GetComponent<EnemyManager>();

            if (enemy != null)
            {
                enemy.currentHealth -= weapon.currentWeapon.damage;
            }

        }
    }

}
