using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponBonus : MonoBehaviour
{
    public WeaponSO[] weapons;
    private Weapon weapon;
    private WeaponSO newWeapon;

    private void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("weapon").GetComponent<Weapon>();
        WeaponSO currentWeapon = weapon.currentWeapon;
        StartCoroutine(LifeTime());
        int rand = Random.Range(0, weapons.Length);
        if (weapons[rand] == currentWeapon)
        {
            while (weapons[rand].weaponName == currentWeapon.weaponName)
            {
                 rand = Random.Range(0, weapons.Length);
            }
        }
        newWeapon = weapons[rand];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            weapon.currentWeapon = newWeapon;
            Destroy(gameObject);

        }
    }

    private IEnumerator LifeTime()
    {
        WaitForSeconds wait = new WaitForSeconds(5);

        yield return wait;
        Destroy(gameObject);
    }
}
