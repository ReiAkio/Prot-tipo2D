using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public float Speed = 2.5f;

    // Private variables
    private Direction LastDirection;
    private Rigidbody2D RigidBody2DReference;

    private void Awake()
    {
        // Setting default settings...
        
        // Setting KeyBind settings
        if (UpKey == KeyCode.None)
            UpKey = KeyCode.W;
        if (DownKey == KeyCode.None)
            DownKey = KeyCode.S;
        if (LeftKey == KeyCode.None)
            LeftKey = KeyCode.A;
        if (RightKey == KeyCode.None)
            RightKey = KeyCode.D;
        
        // Setting default direction
        if (LastDirection.Equals(null))
            LastDirection = Direction.NONE;
        
        // Getting references
        RigidBody2DReference = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }
    
    private void MoveCharacter()
    {
        // Update the velocity vector of the player
        RigidBody2DReference.velocity = MovementInputVector() * Speed;
    }
    
    private Vector2 MovementInputVector()
    {
        // Creation of the new vector
        var InputVector = Vector2.zero;
        
        // Evaluation of the Horizontal axis
        if (Input.GetKey(LeftKey))
            InputVector.x = -1f;
        else if (Input.GetKey(RightKey))
            InputVector.x = 1f;

        // Evaluation of the Vertical axis
        if (Input.GetKey(UpKey))
            InputVector.y = 1f;
        else if (Input.GetKey(DownKey))
            InputVector.y = -1f;

        // Return the new movement vector
        return InputVector.normalized;
    }

    public Direction GetCurrentDirection()
    {
        // Fix the values the function will work with
        var movementState = MovementInputVector();
        var current = Direction.NONE;
        
        // Verify Horizontal Movement
        if (movementState.x > 0)
            current = Direction.RIGHT;
        else if (movementState.x < 0)
            current = Direction.LEFT;

        // Verify Vertical Movement
        if (movementState.y > 0)
            current = Direction.UP;
        else if (movementState.y < 0)
            current = Direction.DOWN;

        // Verify if the player is not moving
        if (movementState.magnitude == 0)
            current = LastDirection switch
            {
                Direction.RIGHT => Direction.RIGHT_IDLE,
                Direction.LEFT => Direction.LEFT_IDLE,
                Direction.UP => Direction.UP_IDLE,
                Direction.DOWN => Direction.DOWN_IDLE,
                Direction.RIGHT_IDLE => Direction.RIGHT_IDLE,
                Direction.LEFT_IDLE => Direction.LEFT_IDLE,
                Direction.UP_IDLE => Direction.UP_IDLE,
                Direction.DOWN_IDLE => Direction.DOWN_IDLE,
                _ => current
            };

        // Verify the initial case
        if (LastDirection == Direction.NONE)
            current = Direction.RIGHT;

        // Update Last Direction for the not moving case
        LastDirection = current;
        
        return current;
    }
}
