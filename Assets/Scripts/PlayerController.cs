using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 rawInput;

    [SerializeField] float moveSpeed;


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
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        newPos.x = transform.position.x + delta.x;
        newPos.y = transform.position.y + delta.y;
        transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
