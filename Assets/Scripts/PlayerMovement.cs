using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    //runspeed
    public float runSpeed = 100f;
    //fixed dasn distance for now
    public float dashDistance = 100f;

    float horizontalMove = 0f;

    //check prev direction for dashing (maybe float?)
    private Vector3 lastMoveDir;
    // check for jump
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        //need to specify direction for the player to actually take a movement command
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //check for jump key
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        PlayerDash();
    }

    void FixedUpdate() 
    {
        //move our character
        //Time.fixedDeltaTime --> amount of time elapsed since it was last called
        //ensures same amount of movdement despite tiems it was called
        // ensures functionality of character across al machines
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);  // move function takes (dir, crouch, jump)
        jump = false;

        //register release
    }

    // Dash handling
    private void PlayerDash() 
    {
        Vector3 movement;
        //checks input of left shift [makes most sense]
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            transform.position += lastMoveDir * dashDistance;
            
        }
    }

}
