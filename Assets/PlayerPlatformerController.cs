using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    //basic movement vars
    public float maxSpeed;
    public float jumpTakeOffSpeed;
    //dash vars
    public float dashDistance;
    public float startDashTimer;

    float currentDashTimer;
    float dashDirection;

    bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        //Basic movement functions
        
        move.x = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        } else if(Input.GetButtonUp("Jump"))
        {
            if(velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }

        targetVelocity = move * maxSpeed;

        //Dashing functions

        if(Input.GetKeyDown(KeyCode.LeftShift) && grounded && isDashing == false)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            rb2d.velocity = Vector2.zero;
            dashDirection = move.x;
        }

        if(isDashing)
        {
            rb2d.velocity = transform.right * dashDirection * dashDistance;
            currentDashTimer -= Time.deltaTime;
            if(currentDashTimer <= 0)
            {
                rb2d.velocity = Vector2.zero;
                isDashing = false;
            }
        }
    }
}
