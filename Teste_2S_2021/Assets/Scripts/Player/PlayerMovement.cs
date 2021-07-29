using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Enums;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control Settings")] 
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;

    [Header("Speed Settings")] 
    public float Speed = 2.05f;

    private Directions LastDirection;
    private Rigidbody2D BodyRef;

    private void Awake()
    {
        // Set default settings
        if (UpKey == KeyCode.None)
            UpKey = KeyCode.W;
        if (DownKey == KeyCode.None)
            DownKey = KeyCode.S;
        if (LeftKey == KeyCode.None)
            LeftKey = KeyCode.A;
        if (RightKey == KeyCode.None)
            RightKey = KeyCode.D;
        if (LastDirection.Equals(null))
            LastDirection = Directions.RIGHT;
        BodyRef = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log("Direção Atual: " + GetCurrentDirection());
    }

    private void FixedUpdate()
    {
        movementVerify();
    }

    private void movementVerify()
    {
        BodyRef.velocity = MovementVector() * Speed;
    }

    private Vector2 MovementVector()
    {
        var MovementVector = new Vector2(0, 0);
        if (Input.GetKey(LeftKey))
        {
            MovementVector[0] = -1f;
            LastDirection = Directions.LEFT;
        }
        else if (Input.GetKey(RightKey))
        {
            MovementVector[0] = 1f;
            LastDirection = Directions.RIGHT;
        }

        if (Input.GetKey(UpKey))
        {
            MovementVector[1] = 1f;
            LastDirection = Directions.UP;
        }
        else if (Input.GetKey(DownKey))
        {
            MovementVector[1] = -1f;
            LastDirection = Directions.DOWN;
        }

        return MovementVector.normalized;
    }

    public Directions GetCurrentDirection()
    {
        if (MovementVector()[0] > 0)
            return Directions.RIGHT;
        if (MovementVector()[0] < 0)
            return Directions.LEFT;
        if (MovementVector()[1] > 0)
            return Directions.UP;
        if (MovementVector()[1] < 0)
            return Directions.DOWN;
        if (MovementVector().magnitude == 0)
        {
            switch (LastDirection)
            {
                case Directions.UP:
                    return Directions.UP_IDLE;
                case Directions.DOWN:
                    return Directions.DOWN_IDLE;
                case Directions.LEFT:
                    return Directions.LEFT_IDLE;
                case Directions.RIGHT:
                    return Directions.RIGHT_IDLE;
                case Directions.UP_IDLE:
                    return Directions.UP_IDLE;
                case Directions.DOWN_IDLE:
                    return Directions.DOWN_IDLE;
                case Directions.LEFT_IDLE:
                    return Directions.LEFT_IDLE;
                case Directions.RIGHT_IDLE:
                    return Directions.RIGHT_IDLE;
                
            }
        }
        return Directions.RIGHT;
    }
}
