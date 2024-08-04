using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    public Vector2 mousePosition;
    Vector3 followPosition;
    Rigidbody2D rb;
    public Weapon weapon;
    public float movementSpeed = 4f;
    public float rotationSpeed = 180f;
    public float aimAngle;

    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions  = new List<RaycastHit2D>();

    private UILogic UIscript;


    public bool invulnerable;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UIscript = GameObject.FindGameObjectWithTag("logic").GetComponent<UILogic>();
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            int count = rb.Cast(movementInput, movementFilter, castCollisions, movementSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime);
            }
        }
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
       

        Vector2 aimDirection = (mousePosition - rb.position);
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        //Quaternion rotation = Quaternion.LookRotation(mousePosition - rb.position);
        // rb.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //  transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        //}
        
        rb.MoveRotation(aimAngle + rotationSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        weapon.Fire();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" && !invulnerable)
            Death();
    }

    public void Death()
    {
        
        UIscript.GameOver();
        Destroy(gameObject);

        
    }

}
