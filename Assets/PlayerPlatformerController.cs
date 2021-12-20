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
    //animation vars
    public bool faceRight = false;
    public Animator animator;

    

    bool isDashing = false;

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        //animation
        if(Input.GetButton("Horizontal"))
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if(Input.GetKeyDown(KeyCode.A) && faceRight)
        {
            ChangeDirection();
        }
        else if(Input.GetKeyDown(KeyCode.D) && !faceRight)
        {
            ChangeDirection();
        }
        
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

        

        //Dashing functions

        if(Input.GetKeyDown(KeyCode.LeftShift) && grounded && isDashing == false)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            targetVelocity = Vector2.zero;
            dashDirection = move.x;
        }

        if(isDashing)
        {
            targetVelocity = move * dashDistance;
            currentDashTimer -= Time.deltaTime;
            if(currentDashTimer <= 0)
            {
                targetVelocity = Vector2.zero;
                isDashing = false;
            }
        }
        else
        {
            targetVelocity = move * maxSpeed;
        }
    }

    private void ChangeDirection()
    {
        faceRight = !faceRight;

        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;
        transform.localScale = flipped;
    }
}
