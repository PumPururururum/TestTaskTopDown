using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public WeaponSO currentWeapon;
    private float shotDelay;
    private PlayerMovement player;
    private bool shootLauncher = false;
    public bool explosion;

    private GameObject bullet;

    private Vector2  mouseShotPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerMovement>();
    }
    private void Update()
    {
       
        if (shotDelay > 0)
        {
            shotDelay -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (shootLauncher)
        {
            
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, mouseShotPosition, bulletSpeed * Time.fixedDeltaTime);
            if (bullet.GetComponent<Rigidbody2D>().position == mouseShotPosition)
            {
                shootLauncher = false;
                bullet.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void Fire()
    {
        if (shotDelay <= 0)
        {
            shotDelay = 1 / currentWeapon.shotsPerSec;
            if (currentWeapon.weaponName == "Pistol" || currentWeapon.weaponName == "Rifle")
            {
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

            }
            if (currentWeapon.weaponName == "Shotgun")
            {
                float SpreadAngle = 10;
                int NumberOfProjectiles = 5;
                float minAngle = player.aimAngle - (SpreadAngle * 0.5f);
                float maxAngle = player.aimAngle + (SpreadAngle * 0.5f);
                for (int i = 0; i < NumberOfProjectiles; i++)
                {
                    
                    float randomAngle = Random.Range(minAngle, maxAngle);
                    Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, randomAngle));
                    bullet = Instantiate(bulletPrefab, firePoint.position, rotation);                   
                    Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, randomAngle + 90f) * Vector2.right);
                    bullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
                }
            }
            if (currentWeapon.weaponName == "Launcher")
            {
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                mouseShotPosition = player.mousePosition;
                // bullet.GetComponent<Rigidbody2D>().position = Vector3.MoveTowards(firePoint.position, player.mousePosition, bulletSpeed * Time.fixedDeltaTime);
                // bullet.GetComponent<Rigidbody2D>().MovePosition(player.mousePosition + bulletSpeed * Time.fixedDeltaTime);
                shootLauncher = true;
            }

        }

    }
}
