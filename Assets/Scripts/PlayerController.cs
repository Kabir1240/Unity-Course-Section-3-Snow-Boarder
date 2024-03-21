using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;                                   // reference for player
    SurfaceEffector2D se2d;                             // reference for ground surface effector

    [SerializeField] float torqueAmount = 1;            // amount of torque when controlling player
    [SerializeField] float baseSpeed;                   // normal speed
    [SerializeField] float boostSpeed;                  // speed when boosted
    [SerializeField] float slowSpeed;                   // speed when slowed down

    // check to see if player has disabled controls or not
    bool canMove = true;

    void Start()
    {
        // get references
        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        // only allow rotation and boost controls if player is allowed to move
        if (canMove)
        {
            RotatePlayer();
            Boost();
        }
        
    }

    // method to disable controls
    public void DisableControls()
    {
        canMove = false;
    }

    private void Boost()
    {
        // throw new NotImplementedException();

        // boost if player presses up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            se2d.speed = boostSpeed;
        }
        // slow down if player presses down
        else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            se2d.speed = slowSpeed;
        }
        // apply base speed otherwise
        else 
        {
            se2d.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        // apply rotation based on left and right key presses
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
