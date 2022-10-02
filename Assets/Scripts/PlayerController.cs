using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 rawInput;
    Rigidbody2D myRigidBody;

    [SerializeField] float moveSpeed;


    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        FlipSprite();
    }

    void FlipSprite()
    {
        if(rawInput.x != 0)
        {
            transform.localScale = new Vector2(MathF.Sign(rawInput.x), 1f);
        }
    }

    void Move()
    {
        Vector2 playerVelocity = new Vector2(rawInput.x * moveSpeed, rawInput.y * moveSpeed);
        myRigidBody.velocity = playerVelocity;

        //Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        //Vector2 newPos = new Vector2();
        //
        //myRigidBody.velocity.x = rawInput.x * moveSpeed;

        // newPos.x = transform.position.x + delta.x;
        // newPos.y = transform.position.y + delta.y;
        // transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
