using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float jumpSpeed = 2f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    CapsuleCollider2D myFeetCollider;
    BoxCollider2D myBodyCollider;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myFeetCollider = GetComponent<CapsuleCollider2D>();
        myBodyCollider = GetComponent<BoxCollider2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
            Jump();
            Die();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }

    }
    void Jump()
    {
        //if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void DieThietNe()
    {
        FindObjectOfType<GameSession>().ResetGameSession();

    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies"))
            || myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            Invoke("DieThietNe", 2f);
        }
    }
}
